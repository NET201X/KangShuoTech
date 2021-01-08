namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using CommonModel;
    using CommonUtilities.SQL;

    public class CodeBaseDAL
    {
        /// <summary>
        /// 获取代码类别
        /// </summary>
        /// <returns></returns>
        public DataSet GetCategory(bool bIncludeNo = false)
        {
            StringBuilder builder = new StringBuilder();
            
            builder.AppendFormat(@"
                        SELECT 
    		                DISTINCT 
                            CodeNo
                    	    ,{0} AS CodeName
                    	    ,CASE WHEN Category='Z' THEN '0' ELSE Category END AS CategoryOrder
                        FROM
                            tbl_CodeBase 
                        WHERE 
                            Category = 'Z'
                        ORDER BY 
                            CodeSeq", bIncludeNo ? "CodeNo + ' ' + CodeName" : "CodeName");

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 获取代码档-编辑
        /// </summary>
        /// <returns></returns>
        public DataSet GetCodeBase(int ID)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"SELECT * FROM tbl_CodeBase WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", ID) };

            return MySQLHelper.Query(builder.ToString(), cmdParms);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(1) FROM tbl_CodeBase ");

            if (strWhere.Trim() != "") builder.Append(" WHERE 1=1 " + strWhere);

            object single = MySQLHelper.GetSingle(builder.ToString());

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT ID,Category,CodeNo,CodeSeq,CodeName,CodeRemark, ");
            builder.Append(" CASE WHEN CodeValue = 0 THEN '' ELSE CodeValue END AS  CodeValue, ");
            builder.Append(" CreateBy,CreateDate,UpdateBy,UpdateDate ");
            builder.Append(" FROM tbl_CodeBase ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" ORDER BY " + orderby);
            }
            else
            {
                builder.Append(" ORDER BY ID ");
            }

            builder.Append(string.Format(" LIMIT {0},{1}", startIndex, endIndex));

            return MySQLHelper.Query(builder.ToString());
        }

        /// <summary>
        /// 判断代码类别、代码是否已存在-修改去掉本身
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(CodeBaseModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT COUNT(1) FROM tbl_CodeBase");
            builder.Append(" WHERE Category=@Category");
            builder.Append(" AND CodeNo=@CodeNo");
            builder.Append(" AND ID<>@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Category", MySqlDbType.String) ,
                new MySqlParameter("@CodeNo", MySqlDbType.String) ,
                new MySqlParameter("@ID", MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.Category;
            cmdParms[1].Value = model.CodeNo;
            cmdParms[2].Value = model.ID;

            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public int Insert(CodeBaseModel model)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("INSERT INTO tbl_CodeBase(");
            builder.Append("Category,CodeNo,CodeName,CodeSeq,CodeRemark,CodeValue,CreateBy,CreateDate,UpdateBy,UpdateDate)");
            builder.Append(" VALUES (");
            builder.Append("@Category,@CodeNo,@CodeName,@CodeSeq,@CodeRemark,@CodeValue,@CreateBy,NOW(),@UpdateBy,NOW())");
            builder.Append(";SELECT @@IDENTITY");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Category", MySqlDbType.String),
                new MySqlParameter("@CodeNo", MySqlDbType.String),
                new MySqlParameter("@CodeName", MySqlDbType.String),
                new MySqlParameter("@CodeSeq", MySqlDbType.Int32),
                new MySqlParameter("@CodeRemark", MySqlDbType.String),
                new MySqlParameter("@CodeValue", MySqlDbType.Int32),
                new MySqlParameter("@CreateBy", MySqlDbType.String),
                new MySqlParameter("@UpdateBy", MySqlDbType.String)
             };

            cmdParms[0].Value = model.Category;
            cmdParms[1].Value = model.CodeNo;
            cmdParms[2].Value = model.CodeName;
            cmdParms[3].Value = model.CodeSeq;
            cmdParms[4].Value = model.CodeRemark;
            cmdParms[5].Value = model.CodeValue;
            cmdParms[6].Value = model.CreateBy;
            cmdParms[7].Value = model.UpdateBy;

            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        public bool Update(CodeBaseModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE tbl_CodeBase SET ");
            builder.Append("Category=@Category,");
            builder.Append("CodeNo=@CodeNo,");
            builder.Append("CodeName=@CodeName,");
            builder.Append("CodeSeq=@CodeSeq,");
            builder.Append("CodeRemark=@CodeRemark,");
            builder.Append("CodeValue=@CodeValue,");
            builder.Append("UpdateBy=@UpdateBy,");
            builder.Append("UpdateDate=NOW()");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@Category", MySqlDbType.String),
                new MySqlParameter("@CodeNo", MySqlDbType.String),
                new MySqlParameter("@CodeName", MySqlDbType.String),
                new MySqlParameter("@CodeSeq", MySqlDbType.Int32),
                new MySqlParameter("@CodeRemark", MySqlDbType.String),
                new MySqlParameter("@CodeValue", MySqlDbType.Int32),
                new MySqlParameter("@UpdateBy", MySqlDbType.String),
                new MySqlParameter("@ID", MySqlDbType.Int32)
             };

            cmdParms[0].Value = model.Category;
            cmdParms[1].Value = model.CodeNo;
            cmdParms[2].Value = model.CodeName;
            cmdParms[3].Value = model.CodeSeq;
            cmdParms[4].Value = model.CodeRemark;
            cmdParms[5].Value = model.CodeValue;
            cmdParms[6].Value = model.UpdateBy;
            cmdParms[7].Value = model.ID;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 删除选中代码
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" DELETE FROM tbl_CodeBase ");
            builder.Append(" WHERE ID=@ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32) };
            cmdParms[0].Value = ID;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 删除选中代码下所有子类
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteSub(string codeNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" DELETE FROM tbl_CodeBase ");
            builder.Append(" WHERE Category=@CodeNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@CodeNo", MySqlDbType.String) };
            cmdParms[0].Value = codeNo;

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        /// <summary>
        /// 取得代码档选项资料
        /// </summary>
        /// <param name="pCategory">代码类别</param>
        /// <param name="bIncludeNo">是否包含选项</param>
        /// <returns></returns>
        public DataSet GetCodeBaseByCategory(string pCategory, bool bIncludeNo = false)
        {
            StringBuilder sql = new StringBuilder();

            // 查詢Sql
            sql.AppendFormat(@"
                        SELECT 
    		                DISTINCT 
                            CodeNo
                    	    ,{0} AS CodeName
                        FROM
                            tbl_CodeBase 
                        WHERE 
                            Category = @Category
                        ORDER BY 
                            CodeSeq", bIncludeNo ? "CodeNo + ' ' + CodeName" : "CodeName");
            
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@Category", pCategory) };
            
            return MySQLHelper.Query(sql.ToString(), cmdParms);
        }
    }
}
