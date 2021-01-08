using KangShuoTech.Utilities.MySQLHelper;

namespace KangShuoTech.DataAccessProjects.DAL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public class DataOperationDAL
    {
        private void addrow(DataTable dta, DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dta.Rows.Add(dtb.Rows[0].ItemArray);
            }
        }

        //public void CheckDBPassword(string pwd)
        //{
        //    MySQLHelper.CheckPassword(pwd);
        //}

        //public void ClearDB()
        //{
        //    ArrayList sQLStringList = new ArrayList();
        //    sQLStringList.Add("delete from ARCHIVE_ASSESSMENTGUIDE");
        //    sQLStringList.Add("delete from ARCHIVE_ASSISTCHECK");
        //    sQLStringList.Add("delete from ARCHIVE_CUSTOMERBASEINFO");
        //    sQLStringList.Add("delete from ARCHIVE_FAMILYBEDHISTORY");
        //    sQLStringList.Add("delete from ARCHIVE_GENERALCONDITION");
        //    sQLStringList.Add("delete from ARCHIVE_HEALTHQUESTION");
        //    sQLStringList.Add("delete from ARCHIVE_HOSPITALHISTORY");
        //    sQLStringList.Add("delete from ARCHIVE_INOCULATIONHISTORY");
        //    sQLStringList.Add("delete from ARCHIVE_LIFESTYLE");
        //    sQLStringList.Add("delete from ARCHIVE_MEDI_PHYS_DIST");
        //    sQLStringList.Add("delete from ARCHIVE_MEDICATION");
        //    sQLStringList.Add("delete from ARCHIVE_PHYSICALEXAM");
        //    sQLStringList.Add("delete from ARCHIVE_VISCERAFUNCTION");
        //    sQLStringList.Add("delete from tbl_deviceinfo");
        //    sQLStringList.Add("delete from CD_DIABETESFOLLOWUPRECORD");
        //    sQLStringList.Add("delete from CD_DRUGCONDITION");
        //    sQLStringList.Add("delete from CD_HYPERTENSIONFOLLOWUPRECORD");
        //    MySQLHelper.ExecuteSqlTran(sQLStringList);
        //}

        //public void CreateDB(string file)
        //{
        //    MySQLHelper.CreateDB(file);
        //}

        //public void CreateDB(string file, string pwd = null)
        //{
        //    MySQLHelper.CreateDB(file, pwd);
        //}

        public void ExcureTran(List<string> sqls)
        {
            MySQLHelper.ExecuteSqlTran(sqls);
        }

        public int ExecuteVoidSql(string sql)
        {
            return MySQLHelper.ExecuteSql(sql);
        }

        public string GetCity(string cityid)
        {
            return MySQLHelper.GetString(string.Format("select name from ARCHIVE_CANTON where code = '{0}'", cityid));
        }

        public DataTable GetStatistics()
        {
            DataTable dta = new DataTable();
            dta.Columns.Add("项目");
            dta.Columns.Add(DateTime.Today.AddDays(-6.0).ToShortDateString());
            dta.Columns.Add(DateTime.Today.AddDays(-5.0).ToShortDateString());
            dta.Columns.Add(DateTime.Today.AddDays(-4.0).ToShortDateString());
            dta.Columns.Add(DateTime.Today.AddDays(-3.0).ToShortDateString());
            dta.Columns.Add(DateTime.Today.AddDays(-2.0).ToShortDateString());
            dta.Columns.Add(DateTime.Today.AddDays(-1.0).ToShortDateString());
            dta.Columns.Add(DateTime.Today.AddDays(0.0).ToShortDateString());
            DataTable datatable = MySQLHelper.GetDataTable(this.getStatisticsSql("创建个人档案", "tbl_recordsbaseinfo"));
            DataTable dtb = MySQLHelper.GetDataTable(this.getStatisticsSql("体检信息", "tbl_recordscustomerbaseinfo", "CheckDate"));
            DataTable table4 = MySQLHelper.GetDataTable(this.getStatisticsSql("高血压补充表", "tbl_chronichypertensionbaseinfo"));
            DataTable table5 = MySQLHelper.GetDataTable(this.getStatisticsSql("高血压随访", "tbl_chronichypertensionvisit", "FollowUpDate"));
            DataTable table6 = MySQLHelper.GetDataTable(this.getStatisticsSql("糖尿病补充表", "tbl_chronicdiabetesbaseinfo"));
            DataTable table7 = MySQLHelper.GetDataTable(this.getStatisticsSql("糖尿病随访", "tbl_chronicdiadetesvisit", "VisitDate"));
            DataTable table8 = MySQLHelper.GetDataTable(this.getStatisticsSql("精神病补充表", "tbl_chronicmentaldiseasebaseinfo"));
            DataTable table9 = MySQLHelper.GetDataTable(this.getStatisticsSql("精神病随访", "tbl_chronicmentaldiseasevisit", "FollowUpDate"));
            DataTable table10 = MySQLHelper.GetDataTable(this.getStatisticsSql("儿童基本信息", "tbl_kidsbaseinfo"));
            DataTable table11 = MySQLHelper.GetDataTable(this.getStatisticsSql("新生儿随访", "tbl_kidsnewbornvisit", "InterviewDate"));
            DataTable table12 = MySQLHelper.GetDataTable(this.getStatisticsSql("一岁内随访", "tbl_kidswithinoneyearold", "VisitDate"));
            DataTable table13 = MySQLHelper.GetDataTable(this.getStatisticsSql("一至二岁随访", "tbl_kidsonetothreeyearold", "FollowupDate"));
            DataTable table14 = MySQLHelper.GetDataTable(this.getStatisticsSql("三至六岁随访", "tbl_kidsthreetosixyearold", "VisitDate"));
            DataTable table15 = MySQLHelper.GetDataTable(this.getStatisticsSql("孕妇基本信息", "tbl_womengravidabaseinfo"));
            DataTable table16 = MySQLHelper.GetDataTable(this.getStatisticsSql("第一次产前随访", "tbl_womengravidafirstvisit", "RecordDate"));
            DataTable table17 = MySQLHelper.GetDataTable(this.getStatisticsSql("二到五次产前随访", "tbl_womengravidatwotofivevisit", "FollowupDate"));
            DataTable table18 = MySQLHelper.GetDataTable(this.getStatisticsSql("产后访视", "tbl_womengravidapostpartum", "FollowupDate"));
            DataTable table19 = MySQLHelper.GetDataTable(this.getStatisticsSql("产后42天访视", "tbl_womengravidapostpartum42day", "FollowupDate"));
            this.addrow(dta, datatable);
            this.addrow(dta, dtb);
            this.addrow(dta, table4);
            this.addrow(dta, table5);
            this.addrow(dta, table6);
            this.addrow(dta, table7);
            this.addrow(dta, table8);
            this.addrow(dta, table9);
            this.addrow(dta, table10);
            this.addrow(dta, table11);
            this.addrow(dta, table12);
            this.addrow(dta, table13);
            this.addrow(dta, table14);
            this.addrow(dta, table15);
            this.addrow(dta, table16);
            this.addrow(dta, table17);
            this.addrow(dta, table18);
            this.addrow(dta, table19);
            DataTable table20 = MySQLHelper.GetDataTable("select distinct DeviceName from tbl_deviceinfo ");
            bool bcc = DateTime.Today.ToString().Contains<char>('/');
            foreach (DataRow row in table20.Rows)
            {
                DataTable table21 = MySQLHelper.GetDataTable(this.getStatisticsSql_dev(row["DeviceName"].ToString(), bcc));
                this.addrow(dta, table21);
            }
            return dta;
        }
        public DataTable GetTimeBucketStatis(string starttime,string endtime,  int timebucket)
        {
            DataTable dta = new DataTable();
            dta.Columns.Add("项目");
            int year = 0, month = 0, day = 0;
            string endt = endtime;
            if (timebucket == 1)
            {
                if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
                {
                    year = Convert.ToInt32(endtime) - Convert.ToInt32(starttime);
                    while (year >= 0)
                    {
                        dta.Columns.Add(endt + "年");
                        endt = Convert.ToString(Convert.ToInt32(endt) - 1); ;
                        year--;
                    }
                }
            }
            else if (timebucket == 2)
            {
                if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
                {
                    DateTime dtbegin = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), 1); //起始时间
                    DateTime dtend = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)),1);    //结束时间
                    if ((dtend.Year - dtbegin.Year) == 0)
                    {
                        month = dtend.Month - dtbegin.Month;
                    }
                    if ((dtend.Year - dtbegin.Year) >= 1)
                    {
                        if (dtend.Month - dtbegin.Month < 0)
                        {
                            month = (dtend.Year - dtbegin.Year - 1) * 12 + (12 - dtbegin.Month) + dtend.Month;
                        }
                        else
                        {
                            month = (dtend.Year - dtbegin.Year) * 12 + dtend.Month - dtbegin.Month;
                        }
                    }
                    while (month >= 0)
                    {
                        dta.Columns.Add(endt.Substring(0, 4) + "-" + endt.Substring(4, 2));
                        endt = dtend.AddMonths(-1).ToString("yyyyMM");
                        dtend = dtend.AddMonths(-1);
                        month--;
                    }
                }
            }
            else if (timebucket == 3)
            {
                if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
                {
                    DateTime dte = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)), Convert.ToInt32(endtime.Substring(6, 2)));
                    DateTime dts = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), Convert.ToInt32(starttime.Substring(6, 2)));
                    TimeSpan daycount = dte - dts;
                    string strday = Convert.ToString (daycount);
                    int i = 0;
                    foreach (char c in strday)
                    {
                        if (c != '.')
                        {
                            i++;
                            continue;
                        }
                        break;
                    }
                    if (i == strday.Length)
                    {
                        day = 0;
                    }
                    else
                    {
                        day = Convert.ToInt32(strday.Substring(0, i));
                    }
                    while (day >= 0)
                    {
                        dta.Columns.Add(endt.Substring(0, 4) + "-" + endt.Substring(4, 2) + "-" + endt.Substring(6, 2));
                        endt = dte.AddDays(-1.0).ToString("yyyyMMdd");
                        dte = dte.AddDays(-1.0);
                        day--;
                    }
                }
            }
            else
            {
                dta.Columns.Add(DateTime.Today.AddDays(-6.0).ToShortDateString());
                dta.Columns.Add(DateTime.Today.AddDays(-5.0).ToShortDateString());
                dta.Columns.Add(DateTime.Today.AddDays(-4.0).ToShortDateString());
                dta.Columns.Add(DateTime.Today.AddDays(-3.0).ToShortDateString());
                dta.Columns.Add(DateTime.Today.AddDays(-2.0).ToShortDateString());
                dta.Columns.Add(DateTime.Today.AddDays(-1.0).ToShortDateString());
                dta.Columns.Add(DateTime.Today.AddDays(0.0).ToShortDateString());
            }
            DataTable datatable = MySQLHelper.GetDataTable(this.getStatisticsSql("创建个人档案", "tbl_recordsbaseinfo",starttime,endtime, timebucket));
            DataTable dtb = MySQLHelper.GetDataTable(this.getStatisticsSql("体检信息", "tbl_recordscustomerbaseinfo", "CheckDate", starttime, endtime, timebucket));
            DataTable table4 = MySQLHelper.GetDataTable(this.getStatisticsSql("高血压补充表", "tbl_chronichypertensionbaseinfo", starttime, endtime, timebucket));
            DataTable table5 = MySQLHelper.GetDataTable(this.getStatisticsSql("高血压随访", "tbl_chronichypertensionvisit", "FollowUpDate", starttime, endtime, timebucket));
            DataTable table6 = MySQLHelper.GetDataTable(this.getStatisticsSql("糖尿病补充表", "tbl_chronicdiabetesbaseinfo", starttime, endtime, timebucket));
            DataTable table7 = MySQLHelper.GetDataTable(this.getStatisticsSql("糖尿病随访", "tbl_chronicdiadetesvisit", "VisitDate", starttime, endtime, timebucket));
            DataTable table8 = MySQLHelper.GetDataTable(this.getStatisticsSql("精神病补充表", "tbl_chronicmentaldiseasebaseinfo", starttime, endtime, timebucket));
            DataTable table9 = MySQLHelper.GetDataTable(this.getStatisticsSql("精神病随访", "tbl_chronicmentaldiseasevisit", "FollowUpDate", starttime, endtime, timebucket));
            DataTable table10 = MySQLHelper.GetDataTable(this.getStatisticsSql("儿童基本信息", "tbl_kidsbaseinfo", starttime, endtime, timebucket));
            DataTable table11 = MySQLHelper.GetDataTable(this.getStatisticsSql("新生儿随访", "tbl_kidsnewbornvisit", "InterviewDate", starttime, endtime, timebucket));
            DataTable table12 = MySQLHelper.GetDataTable(this.getStatisticsSql("一岁内随访", "tbl_kidswithinoneyearold", "VisitDate", starttime, endtime, timebucket));
            DataTable table13 = MySQLHelper.GetDataTable(this.getStatisticsSql("一至二岁随访", "tbl_kidsonetothreeyearold", "FollowupDate", starttime, endtime, timebucket));
            DataTable table14 = MySQLHelper.GetDataTable(this.getStatisticsSql("三至六岁随访", "tbl_kidsthreetosixyearold", "VisitDate", starttime, endtime, timebucket));
            DataTable table15 = MySQLHelper.GetDataTable(this.getStatisticsSql("孕妇基本信息", "tbl_womengravidabaseinfo", starttime, endtime, timebucket));
            DataTable table16 = MySQLHelper.GetDataTable(this.getStatisticsSql("第一次产前随访", "tbl_womengravidafirstvisit", "RecordDate", starttime, endtime, timebucket));
            DataTable table17 = MySQLHelper.GetDataTable(this.getStatisticsSql("二到五次产前随访", "tbl_womengravidatwotofivevisit", "FollowupDate", starttime, endtime, timebucket));
            DataTable table18 = MySQLHelper.GetDataTable(this.getStatisticsSql("产后访视", "tbl_womengravidapostpartum", "FollowupDate", starttime, endtime, timebucket));
            DataTable table19 = MySQLHelper.GetDataTable(this.getStatisticsSql("产后42天访视", "tbl_womengravidapostpartum42day", "FollowupDate",starttime,endtime, timebucket));
            this.addrow(dta, datatable);
            this.addrow(dta, dtb);
            this.addrow(dta, table4);
            this.addrow(dta, table5);
            this.addrow(dta, table6);
            this.addrow(dta, table7);
            this.addrow(dta, table8);
            this.addrow(dta, table9);
            this.addrow(dta, table10);
            this.addrow(dta, table11);
            this.addrow(dta, table12);
            this.addrow(dta, table13);
            this.addrow(dta, table14);
            this.addrow(dta, table15);
            this.addrow(dta, table16);
            this.addrow(dta, table17);
            this.addrow(dta, table18);
            this.addrow(dta, table19);
            DataTable table20 = MySQLHelper.GetDataTable("select distinct DeviceName from tbl_deviceinfo ");
            foreach (DataRow row in table20.Rows)
            {
                DataTable table21 = MySQLHelper.GetDataTable(this.getStatisticsSql_dev(row["DeviceName"].ToString(), starttime, endtime, timebucket));
                this.addrow(dta, table21);
            }
            return dta;
        }
        private string getStatisticsSql(string name, string table)
        {
            string str =string.Format( "select '{1}'\r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -6 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -5 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -4 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -3 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date( date_add(now(),interval -2 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) = date(date_add(now(),interval-1 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) = date(now())) as  a \r\nfrom tbl_recordsbaseinfo  limit 0,1", table, name);
            return string.Format("select '{1}'\r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -6 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -5 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -4 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -3 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date( date_add(now(),interval -2 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) = date(date_add(now(),interval-1 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) = date(now())) as  a \r\nfrom tbl_recordsbaseinfo  limit 0,1", table, name);
        }
        private string getStatisticsSql(string name, string table,string starttime,string endtime,int timebucket)
        {
            int year = 0, month = 0, day = 0;
            string str = "";
            if (timebucket == 1)
            {
                year = Convert.ToInt32(endtime) - Convert.ToInt32(starttime);
                str = str + "select '" + name + "'\r\n ";
                while (year > 0 || year ==0)
                {
                    string ends = endtime + "-01-01";
                    string ende = endtime + "-12-31";
                    str = str + "," + string.Format("(select count(*) from {2} where CreateDate between '{0}' and '{1}') as  a \r\n",ends,ende,table);
                    endtime = Convert.ToString(Convert.ToInt32(endtime) - 1);
                    year--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else if (timebucket == 2)
            {
                DateTime dtbegin = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), 1); //起始时间
                DateTime dtend = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)), 1);    //结束时间
                DateTime dtmend = dtend.AddMonths(+1);
                string endt = endtime;
                string endmt= dtmend.ToString("yyyyMMdd");
                if ((dtend.Year - dtbegin.Year) == 0)
                {
                    month = dtend.Month - dtbegin.Month;
                }
                if ((dtend.Year - dtbegin.Year) >= 1)
                {
                    if (dtend.Month - dtbegin.Month < 0)
                    {
                        month = (dtend.Year - dtbegin.Year - 1) * 12 + (12 - dtbegin.Month) + dtend.Month;
                    }
                    else
                    {
                        month = (dtend.Year - dtbegin.Year) * 12 + dtend.Month - dtbegin.Month;
                    }
                }
                str = str + "select '" + name + "'\r\n ";
                while (month >= 0)
                {
                    string endms = endt.Substring(0, 4) + "-" + endt.Substring(4, 2) + "-01";//开始月初
                    string endme = endmt.Substring(0, 4) + "-" + endmt.Substring(4, 2) + "-01";//开始月末
                    str = str + "," + string.Format("(select count(*) from {2} where CreateDate >='{0}' and CreateDate <'{1}' ) as  a \r\n", endms, endme, table);
                    endt = dtend.AddMonths(-1).ToString("yyyyMM");
                    endmt = dtmend.AddMonths(-1).ToString("yyyyMM");
                    dtend = dtend.AddMonths(-1);
                    dtmend = dtmend.AddMonths(-1);
                    month--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else if (timebucket == 3)
            {
                string endt = endtime;
                DateTime dte = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)), Convert.ToInt32(endtime.Substring(6, 2)));
                DateTime dts = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), Convert.ToInt32(starttime.Substring(6, 2)));
                TimeSpan daycount = dte - dts;
                string strday = Convert.ToString(daycount);
                int i = 0;
                foreach (char c in strday)
                {
                    if (c != '.')
                    {
                        i++;
                        continue;
                    }
                    break;
                }
                if (i == strday.Length)
                {
                    day = 0;
                }
                else
                {
                    day = Convert.ToInt32(strday.Substring(0, i));
                }
                str = str + "select '" + name + "'\r\n ";
                while (day >= 0)
                {
                    string ends = endt.Substring(0, 4) + "-" + endt.Substring(4, 2) + "-" + endt.Substring(6, 2);
                    str = str + "," + string.Format("(select count(*) from {1} where CreateDate = '{0}') as  a \r\n", ends, table);
                    endt = dte.AddDays(-1.0).ToString("yyyyMMdd");
                    dte = dte.AddDays(-1.0);
                    day--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else
            {
                return string.Format("select '{1}'\r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -6 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -5 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -4 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date(date_add(now(),interval -3 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) =date( date_add(now(),interval -2 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) = date(date_add(now(),interval-1 day))) as  a \r\n, (select count(*) from {0} where date(CreateDate) = date(now())) as  a \r\nfrom tbl_recordsbaseinfo  limit 0,1", table, name);
            }
            return string.Format(str);
        }
        private string getStatisticsSql(string name, string table, string col_date)
        {
            return string.Format("select '{2}'\r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -6 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -5 day))) as  a \r\n, (select count(*) from {0} where date({1}) =date(date_add(now(),interval -4 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -3 day))) as  a \r\n, (select count(*) from {0} where date({1}) =date( date_add(now(),interval -2 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -1 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(now())) as  a \r\nfrom tbl_recordsbaseinfo  limit 0,1", table, col_date, name);
        }
        private string getStatisticsSql(string name, string table, string col_date,string starttime,string endtime, int timebucket)
        {
            int year = 0, month = 0, day = 0;
            string str = "";
            if (timebucket == 1)
            {
                year = Convert.ToInt32(endtime) - Convert.ToInt32(starttime);
                str = str + "select '" + name + "'\r\n ";
                while (year > 0 || year == 0)
                {
                    string ends = endtime + "-01-01";
                    string ende = endtime + "-12-31";
                    str = str + "," + string.Format("(select count(*) from {2} where {3} between '{0}' and '{1}') as  a \r\n", ends, ende, table, col_date);
                    endtime = Convert.ToString(Convert.ToInt32(endtime) - 1);
                    year--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else if (timebucket == 2)
            {
                DateTime dtbegin = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), 1); //起始时间
                DateTime dtend = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)), 1);    //结束时间
                DateTime dtmend = dtend.AddMonths(+1);
                string endt = endtime;
                string endmt = dtmend.ToString("yyyyMMdd");
                if ((dtend.Year - dtbegin.Year) == 0)
                {
                    month = dtend.Month - dtbegin.Month;
                }
                if ((dtend.Year - dtbegin.Year) >= 1)
                {
                    if (dtend.Month - dtbegin.Month < 0)
                    {
                        month = (dtend.Year - dtbegin.Year - 1) * 12 + (12 - dtbegin.Month) + dtend.Month ;
                    }
                    else
                    {
                        month = (dtend.Year - dtbegin.Year) * 12 + dtend.Month - dtbegin.Month;
                    }
                }
                str = str + "select '" + name + "'\r\n ";
                while (month >= 0)
                {
                    string endms = endt.Substring(0, 4) + "-" + endt.Substring(4, 2) + "-01";//开始月初
                    string endme = endmt.Substring(0, 4) + "-" + endmt.Substring(4, 2) + "-01";//开始月末
                    str = str + "," + string.Format("(select count(*) from {2} where {3}>='{0}' and {3}< '{1}' ) as  a \r\n", endms, endme, table, col_date);
                    endt = dtend.AddMonths(-1).ToString("yyyyMM");
                    endmt = dtmend.AddMonths(-1).ToString("yyyyMM");
                    dtend = dtend.AddMonths(-1);
                    dtmend = dtmend.AddMonths(-1);
                    month--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else if (timebucket == 3)
            {
                string endt = endtime;
                DateTime dte = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)), Convert.ToInt32(endtime.Substring(6, 2)));
                DateTime dts = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), Convert.ToInt32(starttime.Substring(6, 2)));
                TimeSpan daycount = dte - dts;
                string strday = Convert.ToString(daycount);
                int i = 0;
                foreach (char c in strday)
                {
                    if (c != '.')
                    {
                        i++;
                        continue;
                    }
                    break;
                }
                if (i == strday.Length)
                {
                    day = 0;
                }
                else
                {
                    day = Convert.ToInt32(strday.Substring(0, i));
                }
                str = str + "select '" + name + "'\r\n ";
                while (day >= 0)
                {
                    string ends = endt.Substring(0, 4) + "-" + endt.Substring(4, 2) + "-" + endt.Substring(6, 2);
                    str = str + "," + string.Format("(select count(*) from {1} where {2} = '{0}') as  a \r\n", ends, table, col_date);
                    endt = dte.AddDays(-1.0).ToString("yyyyMMdd");
                    dte = dte.AddDays(-1.0);
                    day--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else
            {
                return string.Format("select '{2}'\r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -6 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -5 day))) as  a \r\n, (select count(*) from {0} where date({1}) =date(date_add(now(),interval -4 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -3 day))) as  a \r\n, (select count(*) from {0} where date({1}) =date( date_add(now(),interval -2 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(date_add(now(),interval -1 day))) as  a \r\n, (select count(*) from {0} where date({1}) = date(now())) as  a \r\nfrom tbl_recordsbaseinfo  limit 0,1", table, col_date, name);
            }
            return string.Format(str);
        }

        private string getStatisticsSql_dev(string name, bool bcc)
        {
            if (bcc)
            {
                return string.Format("select '{0}'\r\n, (select count(*) from tbl_deviceinfo where UpdateData like '{1}%'  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where UpdateData like '{2}%'  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where UpdateData like '{3}%'  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where UpdateData like '{4}%'  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where UpdateData like '{5}%'  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where UpdateData like '{6}%'  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where UpdateData like '{7}%'  and DeviceName = '{0}') as  a ", new object[] { name, DateTime.Today.AddDays(-6.0).ToString("yyyy/M/d"), DateTime.Today.AddDays(-5.0).ToString("yyyy/M/d"), DateTime.Today.AddDays(-4.0).ToString("yyyy/M/d"), DateTime.Today.AddDays(-3.0).ToString("yyyy/M/d"), DateTime.Today.AddDays(-2.0).ToString("yyyy/M/d"), DateTime.Today.AddDays(-1.0).ToString("yyyy/M/d"), DateTime.Today.ToString("yyyy/M/d") });
            }
            return string.Format("select '{0}'\r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(date_add(now(),interval -6 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) =date( date_add(now(),interval -5 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) =date( date_add(now(),interval -4 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(date_add(now(),interval -3 day)  and DeviceName = '{0}')) as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) =date( date_add(now(),interval -2 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(date_add(now(),interval -1 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(now()) and DeviceName = '{0}') as  a  ", name);
        }
        private string getStatisticsSql_dev(string name, string starttime, string endtime, int timebucket)
        {
            int year = 0, month = 0, day = 0;
            string str = "";
            if (timebucket == 1)
            {
                year = Convert.ToInt32(endtime) - Convert.ToInt32(starttime);
                str = str + "select '" + name + "'\r\n ";
                while (year > 0 || year == 0)
                {
                    string ends = endtime + "-01-01";
                    string ende = endtime + "-12-31";
                    str = str + "," + string.Format("(select count(*) from tbl_deviceinfo where UpdateData between '{0}' and '{1}') as  a \r\n", ends, ende);
                    endtime = Convert.ToString(Convert.ToInt32(endtime) - 1);
                    year--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else if (timebucket == 2)
            {
                DateTime dtbegin = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), 1); //起始时间
                DateTime dtend = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)), 1);    //结束时间
                DateTime dtmend = dtend.AddMonths(+1);
                string endt = endtime;
                string endmt = dtmend.ToString("yyyyMMdd");
                if ((dtend.Year - dtbegin.Year) == 0)
                {
                    month = dtend.Month - dtbegin.Month;
                }
                if ((dtend.Year - dtbegin.Year) >= 1)
                {
                    if (dtend.Month - dtbegin.Month < 0)
                    {
                        month = (dtend.Year - dtbegin.Year - 1) * 12 + (12 - dtbegin.Month) + dtend.Month;
                    }
                    else
                    {
                        month = (dtend.Year - dtbegin.Year) * 12 + dtend.Month - dtbegin.Month;
                    }
                }
                str = str + "select '" + name + "'\r\n ";
                while (month >= 0)
                {
                    string endms = endt.Substring(0, 4) + "-" + endt.Substring(4, 2) + "-01";//开始月初
                    string endme = endmt.Substring(0, 4) + "-" + endmt.Substring(4, 2) + "-01";//开始月末
                    str = str + "," + string.Format("(select count(*) from tbl_deviceinfo where UpdateData >= '{0}' and UpdateData < '{0}') as  a \r\n", endms, endme);
                    endt = dtend.AddMonths(-1).ToString("yyyyMM");
                    endmt = dtmend.AddMonths(-1).ToString("yyyyMM");
                    dtend = dtend.AddMonths(-1);
                    dtmend = dtmend.AddMonths(-1);
                    month--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else if (timebucket == 3)
            {
                string endt = endtime;
                DateTime dte = new DateTime(Convert.ToInt32(endtime.Substring(0, 4)), Convert.ToInt32(endtime.Substring(4, 2)), Convert.ToInt32(endtime.Substring(6, 2)));
                DateTime dts = new DateTime(Convert.ToInt32(starttime.Substring(0, 4)), Convert.ToInt32(starttime.Substring(4, 2)), Convert.ToInt32(starttime.Substring(6, 2)));
                TimeSpan daycount = dte - dts;
                string strday = Convert.ToString(daycount);
                int i = 0;
                foreach (char c in strday)
                {
                    if (c != '.')
                    {
                        i++;
                        continue;
                    }
                    break;
                }
                if (i == strday.Length)
                {
                    day = 0;
                }
                else
                {
                    day = Convert.ToInt32(strday.Substring(0, i));
                }
                str = str + "select '" + name + "'\r\n ";
                while (day >= 0)
                {
                    string ends = endt.Substring(0, 4) + "-" + endt.Substring(4, 2) + "-" + endt.Substring(6, 2);
                    str = str + "," + string.Format("(select count(*) from tbl_deviceinfo where UpdateData = '{0}') as  a \r\n", ends);
                    endt = dte.AddDays(-1.0).ToString("yyyyMMdd");
                    dte = dte.AddDays(-1.0);
                    day--;
                }
                str = str + " from tbl_recordsbaseinfo  limit 0,1";
                return string.Format(str);
            }
            else
            {
                return string.Format("select '{0}'\r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(date_add(now(),interval -6 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) =date( date_add(now(),interval -5 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) =date( date_add(now(),interval -4 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(date_add(now(),interval -3 day)  and DeviceName = '{0}')) as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) =date( date_add(now(),interval -2 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(date_add(now(),interval -1 day))  and DeviceName = '{0}') as  a \r\n, (select count(*) from tbl_deviceinfo where date(UpdateData) = date(now()) and DeviceName = '{0}') as  a  ", name);
            }
            return str;
        }
        //public void SetPassword(string pwd)
        //{
        //    MySQLHelper.ResetPassword(pwd);
        //}

        public bool TableExist(string[] tabels)
        {
            string str = "";
            foreach (string str2 in tabels)
            {
                str = str + "'" + str2 + "',";
            }
            DataTable datatable = MySQLHelper.GetDataTable(string.Format(" select table_name from information_schema.tables where table_name in ({0}) ", str.Trim(new char[] { ',' })));
            bool flag = false;
            if ((datatable != null) && (datatable.Rows.Count > 0))
            {
                flag = true;
            }
            return flag;
        }

        public bool TruncTabels(string[] tabels)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in tabels)
            {
                builder.Append(string.Format("delete from '{0}';", str));
                builder.Append(string.Format("DELETE FROM sqlite_sequence WHERE name = '{0}';", str));
            }
            return (MySQLHelper.ExecuteSql(builder.ToString()) > 0);
        }
    }
}

