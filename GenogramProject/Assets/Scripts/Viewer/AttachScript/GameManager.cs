using Presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Viewer
{
    public class GameManager : MonoBehaviour
    {

        /// <summary>
        /// メインシーンプレゼンター
        /// </summary>
        PMaineScenePresenter maineScenePresenter;

        /// <summary>
        /// データセッティングプレゼンター
        /// </summary>
        PDeployObjectPresenter DeployObjectPresenter;

        /// <summary>
        /// オブジェクト生成完了イベント
        /// </summary>
        public event Action<bool> ObjectGenerationCompleteEvent;

        /// <summary>
        /// オブジェクト名列挙型
        /// </summary>
        public enum ObjectName
        {
            // オス用のオブジェクト名
            MaleObject,
            // メス用のオブジェクト名
            FemaleObject,
            //レイアウト用オブジェクト
            ObjectLayout,
            // つなぎ線オブジェクト　並列
            ConnectingLine_Parallel,
            // つなぎ線オブジェクト　直列
            ConnectingLine_Series,
        }

        /// <summary>
        /// 起動時に1回だけ呼ばれる
        /// </summary>
        void Start()
        {
            //各種プレゼンターのinstanceを起こす
            CreatePrewsenterInstance();
        }

        // Update is called once per frame
        void Update()
        {
            var test = GameObject.Find("ParentObject");

            if (test != null)
            {
                ObjectGenerationCompleteEvent?. Invoke(true);
            }
        }

        /// <summary>
        /// 各種プレゼンターのinstanceを起こす
        /// </summary>
        void CreatePrewsenterInstance()
        {
            //メインシーンプレゼンター
            maineScenePresenter = new PMaineScenePresenter();

            //データセッティングプレゼンター
            DeployObjectPresenter = new PDeployObjectPresenter();
        }

        /// <summary>
        /// 引数で渡されたオブジェクトを生成
        /// </summary>
        /// <param name="objName">オブジェクト名</param>
        /// <returns></returns>
        public GameObject ObjectDisposition(ObjectName objName)
        {

            //switch文
            switch (objName)
            {
                case ObjectName.MaleObject:
                    return Instantiate((GameObject)Resources.Load("MaleObject"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

                case ObjectName.FemaleObject:
                    return Instantiate((GameObject)Resources.Load("FemaleObject"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

                case ObjectName.ObjectLayout:
                    return Instantiate((GameObject)Resources.Load("ObjectLayout"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

                case ObjectName.ConnectingLine_Parallel:
                    return Instantiate((GameObject)Resources.Load("ConnectingLine_Parallel"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

                case ObjectName.ConnectingLine_Series:
                    return Instantiate((GameObject)Resources.Load("ConnectingLine_Series"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            }

            return null;
        }

        /// <summary>
        /// オブジェクトを生成
        /// </summary>
        /// <param name="obj"></param>
        public GameObject Instantiate(GameObject obj)
        {
           return GameObject.Instantiate(obj);
        }
    }
}
