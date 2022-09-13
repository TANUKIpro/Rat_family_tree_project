using System;
using TMPro;
using UnityEngine;

namespace Viewer
{
    public class MouseObjectData : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var parentObject = transform.parent;

            var birthdaylayoutObject = parentObject.transform.Find(Birthday);
            if (birthdaylayoutObject != null)
            {
                transform.parent = birthdaylayoutObject.transform;
                transform.position = birthdaylayoutObject.position;
            }
        }

        /// <summary>
        /// �㑤�ڈ�I�u�W�F�N�g
        /// </summary>
        public GameObject _markPointObject_Upside;

        /// <summary>
        /// �㑤���I�u�W�F�N�g
        /// </summary>
        public GameObject _coverall_Upside;

        /// <summary>
        /// �a����
        /// </summary>
        public string Birthday;

        /// <summary>
        /// ���O�̃e�L�X�g 
        /// </summary>
        public GameObject _nameText;
        
        /// <summary>
        /// �a������ݒ�
        /// </summary>
        /// <param name="birthday"></param>
        public void SetBirthday(DateTime birthday)
        {
            Birthday = birthday.ToShortDateString();
        }

        public void SetNameText(string name)
        {
            var textcomp = _nameText.GetComponent<TextMeshPro>();
            _nameText.GetComponent<TextMeshPro>().text = name;
        }
    }
}
