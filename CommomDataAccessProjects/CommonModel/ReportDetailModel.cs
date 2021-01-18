namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class ReportDetailModel
    {
        public int ID { get; set; }

        /// <summary>
        /// ARCHIVE_REPORT ID 外键
        /// </summary>
        public int? ReportID { get; set; }

        /// <summary>
        /// 报表名称
        /// </summary>
        public string ReportName { get; set; }

        /// <summary>
        /// 汇出类型  1:csv  2:excel
        /// </summary>
        public int ExportType { get; set; }

        /// <summary>
        /// 显示栏位名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 显示栏位内容
        /// </summary>
        public string ColumnValue { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int? Seq { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }

        #region ARCHIVE_REPORT 字段
        /// <summary>
        /// ARCHIVE_REPORT ID
        /// </summary>
        public int TblReportID { get; set; }

        /// <summary>
        /// ARCHIVE_REPORT 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// ARCHIVE_REPORT 别名
        /// </summary>
        public string AnotherName { get; set; }

        /// <summary>
        /// ARCHIVE_REPORT 栏位名
        /// </summary>
        public string OptionName { get; set; }

        /// <summary>
        /// ARCHIVE_REPORT 中文名称
        /// </summary>
        public string ChinaName { get; set; }
        #endregion
        public int RowID { get; set; }
    }
}
