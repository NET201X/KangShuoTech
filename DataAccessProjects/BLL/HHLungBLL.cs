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
    public class HHLungBLL
    {
        private readonly HHLungDAL dal = new HHLungDAL();

        /// <summary>
        /// 新增肺功能资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HHLungModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 修改肺功能资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HHLungModel model)
        {
            return dal.Update(model);
        }
           /// <summary>
        /// 根据PID判断肺功能资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }
        public HHLungModel GetData(string IDCardNo, int PID)
        {
            return this.dal.GetData(IDCardNo,PID);
        }
    }
}
