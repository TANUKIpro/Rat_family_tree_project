using CoreLogic;
using Entitys;
using System.Collections.Generic;
using UnityEngine;
using static CoreLogic.CLObjectDeployManager;

namespace CoreLogicApi
{
    public class CLObjectDeployManagerApi
    {
        CLObjectDeployManager _objectDeployManager;

        public CLObjectDeployManagerApi()
        {
            _objectDeployManager = new CLObjectDeployManager();
        }


        /// <summary>
        /// �v�f�I�u�W�F�N�g�z�u
        /// </summary>
        /// <param name="objectName">�I�u�W�F�N�g��</param>
        /// <param name="mouseData">�}�E�X�f�[�^�G���e�B�e�B</param>
        public void ChildObjectGenerate( List<MouseDataEntity> mouseData)
        {
            _objectDeployManager.ChildObjectGenerate(mouseData);
        }

        /// <summary>
        /// �e�I�u�W�F�N�g�̔z�u�𐮂���
        /// </summary>
        public void ParentObjectArrange(List<Dictionary<string, string>> parentDataList)
        {
            _objectDeployManager.ParentObjectGenerate(parentDataList);
        }
    }
}
