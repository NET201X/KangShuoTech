

namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RequireModel
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public string OptionName { get; set; }
        public string ChinName { get; set; }
        public string Comment { get; set; }
        public string Isrequired { get; set; }
        public string TabName { get; set; }
        public string SetValue { get; set; }
        public string Content { get; set; }
        public string TypeName { get; set; }
        public string ItemValue { get; set; }
        /// <summary>
        /// 是否启用小数
        /// </summary>
        public string IsDecimalPlace { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int DecimalPlace { get; set; }
        /// <summary>
        /// 是否奇偶数
        /// </summary>
        public string IsOdevity { get; set; }

    }
}
