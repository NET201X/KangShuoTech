using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class OldMedGuideBLL
    {
      private readonly  OldMedGuideDAL dal = new OldMedGuideDAL();

        public int Add(OldMedGuideModel model)
        {
            return this.dal.Add(model);
        }

        /// <summary>
        /// 中医体质同步存入指导意见
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByUpload(OldMedGuideModel model)
        {
            return this.dal.UpdateByUpload(model);
        }
    }
}
