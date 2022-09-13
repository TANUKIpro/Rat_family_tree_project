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
        public GameObject ObjectDisposition(string objName)
        {
            return Instantiate((GameObject)Resources.Load(objName), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

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
