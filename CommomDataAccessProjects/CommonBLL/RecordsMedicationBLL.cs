using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Collections.Generic;
using System.Data;
using CommomUtilities.Common;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsMedicationBLL
    {
        private readonly RecordsMedicationDAL dal = new RecordsMedicationDAL();

        public bool Add(RecordsMedicationModel model)
        {
            return this.dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddList(List<RecordsMedicationModel> modelList)
        {
            foreach (RecordsMedicationModel a in modelList)
            {
                if(string.IsNullOrEmpty(a.MedicinalName))  continue;

                if (!dal.Add(a)) return false;
            }

            return true;
        }

        public bool DeleteByOutKey(int OutKey)
        {
            return this.dal.DeleteByOutKey(OutKey);
        }

		public List<RecordsMedicationModel> GetModelList(string strWhere)
		{
            DataSet ds = this.dal.GetList(strWhere);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsMedicationModel> list = ModelConvertHelper<RecordsMedicationModel>.ToList(ds.Tables[0]);
                if (list.Count > 0) return list;
            }

            return null;
		}

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
    }
}
