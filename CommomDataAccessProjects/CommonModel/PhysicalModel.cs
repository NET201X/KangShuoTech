using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{

    [Serializable]
    public class PhysicalModel
    {
        public string IDCardNo { get; set; }  //身份证号码
        public string  CheckDate { get; set; }//体检时间
        public decimal? Height { get; set; } //身高
        public decimal? Weight { get; set; }//体重
        public decimal? BMI { get; set; }//体质指数
        public decimal? Waistline { get; set; }//腰围
        public decimal? LeftHeight { get; set; }//左侧高血压
        public decimal? LeftPre { get; set; }//左侧低血压
        public decimal? RightHeight { get; set; }//右侧高血压
        public decimal? RightPre { get; set; }//右侧低血压
        public decimal? HB { get; set; }//血红蛋白
        public decimal? WBC { get; set; }//白细胞
        public decimal? PLT { get; set; }//血小板
        public string BloodType { get; set; }//血型
        public string PRO { get; set; }//尿蛋白
        public string GLU { get; set; }//尿糖
        public string KET { get; set; }//尿酮体
        public string BLD { get; set; }//尿潜血
        public decimal? FPGDL { get; set; }//空腹血糖
        public decimal? AFPGDL { get; set; }//餐后血糖
        public decimal? SGPT { get; set; }//血清谷丙转氨酶
        public decimal? GOT { get; set; }//血清谷草转氨酶
        public decimal? BP { get; set; }//白蛋白
        public decimal? TBIL { get; set; }//总胆红素
        public decimal? CB { get; set; }//结合胆红素
        public decimal? SCR { get; set; }//血清肌酐
        public decimal? BUN { get; set; }//血尿素氮
        public decimal? PC { get; set; }//血钾浓度
        public decimal? HYPE { get; set; }//血钠浓度
        public decimal? TC { get; set; }//总胆固醇
        public decimal? TG { get; set; }//甘油三酯
        public decimal? LowCho { get; set; }//血清低密度脂蛋白胆固醇
        public decimal? HeiCho { get; set; }//血清高密度脂蛋白胆固醇
        public string ECG { get; set; }//心电
        public string ECGEx { get; set; }//心电异常
        public string BCHAO { get; set; }//B超
        public string BCHAOEx { get; set; }//B超异常
        public string Remark { get; set; }//医生指导
        public string DoctorName { get; set; }//医生签名
        public string MedicalResults { get; set; }//体检结果

        public string Skin { get; set; }//皮肤
        public string SkinEx { get; set; }//皮肤其他
        public string Sclera { get; set; }//巩膜
        public string ScleraEx { get; set; }//巩膜其他
        public string Lymph { get; set; }//淋巴结
        public string LymphEx { get; set; }//淋巴结其他
        public string BarrelChest { get; set; }//桶状胸
        public string BreathSounds { get; set; }//呼吸音
        public string BreathSoundsEx { get; set; }//呼吸音异常
        public string Rale { get; set; }//罗音
        public string RaleEx { get; set; }//罗音异常
        public string HeartRate { get; set; }//心率
        public string HeartRhythm { get; set; }//心律
        public string Noise { get; set; }//杂音
        public string NoiseEx { get; set; }//杂音(有)
        public string PressPain { get; set; }//压痛
        public string PressPainEx { get; set; }//压痛有
        public string EnclosedMass { get; set; }//包块
        public string EnclosedMassEx { get; set; }//包块（有）
        public string Liver { get; set; }//肝大
        public string LiverEx { get; set; }//肝大（有）
        public string Spleen { get; set; }//脾大
        public string SpleenEx { get; set; }//脾大（有）
        public string Voiced { get; set; }//移动性浊音
        public string VoicedEx { get; set; }//移动性浊音（有）
        public string Edema { get; set; }//下肢水肿
        public string FootBack { get; set; }//足背动脉搏动
        public string CHESTX { get; set; }//胸部X线
        public string CHESTXEx { get; set; }//胸部X线异常
        public string Address { get; set; }//现住址
        public string Phone { get; set; }//联系电话
        public string WorkUnit { get; set; }//工作单位
        public string Breast { get; set; }    // 乳腺
        public string Vulva { get; set; }    // 外阴
        public string Vagina { get; set; }    // 阴道
        public string CervixUteri { get; set; }    // 宫颈
        public string Corpus { get; set; }    // 宫体
        public string Attach { get; set; }    // 附件
        public string BreastEx { get; set; }   // 乳腺异常
        public string CervixUteriEx { get; set; }    // 宫颈异常
        public string CorpusEx { get; set; }    // 宫体异常
        public string AttachEx { get; set; }   // 附件异常
        public string VulvaEx { get; set; }   // 外阴异常
        public string VaginaEx { get; set; }    // 阴道异常
        public string CERVIX { get; set; }    // 宫颈涂片
        public string CERVIXEx { get; set; }    // 宫颈涂片异常
        public string ToothResides { get; set; }    // 齿列
        public string HypodontiaEx { get; set; }    // 缺齿
        public string SaprodontiaEx { get; set; }   // 龋齿
        public string DentureEx { get; set; }         // 义齿(假牙)
        public string LeftView { get; set; }    // 左眼视力
        public string RightView { get; set; }   // 右眼视力
        public string LeftEyecorrect { get; set; }    // 左眼矫正
        public string RightEyecorrect { get; set; }  // 右眼矫正
    }
}