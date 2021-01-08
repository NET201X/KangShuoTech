using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class FingerPrintBLL
    {
        private readonly FingerPrintDAL dal = new FingerPrintDAL();

        /// <summary>
        /// 保存指纹&身份证对应
        /// </summary>
        /// <param name="strFingerId"></param>
        /// <param name="strIDCard"></param>
        /// <param name="strFingerInfo"></param>
        public string SaveFingerInfo(string strFingerId, string strIDCard, string strFingerInfo)
        {
            return this.dal.SaveFingerInfo(strFingerId, strIDCard, strFingerInfo);
        }

        /// <summary>
        /// 根据身份获取指纹ID
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public string GetFinerIDByIDCardNo(string strIDCard)
        {
            return this.dal.GetFinerIDByIDCardNo(strIDCard);
        }

        /// <summary>
        /// 获取最大指纹ID
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public string GetMaxFinerID()
        {
            return this.dal.GetMaxFinerID();
        }

        /// <summary>
        /// 根据指纹ID获取身份
        /// </summary>
        /// <param name="strFingerID"></param>
        /// <returns></returns>
        public string GetIDCardNoByFinerID(string strFingerID)
        {
            return this.dal.GetIDCardNoByFinerID(strFingerID);
        }

        /// <summary>
        /// 取得所有指纹记录
        /// </summary>
        /// <param name="strIDCard"></param>
        /// <returns></returns>
        public DataTable GetFingerInfo()
        {
            return this.dal.GetFingerInfo();
        }

        /// <summary>
        /// 删除不存在的指纹id
        /// </summary>
        public void DeleteFingerInfo()
        {
            this.dal.DeleteFingerInfo();
        }
    }
}