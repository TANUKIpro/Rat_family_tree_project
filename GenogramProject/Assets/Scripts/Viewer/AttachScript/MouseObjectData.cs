using System;
using TMPro;
using UnityEngine;

namespace Viewer
{
    public class MouseObjectData : MonoBehaviour
    {

        /// <summary>
        /// 上側目印オブジェクト
        /// </summary>
        public GameObject _markPointObject_Upside;

        /// <summary>
        /// 上側線オブジェクト
        /// </summary>
        public GameObject _coverall_Upside;

        /// <summary>
        /// 誕生日
        /// </summary>
        public string Birthday;

        /// <summary>
        /// 名前のテキスト 
        /// </summary>
        public GameObject _nameText;
        
        /// <summary>
        /// 誕生日を設定
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
