using System.Collections.Generic;
namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    public class UrineDataModel
    {
        /// <summary>
        /// 日期时间
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 样本编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 样本条码
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDcard { get; set; }
        /// <summary>
        /// 检测结果
        /// </summary>
        public List<ResultsItem> results { get; set; }
    }

    public class ResultsItem
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string item { get; set; }
        /// <summary>
        /// 项目结果
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 项目单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 是否异常
        /// </summary>
        public string abnormal { get; set; }
    }
}
