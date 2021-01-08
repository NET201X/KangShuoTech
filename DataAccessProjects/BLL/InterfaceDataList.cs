using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public interface InterfaceDataList
    {
        bool Delete(int ID);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        int GetRecordCount(string strWhere);
    }
}
