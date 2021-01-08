using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KangShuoTech.DataAccessProjects.DAL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.DataAccessProjects.BLL
{
    public class HealthOverviewSetBLL
    {
        private readonly HealthOverviewSetDAL dal = new HealthOverviewSetDAL();
        public int Add(HealthOverviewSetModel model)
        {
            return this.dal.Add(model);
        }
        public List<HealthOverviewSetModel> GetList(string strwhere)
        {
            return this.dal.GetList(strwhere);
        }
        public bool Update(HealthOverviewSetModel model)
        {
            return this.dal.Update(model);
        }

        /// <summary>
        ///  获取体检数据类型的异常信息
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public HealthOverviewSetModel GetModel(string strwhere)
        {
            return this.dal.GetModel(strwhere);
        }
    }
}
