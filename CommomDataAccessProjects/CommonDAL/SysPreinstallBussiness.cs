using CommonUtilities.SQL;
using MySql.Data.MySqlClient;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class SysPreinstallBussiness
    {
        /// <summary>
        /// 获取页签信息 一级菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetTabInfo()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT DISTINCT TabName AS 页签名称 FROM tbl_SysPreinstAll ORDER BY ID ");

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取页签信息 二级菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetComInfo(string TabName)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT DISTINCT Comment AS " + TabName + " FROM tbl_SysPreinstAll WHERE TabName='" + TabName + "' ORDER BY ID ");

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取页签信息 字段信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetChinInfo(string TabName, string ConName)
        {
            StringBuilder sql = new StringBuilder();
            string sqlWhere = "";

            if (TabName != "") sqlWhere = "AND TabName='" + TabName + "' ";

            sql.Append("SELECT OptionName,RemarksCut,TableName,Content,ChinName AS " + ConName + ",ImgPath,Seq,Text,Separa,Width,Height,ID,Type,TabName,Compare FROM tbl_SysPreinstAll ");
            sql.Append("WHERE Comment='" + ConName + "' AND OptionName!='' ");                       
            sql.Append(sqlWhere);

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        public DataTable GetTab()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT DISTINCT TabName FROM tbl_SysPreinstAll");

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        public DataTable GetCom(string Tab)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT DISTINCT Comment FROM tbl_SysPreinstAll WHERE TabName='" + Tab + "'");

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        public DataTable GetCon(string Com)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT DISTINCT ChinName FROM tbl_SysPreinstAll WHERE Comment='" + Com + "'");

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据模块、功能、栏位等信息筛选数据
        /// </summary>
        /// <param name="TabName">模块名称</param>
        /// <param name="Comment">功能名称</param>
        /// <param name="ChinName">栏位信息</param>
        /// <param name="Compare">模板标签名称</param>
        /// <returns></returns>
        public DataTable GetSystemInfo(string TabName, string Comment, string ChinName, string Compare)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * FROM tbl_SysPreinstAll WHERE 1=1");

            if (!string.IsNullOrWhiteSpace(TabName) && TabName != "请选择")
            {
                sql.Append(" AND TabName='" + TabName + "'");
            }
            if (!string.IsNullOrWhiteSpace(Comment) && Comment != "请选择")
            {
                sql.Append(" AND Comment='" + Comment + "'");
            }
            if (!string.IsNullOrWhiteSpace(ChinName) && ChinName != "请选择")
            {
                sql.Append(" AND ChinName='" + ChinName + "'");
            }
            if (!string.IsNullOrWhiteSpace(Compare))
            {
                sql.Append(" AND Compare='" + Compare + "'");
            }

            sql.Append(" ORDER BY TabName,Comment,TableName,OptionName");

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 取得中医标签名称
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetCompare(string where)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT Compare FROM tbl_SysPreinstAll WHERE 1=1 ");

            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(where);
            }

            sql.Append(" ORDER BY TabName,Comment,TableName,Compare");

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 添加系统预设信息
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public int InsertSys(SysPreinstallModel model)
        {
            string sql = @"INSERT INTO tbl_SysPreinstAll
                            ( 
                                TabName
                                ,Comment
                                ,TableName
                                ,OptionName
                                ,ChinName
                                ,Content
                                ,RemarksCut
                                ,Compare
                                ,ImgPath
                                ,Seq
                                ,Text
                                ,Separa
                                ,Height
                                ,Type
                                ,Width
                                ,Col2
                                ,Col3
                            ) 
                            VALUES 
                            ( 
                                @TabName
                                ,@Comment
                                ,@TableName
                                ,@OptionName
                                ,@ChinName
                                ,@Content
                                ,@RemarksCut
                                ,@Compare
                                ,@ImgPath
                                ,@Seq
                                ,@Text
                                ,@Separa
                                ,@Height
                                ,@Type
                                ,@Width
                                ,@Col2
                                ,@Col3
                            ) ;SELECT @@IDENTITY";

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@TabName", MySqlDbType.String, 50),
                 new MySqlParameter("@Comment", MySqlDbType.String, 50),
                 new MySqlParameter("@TableName", MySqlDbType.String, 50),
                 new MySqlParameter("@OptionName", MySqlDbType.String, 50),
                 new MySqlParameter("@ChinName", MySqlDbType.String, 50),
                 new MySqlParameter("@Content", MySqlDbType.String, 255),
                 new MySqlParameter("@RemarksCut", MySqlDbType.String, 50),
                 new MySqlParameter("@Compare", MySqlDbType.String, 50),
                 new MySqlParameter("@ImgPath", MySqlDbType.String, 255),
                 new MySqlParameter("@Seq", MySqlDbType.Int32 ),
                 new MySqlParameter("@Text", MySqlDbType.String, 255),
                 new MySqlParameter("@Separa", MySqlDbType.String, 50),
                 new MySqlParameter("@Height", MySqlDbType.String, 50),
                 new MySqlParameter("@Type", MySqlDbType.String, 2),
                 new MySqlParameter("@Width", MySqlDbType.String, 50),
                 new MySqlParameter("@Col2", MySqlDbType.String, 100),
                 new MySqlParameter("@Col3", MySqlDbType.String, 100)
            };

            cmdParms[0].Value = model.TabName;
            cmdParms[1].Value = model.Comment;
            cmdParms[2].Value = model.TableName;
            cmdParms[3].Value = model.OptionName;
            cmdParms[4].Value = model.ChinName;
            cmdParms[5].Value = model.Content;
            cmdParms[6].Value = model.RemarksCut;
            cmdParms[7].Value = model.Compare;
            cmdParms[8].Value = model.ImgPath;
            cmdParms[9].Value = model.Seq;
            cmdParms[10].Value = model.Text;
            cmdParms[11].Value = model.Separa;
            cmdParms[12].Value = model.Height;
            cmdParms[13].Value = model.Type;
            cmdParms[14].Value = model.Width;
            cmdParms[15].Value = model.Col2;
            cmdParms[16].Value = model.Col3;

            object single = MySQLHelper.GetSingle(sql, cmdParms);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 修改系统预设信息
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public int UpdateSys(SysPreinstallModel model)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"UPDATE tbl_SysPreinstAll 
                         SET 
                            TabName = @TabName 
                            ,Comment = @Comment 
                            ,TableName = @TableName 
                            ,OptionName = @OptionName 
                            ,ChinName = @ChinName 
                            ,Content = @Content 
                            ,Compare = @Compare 
                            ,ImgPath = @ImgPath 
                            ,Width = @Width 
                            ,Height = @Height 
                            ,Seq = @Seq 
                            ,Text = @Text 
                          WHERE ID = @ID");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                 new MySqlParameter("@TabName", MySqlDbType.String, 50),
                 new MySqlParameter("@Comment", MySqlDbType.String, 50),
                 new MySqlParameter("@TableName", MySqlDbType.String, 50),
                 new MySqlParameter("@OptionName", MySqlDbType.String, 50),
                 new MySqlParameter("@ChinName", MySqlDbType.String, 50),
                 new MySqlParameter("@Content", MySqlDbType.String, 255),
                 new MySqlParameter("@Compare", MySqlDbType.String, 255),
                 new MySqlParameter("@ImgPath", MySqlDbType.String, 255),
                 new MySqlParameter("@Width", MySqlDbType.Int32),
                 new MySqlParameter("@Height", MySqlDbType.Int32),
                 new MySqlParameter("@Seq", MySqlDbType.Int32 ),
                 new MySqlParameter("@Text", MySqlDbType.String, 255),
                 new MySqlParameter("@ID", MySqlDbType.Int32)
            };

            cmdParms[0].Value = model.TabName;
            cmdParms[1].Value = model.Comment;
            cmdParms[2].Value = model.TableName;
            cmdParms[3].Value = model.OptionName;
            cmdParms[4].Value = model.ChinName;
            cmdParms[5].Value = model.Content;
            cmdParms[6].Value = model.Compare;
            cmdParms[7].Value = model.ImgPath;
            cmdParms[8].Value = model.Width;
            cmdParms[9].Value = model.Height;
            cmdParms[10].Value = model.Seq;
            cmdParms[11].Value = model.Text;
            cmdParms[12].Value = model.ID;

            return MySQLHelper.ExecuteSql(sql.ToString(), cmdParms);
        }

        public DataTable GetTable(string ID)
        {
            string sql = "SELECT * FROM tbl_SysPreinstAll WHERE ID='" + ID + " '";

            return MySQLHelper.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取数据库名称
        /// </summary>
        /// <returns></returns>
        public string GetTableName(string comment)
        {
            string TableName = "";
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT DISTINCT TableName FROM tbl_SysPreinstAll WHERE Comment='" + comment + "'");

            dt = MySQLHelper.GetDataTable(sql.ToString());

            if (dt.Rows.Count != 0) TableName = dt.Rows[0]["TableName"].ToString();

            return TableName;
        }

        /// <summary>
        /// 获取数据库栏位名称
        /// </summary>
        /// <returns></returns>
        public string GetOptionName(string china, string TableName)
        {
            string OptionName = "";
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT OptionName FROM tbl_SysPreinstAll WHERE TableName='" + TableName + "' AND ChinName='" + china + "'");

            dt = MySQLHelper.GetDataTable(sql.ToString());

            if (dt.Rows.Count != 0) OptionName = dt.Rows[0]["OptionName"].ToString();

            return OptionName;
        }

        /// <summary>
        /// 删除预设数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DelSys(string ID)
        {
            string sql = "DELETE FROM tbl_SysPreinstAll WHERE ID=" + ID;

            return MySQLHelper.ExecuteSql(sql.ToString());
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        public void Insert(string sql)
        {
            MySQLHelper.ExecuteSql(sql);
        }

        public DataTable GetInfo(string sql)
        {
            return MySQLHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 获取临时表的信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfo()
        {
            string sql = "SELECT * FROM WordInfo";

            return MySQLHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 新增word域格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int InsertFormat(string value)
        {
            string sql = "INSERT INTO tbl_format (Value) VALUE('" + value + "')";

            return MySQLHelper.ExecuteSql(sql);
        }

        public DataTable GetFormat()
        {
            string sql = "SELECT Value FROM tbl_format";

            return MySQLHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 根据内容信息删除Word域格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int DelFormat(string value)
        {
            string sql = "DELETE FROM tbl_format WHERE Value='" + value + "'";

            return MySQLHelper.ExecuteSql(sql);
        }

        public DataTable GetHealth(string idCardNo, string checkDate)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("SELECT * FROM ARCHIVE_CUSTOMERBASEINFO Customer ");
            builder.Append(" INNER JOIN ARCHIVE_BASEINFO BaseInfo ");
            builder.Append(" ON BaseInfo.IDCardNo=Customer.IDCardNo ");
            builder.Append(" LEFT JOIN ARCHIVE_GENERALCONDITION General ");
            builder.Append(" ON General.IDCardNo=Customer.IDCardNo ");
            builder.Append(" AND Customer.ID=General.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_LIFESTYLE Life ");
            builder.Append(" ON Life.IDCardNo=Customer.IDCardNo ");
            builder.Append(" AND Customer.ID=Life.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_VISCERAFUNCTION Function ");
            builder.Append(" ON Function.IDCardNo=Customer.IDCardNo ");
            builder.Append(" AND Customer.ID=Function.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_PHYSICALEXAM Physical ");
            builder.Append(" ON Physical.IDCardNo=Customer.IDCardNo ");
            builder.Append(" AND Customer.ID=Physical.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_ASSISTCHECK Checks ");
            builder.Append(" ON Checks.IDCardNo=Customer.IDCardNo ");
            builder.Append(" AND Customer.ID=Checks.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_HEALTHQUESTION Health ");
            builder.Append(" ON Health.IDCardNo=Customer.IDCardNo ");
            builder.Append(" AND Customer.ID=Health.OutKey ");
            builder.Append(" LEFT JOIN ARCHIVE_ASSESSMENTGUIDE Assess ");
            builder.Append(" ON Assess.IDCardNo=Customer.IDCardNo ");
            builder.Append(" AND Customer.ID=Assess.OutKey ");
            builder.Append(" LEFT JOIN ( ");
            builder.Append("    SELECT IDCardNo,Value9 AS LEU,Value8 AS NIT,Value1 AS UBG,Value3 AS BIL,Value10 AS SG,Value7 AS PH,Value11 AS VC FROM ARCHIVE_DEVICEINFO ");
            builder.Append("    WHERE Devicetype='33' ");
            builder.Append("    AND IDCardNo=@IDCardNo ");
            builder.Append("    AND UpdateData LIKE CONCAT(LEFT(@CheckDate, 4), '%') ");
            builder.Append("    ORDER BY UpdateData DESC LIMIT 0,1 ");
            builder.Append(" ) AS Device ");
            builder.Append(" ON Device.IDCardNo=Customer.IDCardNo ");
            builder.Append(" LEFT JOIN ( ");
            builder.Append("    SELECT * FROM ARCHIVE_BLOODTEST ");
            builder.Append("    WHERE IDCardNo=@IDCardNo ");
            builder.Append("    AND TestTime LIKE CONCAT(LEFT(@CheckDate, 4), '%') ");
            builder.Append("    ORDER BY TestTime DESC LIMIT 0,1 ");
            builder.Append(" ) AS Xq ");
            builder.Append(" ON Xq.IDCardNo=Customer.IDCardNo ");
            builder.Append(" WHERE Customer.IDCardNo=@IDCardNo ");

            if (checkDate != "") builder.Append("AND CheckDate=@CheckDate");
            else checkDate = DateTime.Now.ToString("yyyy-MM-dd");

            builder.Append(" ORDER BY CheckDate DESC LIMIT 0,1 ");

            MySqlParameter[] cmdParms = new MySqlParameter[] {
                new MySqlParameter("@IDCardNo", MySqlDbType.String),
                new MySqlParameter("@CheckDate", MySqlDbType.String)
            };

            cmdParms[0].Value = idCardNo;
            cmdParms[1].Value = checkDate;

            return MySQLHelper.GetDataTable(builder.ToString(), cmdParms);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool Exist(string strWhere)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT COUNT(0) FROM tbl_SysPreinstAll WHERE 1=1 ");

            if (!string.IsNullOrEmpty(strWhere)) builder.Append(strWhere);

            return MySQLHelper.Exists(builder.ToString());
        }
    }
}
