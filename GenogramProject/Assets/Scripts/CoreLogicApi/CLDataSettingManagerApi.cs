using CoreLogic;
using Entitys;
using System.Collections;
using System.Collections.Generic;

namespace CoreLogicApi
{

    /// <summary>
    /// �f�[�^�Z�b�g�Ǘ��}�l�[�W���[API
    /// </summary>
    public class CLDataSettingManagerApi
    {
        CLDataSettingManager _dataSettingManager;


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CLDataSettingManagerApi()
        {

            _dataSettingManager = new CLDataSettingManager();
        }


        /// <summary>
        /// �f�[�^��ݒ肷��
        /// </summary>
        /// <param name="name">��ID</param>
        /// <param name="nature">����</param>
        /// <param name="fathe">���e�̌�ID</param>
        /// <param name="mother">��e�̌�ID</param>
        /// <param name="birthday">�a����</param>
        public void SetData(string name, string nature, string? fathe, string? mother , string birthday)
        {

            _dataSettingManager.SetData(name, nature, fathe, mother , birthday);
        }

        /// <summary>
        /// �f�[�^���X�g���擾����
        /// </summary>
        /// <returns></returns>
        public List<MouseDataEntity> GetAllData()
        {
            return _dataSettingManager.GetAllData();
        }

        /// <summary>
        /// �e�I�u�W�F�N�g�f�[�^�Z�b�g���X�g
        /// </summary>
        public List<Dictionary<string, string>> GetAllParentSetIdList()
        {
            return _dataSettingManager.GetAllParentSetIdList();


        }
    }
}
