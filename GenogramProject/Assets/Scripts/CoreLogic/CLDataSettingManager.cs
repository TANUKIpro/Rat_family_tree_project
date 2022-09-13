using Entitys;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLogic
{

    /// <summary>
    /// データセット管理マネージャー
    /// </summary>
    public class CLDataSettingManager
    {
        /// <summary>
        /// マウスデータのリスト
        /// </summary>
        List<MouseDataEntity> _mouseDataList = new List<MouseDataEntity>();


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
            //すでにリストに含まれているなら処理しない
            if (GetData(name) != null) return;

            DateTime dTime = DateTime.Now;

            try
            {
                dTime = DateTime.Parse(birthday);
            }
            catch (System.Exception e)
            {
                //MethodCで投げられた例外はここで処理される
                //のちのちエラー分表示も作りたい
                Debug.Log("引数の形式間違い");
            }

            MouseDataEntity mouseData = new MouseDataEntity
            {
                AnalysisId = name,
                Nature = nature,
                FatherId = fathe,
                MotherId = mother,
                Birthday = dTime
            };

            //リストに追加
            _mouseDataList.Add(mouseData);
        }

        /// <summary>
        /// データリストをすべて取得
        /// </summary>
        /// <returns></returns>
        public List<MouseDataEntity> GetAllData()
        {
            return _mouseDataList;
        }

        /// <summary>
        /// 親オブジェクトデータセットリスト
        /// </summary>
        public List<Dictionary<string,string>> GetAllParentSetIdList()
        {

            List<Dictionary<string, string>> parentIdList = new List<Dictionary<string, string>>();

            foreach(var data in _mouseDataList)
            {
                if (data.FatherId == null) continue;

                //親IDセット
                Dictionary<string, string> parentIdDic = new Dictionary<string, string>()
                {
                    {"FatherId", data.FatherId},
                    {"MotherId", data.MotherId},
                };

                //リストに同じものが含まれていなければ追加
                if (parentIdList.Find(n => n["FatherId"] == data.FatherId) != null && parentIdList.Find(n => n["MotherId"] == data.MotherId) != null) continue;
                
                parentIdList.Add(parentIdDic);
            }

            return parentIdList;
        }

        /// <summary>
        /// マウスIDのMouseDataEntityを取得
        /// </summary>
        /// <param name="analysisId">マウスID</param>
        /// <returns></returns>
        public MouseDataEntity GetData(string analysisId)
        {
            return _mouseDataList.Find(n => n.AnalysisId == analysisId);
        }

    }
}
