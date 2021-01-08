using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class VisionInfoModel
    {
        public int ID { get; set; }
        public string IDCard { get; set; }
        public string UserName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }

        /// <summary>
        /// 左眼裸眼视力
        /// </summary>
        public string LeftNakedEye { get; set; }

        /// <summary>
        /// 右眼裸眼视力
        /// </summary>
        public string RightNakedEye { get; set; }

        /// <summary>
        /// 左眼矫正视力
        /// </summary>
        public string LeftCorrect { get; set; }

        /// <summary>
        /// 右眼矫正视力
        /// </summary>
        public string RightCorrect { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 时间字符串 如20191211
        /// </summary>
        public string TimeString { get; set; }
    }
}
