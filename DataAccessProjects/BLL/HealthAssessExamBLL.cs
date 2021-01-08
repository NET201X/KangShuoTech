using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthAssessExamBLL
    {
        private readonly HealthAssessExamDAL dal = new HealthAssessExamDAL();
        public int Add(HealthAssessExamModel model)
        {
            return this.dal.Add(model);
        }
        public HealthAssessExamModel GetModel(int PID)
        {
            return this.dal.GetModel(PID);
        }
        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }
        public bool Update(HealthAssessExamModel model)
        {
            return this.dal.Update(model);
        }

        #region 问询信息查询

        public int GetHealthInquiryRecordCount(string strWhere)
        {
            return this.dal.GetHealthInquiryRecordCount(strWhere);
        }

        public DataSet GetHealthInquiryListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetHealthInquiryListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        #endregion
        public HealthAssessExamModel GetMaxModel(string IDCardNo)
        {
            return this.dal.GetMaxModel(IDCardNo);
        }
    }
}
