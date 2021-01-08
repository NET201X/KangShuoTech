namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonModel;
    using QKangShuoTech.CommomDataAccessProjects.CommonDAL;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsFamilyHistoryInfoBLL
    {
        private readonly RecordsFamilyHistoryInfoDAL dal = new RecordsFamilyHistoryInfoDAL();
        
        public RecordsFamilyHistoryInfoModel GetModel(string IDCardNo)
        {
            DataSet ds= this.dal.GetModel(IDCardNo);

            if (ds != null && ds.Tables.Count > 0) 
            {
                List<RecordsFamilyHistoryInfoModel> list = ModelConvertHelper<RecordsFamilyHistoryInfoModel>.ToList(ds.Tables[0]);

                if(list.Count>0) return list[0];
            }

            return new RecordsFamilyHistoryInfoModel();
        }
    }
}

