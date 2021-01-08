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
    public class HHBoneBLL
    {
        private readonly HHBoneDAL dal = new HHBoneDAL();

        /// <summary>
        /// 新增骨密度资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(HHBoneModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 修改骨密度资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(HHBoneModel model)
        {
            return dal.Update(model);
        }
          /// <summary>
        /// 根据PID判断骨密度资料是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPID(string IDCardNo, int PID)
        {
            return this.dal.ExistsPID(IDCardNo,PID);
        }
        public HHBoneModel GetData(string IDCardNo, int PID)
        {
            return this.dal.GetData(IDCardNo,PID);
        }
    }
}
