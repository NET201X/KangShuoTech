namespace KangShuoTech.DataAccessProjects.BLL
{
    using KangShuoTech.Utilities.Common;
    using KangShuoTech.DataAccessProjects.DAL;
    using KangShuoTech.DataAccessProjects.Model;
    using System.Collections.Generic;
    using System.Data;

    public class RecordsBaseInfoBLL
    {
        private readonly RecordsBaseInfoDAL dal = new RecordsBaseInfoDAL();

        public int Add(RecordsBaseInfoModel model)
        {
            return this.dal.Add(model);
        }

        public List<RecordsBaseInfoModel> DataTableToList(DataTable dt)
        {
            List<RecordsBaseInfoModel> list = new List<RecordsBaseInfoModel>();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    RecordsBaseInfoModel item = this.dal.DataRowToModel(dt.Rows[i]);
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public int DelTheMan(string idcard)
        {
            return this.dal.DelTheMan(idcard);
        }

        public bool Exists(string idcard)
        {
            return this.dal.Exists(idcard);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetList(string strWhere, string orderby)
        {
            return this.dal.GetList(strWhere, orderby);
        }

        public DataSet GetVisitPercentDt(string strwhere)
        {
            return this.dal.GetVisitPercentDt(strwhere);
        }

        public DataSet GetUserDt(string strWhere)
        {
            return this.dal.GetUserDt(strWhere);
        }

        public DataSet GetListDT(string strWhere, string orderby)
        {
            return this.dal.GetListDt(strWhere, orderby);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetNoVisitListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetNoVisitListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GerenDanganDt(string strWhere)
        {
            return this.dal.GerenDanganDt(strWhere);
        }

        public DataSet JiankangCheckDt(string strWhere)
        {
            return this.dal.JiankangCheckDt(strWhere);
        }

        public DataSet DiabetesDt(string strWhere)
        {
            return this.dal.DiabetesDt(strWhere);
        }

        public DataSet HyperDt(string strWhere)
        {
            return this.dal.HyperDt(strWhere);
        }

        public RecordsBaseInfoModel GetModel(string IDCardNo)
        {
            DataSet ds = this.dal.GetModel(IDCardNo);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                List<RecordsBaseInfoModel> list = ModelConvertHelper<RecordsBaseInfoModel>.ToList(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        public List<RecordsBaseInfoModel> GetModelList(string strWhere)
        {
            return this.DataTableToList(this.dal.GetList(strWhere).Tables[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public DataSet GetVisitRecordCountTenDay(string strWhere, string CheckDate, string orderby)
        {
            return this.dal.GetVistRecordCountTenDay(strWhere, CheckDate, orderby);
        }

        public DataSet GetNoVistRecordCount(string strWhere, string CheckDate, string orderby)
        {
            return this.dal.GetNoVistRecordCount(strWhere, CheckDate, orderby);
        }

        //老年人十天
        public int GetOLDVisitCountTenDay(string strWhere, string CheckDate)
        {
            return dal.GetOLDVisitCountTenDay(strWhere, CheckDate);
        }

        //老年人未随访
        public int GetOLDNoVisitCount(string strWhere, string CheckDate)
        {
            return dal.GetOLDNoVisitCount(strWhere, CheckDate);
        }

        //高血压十天
        public int GetHyperVisitCountTenDay(string strWhere, string CheckDate)
        {
            return dal.GetHyperVisitCountTenDay(strWhere, CheckDate);
        }

        //高血压未随访
        public int GetHyperNoVisitCount(string strWhere, string CheckDate)
        {
            return dal.GetHyperNoVisitCount(strWhere, CheckDate);
        }

        //糖尿病十天
        public int GetDiaVisitCountTenDay(string strWhere, string CheckDate)
        {
            return dal.GetDiaVisitCountTenDay(strWhere, CheckDate);
        }

        //糖尿病未随访
        public int GetDiaNoVisitCount(string strWhere, string CheckDate)
        {
            return dal.GetDiaNoVisitCount(strWhere, CheckDate);
        }

        //精神疾病十天
        public int GetMentalVisitCountTenDay(string strWhere, string CheckDate)
        {
            return dal.GetMentalVisitCountTenDay(strWhere, CheckDate);
        }

        //精神疾病未随访
        public int GetMentalNoVisitCount(string strWhere, string CheckDate)
        {
            return dal.GetMentalNoVisitCount(strWhere, CheckDate);
        }

        //肺结核十天
        public int GetLungerVisitCountTenDay(string strWhere, string CheckDate)
        {
            return dal.GetLungerVisitCountTenDay(strWhere, CheckDate);
        }

        //肺结核未随访
        public int GetLungerNoVisitCount(string strWhere, string CheckDate)
        {
            return dal.GetLungerNoVisitCount(strWhere, CheckDate);
        }

        //脑卒中十天
        public int GetStrokeVisitCountTenDay(string strWhere, string CheckDate)
        {
            return dal.GetStrokeVisitCountTenDay(strWhere, CheckDate);
        }

        //脑卒中未随访
        public int GetStrokeNoVisitCount(string strWhere, string CheckDate)
        {
            return dal.GetStrokeNoVisitCount(strWhere, CheckDate);
        }

        // 冠心病十天
        public int GetChdVisitCountTenDay(string strWhere, string CheckDate)
        {
            return dal.GetChdVisitCountTenDay(strWhere, CheckDate);
        }

        // 冠心病未随访
        public int GetChdNoVisitCount(string strWhere, string CheckDate)
        {
            return dal.GetChdNoVisitCount(strWhere, CheckDate);
        }

        //10天内应访视人数
        public DataSet GetTenVisitRecordCount(string strWhere, string CheckDate, string orderby)
        {
            return this.dal.GetTenVisitRecordCount(strWhere, CheckDate, orderby);
        }

        // 老年人10天内应访视人数
        public int GetTenOLDVisitCount(string strWhere, string CheckDate)
        {
            return this.dal.GetTenOLDVisitCount(strWhere, CheckDate);
        }

        // 高血压10天内应访视人数
        public int GetTenHyperVisitCount(string strWhere, string CheckDate)
        {
            return this.dal.GetTenHyperVisitCount(strWhere, CheckDate);
        }

        // 糖尿病10天内应访视人数
        public int GetTenDiaVisitCount(string strWhere, string CheckDate)
        {
            return this.dal.GetTenDiaVisitCount(strWhere, CheckDate);
        }

        // 精神疾病10天应内访视人数
        public int GetTenMentalVisitCount(string strWhere, string CheckDate)
        {
            return this.dal.GetTenMentalVisitCount(strWhere, CheckDate);
        }

        // 肺结核10天内应访视人数
        public int GetTenLungerVisitCount(string strWhere, string CheckDate)
        {
            return this.dal.GetTenLungerVisitCount(strWhere, CheckDate);
        }

        // 脑卒中10天内应访视人数
        public int GetTenStrokeVisitCount(string strWhere, string CheckDate)
        {
            return this.dal.GetTenStrokeVisitCount(strWhere, CheckDate);
        }

        // 冠心病10天内应访视人数
        public int GetTenChdVisitCount(string strWhere, string CheckDate)
        {
            return this.dal.GetTenChdVisitCount(strWhere, CheckDate);
        }

        public bool Update(RecordsBaseInfoModel model)
        {
            return this.dal.Update(model);
        }

        public DataSet dtbaseinfo()
        {
            return this.dal.dtbaseinfo();
        }

        public int UpdateIDCard(string Oldidcard, string Newidcard)
        {
            return this.dal.UpdateIDCard(Oldidcard, Newidcard);
        }
        public void UpdatePhysicalClass(string idcard, string PhysicalClass)
        {
            dal.UpdatePhysicalClass(idcard,PhysicalClass);
        }
        #region 漏项查询

            /// <summary>
            /// 个人资料漏项查询
            /// </summary>
            /// <param name="strCol"></param>
            /// <param name="strWhere"></param>
            /// <param name="orderBy"></param>
            /// <param name="startIndex"></param>
            /// <param name="endIndex"></param>
            /// <returns></returns>
        public DataTable GetData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            DataSet ds = this.dal.GetData(strCol, strWhere, orderBy, startIndex, endIndex);

            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];

            return new DataTable();
        }

        /// <summary>
        /// 个人资料漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDataCount(string strCol, string strWhere)
        {
            return dal.GetDataCount(strCol, strWhere);
        }

        /// <summary>
        /// 体检资料漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetHealthData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            DataSet ds = this.dal.GetHealthData(strCol, strWhere, orderBy, startIndex, endIndex);

            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];

            return new DataTable();
        }

        /// <summary>
        /// 体检资料漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetHealthCount(string strCol, string strWhere)
        {
            return dal.GetHealthCount(strCol, strWhere);
        }

        /// <summary>
        /// 老年随访漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetOldData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            DataSet ds = this.dal.GetOldData(strCol, strWhere, orderBy, startIndex, endIndex);

            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];

            return new DataTable();
        }

        /// <summary>
        /// 老年随访漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetOldDataCount(string strCol, string strWhere)
        {
            return dal.GetOldDataCount(strCol, strWhere);
        }

        /// <summary>
        /// 高血压随访漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetHyperData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            DataSet ds = this.dal.GetHyperData(strCol, strWhere, orderBy, startIndex, endIndex);

            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];

            return new DataTable();
        }

        /// <summary>
        /// 高血压随访漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetHyperDataCount(string strCol, string strWhere)
        {
            return dal.GetHyperDataCount(strCol, strWhere);
        }

        /// <summary>
        /// 糖尿病随访漏项查询
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDiabeteData(string strCol, string strWhere, string orderBy, int startIndex, int endIndex)
        {
            DataSet ds = this.dal.GetDiabeteData(strCol, strWhere, orderBy, startIndex, endIndex);

            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];

            return new DataTable();
        }

        /// <summary>
        /// 糖尿病随访漏项查询清单笔数
        /// </summary>
        /// <param name="strCol"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetDiabeteDataCount(string strCol, string strWhere)
        {
            return dal.GetDiabeteDataCount(strCol, strWhere);
        }

        #endregion
    }
}