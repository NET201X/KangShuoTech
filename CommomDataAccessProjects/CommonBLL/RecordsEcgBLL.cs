using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsEcgBLL
    {
        private readonly RecordsEcgDAL dal = new RecordsEcgDAL();

        public DataSet GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderBy, startIndex, endIndex);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public int GetMIDCount(string strWhere)
        {
            return this.dal.GetMIDCount(strWhere);
        }

        public DataSet GetUserDt(string strWhere)
        {
            return this.dal.GetUserDt(strWhere);
        }

        /// <summary>
        /// 获取最近一条体检记录
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public EcgDataModel GetMaxModel(string IDCardNo, string CheckDate = "")
        {
            DataSet ds = dal.GetMaxModel(IDCardNo, CheckDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<EcgDataModel> list = ModelConvertHelper<EcgDataModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public int Add(EcgDataModel model)
        {
            return dal.Add(model);
        }

        public void Delete(EcgDataModel model)
        {
            dal.Delete(model);
        }
    }

    public class TypeBBLL
    {
        private readonly TypeBDAL dal = new TypeBDAL();

        /// <summary>
        /// 获取最近一条体检记录
        /// </summary>
        /// <param name="IDCardNo"></param>
        /// <param name="CheckDate"></param>
        /// <returns></returns>
        public DataSet GetList(string IDCardNo, string CheckDate = "")
        {
            return dal.GetList(IDCardNo, CheckDate);
        }

        public DataSet GetPutInfo(string strStart, string strEnd, string conn = "")
        {
            return dal.GetPutInfo(strStart, strEnd, conn);
        }

        public void InsDB(DataRow drInfo)
        {
            dal.InsDB(drInfo);
        }

        public int DelDB(DataRow drInfo)
        {
            return dal.DelDB(drInfo);
        }

        #region 新版B超

        public void DeletePtn(DataRow drInfo)
        {
            dal.DeletePtn(drInfo);
        }

        public int InsertPtn(DataRow drInfo)
        {
            return dal.InsertPtn(drInfo);
        }

        #endregion

        #region 重庆B超

        public void DeleteByChongQing(DataRow drInfo)
        {
            dal.DeleteByChongQing(drInfo);
        }

        public void InsDBByChongQing(DataRow drInfo)
        {
            dal.InsDBByChongQing(drInfo);
        }

        #endregion
    }
}
