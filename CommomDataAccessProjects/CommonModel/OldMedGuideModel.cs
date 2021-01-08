using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    [Serializable]
    public class OldMedGuideModel
    {
        public int ID { get; set; }
        public string IDCardNo { get; set; }
        public DateTime? GuideDate { get; set; }//指导日期
        public string Doctor { get; set; }//指导医师
        public string IdentifyResult { get; set; }//体质辨识结果
        public string IdentifyDes { get; set; }//体质辨识结果描述
        public string EmotionAdjust { get; set; }//情致调摄
        public string DietAdjust { get; set; }//饮食调节
        public string LiveAdjust { get; set; }//起居调摄
        public string Sport { get; set; }//运动保健
        public string Collateral { get; set; }//经络保健
        public string Attention { get; set; }//注意事项
        public string OtherGuide { get; set; }//其他指导
        public int OutKey { get; set; }
        public int Type { get; set; }
    }
}
