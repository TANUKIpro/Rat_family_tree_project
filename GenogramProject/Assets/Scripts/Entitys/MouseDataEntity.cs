using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entitys
{
    /// <summary>
    /// マウスの親子データ エンティティ
    /// </summary>
    public class MouseDataEntity
    {
        /// <summary>
        /// マウスの個体ID
        /// </summary>
        public string AnalysisId { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public string Nature { get; set; }

        /// <summary>
        /// オスの親の個体ID
        /// </summary>
        public string? FatherId { get; set; }

        /// <summary>
        /// メスの親の個体ID
        /// </summary>
        public string? MotherId { get; set; }

        /// <summary>
        /// 生まれた日付
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
