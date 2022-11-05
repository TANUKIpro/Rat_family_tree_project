using Entitys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Viewer;

namespace CoreLogic
{
    
    /// <summary>
    /// オブジェクト配置コアロジッククラス
    /// </summary>
    public class CLObjectDeployManager
    {
        /// <summary>
        /// ゲームマネージャー　オブジェクト配置用
        /// </summary>
        GameManager _gameManager = null;

        /// <summary>
        /// レイアウトオブジェクトリスト
        /// </summary>
        private List<GameObject> _layoutObjectList = new List<GameObject>();

        /// <summary>
        /// 子オブジェクトリスト
        /// </summary>
        private List<Transform> _childrenList = new List<Transform>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CLObjectDeployManager()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _gameManager.ObjectGenerationCompleteEvent += ArrangementChildrenObject;
        }

        /// <summary>
        /// 子供の要素オブジェクト生成
        /// </summary>
        /// <param name="objectName">オブジェクト名</param>
        /// <param name="mouseData">マウスデータエンティティ</param>
        public void ChildObjectGenerate(List<MouseDataEntity> mouseData)
        {

            foreach (var data in mouseData)
            {
                //親オブジェクトなら生成しない。
                if (data.FatherId == null) continue;

                //自分の親となるレイアウトオブジェクトを探す
                var layoutObject = GameObject.Find(data.FatherId + "-" + data.MotherId);
                //見つからなければ処理終了
                if (layoutObject == null) continue;
                //タグを変更
                layoutObject.tag = "ChildLayoutObject";

                GameObject gameObject = null;

                //どちらのオブジェクトを生成するか場合分け
                switch (data.Nature)
                {
                    // オス用のオブジェクト名
                    case "MaleObject":
                        //オブジェクト配置
                        gameObject = _gameManager.ObjectDisposition(GameManager.ObjectName.MaleObject);
                        break;

                    // メス用のオブジェクト名
                    case "FemaleObject":
                        //オブジェクト配置
                        gameObject = _gameManager.ObjectDisposition(GameManager.ObjectName.FemaleObject);
                        break;
                }
                //オブジェクトが生成されていなければ処理終了
                if (gameObject == null) continue;

                //誕生日設定
                gameObject.GetComponent<MouseObjectData>()?.SetBirthday(data.Birthday);
                //名前テキスト設定
                gameObject.GetComponent<MouseObjectData>()?.SetNameText(data.AnalysisId);
                //オブジェクト名をIDに変更
                gameObject.name = data.AnalysisId;

                //配置を整えるオブジェクトの子に移動
                gameObject.transform.parent = layoutObject.transform;
                gameObject.transform.position = layoutObject.transform.position;

                
            }
            CreateBirthdayLayoutObject();
        }

        /// <summary>
        /// 親オブジェクトの配置を整える
        /// </summary>
        public void ParentObjectGenerate(List<Dictionary<string, string>> parentDataList)
        {
            foreach(var parentData in parentDataList)
            {
                //レイアウトオブジェクト取得用
                GameObject layoutObject = null;
                //レイアウトオブジェクトがすでに存在しない場合生成
                if (_layoutObjectList.Find(n => n.name == parentData["FatherId"] + "-" + parentData["MotherId"]) == null)
                {
                    //レイアウト用オブジェクト配置
                    layoutObject = _gameManager.ObjectDisposition(GameManager.ObjectName.ObjectLayout);
                    //名前変更
                    layoutObject.name = parentData["FatherId"] + "-" + parentData["MotherId"];
                    //レイアウトオブジェクトをリストに追加
                    _layoutObjectList.Add(layoutObject);
                }

                //レイアウト用オブジェクト取得
                layoutObject = GameObject.Find(parentData["FatherId"] + "-" + parentData["MotherId"]);
                //もしこれでもnullの場合作る
                //*ケース思いつかないが一応...
                if (layoutObject == null)
                {
                    //レイアウト用オブジェクト配置
                    layoutObject = _gameManager.ObjectDisposition(GameManager.ObjectName.ObjectLayout);
                    //名前変更
                    layoutObject.name = parentData["FatherId"] + "-" + parentData["MotherId"];
                    //レイアウトオブジェクトをリストに追加
                    _layoutObjectList.Add(layoutObject);
                }


                //親オブジェクト生成用
                GameObject gameObject = null;

                //親オブジェクトをレイアウトオブジェクトの子に移動
                foreach (var id in parentData.Values)
                {
                    //Keyで場合分け
                    switch (parentData.FirstOrDefault(c => c.Value == id).Key)
                    {
                        // オス用のオブジェクト名
                        case "FatherId":
                            //オブジェクト生成
                            gameObject = _gameManager.ObjectDisposition(GameManager.ObjectName.MaleObject);
                            //つなぎ線オブジェクトを見えなくする
                            gameObject.GetComponent<MouseObjectData>()?._coverall_Upside.SetActive(false);
                            break;

                        // メス用のオブジェクト名
                        case "MotherId":
                            //オブジェクト生成
                            gameObject = _gameManager.ObjectDisposition(GameManager.ObjectName.FemaleObject);
                            //つなぎ線オブジェクトを見えなくする
                            gameObject.GetComponent<MouseObjectData>()?._coverall_Upside.SetActive(false);
                            break;
                    }

                    //オブジェクト生成されていなければ次へ
                    if (gameObject == null) continue;
                    //名前をIDに変更
                    gameObject.name = id;
                    //名前テキスト設定
                    gameObject.GetComponent<MouseObjectData>()?.SetNameText(id);

                    //配置を整える用のオブジェクトを生成
                    var parentObj = layoutObject.transform.GetChild(0);
                    //タグを変更
                    parentObj.tag = "ParentLayoutObject";
                    //配置を整えるオブジェクトの子に移動
                    gameObject.transform.parent = parentObj;

                }
            }
        }

