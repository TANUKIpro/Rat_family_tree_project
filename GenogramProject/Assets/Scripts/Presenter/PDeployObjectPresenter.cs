using ApLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presenter
{
    /// <summary>
    /// オブジェクト配置用プレゼンター
    /// </summary>
    public class PDeployObjectPresenter
    {
        /// <summary>
        /// データ設定用マネージャー
        /// </summary>
        private readonly ALDataSettingManager _dataSettingManager = new ALDataSettingManager();

        /// <summary>
        /// オブジェクト配置用マネージャー
        /// </summary>
        private readonly ALObjectDeployManager _objectDeployManager = new ALObjectDeployManager();
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PDeployObjectPresenter()
        {

            Initialize();
        }

        public PDeployObjectPresenter CreateInstance()
        {
            return new PDeployObjectPresenter();
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void Initialize()
        {
            //仮のデータ設定
            //1世代分
            _dataSettingManager.SetData("01", "MaleObject",null, null, "2022/01/01");
            _dataSettingManager.SetData("02", "FemaleObject", null, null, "2022/01/01");

            //2023/01/01生まれ
            _dataSettingManager.SetData("03", "MaleObject", "01", "02", "2023/01/01");
            _dataSettingManager.SetData("04", "MaleObject", "01", "02", "2023/01/01");
            //_dataSettingManager.SetData("05", "MaleObject", "01", "02", "2023/01/01");
            //2023/02/01生まれ
            _dataSettingManager.SetData("33", "MaleObject", "01", "02", "2023/02/01");
            _dataSettingManager.SetData("44", "MaleObject", "01", "02", "2023/02/01");
            _dataSettingManager.SetData("55", "MaleObject", "01", "02", "2023/02/01");
            //2023/03/01生まれ
            _dataSettingManager.SetData("333", "MaleObject", "01", "02", "2023/03/01");
            _dataSettingManager.SetData("444", "MaleObject", "01", "02", "2023/03/01");
            _dataSettingManager.SetData("555", "MaleObject", "01", "02", "2023/03/01");


            //1世代分
            //_dataSettingManager.SetData("11", "MaleObject", null, null, "2022/01/02");
            //_dataSettingManager.SetData("22", "FemaleObject", null, null, "2022/01/02");

            ////2023/01/02生まれ
            //_dataSettingManager.SetData("3333", "MaleObject", "11", "22", "2023/01/02");

            //オブジェクト配置
            DeployObject();
        }

        /// <summary>
        /// オブジェクトを配置
        /// </summary>
        private void DeployObject()
        {
            
            //親データの辞書リスト取得
            var parentSetdata = _dataSettingManager.GetAllParentSetIdList();
            if (parentSetdata == null) return;

            //マウスデータをすべて取得
            var dataList = _dataSettingManager.GetAllData();
            if (dataList == null) return;

            //オブジェクト配置
            _objectDeployManager.ObjectDisposition(parentSetdata, dataList);



        }
        
    }
}
