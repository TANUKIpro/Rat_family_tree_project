using CoreLogicApi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Viewer
{
    /// <summary>
    /// オブジェクトのレイアウト用スクリプト
    /// </summary>
    public class ObjectLayout : MonoBehaviour
    {

        //レイアウト完了したかのフラグ
        private int _layoutCompletion = 0;

        /// <summary>
        /// オブジェクト配置コアロジッククラスAPI
        /// </summary>
        CLObjectDeployManagerApi _objectDeployManagerApi;


        // Start is called before the first frame update
        void Start()
        {
            _objectDeployManagerApi = new CLObjectDeployManagerApi();
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// 
        /// </summary>
        void Update()
        {
            //レイアウト完了していれば実行しない
            if (_layoutCompletion == 10)
            {
                ConnectingLineObjectDisposition();
                _layoutCompletion += 1;
                return;
            }
            //レイアウト完了していれば実行しない
            if (_layoutCompletion > 10)
            {
                return;
            }

            //最上位ノード
            //判定：子ノードが存在する。かつ、子ノードの最初の名前がParentObject
            if (gameObject.transform.childCount != 0 && gameObject.transform.GetChild(0).name == "ParentObject")
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if (i < gameObject.transform.childCount - 1)
                    {
                        //ParentObjectの場合
                        if (gameObject.transform.GetChild(i).name == "ParentObject")
                        {
                            //ParentObject
                            var parentObj = gameObject.transform.GetChild(i);
                            parentObj.position = new Vector3(0, 3, 0);
                        }
                        else
                        {
                            //対象の孫ノードで最後尾のオブジェクトを取得
                            var ChildObject = gameObject.transform.GetChild(i);
                            var rearGrandchildObject = ChildObject.GetChild(ChildObject.childCount - 1);

                            //移動
                            gameObject.transform.GetChild(i+1).position = new Vector3(rearGrandchildObject.position.x + 4, gameObject.transform.GetChild(i).position.y, gameObject.transform.GetChild(i).position.z);
                        }
                    }
                }
                _layoutCompletion += 1;
            }
            //第二位ノード
            //判定：子ノードが存在する。
            else if (gameObject.transform.childCount != 0)
            {
                for (int i = 0; i < gameObject.transform.childCount ; i++)
                {
                    //０の位置かえない。基準
                    if (i == 0) continue;

                    //前のオブジェクトの右に移動
                    gameObject.transform.GetChild(i).position = new Vector3(gameObject.transform.GetChild(i - 1).position.x + 2.5f, gameObject.transform.GetChild(i).position.y, gameObject.transform.GetChild(i).position.z);

                }
                _layoutCompletion+=1;
            }
        }


        /// <summary>
        /// つなぎ線の配置
        /// </summary>
        private void ConnectingLineObjectDisposition()
        {
            _objectDeployManagerApi.ConnectingLineObjectDisposition(this.gameObject);

        }
    }
}
