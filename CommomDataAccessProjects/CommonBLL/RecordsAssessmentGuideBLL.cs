namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsAssessmentGuideBLL
    {
        private readonly RecordsAssessmentGuideDAL dal = new RecordsAssessmentGuideDAL();

        public int Add(RecordsAssessmentGuideModel model)
        {
            return dal.Add(model);
        }

        public RecordsAssessmentGuideModel GetModelByOutKey(int OutKey)
        {
            DataSet ds = this.dal.GetModelByOutKey(OutKey);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<RecordsAssessmentGuideModel> list = ModelConvertHelper<RecordsAssessmentGuideModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
    }
}