

namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    public class RecordsEcgDAL
    {
        public DataSet GetConclusion(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,IDCardNo,Conclusion ");
            builder.Append(" FROM tbl_recordsecg where IDCardNo = '"+IDCardNo+"'  ");
            return MySQLHelper.Query(builder.ToString());
        }
        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT count(*) from ");
            builder.Append(" (select MAX(E.MID)as MID FROM  tbl_recordsecg E left join tbl_recordsbaseinfo T  on T.IDCardNo = E.IDCardNo ");
            builder.Append(" left join tbl_recordscustomerbaseinfo B on E.IDCardNo = B.IDCardNo ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where 1=1 " + strWhere);
            }
            builder.Append(" GROUP BY E.IDCardNo )F ");
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetUserDt(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select T.CreateMenName FROM  tbl_recordsecg E left join tbl_recordsbaseinfo T  on T.IDCardNo = E.IDCardNo ");
            builder.Append("left join tbl_recordscustomerbaseinfo B on E.IDCardNo = B.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }
            builder.Append(" group by T.CreateMenName ");
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select E.IDCardNo,T.CustomerName,T.Sex,T.Nation,T.Birthday,T.Phone,T.HouseHoldAddress,");
            builder.Append("E.Conclusion ,MAX(E.MID)as MID,T.Minority ");
            builder.Append(" from  tbl_recordsecg E left join tbl_recordsbaseinfo T  on T.IDCardNo = E.IDCardNo");
            builder.Append(" left join tbl_recordscustomerbaseinfo B on T.IDCardNo = B.IDCardNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE 1=1 " + strWhere);
            }

            builder.Append(" GROUP BY E.IDCardNo");

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }

            builder.Append(string.Format(" limit {0},{1}", startIndex, endIndex));
            return MySQLHelper.Query(builder.ToString());
        }
        public int GetMIDCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT count(*) from ");
            builder.Append(" (select MAX(E.MID)as MID FROM  tbl_recordsecg E left join tbl_recordsbaseinfo T  on T.IDCardNo = E.IDCardNo ");
            builder.Append(" left join tbl_recordscustomerbaseinfo B on E.IDCardNo = B.IDCardNo ");
            builder.Append(" where MID is not NULL ");
            if (strWhere.Trim() != "")
            {
                builder.Append(string.Format("and E.IDCardNo = '{0}' ", strWhere));
            }
            builder.Append(" GROUP BY E.IDCardNo )F ");
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,MID,IDCardNo,Name,Conclusion,CreateTime");
            builder.Append(" FROM tbl_recordsecg ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public RecordsEcgModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * ");
            builder.Append(" FROM tbl_recordsecg ");
            builder.Append(" where IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsEcgModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public RecordsEcgModel DataRowToModel(DataRow row)
        {
            RecordsEcgModel EcgModel = new RecordsEcgModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    EcgModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["MID"] != null) && (row["MID"] != DBNull.Value))
                {
                    EcgModel.MID = row["MID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    EcgModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Name"] != null) && (row["Name"] != DBNull.Value))
                {
                    EcgModel.Name = row["Name"].ToString();
                }
                if ((row["Conclusion"] != null) && (row["Conclusion"] != DBNull.Value))
                {
                    EcgModel.Conclusion = row["Conclusion"].ToString();
                }
                if ((row["CreateTime"] != null) && (row["CreateTime"] != DBNull.Value))
                {
                    EcgModel.CreateTime = new DateTime?(DateTime.Parse(row["CreateTime"].ToString()));
                }

            }
            return EcgModel;
        }
        public DataSet GetData(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(" SELECT * ");
            builder.Append(" FROM tbl_recordsecg ");
            builder.Append(" WHERE IDCardNo=@IDCardNo");

            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;

            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);

            return set;
        }
        
    }
}
