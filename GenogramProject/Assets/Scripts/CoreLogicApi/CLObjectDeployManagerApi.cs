using CoreLogic;
using Entitys;
using System.Collections.Generic;
using UnityEngine;
using static CoreLogic.CLObjectDeployManager;

namespace CoreLogicApi
{
    /// <summary>
    /// オブジェクト配置コアロジッククラスAPI
    /// </summary>
    public class CLObjectDeployManagerApi
    {
        CLObjectDeployManager _objectDeployManager;

        public CLObjectDeployManagerApi()
        {
            _objectDeployManager = new CLObjectDeployManager();
        }


        /// <summary>
        /// 要素オブジェクト配置
        /// </summary>
        /// <param name="objectName">オブジェクト名</param>
        /// <param name="mouseData">マウスデータエンティティ</param>
        public void ChildObjectGenerate( List<MouseDataEntity> mouseData)
        {
            _objectDeployManager.ChildObjectGenerate(mouseData);
        }

        /// <summary>
        /// 親オブジェクトの配置を整える
        /// </summary>
        public void ParentObjectArrange(List<Dictionary<string, string>> parentDataList)
        {
            _objectDeployManager.ParentObjectGenerate(parentDataList);
        }

        /// <summary>
        /// つなぎ線オブジェクトの配置
        /// </summary>
        /// <param name="Tag">配置するオブジェクトのタグ</param>
        public void ConnectingLineObjectDisposition(string tag)
        {
            ConnectingLineObjectDisposition(tag);
        }
    }
}
