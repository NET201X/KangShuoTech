using CommonUtilities.SQL;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;

namespace KangShuoTech.CommomDataAccessProjects.CommonDAL
{
    public class AnomalyRangeBussiness
    {
        /// <summary>
        /// 添加异常范围及指导建议
        /// </summary>
        /// <returns></returns>
        public int AddAnomaly(AnomalyRangeModel anomal)
        {
            string sql = @"INSERT INTO tbl_anomaly (Sex,RangeMin,RangeMax,GuidanceMin,GuidanceMax,preinstallId) 
                             VALUES ('" + anomal.Sex + "','" + anomal.RangeMin + "','" + anomal.RangeMax + "','" + anomal.GuidanceMin + "','" + anomal.GuidanceMax + "','" + anomal.PreinstallId + "');SELECT @@IDENTITY ";

            object single = MySQLHelper.GetSingle(sql);

            if (single == null) return 0;

            return Convert.ToInt32(single);
        }

        /// <summary>
        /// 修改异常范围及指导建议
        /// </summary>
        /// <param name="anomal"></param>
        /// <returns></returns>
        public int UpdateAnomaly(AnomalyRangeModel anomal)
        {
            string sql = @"UPDATE tbl_anomaly Set Sex='" + anomal.Sex + @"',
                                                 RangeMin='" + anomal.RangeMin + @"',
                                                 RangeMax='" + anomal.RangeMax + @"',
                                                GuidanceMin='" + anomal.GuidanceMin + @"',
                                                GuidanceMax='" + anomal.GuidanceMax + @"',
                                               preinstallId='" + anomal.PreinstallId + @"'
                                            WHERE id=" + anomal.id;

            return MySQLHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 获取异常值及范围设置
        /// </summary>
        /// <returns></returns>
        public DataTable GetAnomaly(string PreinstallId)
        {
            string sql = "SELECT * FROM tbl_anomaly WHERE PreinstallId='" + PreinstallId + "'";

            return MySQLHelper.GetDataTable(sql);
        }
    }
}
