using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
   public class RecordsChdStrokeReportModel
    {
       public int ID { get; set; }
       public string PatientNo { get; set; }//门诊号
       public string AdmissionNo { get; set; }//住院号
       public string CardNo { get; set; }//卡片编号
       public string  IDCardNo { get; set; }//身份证
       public string ICD10Code { get; set; }//icd10编码
      // public string Name { get; set; }
       //public string Sex { get; set; }
       //public DateTime? Birthday { get; set; }
       public string Age { get; set; }
       //public string Job { get; set; }
      // public string Nation { get; set; }
       public string Phone { get; set; }
       //public string WorkUnit { get; set; }
       public string AddDistrict { get; set; }//户籍
       public string AddTown { get; set; }
       public string AddVillage { get; set; }
       public string AddNum { get; set; }
       public string HouesAddDistrict { get; set; } //现住址
       public string HouesAddTown { get; set; }
       public string HouseAddVillage { get; set; }
       public string HouseAddNum { get; set; }
       public string AcuteMI { get; set; }//冠心病诊断
       public string SAH { get; set; }//脑卒中诊断
       public string Diagnosis { get; set; }//诊断依据
       public DateTime? DiseaseTime { get; set; }//发病日期
       public DateTime? DiagnosisTime { get; set; }//确诊日期
       public string FirstOnset { get; set; }//是否首次发病
       public string ConfirmedUnit { get; set; }//确诊单位
       public string CardUnit { get; set; }//报卡单位
       public string CardDoctor { get; set; }//报卡医师
       public DateTime? CardDate { get; set; }//报卡日期
       public DateTime? DeathDate { get; set; }//死亡日期
       public string DeathReason { get; set; }//死亡原因
       public string DeathCode { get; set; }//死因编码
       public int OutKey { get; set; }

    }
}
