using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presenter
{

    public class PMaineScenePresenter
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMaineScenePresenter()
        {

        }

        public PMaineScenePresenter CreateInstance()
        {
            return new PMaineScenePresenter();
        }

    }
}
