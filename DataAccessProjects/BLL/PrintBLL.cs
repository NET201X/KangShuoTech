using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;
using System.Data;
using System.Text;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class PrintBLL
    {
        private readonly PrintDAL dal = new PrintDAL();

        /// <summary>
        /// 取得资料
        /// </summary>
        public DataSet GetData(string strWhere)
        {            
            return dal.GetData(strWhere);
        }

        public bool Update(PrintModel model)
        {
            return dal.Update(model);
        }
    }
}
