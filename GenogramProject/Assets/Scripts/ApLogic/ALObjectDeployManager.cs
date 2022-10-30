
using CoreLogicApi;
using Entitys;
using System.Collections.Generic;
using UnityEngine;
using static CoreLogic.CLObjectDeployManager;

namespace ApLogic
{
    /// <summary>
    /// オブジェクト配置ロジッククラス
    /// </summary>
    public class ALObjectDeployManager
    {
        // オブジェクト配置コアロジッククラスAPI
        CLObjectDeployManagerApi _objectDeployManagerApi = new CLObjectDeployManagerApi();


        /// <summary>
        /// 要素オブジェクト配置
        /// </summary>
        /// <param name="parentDataList">親データの辞書リスト</param>
        /// <param name="mouseData">マウスデータエンティティリスト</param>
        public void ObjectDisposition (List<Dictionary<string, string>> parentDataList , List<MouseDataEntity> mouseData)
        {
            //親オブジェクト
            _objectDeployManagerApi.ParentObjectArrange(parentDataList);

            //子オブジェクト
            _objectDeployManagerApi.ChildObjectGenerate(mouseData);
        }

    }
}