        /// <summary>
        /// 誕生日の空オブジェクト生成
        /// </summary>
        private void CreateBirthdayLayoutObject()
        {
            //子オブジェクトを誕生日ごとに分ける
            foreach (var layoutObject in _layoutObjectList)
            {
                //タグを変更
                layoutObject.tag = "OriginLayoutObject";
                //子オブジェクトリスト作成
                for (var i = 0; i < layoutObject.transform.childCount; ++i)
                {
                    if (layoutObject.transform.GetChild(i).name == "ParentObject" || layoutObject.transform.GetChild(i).name == "ChildrenObject") continue;
                    //子オブジェクトのみリストに追加する
                    _childrenList.Add(layoutObject.transform.GetChild(i));
                }

                //誕生日リスト：何産したか？
                List<string> birthdayList = new List<string>();
                foreach (var child in _childrenList)
                {
                    if (birthdayList.Find(n => n == child.GetComponent<MouseObjectData>().Birthday) != null) continue;
                    birthdayList.Add(child.GetComponent<MouseObjectData>().Birthday);
                }

                //誕生日リスト分だけChildrenObjectを生成して名前を誕生日に変更
                var childlayoutObject = layoutObject.transform.Find("ChildrenObject").gameObject;
                for (var i = 1; i <= birthdayList.Count; ++i)
                {
                    if (i == 1)
                    {
                        childlayoutObject.name = birthdayList[0];
                        continue;
                    }

                    //instance生成
                    var instance = _gameManager.Instantiate(childlayoutObject);
                    //名前と場所変更
                    instance.transform.name = birthdayList[i - 1];
                    instance.transform.parent = layoutObject.transform;
                }
            }
        }

        /// <summary>
        /// 子オブジェクトの配置を変更する
        /// </summary>
        /// <param name="isCreate"></param>
        private void ArrangementChildrenObject(bool isCreate)
        {
            foreach (var layoutObject in _layoutObjectList)
            {
                //子オブジェクトを誕生日ごとに振り分ける
                foreach (var child in _childrenList)
                {
                    // 子オブジェクトを格納する配列作成
                    var children = new List<Transform>();

                    // 0～個数-1までの子を順番に配列に格納
                    for (var i = 0; i < layoutObject.transform.childCount; ++i)
                    {
                        children.Add(layoutObject.transform.GetChild(i));
                    }
                    //子の誕生日
                    var birthday = child.GetComponent<MouseObjectData>().Birthday;
                    //誕生日レイアウトオブジェクト
                    var birthdaylayoutObject = children.Find(n => n.name == birthday);

                    if (birthdaylayoutObject == null) return;
                    //オブジェクト移動
                    child.transform.parent = birthdaylayoutObject.transform;
                    //位置を親と同じにする
                    child.transform.position = birthdaylayoutObject.position;
                    //タグを変更
                    birthdaylayoutObject.tag = "ChildLayoutObject";
                }
            }


            //イベント購読解除
            _gameManager.ObjectGenerationCompleteEvent -= ArrangementChildrenObject;
        }
        /// <summary>
        /// つなぎ線オブジェクトの配置
        /// </summary>
        /// /// <param name="targetObject">配置するオブジェクト</param>
        public void ConnectingLineObjectDisposition(GameObject targetObject)
        {

            //タグの種類で場合分け

            if (targetObject.tag == "OriginLayoutObject")
            {

            }
            else if (targetObject.tag == "ParentLayoutObject")
            {
                //オブジェクト生成
                var createObject = _gameManager.ObjectDisposition(GameManager.ObjectName.ConnectingLine_Parallel);
                //生成したオブジェクトを対象オブジェクトの子に配置
                createObject.transform.parent = targetObject.transform;
                //位置を親と同じにする
                createObject.transform.position = targetObject.transform.position;
                createObject.transform.localPosition = new Vector3(createObject.transform.localPosition.x + 1, createObject.transform.localPosition.y, createObject.transform.localPosition.z);
                //Z軸90に回転
                createObject.transform.Rotate(0f,0f,90f); 

            }
            else if(targetObject.tag == "ChildLayoutObject")
            {
                //無限ループ回避のために代入
                int loopCount = targetObject.transform.childCount - 1;
                for (int i = 0; i < loopCount; ++i)
                {
                    //子オブジェクトデータ
                    var childMouseObjectData = targetObject.transform.GetChild(i).GetComponent<MouseObjectData>();

                    //オブジェクト生成
                    var createObject = _gameManager.ObjectDisposition(GameManager.ObjectName.ConnectingLine_Parallel);
                    //生成したオブジェクトを上側目印オブジェクトの子に配置
                    createObject.transform.parent = childMouseObjectData._markPointObject_Upside.transform;
                    //位置を親と同じにする
                    createObject.transform.position = childMouseObjectData._markPointObject_Upside.transform.position;
                    createObject.transform.localPosition = new Vector3(createObject.transform.localPosition.x + 6, createObject.transform.localPosition.y, createObject.transform.localPosition.z);

                    //Z軸90に回転
                    createObject.transform.Rotate(0f, 0f, 90f);
                }
            }
            
        }

    }
}
