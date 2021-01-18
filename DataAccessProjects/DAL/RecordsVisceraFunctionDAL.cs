namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsVisceraFunctionDAL
    {
        public int Add(RecordsVisceraFunctionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_VISCERAFUNCTION(");
            builder.Append("PhysicalID,IDCardNo,Lips,ToothResides,ToothResidesOther,Pharyngeal,LeftView,Listen,RightView,SportFunction,LeftEyecorrect,RightEyecorrect,OutKey,HypodontiaEx,SaprodontiaEx,DentureEx,LipsEx,PharyngealEx )");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@Lips,@ToothResides,@ToothResidesOther,@Pharyngeal,@LeftView,@Listen,@RightView,@SportFunction,@LeftEyecorrect,@RightEyecorrect,@OutKey,@HypodontiaEx,@SaprodontiaEx,@DentureEx,@LipsEx,@PharyngealEx )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Lips", MySqlDbType.String, 1), 
                new MySqlParameter("@ToothResides", MySqlDbType.String, 100), 
                new MySqlParameter("@ToothResidesOther", MySqlDbType.String, 100), 
                new MySqlParameter("@Pharyngeal", MySqlDbType.String, 1), 
                new MySqlParameter("@LeftView", MySqlDbType.Decimal), 
                new MySqlParameter("@Listen", MySqlDbType.String, 1),
                new MySqlParameter("@RightView", MySqlDbType.Decimal), 
                new MySqlParameter("@SportFunction", MySqlDbType.String, 1), 
                new MySqlParameter("@LeftEyecorrect", MySqlDbType.Decimal), 
                new MySqlParameter("@RightEyecorrect", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4),
                new MySqlParameter("@HypodontiaEx", MySqlDbType.String, 100), 
                new MySqlParameter("@SaprodontiaEx", MySqlDbType.String, 100), 
                new MySqlParameter("@DentureEx", MySqlDbType.String, 100),
                new MySqlParameter("@LipsEx", MySqlDbType.String, 100),
                new MySqlParameter("@PharyngealEx", MySqlDbType.String, 100)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Lips;
            cmdParms[3].Value = model.ToothResides;
            cmdParms[4].Value = model.ToothResidesOther;
            cmdParms[5].Value = model.Pharyngeal;
            cmdParms[6].Value = model.LeftView;
            cmdParms[7].Value = model.Listen;
            cmdParms[8].Value = model.RightView;
            cmdParms[9].Value = model.SportFunction;
            cmdParms[10].Value = model.LeftEyecorrect;
            cmdParms[11].Value = model.RightEyecorrect;
            cmdParms[12].Value = model.OutKey;
            cmdParms[13].Value = model.HypodontiaEx;//缺齿
            cmdParms[14].Value = model.SaprodontiaEx;//龋齿
            cmdParms[15].Value = model.DentureEx;//义齿
            cmdParms[16].Value = model.LipsEx;//口唇其他
            cmdParms[17].Value = model.PharyngealEx;//咽部其他
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public int AddServer(RecordsVisceraFunctionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ARCHIVE_VISCERAFUNCTION(");
            builder.Append("PhysicalID,IDCardNo,Lips,ToothResides,ToothResidesOther,Pharyngeal,LeftView,Listen,RightView,SportFunction,LeftEyecorrect,RightEyecorrect,OutKey,HypodontiaEx,SaprodontiaEx,DentureEx,LipsEx,PharyngealEx )");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@Lips,@ToothResides,@ToothResidesOther,@Pharyngeal,@LeftView,@Listen,@RightView,@SportFunction,@LeftEyecorrect,@RightEyecorrect,@OutKey,@HypodontiaEx,@SaprodontiaEx,@DentureEx,@LipsEx,@PharyngealEx )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@Lips", MySqlDbType.String, 1), 
                new MySqlParameter("@ToothResides", MySqlDbType.String, 100), 
                new MySqlParameter("@ToothResidesOther", MySqlDbType.String, 200), 
                new MySqlParameter("@Pharyngeal", MySqlDbType.String, 1), 
                new MySqlParameter("@LeftView", MySqlDbType.Decimal), 
                new MySqlParameter("@Listen", MySqlDbType.String, 1),
                new MySqlParameter("@RightView", MySqlDbType.Decimal), 
                new MySqlParameter("@SportFunction", MySqlDbType.String, 1), 
                new MySqlParameter("@LeftEyecorrect", MySqlDbType.Decimal), 
                new MySqlParameter("@RightEyecorrect", MySqlDbType.Decimal),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4),
                new MySqlParameter("@HypodontiaEx", MySqlDbType.String, 100), 
                new MySqlParameter("@SaprodontiaEx", MySqlDbType.String, 100), 
                new MySqlParameter("@DentureEx", MySqlDbType.String, 100),
                new MySqlParameter("@LipsEx", MySqlDbType.String, 100),
                new MySqlParameter("@PharyngealEx", MySqlDbType.String, 100)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Lips;
            cmdParms[3].Value = model.ToothResides;
            cmdParms[4].Value = model.ToothResidesOther;
            cmdParms[5].Value = model.Pharyngeal;
            cmdParms[6].Value = model.LeftView;
            cmdParms[7].Value = model.Listen;
            cmdParms[8].Value = model.RightView;
            cmdParms[9].Value = model.SportFunction;
            cmdParms[10].Value = model.LeftEyecorrect;
            cmdParms[11].Value = model.RightEyecorrect;
            cmdParms[12].Value = model.OutKey;
            cmdParms[13].Value = model.HypodontiaEx;//缺齿
            cmdParms[14].Value = model.SaprodontiaEx;//龋齿
            cmdParms[15].Value = model.DentureEx;//义齿
            cmdParms[16].Value = model.LipsEx;//口唇其他
            cmdParms[17].Value = model.PharyngealEx;//咽部其他
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsVisceraFunctionModel DataRowToModel(DataRow row)
        {
            RecordsVisceraFunctionModel recordsVisceraFunctionModel = new RecordsVisceraFunctionModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsVisceraFunctionModel.ID = int.Parse(row["ID"].ToString());
                }
                if (((row["OutKey"] != null) && (row["OutKey"] != DBNull.Value)) && (row["OutKey"].ToString() != ""))
                {
                    recordsVisceraFunctionModel.OutKey = int.Parse(row["OutKey"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["Lips"] != null) && (row["Lips"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.Lips = row["Lips"].ToString();
                }
                if ((row["ToothResides"] != null) && (row["ToothResides"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.ToothResides = row["ToothResides"].ToString();
                }
                if ((row["ToothResidesOther"] != null) && (row["ToothResidesOther"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.ToothResidesOther = row["ToothResidesOther"].ToString();
                }
                if ((row["Pharyngeal"] != null) && (row["Pharyngeal"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.Pharyngeal = row["Pharyngeal"].ToString();
                }
                if (((row["LeftView"] != null) && (row["LeftView"] != DBNull.Value)) && (row["LeftView"].ToString() != ""))
                {
                    recordsVisceraFunctionModel.LeftView = new decimal?(decimal.Parse(row["LeftView"].ToString()));
                }
                if ((row["Listen"] != null) && (row["Listen"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.Listen = row["Listen"].ToString();
                }
                if (((row["RightView"] != null) && (row["RightView"] != DBNull.Value)) && (row["RightView"].ToString() != ""))
                {
                    recordsVisceraFunctionModel.RightView = new decimal?(decimal.Parse(row["RightView"].ToString()));
                }
                if ((row["SportFunction"] != null) && (row["SportFunction"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.SportFunction = row["SportFunction"].ToString();
                }
                if (((row["LeftEyecorrect"] != null) && (row["LeftEyecorrect"] != DBNull.Value)) && (row["LeftEyecorrect"].ToString() != ""))
                {
                    recordsVisceraFunctionModel.LeftEyecorrect = new decimal?(decimal.Parse(row["LeftEyecorrect"].ToString()));
                }
                if (((row["RightEyecorrect"] != null) && (row["RightEyecorrect"] != DBNull.Value)) && (row["RightEyecorrect"].ToString() != ""))
                {
                    recordsVisceraFunctionModel.RightEyecorrect = new decimal?(decimal.Parse(row["RightEyecorrect"].ToString()));
                }
                if ((row["HypodontiaEx"] != null) && (row["HypodontiaEx"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.HypodontiaEx = row["HypodontiaEx"].ToString();
                }
                if ((row["DentureEx"] != null) && (row["DentureEx"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.DentureEx = row["DentureEx"].ToString();
                }
                if ((row["SaprodontiaEx"] != null) && (row["SaprodontiaEx"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.SaprodontiaEx = row["SaprodontiaEx"].ToString();
                }
                if ((row["LipsEx"] != null) && (row["LipsEx"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.LipsEx = row["LipsEx"].ToString();
                }
                if ((row["PharyngealEx"] != null) && (row["PharyngealEx"] != DBNull.Value))
                {
                    recordsVisceraFunctionModel.PharyngealEx = row["PharyngealEx"].ToString();
                }
            }
            return recordsVisceraFunctionModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_VISCERAFUNCTION ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ARCHIVE_VISCERAFUNCTION ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_VISCERAFUNCTION");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Lips,ToothResides,ToothResidesOther,Pharyngeal,LeftView,Listen,RightView,SportFunction,LeftEyecorrect,RightEyecorrect,HypodontiaEx,SaprodontiaEx,DentureEx,LipsEx,PharyngealEx,OutKey ");
            builder.Append(" FROM ARCHIVE_VISCERAFUNCTION ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            return MySQLHelper.Query(builder.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT * FROM ( ");
            builder.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                builder.Append(" order by T." + orderby);
            }
            else
            {
                builder.Append(" order by T.ID desc");
            }
            builder.Append(")AS Row, T.*  from ARCHIVE_VISCERAFUNCTION T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE " + strWhere);
            }
            builder.Append(" ) TT");
            builder.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySQLHelper.Query(builder.ToString());
        }

        public int GetMaxId()
        {
            return MySQLHelper.GetMaxID("ID", "ARCHIVE_VISCERAFUNCTION");
        }

        public RecordsVisceraFunctionModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Lips,ToothResides,ToothResidesOther,Pharyngeal,LeftView,Listen,RightView,SportFunction,LeftEyecorrect,RightEyecorrect,HypodontiaEx,SaprodontiaEx,DentureEx,LipsEx,PharyngealEx,OutKey from ARCHIVE_VISCERAFUNCTION ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsVisceraFunctionModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) FROM ARCHIVE_VISCERAFUNCTION ");
            if (strWhere.Trim() != "")
            {
                builder.Append(" where " + strWhere);
            }
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public bool Update(RecordsVisceraFunctionModel model) //ToothResidesOther,LipsEx,PharyngealEx
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_VISCERAFUNCTION set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Lips=@Lips,");
            builder.Append("ToothResides=@ToothResides,");
            builder.Append("Pharyngeal=@Pharyngeal,");
            builder.Append("LeftView=@LeftView,");
            builder.Append("Listen=@Listen,");
            builder.Append("RightView=@RightView,");
            builder.Append("SportFunction=@SportFunction,");
            builder.Append("LeftEyecorrect=@LeftEyecorrect,");
            builder.Append("RightEyecorrect=@RightEyecorrect,");
            builder.Append("HypodontiaEx=@HypodontiaEx,");
            builder.Append("SaprodontiaEx=@SaprodontiaEx,");
            builder.Append("DentureEx=@DentureEx, ");
            builder.Append("ToothResidesOther=@ToothResidesOther, ");
            builder.Append("LipsEx=@LipsEx, ");
            builder.Append("PharyngealEx=@PharyngealEx ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Lips", MySqlDbType.String, 1), 
                new MySqlParameter("@ToothResides", MySqlDbType.String, 100), 
                new MySqlParameter("@Pharyngeal", MySqlDbType.String, 1), 
                new MySqlParameter("@LeftView", MySqlDbType.Decimal), 
                new MySqlParameter("@Listen", MySqlDbType.String, 1), 
                new MySqlParameter("@RightView", MySqlDbType.Decimal), 
                new MySqlParameter("@SportFunction", MySqlDbType.String, 1),
                new MySqlParameter("@LeftEyecorrect", MySqlDbType.Decimal),
                new MySqlParameter("@RightEyecorrect", MySqlDbType.Decimal), 
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8),
                new MySqlParameter( "@HypodontiaEx",MySqlDbType.String ,100),
                new MySqlParameter( "@SaprodontiaEx",MySqlDbType.String ,100),
                new MySqlParameter( "@DentureEx",MySqlDbType.String ,100),
                new MySqlParameter( "@ToothResidesOther",MySqlDbType.String ,100),
                new MySqlParameter( "@LipsEx",MySqlDbType.String ,100),
                new MySqlParameter( "@PharyngealEx",MySqlDbType.String ,100)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Lips;
            cmdParms[3].Value = model.ToothResides;
            cmdParms[4].Value = model.Pharyngeal;
            cmdParms[5].Value = model.LeftView;
            cmdParms[6].Value = model.Listen;
            cmdParms[7].Value = model.RightView;
            cmdParms[8].Value = model.SportFunction;
            cmdParms[9].Value = model.LeftEyecorrect;
            cmdParms[10].Value = model.RightEyecorrect;
            cmdParms[11].Value = model.OutKey;
            cmdParms[12].Value = model.HypodontiaEx;
            cmdParms[13].Value = model.SaprodontiaEx;
            cmdParms[14].Value = model.DentureEx;
            cmdParms[15].Value = model.ToothResidesOther;
            cmdParms[16].Value = model.LipsEx;
            cmdParms[17].Value = model.PharyngealEx;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsVisceraFunctionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ARCHIVE_VISCERAFUNCTION set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("Lips=@Lips,");
            builder.Append("ToothResides=@ToothResides,");
            builder.Append("Pharyngeal=@Pharyngeal,");
            builder.Append("LeftView=@LeftView,");
            builder.Append("Listen=@Listen,");
            builder.Append("RightView=@RightView,");
            builder.Append("SportFunction=@SportFunction,");
            builder.Append("LeftEyecorrect=@LeftEyecorrect,");
            builder.Append("RightEyecorrect=@RightEyecorrect,");
            builder.Append("ToothResidesOther=@ToothResidesOther,");
            builder.Append("HypodontiaEx=@HypodontiaEx,");
            builder.Append("SaprodontiaEx=@SaprodontiaEx,");
            builder.Append("DentureEx=@DentureEx,");
            builder.Append("LipsEx=@LipsEx, ");
            builder.Append("PharyngealEx=@PharyngealEx ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@Lips", MySqlDbType.String, 1), 
                new MySqlParameter("@ToothResides", MySqlDbType.String, 100), 
                new MySqlParameter("@Pharyngeal", MySqlDbType.String, 1), 
                new MySqlParameter("@LeftView", MySqlDbType.Decimal), 
                new MySqlParameter("@Listen", MySqlDbType.String, 1), 
                new MySqlParameter("@RightView", MySqlDbType.Decimal), 
                new MySqlParameter("@SportFunction", MySqlDbType.String, 1),
                new MySqlParameter("@LeftEyecorrect", MySqlDbType.Decimal),
                new MySqlParameter("@RightEyecorrect", MySqlDbType.Decimal), 
                new MySqlParameter( "@ToothResidesOther",MySqlDbType.String ,200),
                new MySqlParameter( "@HypodontiaEx",MySqlDbType.String ,100),
                new MySqlParameter( "@SaprodontiaEx",MySqlDbType.String ,100),
                new MySqlParameter( "@DentureEx",MySqlDbType.String ,100),
                new MySqlParameter( "@LipsEx",MySqlDbType.String ,100),
                new MySqlParameter( "@PharyngealEx",MySqlDbType.String ,100)
               // new MySqlParameter("@ID", MySqlDbType.Int32, 8)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.Lips;
            cmdParms[3].Value = model.ToothResides;
            cmdParms[4].Value = model.Pharyngeal;
            cmdParms[5].Value = model.LeftView;
            cmdParms[6].Value = model.Listen;
            cmdParms[7].Value = model.RightView;
            cmdParms[8].Value = model.SportFunction;
            cmdParms[9].Value = model.LeftEyecorrect;
            cmdParms[10].Value = model.RightEyecorrect;
            cmdParms[11].Value = model.ToothResidesOther;
            cmdParms[12].Value = model.HypodontiaEx;
            cmdParms[13].Value = model.SaprodontiaEx;
            cmdParms[14].Value = model.DentureEx;
            cmdParms[15].Value = model.LipsEx;
            cmdParms[16].Value = model.PharyngealEx;
            //cmdParms[12].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public RecordsVisceraFunctionModel GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,Lips,ToothResides,ToothResidesOther,Pharyngeal,LeftView,Listen,RightView,SportFunction,LeftEyecorrect,RightEyecorrect,HypodontiaEx,SaprodontiaEx,DentureEx,LipsEx,PharyngealEx,OutKey from ARCHIVE_VISCERAFUNCTION ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = OutKey;
            new RecordsVisceraFunctionModel();
            DataSet set = MySQLHelper.Query(builder.ToString(), cmdParms);
            if (set.Tables[0].Rows.Count > 0)
            {
                return this.DataRowToModel(set.Tables[0].Rows[0]);
            }
            return null;
        }
        public bool ExistsOutKey(string IDCardNo, int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from ARCHIVE_VISCERAFUNCTION");
            builder.Append(" where IDCardNo=@IDCardNo ");
            builder.Append(" and OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", MySqlDbType.String) ,
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 4) 
            };
            cmdParms[0].Value = IDCardNo;
            cmdParms[1].Value = OutKey;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }
        public bool UpdateByTJMiniPad(RecordsVisceraFunctionModel model, string checkDate) //体检问询同步
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                    ARCHIVE_VISCERAFUNCTION  D
                             SET 
                                 Lips=@Lips,ToothResides=@ToothResides,Pharyngeal=@Pharyngeal,
                                 Listen=@Listen,SportFunction=@SportFunction,HypodontiaEx=@HypodontiaEx,
                                 SaprodontiaEx=@SaprodontiaEx,DentureEx=@DentureEx 
                             WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                        ARCHIVE_CUSTOMERBASEINFO M
                                        WHERE M.ID = D.OutKey
                                        AND M.IDCardNo = @IDCardNo
                                        AND M.CheckDate = @CheckDate
                                    )
                            ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@CheckDate",checkDate),
                new MySqlParameter("@Lips", model.Lips),
                new MySqlParameter("@ToothResides", model.ToothResides),
                new MySqlParameter("@Pharyngeal", model.Pharyngeal),
                new MySqlParameter("@Listen", model.Listen),
                new MySqlParameter("@SportFunction", model.SportFunction),
                new MySqlParameter("@HypodontiaEx",model.HypodontiaEx),
                new MySqlParameter("@SaprodontiaEx",model.SaprodontiaEx),
                new MySqlParameter("@DentureEx",model.DentureEx)
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

