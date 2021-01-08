using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
   public  class AnomalyRangeModel
    {
        private int _ID;
        private int _preinstallId;
        private string _Sex;
        private string _RangeMin;
        private string _RangeMax;
        private string _GuidanceMin;
        private string _GuidanceMax;

        /// <summary>
        /// 主键
        /// </summary>
        public int id
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get
            {
                return _Sex;
            }

            set
            {
                _Sex = value;
            }
        }

        /// <summary>
        /// 最小范围值
        /// </summary>
        public string RangeMin
        {
            get
            {
                return _RangeMin;
            }

            set
            {
                _RangeMin = value;
            }
        }

        /// <summary>
        /// 最大范围值
        /// </summary>
        public string RangeMax
        {
            get
            {
                return _RangeMax;
            }

            set
            {
                _RangeMax = value;
            }
        }

        /// <summary>
        /// 偏低指导建议
        /// </summary>
        public string GuidanceMin
        {
            get
            {
                return _GuidanceMin;
            }

            set
            {
                _GuidanceMin = value;
            }
        }

        /// <summary>
        /// 偏高指导建议
        /// </summary>
        public string GuidanceMax
        {
            get
            {
                return _GuidanceMax;
            }

            set
            {
                _GuidanceMax = value;
            }
        }

        /// <summary>
        /// 系统预设表主键
        /// </summary>
        public int PreinstallId
        {
            get
            {
                return _preinstallId;
            }

            set
            {
                _preinstallId = value;
            }
        }
    }
}
