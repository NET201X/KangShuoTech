using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class ReportDetailBLL
    {
        private ReportDetailDAL dal = new ReportDetailDAL();

        /// <summary>
        /// 按照文件名删除报表明细
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public bool DeleteReportDetail(string reportName)
        {
            return dal.DeleteReportDetail(reportName);
        }

        /// <summary>
        /// 添加报表明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddReportDetail(ReportDetailModel model)
        {
            return dal.AddReportDetail(model);
        }

        /// <summary>
        /// 获取所有报表名称
        /// </summary>
        /// <returns></returns>
        public DataSet GetReportName()
        {
            return dal.GetReportName();
        }

        /// <summary>
        /// 根据报表名称获取报表详细信息
        /// </summary>
        /// <param name="ReportName"></param>
        /// <returns></returns>
        public DataTable GetModelList(string ReportName)
        {
            DataTable dt = dal.GetModelList(ReportName).Tables[0];

            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    List<ReportDetailModel> list = ModelConvertHelper<ReportDetailModel>.ToList(ds.Tables[0]);

            //    if (list.Count > 0) return list;
            //}

            return dt;
        }
    }
}
