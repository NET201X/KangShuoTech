using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class SysPreinstallBLL
    {
        private readonly SysPreinstallBussiness dal = new SysPreinstallBussiness();

        /// <summary>
        /// 获取页签信息 一级菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetTabInfo()
        {
            return dal.GetTabInfo();
        }

        /// <summary>
        /// 获取页签信息 二级菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetComInfo(string TabName)
        {
            return dal.GetComInfo(TabName);
        }

        /// <summary>
        /// 获取页签信息 字段信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetChinInfo(string TabName, string ConName)
        {
            return dal.GetChinInfo(TabName, ConName);
        }

        public DataTable GetTab()
        {
            return dal.GetTab();
        }

        public DataTable GetCom(string Tab)
        {
            return dal.GetCom(Tab);
        }

        public DataTable GetCon(string Com)
        {
            return dal.GetCon(Com);
        }

        /// <summary>
        /// 根据模块、功能、栏位等信息筛选数据
        /// </summary>
        /// <param name="TabName">模块名称</param>
        /// <param name="Comment">功能名称</param>
        /// <param name="ChinName">栏位信息</param>
        /// <param name="Compare">模板标签名称</param>
        /// <returns></returns>
        public DataTable GetSystemInfo(string TabName, string Comment, string ChinName, string Compare)
        {
            return dal.GetSystemInfo(TabName, Comment, ChinName, Compare);
        }

        /// <summary>
        /// 取得中医标签名称
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetCompare(string where)
        {
            return dal.GetCompare(where);
        }

        /// <summary>
        /// 添加系统预设信息
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public int InsertSys(SysPreinstallModel sys)
        {
            return dal.InsertSys(sys);
        }

        /// <summary>
        /// 修改系统预设信息
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public int UpdateSys(SysPreinstallModel sys)
        {
            return dal.UpdateSys(sys);
        }

        public DataTable GetTable(string id)
        {
            return dal.GetTable(id);
        }

        /// <summary>
        /// 获取数据库名称
        /// </summary>
        /// <returns></returns>
        public string GetTableName(string comment)
        {
            return dal.GetTableName(comment);
        }

        /// <summary>
        /// 获取数据库栏位名称
        /// </summary>
        /// <returns></returns>
        public string GetOptionName(string china, string TableName)
        {
            return dal.GetOptionName(china, TableName);
        }

        /// <summary>
        /// 删除预设数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelSys(string id)
        {
            return dal.DelSys(id);
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        public void Insert(string sql)
        {
            dal.Insert(sql);
        }

        public DataTable GetInfo(string sql)
        {
            return dal.GetInfo(sql);
        }

        /// <summary>
        /// 获取临时表的信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfo()
        {
            return dal.GetInfo();
        }

        /// <summary>
        /// 新增word域格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int InsertFormat(string value)
        {
            return dal.InsertFormat(value);
        }

        public DataTable GetFormat()
        {
            return dal.GetFormat();
        }

        /// <summary>
        /// 根据内容信息删除Word域格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int DelFormat(string value)
        {
            return dal.DelFormat(value);
        }

        public DataTable GetHealth(string idCardNo, string checkDate)
        {
            return dal.GetHealth(idCardNo, checkDate);
        }

        public bool Exist(string strWhere)
        {
            return this.dal.Exist(strWhere);
        }
    }
}
