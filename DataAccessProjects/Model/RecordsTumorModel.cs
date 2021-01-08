using System;
using System.Collections.Generic;
using System.Linq;

namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]
    public class RecordsTumorModel
    {
        public int ID { get; set; }
        public string RecordID { get; set; }//编号
        public string IDCardNo { get; set; }
        public string Age { get; set; } //实足年龄
        public string ClinicID { get; set; } //门诊号
        public string ICD { get; set; } //ICD-10编码
        public string ICDO { get; set; } //ICD-O-3编码
        public string HospitalizationID { get; set; }//住院号
        public string Phone { get; set; }//电话
        public string OrigDiagnose { get; set; }//原诊断
        public string MedicareCardID { get; set; }//医保卡号
        public string HouseholtDistict { get; set; }//户籍地址县
        public string HouseholtTown { get; set; }//
        public string HouseholtVillage { get; set; }//
        public string HouseholtNum { get; set; }//
        public string PresentDistict { get; set; }//现住址县
        public string PresentTown { get; set; }//
        public string PresentVillage { get; set; }//
        public string PresentNum { get; set; }//
        public string Diagnose { get; set; }//诊断
        public string PathologyType { get; set; }//病理学类型
        public string PrimaryParts { get; set; }//原发部位
        public string StageT { get; set; }//分期T
        public string StageN { get; set; }//分期N
        public string StageM { get; set; }//分期M
        public string ReportsUnit { get; set; }//报告单位
        public string ReportsDoctor { get; set; }//报告医师
        public DateTime? ReportDate { get; set; }//报告日期
        public string DieReason { get; set; }//死亡原因
        public string Judgment { get; set; }//诊断依据
        public DateTime? OrigDiagnoseDate { get; set; }//原诊断日期
        public DateTime? DiagnoseDate { get; set; }//诊断日期
        public DateTime? DieDate { get; set; }//死亡日期
        public int OutKey { get; set; }
    }
}
