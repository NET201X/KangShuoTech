using CommonUtilities.SQL;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class AccessClassDAL
    {
        /// <summary>
        /// 取得尿机资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetNJList(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM PersonInfoNJ WHERE Mark='Y' ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得生化资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetBiochemicalList(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM PersonInfoSH WHERE Mark='Y' ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得血球资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetBloodCorpuscleList(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM PersonInfoXQ WHERE Mark='Y' ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得身高体重资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetBaseInfo(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM BaseInfo WHERE Mark='Y' ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得B超资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetTypeBList(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM PatientInfo WHERE jczt = '是' AND sfzh <> '' ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得重庆B超资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetTypeBByChongQing(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM PersonInfoBC WHERE 1=1 ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得安徽X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetChestX(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ChestX WHERE 1=1 ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得视力资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataSet GetVsiual(string strWhere, string conn)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM VisionInfo WHERE 1=1 ");

            if (strWhere.Trim() != "") builder.Append(strWhere);

            return AccessDBUtil.ExecuteQuery(builder.ToString(), conn);
        }

        /// <summary>
        /// 取得Table是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public bool GetTables(string tableName, string conn)
        {
            return AccessDBUtil.GetTables(tableName, conn);
        }
    }
}
