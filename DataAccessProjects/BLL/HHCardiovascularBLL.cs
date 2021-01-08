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
    public class HHCardiovascularBLL
    {
        private readonly HHCardiovascularDAL dal = new HHCardiovascularDAL();

        /// <summary>
        /// 新增心血管资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HHCardiovascularModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 修改心血管资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HHCardiovascularModel model)
        {
            return dal.Update(model);
        }
          /// <summary>
        /// 根据PID判断心血管资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }
           /// <summary>
        /// 根据ID取得资料
        /// </summary>
        public HHCardiovascularModel GetData(string IDCardNo, int PID)
        {
            return this.dal.GetData(IDCardNo,PID);
        }
    }
}
