namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class OlderSelfCareabilityBLL : InterfaceDataList
    {
        private readonly OlderSelfCareabilityDAL dal = new OlderSelfCareabilityDAL();

        public int Add(OlderSelfCareabilityModel model)
        {
            return this.dal.Add(model);
        }

        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }

        public OlderSelfCareabilityModel CheckModel(string strWhere)
        {
            DataSet ds = this.dal.CheckModel(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderSelfCareabilityModel> list = ModelConvertHelper<OlderSelfCareabilityModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
        
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public OlderSelfCareabilityModel GetModel(string IDCardNo)
        {
            DataSet ds = this.dal.GetModel(IDCardNo);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderSelfCareabilityModel> list = ModelConvertHelper<OlderSelfCareabilityModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public OlderSelfCareabilityModel GetModelID(int ID)
        {
            DataSet ds = this.dal.GetModelID(ID);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<OlderSelfCareabilityModel> list = ModelConvertHelper<OlderSelfCareabilityModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return new OlderSelfCareabilityModel();
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public bool Update(OlderSelfCareabilityModel model)
        {
            return this.dal.Update(model);
        }

        /// <summary>
        /// 数据同步自理能力存档
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByUpload(OlderSelfCareabilityModel model)
        {
            return this.dal.UpdateByUpload(model);
        }

        public List<OlderSelfCareabilityModel> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);

            List<OlderSelfCareabilityModel> list = new List<OlderSelfCareabilityModel>();
            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                // 将DataTable转为List
                list = ModelConvertHelper<OlderSelfCareabilityModel>.ToList(ds.Tables[0]);
            }

            return list;
        }
    }
}

