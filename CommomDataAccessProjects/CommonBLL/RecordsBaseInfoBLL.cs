using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsBaseInfoBLL
    {
        private readonly RecordsBaseInfoDAL dal = new RecordsBaseInfoDAL();

        public DataSet GetList(string strWhere, string orderBy)
        {
            return this.dal.GetList(strWhere, orderBy);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderBy, startIndex, endIndex);
        }

        public DataSet GetTownList()
        {
            return this.dal.GetTownList();
        }

        public DataSet GetUserDt(string strWhere)
        {
            return this.dal.GetUserDt(strWhere);
        }

        public RecordsBaseInfoModel GetModel(string IDCardNo)
        {
            DataSet ds = this.dal.GetModel(IDCardNo);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                List<RecordsBaseInfoModel> list = ModelConvertHelper<RecordsBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }


        /// <summary>
        /// 批量删除所有体检表
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public int DeleteIDCard(string idCardNo)
        {
            return this.dal.DeleteIDCard(idCardNo);
        }

        /// <summary>
        /// 批量删除所有体检表数据
        /// </summary>
        /// <param name="CreateDateS"></param>
        /// <param name="CreateDateE"></param>
        /// <returns></returns>
        public bool Delete(string CreateDateS, string CreateDateE)
        {
            return this.dal.Delete(CreateDateS, CreateDateE);
        }
    }
}
