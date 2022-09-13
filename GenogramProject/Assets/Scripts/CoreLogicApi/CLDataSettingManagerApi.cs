using CoreLogic;
using Entitys;
using System.Collections;
using System.Collections.Generic;

namespace CoreLogicApi
{

    /// <summary>
    /// データセット管理マネージャーAPI
    /// </summary>
    public class CLDataSettingManagerApi
    {
        CLDataSettingManager _dataSettingManager;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CLDataSettingManagerApi()
        {

            _dataSettingManager = new CLDataSettingManager();
        }


        /// <summary>
        /// データを設定する
        /// </summary>
        /// <param name="name">個体ID</param>
        /// <param name="nature">性別</param>
        /// <param name="fathe">父親の個体ID</param>
        /// <param name="mother">母親の個体ID</param>
        /// <param name="birthday">誕生日</param>
        public void SetData(string name, string nature, string? fathe, string? mother , string birthday)
        {

            _dataSettingManager.SetData(name, nature, fathe, mother , birthday);
        }

        /// <summary>
        /// データリストを取得する
        /// </summary>
        /// <returns></returns>
        public List<MouseDataEntity> GetAllData()
        {
            return _dataSettingManager.GetAllData();
        }

        /// <summary>
        /// 親オブジェクトデータセットリスト
        /// </summary>
        public List<Dictionary<string, string>> GetAllParentSetIdList()
        {
            return _dataSettingManager.GetAllParentSetIdList();


        }
    }
}
