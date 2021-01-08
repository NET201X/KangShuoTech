using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using CommomUtilities.Common;
using KangShuoTech.CommomDataAccessProjects.CommonDAL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;

namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    public class QCMiniBLL
    {
        private readonly QCMiniBusiness dal = new QCMiniBusiness();

        #region 血压 血糖 身高体重 尿仪 体温体重

        /// <summary>
        /// 获取资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="deviceType">设备类型 20:血压 24:血糖 39:身高体重 33:尿仪 22:体温 40:体重</param>
        /// <returns></returns>
        public int GetDeviceInfoCount(string startDate, string endDate, string deviceType, string conn)
        {
            return dal.GetDeviceInfoCount(startDate, endDate, deviceType, conn);
        }

        /// <summary>
        /// 获取资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="deviceType">设备类型 20:血压 24:血糖 39:身高体重 33:尿仪 22:体温 40:体重</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DeviceInfoModel> GetDeviceInfo(string startDate, string endDate, string deviceType, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetDeviceInfo(startDate, endDate, deviceType, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DeviceInfoModel>.ToList(ds.Tables[0]);

            return new List<DeviceInfoModel>();
        }

        #endregion

        #region 体检问询

        /// <summary>
        /// 获取体检问询资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetMedicalEnquiryCount(string startDate, string endDate, string conn)
        {
            return dal.GetMedicalEnquiryCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取体检问询资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DataUploadModel> GetMedicalEnquiry(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetMedicalEnquiry(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataUploadModel>.ToList(ds.Tables[0]);

            return new List<DataUploadModel>();
        }

        /// <summary>
        /// 获取体检问询用药资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public IList<RecordsMedicationModel> GetMedication(string startDate, string endDate, string conn)
        {
            DataSet ds = dal.GetMedication(startDate, endDate, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<RecordsMedicationModel>.ToList(ds.Tables[0]);

            return new List<RecordsMedicationModel>();
        }

        /// <summary>
        /// 获取体检问询住院、免疫接种史资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public IList<History> GetHistory(string startDate, string endDate, string conn)
        {
            DataSet ds = dal.GetHistory(startDate, endDate, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<History>.ToList(ds.Tables[0]);

            return new List<History>();
        }

        #endregion

        #region 中医体质

        /// <summary>
        /// 获取中医体质资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetMedicineCount(string startDate, string endDate, string conn)
        {
            return dal.GetMedicineCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取中医体质资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <param name="conn">连接字串</param>
        /// <param name="SignPath">签字路径</param>
        /// <param name="FingerPath">指纹路径</param>
        /// <returns></returns>
        public IList<MedicineModel> GetMedicine(string startDate, string endDate, int startIndex, int endIndex, string conn, string SignPath, string FingerPath)
        {
            DataSet ds = dal.GetMedicine(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    row["Sign"] = GetPicture(SignPath, row["IDCardNo"] + ".png");
                    row["Finger"] = GetPicture(FingerPath, row["IDCardNo"] + ".png");
                }

                return ModelConvertHelper<MedicineModel>.ToList(dt);
            }

            return new List<MedicineModel>();
        }

        /// <summary>
        /// 获取自理能力资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public IList<OldSelfSqliteModel> GetOldSelf(string startDate, string endDate, string conn)
        {
            DataSet ds = dal.GetOldSelf(startDate, endDate, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<OldSelfSqliteModel>.ToList(ds.Tables[0]);

            return new List<OldSelfSqliteModel>();
        }

        #endregion

        #region 心电

        /// <summary>
        /// 获取心电资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetECGCount(string startDate, string endDate, string conn)
        {
            return dal.GetECGCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取心电资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <param name="conn">连接字串</param>
        /// <param name="EGCReport">签字路径</param>
        /// <returns></returns>
        public IList<EcgDataModel> GetECG(string startDate, string endDate, int startIndex, int endIndex, string conn, string EGCReport)
        {
            DataSet ds = dal.GetECG(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    row["Picture"] = GetPicture(EGCReport, row["examno"] + ".png");
                }

                return ModelConvertHelper<EcgDataModel>.ToList(dt);
            }

            return new List<EcgDataModel>();
        }

        #endregion

        #region 一代B超

        /// <summary>
        /// 获取B超资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBTypeCount(string startDate, string endDate, string conn)
        {
            return dal.GetBTypeCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取B超资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<BTypeModel> GetBType(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetBType(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    row["Picture"] = GetPicture("D:\\cworkccs\\" + row["RECID"] + "\\", "rep.jpg");
                }

                return ModelConvertHelper<BTypeModel>.ToList(dt);
            }

            return new List<BTypeModel>();
        }

        #endregion

        #region 五官

        /// <summary>
        /// 获取五官资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetMouthCount(string startDate, string endDate, string conn)
        {
            return dal.GetMouthCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 取得对应条件的五官科资料
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<MouthModel> GetMouth(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetMouth(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<MouthModel>.ToList(ds.Tables[0]);

            return new List<MouthModel>();
        }

        #endregion

        #region 外科

        /// <summary>
        /// 获取外科资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetSurgicalCount(string startDate, string endDate, string conn)
        {
            return dal.GetSurgicalCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 取得对应条件的外科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<SurgicalModel> GetSurgical(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetSurgical(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<SurgicalModel>.ToList(ds.Tables[0]);

            return new List<SurgicalModel>();
        }

        #endregion

        #region 内科

        /// <summary>
        /// 获取内科资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetInternalMedicineCount(string startDate, string endDate, string conn)
        {
            return dal.GetInternalMedicineCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 取得对应条件的内科资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<InternalMedicineModel> GetInternalMedicine(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetInternalMedicine(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<InternalMedicineModel>.ToList(ds.Tables[0]);

            return new List<InternalMedicineModel>();
        }

        #endregion

        #region X光

        /// <summary>
        /// 获取X光资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetRecordsChestXCount(string startDate, string endDate, string conn)
        {
            return dal.GetRecordsChestXCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 取得对应条件的X光资料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<RecordsAssistCheckModel> GetRecordsChestX(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetRecordsChestX(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<RecordsAssistCheckModel>.ToList(ds.Tables[0]);

            return new List<RecordsAssistCheckModel>();
        }

        #endregion

        #region 视力

        /// <summary>
        /// 获取视力资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetVsiualCount(string startDate, string endDate, string conn)
        {
            return dal.GetVsiualCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取视力资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DataModel> GetVsiual(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetVsiual(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataModel>.ToList(ds.Tables[0]);

            return new List<DataModel>();
        }

        #endregion

        #region 生化

        /// <summary>
        /// 获取生化资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBiochemicalCount(string startDate, string endDate, string conn)
        {
            return dal.GetBiochemicalCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取生化资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DataModel> GetBiochemical(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetBiochemical(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataModel>.ToList(ds.Tables[0]);

            return new List<DataModel>();
        }

        #endregion

        #region 血球

        /// <summary>
        /// 获取血球资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBloodCount(string startDate, string endDate, string conn)
        {
            return dal.GetBloodCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取血球资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DataModel> GetBlood(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetBlood(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataModel>.ToList(ds.Tables[0]);

            return new List<DataModel>();
        }

        #endregion

        #region 尿仪

        /// <summary>
        /// 获取尿仪资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetUrineCount(string startDate, string endDate, string conn)
        {
            return dal.GetUrineCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取尿仪资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DataModel> GetUrine(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetUrine(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataModel>.ToList(ds.Tables[0]);

            return new List<DataModel>();
        }

        #endregion

        #region 身高体重

        /// <summary>
        /// 获取身高体重资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="conn">数据库连接</param>
        /// <returns></returns>
        public IList<DataModel> GetHeightWeight(string startDate, string endDate, string conn)
        {
            DataSet ds = dal.GetHeightWeight(startDate, endDate, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataModel>.ToList(ds.Tables[0]);

            return new List<DataModel>();
        }

        #endregion

        #region 安徽扫码 X光

        /// <summary>
        /// 获取X光资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetChestXCount(string startDate, string endDate, string conn)
        {
            return dal.GetChestXCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取X光资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DataModel> GetChestX(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetChestX(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataModel>.ToList(ds.Tables[0]);

            return new List<DataModel>();
        }

        #endregion

        #region 重庆B超，从access数据中获取B超

        /// <summary>
        /// 获取B超资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetBChaoCount(string startDate, string endDate, string conn)
        {
            return dal.GetBChaoCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取B超资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<DataModel> GetBChao(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetBChao(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<DataModel>.ToList(ds.Tables[0]);

            return new List<DataModel>();
        }

        #endregion

        #region 新版B超

        /// <summary>
        /// 获取B超资料内容笔数
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public int GetNewBTypeCount(string startDate, string endDate, string conn)
        {
            return dal.GetNewBTypeCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取B超资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<NewBTypeModel> GetNewBType(string startDate, string endDate, int startIndex, int endIndex, string conn)
        {
            DataSet ds = dal.GetNewBType(startDate, endDate, startIndex, endIndex, conn);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    row["Picture"] = GetPicture("D:\\超声影像系统\\picture\\" + row["jcbh"] + "\\",
                        string.Format("{0}_{1}", DateTime.Parse(row["jcrq"].ToString()).ToString("yyyy-MM-dd"), row["sfzh"]) + ".jpg");
                }

                return ModelConvertHelper<NewBTypeModel>.ToList(dt);
            }

            return new List<NewBTypeModel>();
        }

        #endregion

        #region 抑郁评估

        /// <summary>
        /// 查询抑郁评估笔数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int GetGloomyCount(string startDate, string endDate, string conn)
        {
            return dal.GetGloomyCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取抑郁评估资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<OldGloomyModel> GetGloomy(string startDate, string endDate, string conn)
        {
            DataSet ds = dal.GetGloomy(startDate, endDate, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<OldGloomyModel>.ToList(ds.Tables[0]);

            return new List<OldGloomyModel>();
        }

        #endregion

        #region 智力评估

        /// <summary>
        /// 查询智力评估笔数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int GetIntelligenceCount(string startDate, string endDate, string conn)
        {
            return dal.GetIntelligenceCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取智力评估资料内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startIndex">开始笔数</param>
        /// <param name="endIndex">结束笔数</param>
        /// <returns></returns>
        public IList<OldIntelligenceModel> GetIntelligence(string startDate, string endDate, string conn)
        {
            DataSet ds = dal.GetIntelligence(startDate, endDate, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<OldIntelligenceModel>.ToList(ds.Tables[0]);

            return new List<OldIntelligenceModel>();
        }

        #endregion

        #region 健康状况

        /// <summary>
        /// 查询健康状况笔数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int GetHealthCount(string startDate, string endDate, string conn)
        {
            return dal.GetHealthCount(startDate, endDate, conn);
        }

        /// <summary>
        /// 获取健康状况内容
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IList<RecordsHealthConditionModel> GetHealth(string startDate, string endDate, string conn)
        {
            DataSet ds = dal.GetHealth(startDate, endDate, conn);

            if (ds != null && ds.Tables.Count > 0) return ModelConvertHelper<RecordsHealthConditionModel>.ToList(ds.Tables[0]);

            return new List<RecordsHealthConditionModel>();
        }

        #endregion

        /// <summary>
        ///  返回图片
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns>返回结果</returns>
        public string GetPicture(string path, string fileName)
        {
            string img = ImgToBase64String(path + fileName);

            return img;
        }

        /// <summary>
        /// 图片转Base64
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ImgToBase64String(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    FileStream fs = new FileStream(path, FileMode.Open);

                    byte[] arr = new byte[fs.Length];
                    fs.Position = 0;
                    fs.Read(arr, 0, (int)fs.Length);
                    fs.Close();

                    return Convert.ToBase64String(arr);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}