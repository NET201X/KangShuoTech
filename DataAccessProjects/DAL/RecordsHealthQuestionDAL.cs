namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;

    public class RecordsHealthQuestionDAL
    {
        public int Add(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordshealthquestion(");
            builder.Append("PhysicalID,IDCardNo,BrainDis,RenalDis,HeartDis,VesselDis,EyeDis,NerveDis,ElseDis,BrainOther,RenalOther,HeartOther,VesselOther,EyeOther,NerveOther,ElseOther,OutKey )");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@BrainDis,@RenalDis,@HeartDis,@VesselDis,@EyeDis,@NerveDis,@ElseDis,@BrainOther,@RenalOther,@HeartOther,@VesselOther,@EyeOther,@NerveOther,@ElseOther,@OutKey )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@BrainDis", MySqlDbType.String, 30), 
                new MySqlParameter("@RenalDis", MySqlDbType.String, 30),
                new MySqlParameter("@HeartDis", MySqlDbType.String, 30),
                new MySqlParameter("@VesselDis", MySqlDbType.String, 20),
                new MySqlParameter("@EyeDis", MySqlDbType.String, 20),
                new MySqlParameter("@NerveDis", MySqlDbType.String, 100), 
                new MySqlParameter("@ElseDis", MySqlDbType.String, 100), 
                new MySqlParameter("@BrainOther", MySqlDbType.String, 500),
                new MySqlParameter("@RenalOther", MySqlDbType.String, 500), 
                new MySqlParameter("@HeartOther", MySqlDbType.String, 500),
                new MySqlParameter("@VesselOther", MySqlDbType.String, 500), 
                new MySqlParameter("@EyeOther", MySqlDbType.String, 500), 
                new MySqlParameter("@NerveOther", MySqlDbType.String, 500), 
                new MySqlParameter("@ElseOther", MySqlDbType.String, 500),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BrainDis;
            cmdParms[3].Value = model.RenalDis;
            cmdParms[4].Value = model.HeartDis;
            cmdParms[5].Value = model.VesselDis;
            cmdParms[6].Value = model.EyeDis;
            cmdParms[7].Value = model.NerveDis;
            cmdParms[8].Value = model.ElseDis;
            cmdParms[9].Value = model.BrainOther;
            cmdParms[10].Value = model.RenalOther;
            cmdParms[11].Value = model.HeartOther;
            cmdParms[12].Value = model.VesselOther;
            cmdParms[13].Value = model.EyeOther;
            cmdParms[14].Value = model.NerveOther;
            cmdParms[15].Value = model.ElseOther;
            cmdParms[16].Value = model.OutKey;
            object single = MySQLHelper.GetSingle(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
     
        public int AddServer(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_recordshealthquestion(");
            builder.Append("PhysicalID,IDCardNo,BrainDis,RenalDis,HeartDis,VesselDis,EyeDis,NerveDis,ElseDis,BrainOther,RenalOther,HeartOther,VesselOther,EyeOther,NerveOther,ElseOther,OutKey )");
            builder.Append(" values (");
            builder.Append("@PhysicalID,@IDCardNo,@BrainDis,@RenalDis,@HeartDis,@VesselDis,@EyeDis,@NerveDis,@ElseDis,@BrainOther,@RenalOther,@HeartOther,@VesselOther,@EyeOther,@NerveOther,@ElseOther,@OutKey )");
            builder.Append(";select @@IDENTITY");
            MySqlParameter[] cmdParms = new MySqlParameter[]
            {
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8),
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21), 
                new MySqlParameter("@BrainDis", MySqlDbType.String, 30), 
                new MySqlParameter("@RenalDis", MySqlDbType.String, 30),
                new MySqlParameter("@HeartDis", MySqlDbType.String, 30),
                new MySqlParameter("@VesselDis", MySqlDbType.String, 20),
                new MySqlParameter("@EyeDis", MySqlDbType.String, 20),
                new MySqlParameter("@NerveDis", MySqlDbType.String, 100), 
                new MySqlParameter("@ElseDis", MySqlDbType.String, 100), 
                new MySqlParameter("@BrainOther", MySqlDbType.String, 500),
                new MySqlParameter("@RenalOther", MySqlDbType.String, 500), 
                new MySqlParameter("@HeartOther", MySqlDbType.String, 500),
                new MySqlParameter("@VesselOther", MySqlDbType.String, 500), 
                new MySqlParameter("@EyeOther", MySqlDbType.String, 500), 
                new MySqlParameter("@NerveOther", MySqlDbType.String, 500), 
                new MySqlParameter("@ElseOther", MySqlDbType.String, 500),
                new MySqlParameter("@OutKey", MySqlDbType.Int32,4)
            };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BrainDis;
            cmdParms[3].Value = model.RenalDis;
            cmdParms[4].Value = model.HeartDis;
            cmdParms[5].Value = model.VesselDis;
            cmdParms[6].Value = model.EyeDis;
            cmdParms[7].Value = model.NerveDis;
            cmdParms[8].Value = model.ElseDis;
            cmdParms[9].Value = model.BrainOther;
            cmdParms[10].Value = model.RenalOther;
            cmdParms[11].Value = model.HeartOther;
            cmdParms[12].Value = model.VesselOther;
            cmdParms[13].Value = model.EyeOther;
            cmdParms[14].Value = model.NerveOther;
            cmdParms[15].Value = model.ElseOther;
            cmdParms[16].Value = model.OutKey;
            object single = MySQLHelper.GetSingleServer(builder.ToString(), cmdParms);
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }

        public RecordsHealthQuestionModel DataRowToModel(DataRow row)
        {
            RecordsHealthQuestionModel recordsHealthQuestionModel = new RecordsHealthQuestionModel();
            if (row != null)
            {
                if (((row["ID"] != null) && (row["ID"] != DBNull.Value)) && (row["ID"].ToString() != ""))
                {
                    recordsHealthQuestionModel.ID = int.Parse(row["ID"].ToString());
                }
                if ((row["PhysicalID"] != null) && (row["PhysicalID"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.PhysicalID = row["PhysicalID"].ToString();
                }
                if ((row["IDCardNo"] != null) && (row["IDCardNo"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.IDCardNo = row["IDCardNo"].ToString();
                }
                if ((row["BrainDis"] != null) && (row["BrainDis"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.BrainDis = row["BrainDis"].ToString();
                }
                if ((row["RenalDis"] != null) && (row["RenalDis"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.RenalDis = row["RenalDis"].ToString();
                }
                if ((row["HeartDis"] != null) && (row["HeartDis"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.HeartDis = row["HeartDis"].ToString();
                }
                if ((row["VesselDis"] != null) && (row["VesselDis"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.VesselDis = row["VesselDis"].ToString();
                }
                if ((row["EyeDis"] != null) && (row["EyeDis"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.EyeDis = row["EyeDis"].ToString();
                }
                if ((row["NerveDis"] != null) && (row["NerveDis"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.NerveDis = row["NerveDis"].ToString();
                }
                if ((row["ElseDis"] != null) && (row["ElseDis"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.ElseDis = row["ElseDis"].ToString();
                }
                if ((row["BrainOther"] != null) && (row["BrainOther"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.BrainOther = row["BrainOther"].ToString();
                }
                if ((row["RenalOther"] != null) && (row["RenalOther"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.RenalOther = row["RenalOther"].ToString();
                }
                if ((row["HeartOther"] != null) && (row["HeartOther"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.HeartOther = row["HeartOther"].ToString();
                }
                if ((row["VesselOther"] != null) && (row["VesselOther"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.VesselOther = row["VesselOther"].ToString();
                }
                if ((row["EyeOther"] != null) && (row["EyeOther"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.EyeOther = row["EyeOther"].ToString();
                }
                if ((row["NerveOther"] != null) && (row["NerveOther"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.NerveOther = row["NerveOther"].ToString();
                }
                if ((row["ElseOther"] != null) && (row["ElseOther"] != DBNull.Value))
                {
                    recordsHealthQuestionModel.ElseOther = row["ElseOther"].ToString();
                }
            }

            return recordsHealthQuestionModel;
        }

        public bool Delete(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordshealthquestion ");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_recordshealthquestion ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }

        public bool Exists(int ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(1) from tbl_recordshealthquestion");
            builder.Append(" where ID=@ID");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@ID", MySqlDbType.Int32, 4) };
            cmdParms[0].Value = ID;
            return MySQLHelper.Exists(builder.ToString(), cmdParms);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,BrainDis,RenalDis,HeartDis,VesselDis,EyeDis,NerveDis,ElseDis,BrainOther,RenalOther,HeartOther,VesselOther,EyeOther,NerveOther,ElseOther  ");
            builder.Append(" FROM tbl_recordshealthquestion ");
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
            builder.Append(")AS Row, T.*  from tbl_recordshealthquestion T ");
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
            return MySQLHelper.GetMaxID("ID", "tbl_recordshealthquestion");
        }

        public RecordsHealthQuestionModel GetModel(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,BrainDis,RenalDis,HeartDis,VesselDis,EyeDis,NerveDis,ElseDis,BrainOther,RenalOther,HeartOther,VesselOther,EyeOther,NerveOther,ElseOther  from tbl_recordshealthquestion ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@IDCardNo", MySqlDbType.String) };
            cmdParms[0].Value = IDCardNo;
            new RecordsHealthQuestionModel();
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
            builder.Append("select count(1) FROM tbl_recordshealthquestion ");
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

        public DataSet GetXZXGdt(string IDCardNo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select IDCardNo,HeartDis,VesselDis ");
            builder.Append(" FROM tbl_recordshealthquestion where IDCardNo = '"+IDCardNo+"' ");
            return MySQLHelper.Query(builder.ToString());
        }

        public bool Update(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordshealthquestion set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("BrainDis=@BrainDis,");
            builder.Append("RenalDis=@RenalDis,");
            builder.Append("HeartDis=@HeartDis,");
            builder.Append("VesselDis=@VesselDis,");
            builder.Append("EyeDis=@EyeDis,");
            builder.Append("NerveDis=@NerveDis,");
            builder.Append("ElseDis=@ElseDis,");
            builder.Append("BrainOther=@BrainOther,");
            builder.Append("RenalOther=@RenalOther,");
            builder.Append("HeartOther=@HeartOther,");
            builder.Append("VesselOther=@VesselOther,");
            builder.Append("EyeOther=@EyeOther,");
            builder.Append("NerveOther=@NerveOther,");
            builder.Append("ElseOther=@ElseOther ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@BrainDis", MySqlDbType.String, 30), 
                new MySqlParameter("@RenalDis", MySqlDbType.String, 30),
                new MySqlParameter("@HeartDis", MySqlDbType.String, 30),
                new MySqlParameter("@VesselDis", MySqlDbType.String, 20),
                new MySqlParameter("@EyeDis", MySqlDbType.String, 20),
                new MySqlParameter("@NerveDis", MySqlDbType.String, 100), 
                new MySqlParameter("@ElseDis", MySqlDbType.String, 100), 
                new MySqlParameter("@BrainOther", MySqlDbType.String, 500),
                new MySqlParameter("@RenalOther", MySqlDbType.String, 500),
                new MySqlParameter("@HeartOther", MySqlDbType.String, 500),
                new MySqlParameter("@VesselOther", MySqlDbType.String, 500),
                new MySqlParameter("@EyeOther", MySqlDbType.String, 500),
                new MySqlParameter("@NerveOther", MySqlDbType.String, 500),
                new MySqlParameter("@ElseOther", MySqlDbType.String, 500), 
                new MySqlParameter("@OutKey", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BrainDis;
            cmdParms[3].Value = model.RenalDis;
            cmdParms[4].Value = model.HeartDis;
            cmdParms[5].Value = model.VesselDis;
            cmdParms[6].Value = model.EyeDis;
            cmdParms[7].Value = model.NerveDis;
            cmdParms[8].Value = model.ElseDis;
            cmdParms[9].Value = model.BrainOther;
            cmdParms[10].Value = model.RenalOther;
            cmdParms[11].Value = model.HeartOther;
            cmdParms[12].Value = model.VesselOther;
            cmdParms[13].Value = model.EyeOther;
            cmdParms[14].Value = model.NerveOther;
            cmdParms[15].Value = model.ElseOther;
            cmdParms[16].Value = model.OutKey;
            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }

        public bool UpdateServer(RecordsHealthQuestionModel model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_recordshealthquestion set ");
            builder.Append("PhysicalID=@PhysicalID,");
            builder.Append("IDCardNo=@IDCardNo,");
            builder.Append("BrainDis=@BrainDis,");
            builder.Append("RenalDis=@RenalDis,");
            builder.Append("HeartDis=@HeartDis,");
            builder.Append("VesselDis=@VesselDis,");
            builder.Append("EyeDis=@EyeDis,");
            builder.Append("NerveDis=@NerveDis,");
            builder.Append("ElseDis=@ElseDis,");
            builder.Append("BrainOther=@BrainOther,");
            builder.Append("RenalOther=@RenalOther,");
            builder.Append("HeartOther=@HeartOther,");
            builder.Append("VesselOther=@VesselOther,");
            builder.Append("EyeOther=@EyeOther,");
            builder.Append("NerveOther=@NerveOther,");
            builder.Append("ElseOther=@ElseOther ");
            builder.Append(" where IDCardNo=@IDCardNo");
            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@PhysicalID", MySqlDbType.String, 8), 
                new MySqlParameter("@IDCardNo", MySqlDbType.String, 21),
                new MySqlParameter("@BrainDis", MySqlDbType.String, 30), 
                new MySqlParameter("@RenalDis", MySqlDbType.String, 30),
                new MySqlParameter("@HeartDis", MySqlDbType.String, 30),
                new MySqlParameter("@VesselDis", MySqlDbType.String, 20),
                new MySqlParameter("@EyeDis", MySqlDbType.String, 20),
                new MySqlParameter("@NerveDis", MySqlDbType.String, 100), 
                new MySqlParameter("@ElseDis", MySqlDbType.String, 100), 
                new MySqlParameter("@BrainOther", MySqlDbType.String, 500),
                new MySqlParameter("@RenalOther", MySqlDbType.String, 500),
                new MySqlParameter("@HeartOther", MySqlDbType.String, 500),
                new MySqlParameter("@VesselOther", MySqlDbType.String, 500),
                new MySqlParameter("@EyeOther", MySqlDbType.String, 500),
                new MySqlParameter("@NerveOther", MySqlDbType.String, 500),
                new MySqlParameter("@ElseOther", MySqlDbType.String, 500), 
                //new MySqlParameter("@ID", MySqlDbType.Int32, 8)
             };
            cmdParms[0].Value = model.PhysicalID;
            cmdParms[1].Value = model.IDCardNo;
            cmdParms[2].Value = model.BrainDis;
            cmdParms[3].Value = model.RenalDis;
            cmdParms[4].Value = model.HeartDis;
            cmdParms[5].Value = model.VesselDis;
            cmdParms[6].Value = model.EyeDis;
            cmdParms[7].Value = model.NerveDis;
            cmdParms[8].Value = model.ElseDis;
            cmdParms[9].Value = model.BrainOther;
            cmdParms[10].Value = model.RenalOther;
            cmdParms[11].Value = model.HeartOther;
            cmdParms[12].Value = model.VesselOther;
            cmdParms[13].Value = model.EyeOther;
            cmdParms[14].Value = model.NerveOther;
            cmdParms[15].Value = model.ElseOther;

            //cmdParms[16].Value = model.ID;
            return (MySQLHelper.ExecuteSqlServer(builder.ToString(), cmdParms) > 0);
        }
        public RecordsHealthQuestionModel GetModelByOutKey(int OutKey)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID,PhysicalID,IDCardNo,BrainDis,RenalDis,HeartDis,VesselDis,EyeDis,NerveDis,ElseDis,BrainOther,RenalOther,HeartOther,VesselOther,EyeOther,NerveOther,ElseOther  from tbl_recordshealthquestion ");
            builder.Append(" where OutKey=@OutKey");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@OutKey", MySqlDbType.Int32,4) };
            cmdParms[0].Value = OutKey;
            new RecordsHealthQuestionModel();
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
            builder.Append("select count(1) from tbl_recordshealthquestion");
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
        public bool UpdateByTJMiniPad(RecordsHealthQuestionModel model, string checkDate) //体检问询同步
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"UPDATE 
                                    tbl_recordshealthquestion  D
                             SET 
                                 BrainDis=@BrainDis,RenalDis=@RenalDis,HeartDis=@HeartDis,
                                 VesselDis=@VesselDis,EyeDis=@EyeDis,NerveDis=@NerveDis,
                                 ElseDis=@ElseDis,BrainOther=@BrainOther,RenalOther=@RenalOther,
                                 HeartOther=@HeartOther,VesselOther=@VesselOther,EyeOther=@EyeOther,
                                 NerveOther=@NerveOther,ElseOther=@ElseOther 
                             WHERE
                                    EXISTS
                                    (
                                        SELECT 
                                            ID 
                                        FROM
                                        tbl_recordscustomerbaseinfo M
                                        WHERE M.ID = D.OutKey
                                        AND M.IDCardNo = @IDCardNo
                                        AND M.CheckDate = @CheckDate
                                    )
                            ");

            MySqlParameter[] cmdParms = new MySqlParameter[] { 
                new MySqlParameter("@IDCardNo", model.IDCardNo),
                new MySqlParameter("@CheckDate",checkDate),
                new MySqlParameter("@BrainDis", model.BrainDis),
                new MySqlParameter("@RenalDis", model.RenalDis),
                new MySqlParameter("@HeartDis", model.HeartDis),
                new MySqlParameter("@VesselDis", model.VesselDis),
                new MySqlParameter("@EyeDis", model.EyeDis),
                new MySqlParameter("@NerveDis", model.NerveDis),
                new MySqlParameter("@ElseDis", model.ElseDis),
                new MySqlParameter("@BrainOther", model.BrainOther),
                new MySqlParameter("@RenalOther", model.RenalOther),
                new MySqlParameter("@HeartOther", model.HeartOther),
                new MySqlParameter("@VesselOther", model.VesselOther),
                new MySqlParameter("@EyeOther", model.EyeOther),
                new MySqlParameter("@NerveOther", model.NerveOther),
                new MySqlParameter("@ElseOther", model.ElseOther)
 
             };

            return (MySQLHelper.ExecuteSql(builder.ToString(), cmdParms) > 0);
        }
    }
}

