using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
    [Serializable]
    public class HealthRecordsinfoModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public string Prevalence { get; set; }//患病情况
        public string PrevalenceOther { get; set; }//患病情况其他疾病
        public string OrgTelphone { get; set; }//建设机构联系电话
        public string FamilyDoctor { get; set; }//家庭医生
        public string FamilyDoctorTel { get; set; }//家庭医生联系电话
        public string Nurses { get; set; }//社区护士
        public string NursesTel { get; set; }//护士电话
        public string HealthPersonnel { get; set; }//公共卫生人员
        public string HealthPersonnelTel { get; set; }//公共卫生人员电话
        public string Others { get; set; }//其他说明
    }
}
