using CoreLogicApi;
using Entitys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApLogic
{

    public class ALDataSettingManager
    {
        /// <summary>
        /// データセット管理マネージャーApi
        /// </summary>
        CLDataSettingManagerApi _dataSettingManagerApi = new CLDataSettingManagerApi();

        /// <summary>
        /// 世代数カウント用変数
        /// </summary>
        private int _generationCount = 1;

        /// <summary>
        /// データを設定する
        /// </summary>
        /// <param name="name">個体ID</param>
        /// <param name="nature">性別</param>
        /// <param name="fathe">父親の個体ID</param>
        /// <param name="mother">母親の個体ID</param>
        /// <param name="birthday">誕生日</param>
        public void SetData(string name, string nature, string? fathe, string? mother ,string birthday)
        {

            _dataSettingManagerApi.SetData(name, nature, fathe, mother ,birthday);
        }


        /// <summary>
        /// データリストを取得する
        /// </summary>
        /// <returns></returns>
        public List<MouseDataEntity> GetAllData()
        {
            return _dataSettingManagerApi.GetAllData();
        }

        /// <summary>
        /// 親オブジェクトデータセットリスト
        /// </summary>
        public List<Dictionary<string, string>> GetAllParentSetIdList()
        {
            return _dataSettingManagerApi.GetAllParentSetIdList();
        }


        /// <summary>
        /// 世代数を取得
        /// </summary>
        /// <returns></returns>
        public int GetGenerationCount(MouseDataEntity mouseData)
        {
            //変数初期化
            _generationCount = 1;
            var dataList = GetAllData();

            GenerationCount(dataList,mouseData);

            return _generationCount;
                 
        }

        /// <summary>
        /// 再帰で親を探す
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="mouseData"></param>
        private void GenerationCount(List<MouseDataEntity> dataList, MouseDataEntity mouseData)
        {
            if (mouseData.FatherId != null)
            {
                _generationCount++;

                var resultData = dataList.Find(n => n.AnalysisId== mouseData.FatherId);
                if (resultData != null) GenerationCount(dataList, resultData);
            }

            return;
        }
    }
}
