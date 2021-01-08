using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class AccessClassBLL
    {
        private readonly AccessClassDAL dal = new AccessClassDAL();

        /// <summary>
        /// 取得尿机资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetNJList(string strWhere, string conn)
        {
            return this.dal.GetNJList(strWhere, conn);
        }

        /// <summary>
        /// 取得生化资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetBiochemicalList(string strWhere, string conn)
        {
            return this.dal.GetBiochemicalList(strWhere, conn);
        }

        /// <summary>
        /// 取得血球资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetBloodCorpuscleList(string strWhere, string conn)
        {
            return this.dal.GetBloodCorpuscleList(strWhere, conn);
        }

        /// <summary>
        /// 取得身高体重资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetBaseInfo(string strWhere, string conn)
        {
            return this.dal.GetBaseInfo(strWhere, conn);
        }

        /// <summary>
        /// 取得B超资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetTypeBList(string strWhere, string conn)
        {
            return this.dal.GetTypeBList(strWhere, conn);
        }

        /// <summary>
        /// 取得重庆B超资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetTypeBByChongQing(string strWhere, string conn)
        {
            return this.dal.GetTypeBByChongQing(strWhere, conn);
        }

        /// <summary>
        /// 取得安徽X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetChestX(string strWhere, string conn)
        {
            return this.dal.GetChestX(strWhere, conn);
        }

        /// <summary>
        /// 取得视力资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetVsiual(string strWhere, string conn)
        {
            return this.dal.GetVsiual(strWhere, conn);
        }

        /// <summary>
        /// 取得Table是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public bool GetTables(string tableName, string conn)
        {
            return this.dal.GetTables(tableName, conn);
        }
    }
}
