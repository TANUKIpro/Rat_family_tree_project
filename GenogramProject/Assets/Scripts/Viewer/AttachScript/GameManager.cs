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
        /// ���C���V�[���v���[���^�[
        /// </summary>
        PMaineScenePresenter maineScenePresenter;

        /// <summary>
        /// �f�[�^�Z�b�e�B���O�v���[���^�[
        /// </summary>
        PDeployObjectPresenter DeployObjectPresenter;

        /// <summary>
        /// �I�u�W�F�N�g���������C�x���g
        /// </summary>
        public event Action<bool> ObjectGenerationCompleteEvent;

        /// <summary>
        /// �N������1�񂾂��Ă΂��
        /// </summary>
        void Start()
        {
            //�e��v���[���^�[��instance���N����
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
        /// �e��v���[���^�[��instance���N����
        /// </summary>
        void CreatePrewsenterInstance()
        {
            //���C���V�[���v���[���^�[
            maineScenePresenter = new PMaineScenePresenter();

            //�f�[�^�Z�b�e�B���O�v���[���^�[
            DeployObjectPresenter = new PDeployObjectPresenter();
        }

        /// <summary>
        /// �����œn���ꂽ�I�u�W�F�N�g�𐶐�
        /// </summary>
        /// <param name="objName">�I�u�W�F�N�g��</param>
        /// <returns></returns>
        public GameObject ObjectDisposition(string objName)
        {
            return Instantiate((GameObject)Resources.Load(objName), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        }

        /// <summary>
        /// �I�u�W�F�N�g�𐶐�
        /// </summary>
        /// <param name="obj"></param>
        public GameObject Instantiate(GameObject obj)
        {
           return GameObject.Instantiate(obj);
        }
    }
}
