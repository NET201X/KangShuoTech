using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsHealthConditionBLL
    {
        private readonly RecordsHealthConditionDAL dal = new RecordsHealthConditionDAL();

        public List<RecordsHealthConditionModel> GetMaxList(string strWhere, string conn = "")
        {
            DataSet ds = this.dal.GetMaxList(strWhere, conn);

            if (ds == null) return null;

            return CommonExtensions.ToList<RecordsHealthConditionModel>(ds.Tables[0]);
        }
        public bool UpdateByMiniPad(RecordsHealthConditionModel model, string OutKey)
        {
            return this.dal.UpdateByMiniPad(model, OutKey);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(RecordsHealthConditionModel model, string outKey)
        {
            return dal.Add(model, outKey);
        }
    }
}
