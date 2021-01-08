namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    public class KidsTcmhmOneBLL
    {
        private readonly KidsTcmhmOneDAL dal = new KidsTcmhmOneDAL();

        public List<KidsTcmhmOneModel> GetList(string IDCardNo)
        {
            DataSet ds = dal.GetList(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<KidsTcmhmOneModel> list = ModelConvertHelper<KidsTcmhmOneModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }
    }

    public class KidsTcmhmOneToThreeBLL
    {
        private readonly KidsTcmhmOneToThreeDAL dal = new KidsTcmhmOneToThreeDAL();

        public List<KidsTcmhmOneToThreeModel> GetList(string IDCardNo)
        {
            DataSet ds = dal.GetList(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<KidsTcmhmOneToThreeModel> list = ModelConvertHelper<KidsTcmhmOneToThreeModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }
    }

    public class KidsTcmhmThreeToSixBLL
    {
        private readonly KidsTcmhmThreeToSixDAL dal = new KidsTcmhmThreeToSixDAL();

        public List<KidsTcmhmThreeToSixModel> GetList(string IDCardNo)
        {
            DataSet ds = dal.GetList(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<KidsTcmhmThreeToSixModel> list = ModelConvertHelper<KidsTcmhmThreeToSixModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }
    }

    public class KidsWithinOneYearOldBLL
    {
        private readonly KidsWithinOneYearOldDAL dal = new KidsWithinOneYearOldDAL();

        public List<KidsWithinOneYearOldModel> GetList(string IDCardNo)
        {
            DataSet ds = dal.GetList(IDCardNo);

            if (ds != null && ds.Tables.Count > 0)
            {
                List<KidsWithinOneYearOldModel> list = ModelConvertHelper<KidsWithinOneYearOldModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list;
            }

            return null;
        }
    }
}