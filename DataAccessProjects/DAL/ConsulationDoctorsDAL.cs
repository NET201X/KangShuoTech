
namespace KangShuoTech.DataAccessProjects.DAL
{
    using KangShuoTech.Utilities.MySQLHelper;
    using KangShuoTech.DataAccessProjects.Model;
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Text;
    using System.Collections.Generic;

    public class ConsulationDoctorsDAL
    {
        public int Add(List<ConsulationDoctorsModel>model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_consultdoctor(");
            builder.Append("ConsultationUnitName,ConsultationDoctor1,ConsultationDoctor2,ConsultationDoctor3,OutKey)");
            builder.Append("values ");
            foreach (ConsulationDoctorsModel del in model)
            {
                string addstr = string.Format("('{0}','{1}','{2}','{3}',{4}),", del.ConsultationUnitName, del.ConsultationDoctor1, del.ConsultationDoctor2, del.ConsultationDoctor3,del.OutKey);
                builder.Append(addstr);
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(";select @@IDENTITY");
            object single = MySQLHelper.GetSingle(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public int AddServer(List<ConsulationDoctorsModel> model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into tbl_consultdoctor(");
            builder.Append("ConsultationUnitName,ConsultationDoctor1,ConsultationDoctor2,ConsultationDoctor3,OutKey)");
            builder.Append("values ");
            foreach (ConsulationDoctorsModel del in model)
            {
                string addstr = string.Format("('{0}','{1}','{2}','{3}',{4}),", del.ConsultationUnitName, del.ConsultationDoctor1, del.ConsultationDoctor2, del.ConsultationDoctor3, del.OutKey);
                builder.Append(addstr);
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(";select @@IDENTITY");
            object single = MySQLHelper.GetSingleServer(builder.ToString());
            if (single == null)
            {
                return 0;
            }
            return Convert.ToInt32(single);
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ID, ConsultationUnitName,ConsultationDoctor1,ConsultationDoctor2,ConsultationDoctor3 from tbl_consultdoctor ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                builder.Append(" WHERE  " + strWhere);
            }
           return MySQLHelper.Query(builder.ToString());
        }
        public bool Update(List<ConsulationDoctorsModel> model)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update tbl_consultdoctor set ");
          
            string addstr1="";
            string addstr2="";
            string addstr3="";
            string addstr4="";
            string addstrID="";
            foreach (ConsulationDoctorsModel del in model)
            {
                 addstr1 += string.Format(" when {0} then '{1}'",del.ID,del.ConsultationUnitName);
                 addstr2 += string.Format(" when {0} then '{1}'",del.ID,del.ConsultationDoctor1);
                 addstr3 += string.Format(" when {0} then '{1}'",del.ID,del.ConsultationDoctor2);
                 addstr4 += string.Format(" when {0} then '{1}'",del.ID,del.ConsultationDoctor3);
                 addstrID+=del.ID+",";
               
            }
            builder.Append("ConsultationUnitName= case ID ");
            builder.Append(addstr1);
            builder.Append(" END, ");
            builder.Append("ConsultationDoctor1= case ID ");
            builder.Append(addstr2);
            builder.Append(" END, ");
            builder.Append("ConsultationDoctor2= case ID ");
            builder.Append(addstr3);
            builder.Append(" END, ");
            builder.Append("ConsultationDoctor3= case ID ");
            builder.Append(addstr4);
            builder.Append(" END ");
            builder.Append("where ID in ( ");
            builder.Append(addstrID);
            builder.Remove(builder.Length - 1, 1);
            builder.Append(")");
            
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }
        public bool DeleteList(string IDlist)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from tbl_consultdoctor ");
            builder.Append(" where ID in (" + IDlist + ")  ");
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }
    }
}
