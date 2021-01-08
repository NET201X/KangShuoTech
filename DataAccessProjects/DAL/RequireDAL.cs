
namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using System.Collections.Generic;

    public class RequireDAL
    {
        public RequireModel DataRowToModel(DataRow row)
        {
            RequireModel RequiredModel = new RequireModel();
            if (row != null)
            {
                if ((row["ID"] != null) && (row["ID"].ToString() != ""))
                {
                    RequiredModel.ID = int.Parse(row["ID"].ToString());
                }

                if (row["TableName"] != null)
                {
                    RequiredModel.TableName = row["TableName"].ToString();
                }

                if (row["OptionName"] != null)
                {
                    RequiredModel.OptionName = row["OptionName"].ToString();
                }
                if (row["ChinName"] != null)
                {
                    RequiredModel.ChinName = row["ChinName"].ToString();
                }
                if (row["Comment"] != null)
                {
                    RequiredModel.Comment = row["Comment"].ToString();
                }
                if ((row["Isrequired"] != null))
                {
                    RequiredModel.Isrequired = row["Isrequired"].ToString();
                }
                if ((row["TabName"] != null))
                {
                    RequiredModel.TabName = row["TabName"].ToString();
                }
                if ((row["SetValue"] != null))
                {
                    RequiredModel.SetValue = row["SetValue"].ToString();
                }
                if ((row["Content"] != null))
                {
                    RequiredModel.Content = row["Content"].ToString();
                }
                if ((row["TypeName"] != null))
                {
                    RequiredModel.TypeName = row["TypeName"].ToString();
                }
                if ((row["ItemValue"] != null))
                {
                    RequiredModel.ItemValue = row["ItemValue"].ToString();
                }
                if ((row["IsDecimalPlace"] != null))
                {
                    RequiredModel.IsDecimalPlace = row["IsDecimalPlace"].ToString();
                }
                if ((row["DecimalPlace"] != null))
                {
                    int i = 0;
                    if (int.TryParse(row["DecimalPlace"].ToString(), out i))
                    {
                        RequiredModel.DecimalPlace = i;
                    }
                    else
                    {
                        RequiredModel.DecimalPlace = 0;
                    }
                }
                if ((row["IsOdevity"] != null))
                {
                    RequiredModel.IsOdevity = row["IsOdevity"].ToString();
                }
            }
            return RequiredModel;
        }

        public RequireModel GetModel(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,TableName,OptionName,ChinName,Comment,Isrequired,TabName,SetValue,Content,TypeName,IsSetValue,ItemValue,IsDecimalPlace,DecimalPlace,IsOdevity ");
            builder.Append(" from tbl_required where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            new RecordsRequiredModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public RequireModel GetModel(string  TabName,string Comment,string ChinName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,TableName,OptionName,ChinName,Comment,Isrequired,TabName,SetValue,Content,TypeName,IsSetValue,ItemValue,IsDecimalPlace,DecimalPlace,IsOdevity ");
            builder.Append(" from tbl_required where TabName=@TabName and Comment=@Comment and ChinName=@ChinName");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@TabName", MySqlDbType.VarChar), new MySqlParameter("@Comment", MySqlDbType.VarChar), new MySqlParameter("@ChinName", MySqlDbType.VarChar) };
            cmdParms[0].Value = TabName;
            cmdParms[1].Value = Comment;
            cmdParms[2].Value = ChinName;
            new RecordsRequiredModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public List<RequireModel> GetModelList()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,TableName,OptionName,ChinName,Comment,Isrequired,TabName,SetValue,Content,TypeName,IsSetValue,ItemValue,IsDecimalPlace,DecimalPlace,IsOdevity ");
            builder.Append(" from tbl_required where 1=1");
           
            List<RequireModel> list = new List<RequireModel>();
            DataSet set = MySQLHelper.Query(builder.ToString());
            foreach(DataRow dr in set.Tables[0].Rows)
            {
                list.Add(this.DataRowToModel(dr));
            }
            return list;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select *  ");
            builder.Append(" FROM tbl_required ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            builder.Append(" order by  TabName,Comment,ChinName ");
            return MySQLHelper.Query(builder.ToString());
        }
        public bool UpdateID(int id, string Isrequired, string SetValue = "", string isSetValue = "", string ItemValue = "")
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_required set ");
            builder.Append("Isrequired=@Isrequired,  ");
            builder.Append("IsSetValue=@IsSetValue, ");
            builder.Append("SetValue=@SetValue,  ");
            builder.Append("ItemValue=@ItemValue ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
              new MySqlParameter("@Isrequired", MySqlDbType.String),
              new MySqlParameter("@IsSetValue",MySqlDbType.String),
              new MySqlParameter("@SetValue", MySqlDbType.String),
              new MySqlParameter("@ItemValue",MySqlDbType.String),
              new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = Isrequired;
            cmdParms[1].Value = isSetValue;
            cmdParms[2].Value = SetValue;
            cmdParms[3].Value = ItemValue;
            cmdParms[4].Value = id;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public bool UpdateID(int id, string Isrequired, string IsDecimalPlace, int DecimalPlace, string IsOdevity, string SetValue, string isSetValue, string ItemValue)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_required set ");
            builder.Append("Isrequired=@Isrequired,  ");
            builder.Append("IsSetValue=@IsSetValue, ");
            builder.Append("SetValue=@SetValue,  ");
            builder.Append("ItemValue=@ItemValue, ");
            builder.Append("IsDecimalPlace=@IsDecimalPlace, ");
            builder.Append("DecimalPlace=@DecimalPlace, ");
            builder.Append("IsOdevity=@IsOdevity ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
              new MySqlParameter("@Isrequired", MySqlDbType.String),
              new MySqlParameter("@IsSetValue",MySqlDbType.String),
              new MySqlParameter("@SetValue", MySqlDbType.String),
              new MySqlParameter("@ItemValue",MySqlDbType.String),
              new MySqlParameter("@ID", MySqlDbType.Int32, 8),
              new MySqlParameter("@IsDecimalPlace",MySqlDbType.String),
              new MySqlParameter("@DecimalPlace",MySqlDbType.Int32),
              new MySqlParameter("@IsOdevity",MySqlDbType.String)
            };
            cmdParms[0].Value = Isrequired;
            cmdParms[1].Value = isSetValue;
            cmdParms[2].Value = SetValue;
            cmdParms[3].Value = ItemValue;
            cmdParms[4].Value = id;
            cmdParms[5].Value = IsDecimalPlace;
            cmdParms[6].Value = DecimalPlace;
            cmdParms[7].Value = IsOdevity;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public void UpdateTable(string TableName, string OptionName, string DecimalPlace)
        {
            if (string.IsNullOrEmpty(DecimalPlace))
            {
                return;
            }
            //获取字段类型
            string SqlgetType = string.Format("select column_name,column_comment,data_type,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE from information_schema.columns where table_name = '{0}' and table_schema = 'qcpaddb' and column_name='{1}'", TableName, OptionName);
            DataTable dt = MySQLHelper.Query(SqlgetType).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //字段类型
                string data_type = dt.Rows[0]["data_type"].ToString();
                //字段长度
                string NUMERIC_PRECISION = dt.Rows[0]["NUMERIC_PRECISION"].ToString();
                //小数位数
                //string NUMERIC_SCALE = dt.Rows[0]["NUMERIC_SCALE"].ToString();
                if (data_type == "decimal")
                {
                    string sql = string.Format("alter table {0} modify column {1} decimal({2}, {3}); ", TableName, OptionName, NUMERIC_PRECISION, DecimalPlace);
                    MySQLHelper.ExecuteSql(sql);
                }
            }

        }
        public bool Update(RequireModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_required set ");
            builder.Append("TableName=@TableName,");
            builder.Append("OptionName=@OptionName,");
            builder.Append("ChinName =@ChinName,");
            builder.Append("Comment=@Comment, ");
            builder.Append("Isrequired=@Isrequired, ");
            builder.Append("TabName=@TabName, ");
            builder.Append("ItemValue=@ItemValue ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@TableName", MySqlDbType.String),
                new MySqlParameter("@OptionName", MySqlDbType.String),
                new MySqlParameter("@ChinName", MySqlDbType.String),
                new MySqlParameter("@Comment", MySqlDbType.String),
                new MySqlParameter("@Isrequired", MySqlDbType.String),
                new MySqlParameter("@TabName", MySqlDbType.String),
                new MySqlParameter("@SetValue", MySqlDbType.String),
                new MySqlParameter("@ItemValue",MySqlDbType.String),
                new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.TableName;
            cmdParms[1].Value = model.OptionName;
            cmdParms[2].Value = model.ChinName;
            cmdParms[3].Value = model.Comment;
            cmdParms[4].Value = model.Isrequired;
            cmdParms[5].Value = model.TabName;
            cmdParms[6].Value = model.SetValue;
            cmdParms[7].Value = model.ItemValue;
            cmdParms[8].Value = model.ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
        public DataSet GetOutBaseInfoDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select concat(format(");
            builder.Append("(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=112 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.Address != '') ");
            builder.Append("+ (select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a WHERE a.ID=113 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.Phone != '' )");
            builder.Append(",'')) as baseinfocount,");
            builder.Append("concat( format(");
            builder.Append("(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=114 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.ContactName != '')");
            builder.Append("+(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=115 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.ContactPhone != '')");
            builder.Append("+(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=116 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.Disease != '') ");
            builder.Append("+(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=117 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.MedicalPayType != '')");
            builder.Append("+(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=118 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.DrugAllergic != '') ");
            builder.Append("+(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=119 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.Exposure != '')");
            builder.Append("+(select count(0) = 0 from tbl_recordsbaseinfo b join tbl_required a where  a.ID=120 and a.Isrequired=1 and b.IDCardNo = '" + strWhere + "' and b.DiseasEndition != '')");
            builder.Append(",'')) as recordinfocount ,");
            builder.Append("concat( format(");
            builder.Append("(select count(0) = 0 from tbl_recordsillnesshistoryinfo b join tbl_recordsbaseinfo c join tbl_required a where  a.ID=121 and a.Isrequired=1 and  c.IDCardNo = b.IDCardNo ");
            builder.Append("and c.IDCardNo = '" + strWhere + "' and ( b.IllnessType != '' or ((select count(*) from tbl_recordsillnesshistoryinfo) = 0)))");
            builder.Append("+(select count(0) = 0 from tbl_recordsenvironment b join tbl_recordsbaseinfo c join tbl_required a where  a.ID=122 and a.Isrequired=1 and  c.IDCardNo = b.IDCardNo ");
            builder.Append("and c.IDCardNo = '" + strWhere + "' and ( b.BlowMeasure != '' or ((select count(*) from tbl_recordsenvironment) = 0)))");
            builder.Append("+(select count(0) = 0 from tbl_recordsenvironment b  join tbl_recordsbaseinfo c join tbl_required a where  a.ID=123 and a.Isrequired=1 and  c.IDCardNo = b.IDCardNo ");
            builder.Append("and c.IDCardNo = '" + strWhere + "' and ( b.FuelType != '' or ((select count(*) from tbl_recordsenvironment) = 0))) ");
            builder.Append("+(select count(0) = 0 from tbl_recordsenvironment b join tbl_recordsbaseinfo c join tbl_required a where  a.ID=124 and a.Isrequired=1 and  c.IDCardNo = b.IDCardNo ");
            builder.Append("and c.IDCardNo = '" + strWhere + "' and ( b.DrinkWater != '' or ((select count(*) from tbl_recordsenvironment) = 0)))");
            builder.Append("+(select count(0) = 0 from tbl_recordsenvironment b join tbl_recordsbaseinfo c join tbl_required a where  a.ID=125 and a.Isrequired=1 and  c.IDCardNo = b.IDCardNo ");
            builder.Append("and c.IDCardNo = '" + strWhere + "' and ( b.Toilet != '' or ((select count(*) from tbl_recordsenvironment) = 0)))");
            builder.Append("+(select count(0) = 0 from tbl_recordsenvironment b  join tbl_recordsbaseinfo c join tbl_required a where  a.ID=126 and a.Isrequired=1 and  c.IDCardNo = b.IDCardNo ");
            builder.Append("and c.IDCardNo = '" + strWhere + "' and ( b.LiveStockRail != '' or ((select count(*) from tbl_recordsenvironment) = 0)))");
            builder.Append(",'')) as healthinfocount ");
            return MySQLHelper.Query(builder.ToString());
        }
        public DataSet GetTabName()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT TabName  FROM tbl_required  ");
            builder.Append(" GROUP BY TabName ");
            return MySQLHelper.Query(builder.ToString());
        }
        public DataSet GetComment()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT TabName,Comment  FROM tbl_required  ");
            builder.Append(" GROUP BY Comment ");
            return MySQLHelper.Query(builder.ToString());
        }
    }
}
