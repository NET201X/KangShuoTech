using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class RecordsxqBLL
    {
        private readonly RecordsxqDAL dal = new RecordsxqDAL();

        public int AddRow(DataModel model)
        {
            return this.dal.AddRow(model);
        }

        public int AddRowNew(DataModel model)
        {
            return this.dal.AddRowNew(model);
        }

        public DataSet GetData(string strWhere)
        {
            return this.dal.GetData(strWhere);
        }
    }
}
