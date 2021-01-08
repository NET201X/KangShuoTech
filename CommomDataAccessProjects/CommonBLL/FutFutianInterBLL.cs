using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class FutFutianInterBLL
    {
        private readonly FutFutianInterDAL dal = new FutFutianInterDAL();

        public DataSet GetData(string TJBH, string TJCS)
        {
            return dal.GetData(TJBH, TJCS);
        }

        public DataSet GetTjdjb(string strWhere)
        {
            return dal.GetTjdjb(strWhere);
        }

        public int Save(StringBuilder sql, string IDCardNo)
        {
            return dal.Save(sql, IDCardNo);
        }
    }
}