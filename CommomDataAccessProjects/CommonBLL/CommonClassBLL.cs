using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class CommonClassBLL
    {
        private readonly CommonClassDAL dal = new CommonClassDAL();

        /// <summary>
        /// 拍照更新照片路径
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="photoPath"></param>
        /// <returns></returns>
        public bool Update(string idCardNo, string photoPath)
        {
            return this.dal.Update(idCardNo, photoPath);
        }

        /// <summary>
        /// 拍照清单笔数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 拍照资料清单
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderBy, startIndex, endIndex);
        }

        public DataTable GetData(string conn)
        {
            return dal.GetData(conn);
        }

        public bool Update(string conn, string startDate, string endDate, string dataType, string deviceType, string versionNo,
            string isNewTypeB, string ecgType, string total, string count, string col2, string col3)
        {
            return dal.Update(conn, startDate, endDate, dataType, deviceType, versionNo, isNewTypeB, ecgType, total, count, col2, col3);
        }
    }
}
