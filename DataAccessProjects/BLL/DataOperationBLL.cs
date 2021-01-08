using KangShuoTech.DataAccessProjects.DAL;

namespace KangShuoTech.DataAccessProjects.BLL
{
    using System.Collections.Generic;
    using System.Data;
 
    public class DataOperationBLL
    {
        private readonly DataOperationDAL dal = new DataOperationDAL();

        //public void CheckPassword(string pwd)
        //{
        //    this.dal.CheckDBPassword(pwd);
        //}

        //public void ClearDB()
        //{
        //    this.dal.ClearDB();
        //}

        //public void CreateDB(string file)
        //{
        //    this.dal.CreateDB(file);
        //}

        //public void CreateDB(string file, string pwd = null)
        //{
        //    this.dal.CreateDB(file, pwd);
        //}

        public void ExcureTran(List<string> sqls)
        {
            this.dal.ExcureTran(sqls);
        }

        public int ExecuteVoidSql(string sql)
        {
            return this.dal.ExecuteVoidSql(sql);
        }

        public string GetCityName(string cityid)
        {
            return this.dal.GetCity(cityid);
        }

        public DataTable GetStatistics()
        {
            return this.dal.GetStatistics();
        }
        public DataTable GetTimeBucketStatis(string starttime, string endtime, int timebucket)
        {
            return this.dal.GetTimeBucketStatis(starttime,endtime,timebucket);
        }
        //public void SetPassword(string pwd)
        //{
        //    this.dal.SetPassword(pwd);
        //}

        public bool TableExist(string[] tabels)
        {
            return this.dal.TableExist(tabels);
        }

        public bool TruncTabels(string[] tabels)
        {
            return this.dal.TruncTabels(tabels);
        }
    }
}

