using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class PrintBLL
    {
        private readonly PrintDAL dal = new PrintDAL();

        public int Add(PrintModel model)
        {
            return this.dal.Add(model);
        }

        /// <summary>
        /// 取得资料
        /// </summary>
        public DataSet GetData(string strPrint, string strPrintAll)
        {
            return dal.GetData(strPrint,strPrintAll);
        }

        /// <summary>
        /// 获取一键打印类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllPrint()
        {
            return dal.GetAllPrint();
        }

        public bool Exist(string strWhere)
        {
            return this.dal.Exist(strWhere);
        }

        public bool Update(PrintModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获取最大按钮排列序号
        /// </summary>
        /// <returns></returns>
        public int GetMaxOrders()
        {
            return this.dal.GetMaxOrders();
        }

        /// <summary>
        /// 获取Print表中内容
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetPrintData(string strWhere)
        {
            return this.dal.GetPrintData(strWhere);
        }
    }
}
