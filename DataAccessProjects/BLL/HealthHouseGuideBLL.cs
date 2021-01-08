using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KangShuoTech.DataAccessProjects.Model;
using System;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.DAL;


namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthHouseGuideBLL
    {
        private readonly HealthHouseGuideDAL dal = new HealthHouseGuideDAL();

        #region 健康指导
        /// <summary>
        /// 健康指导 根据身份证取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public HealthHouseGuideModel GetGuideData(string idCardNo)
        {
            DataSet ds = this.dal.GetGuideData(idCardNo);

            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                IList<HealthHouseGuideModel> list = CommonExtensions.DataTableToList<HealthHouseGuideModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 健康指导 是否已存在 - 身份证和PID
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public bool ExistsPID(string idCardNo, int pId)
        {
            return this.dal.ExistsPID(idCardNo, pId);
        }

        /// <summary>
        /// 新增健康指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HealthHouseGuideModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 修改健康指导
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HealthHouseGuideModel model)
        {
            return dal.Update(model);
        }

        #endregion

        #region 健康指导查询

        /// <summary>
        /// 查询健康指导信息总笔数
        /// </summary>
        /// <returns></returns>
        public int GetHealthGuideRecordCount(string strWhere)
        {
            return this.dal.GetHealthGuideRecordCount(strWhere);
        }

        /// <summary>
        /// 分页查询-健康指导信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetHealthGuideListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetHealthGuideListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 获取健康指导 - 根据身份证号
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public HealthHouseGuideModel GetHealthGuideByIdCardNo(int ID)
        {
            return this.dal.GetHealthGuideByIdCardNo(ID);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        #endregion
    }
}
