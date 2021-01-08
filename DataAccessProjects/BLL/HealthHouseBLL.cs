using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KangShuoTech.DataAccessProjects.Model;
using System;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.DAL;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthHouseBLL
    {
        private readonly HealthHouseDAL dal = new HealthHouseDAL();

        /// <summary>
        /// 新增骨密度检测记录表
        /// </summary>
        /// <param name="dtInfo"></param>
        /// <returns></returns>
        public int AddBoneBaseInfo(HealthHouseModel model)
        {
            return dal.AddBoneBaseInfo(model);
        }

        /// <summary>
        /// 检测是否存在
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public bool CheckBoneBaseInfo(string strID)
        {
            return dal.CheckBoneBaseInfo(strID);
        }

        /// <summary>
        /// 新增健康小屋基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HealthHouseModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 修改健康小屋基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HealthHouseModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 生成二维码 根据身份证及检查日期取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public HealthHouseModel GetList(string idCardNo, string checkDate)
        {
            DataSet ds = this.dal.GetList(idCardNo, checkDate);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // 将DataTable转为List
                IList<HealthHouseModel> list = CommonExtensions.DataTableToList<HealthHouseModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 体检画面 根据身份证及检查日期取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public HealthHouseModel GetData(string idCardNo, string checkDate)
        {
            DataSet ds = this.dal.GetData(idCardNo, checkDate);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // 将DataTable转为List
                IList<HealthHouseModel> list = CommonExtensions.DataTableToList<HealthHouseModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }

        /// <summary>
        /// 历史数据 根据身份证取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public DataTable GetDataInfo(string idCardNo)
        {
            DataSet ds = this.dal.GetDataInfo(idCardNo);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }

            return new DataTable();
        }

           /// <summary>
        /// 根据ID取得资料
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public HealthHouseModel GetDataByID(int ID)
        {
            DataSet ds = this.dal.GetDataByID(ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // 将DataTable转为List
                IList<HealthHouseModel> list = CommonExtensions.DataTableToList<HealthHouseModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
          /// <summary>
        /// 获取最新的一笔数据
        /// </summary>
        public HealthHouseModel GetMaxData(string idCardNo)
        {
            DataSet ds = this.dal.GetMaxData(idCardNo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // 将DataTable转为List
                IList<HealthHouseModel> list = CommonExtensions.DataTableToList<HealthHouseModel>(ds.Tables[0]);

                if (list.Count > 0) return list[0];
            }

            return null;
        }
        public int GetHouseRecordCount(string strWhere)
        {
            return this.dal.GetHouseRecordCount(strWhere);
        }
        public DataSet GetHouseListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetHouseListByPage(strWhere,orderby,startIndex,endIndex);
        }
        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }
    }
}
