using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entitys
{
    /// <summary>
    /// �}�E�X�̐e�q�f�[�^ �G���e�B�e�B
    /// </summary>
    public class MouseDataEntity
    {
        /// <summary>
        /// �}�E�X�̌�ID
        /// </summary>
        public string AnalysisId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Nature { get; set; }

        /// <summary>
        /// �I�X�̐e�̌�ID
        /// </summary>
        public string? FatherId { get; set; }

        /// <summary>
        /// ���X�̐e�̌�ID
        /// </summary>
        public string? MotherId { get; set; }

        /// <summary>
        /// ���܂ꂽ���t
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
