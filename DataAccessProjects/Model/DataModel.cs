using System;

namespace KangShuoTech.DataAccessProjects.Model
{
    public class DataModel
    {
        // 其他
        public string IDCardNo { get; set; }//身份证ID
        public DateTime TestTime { get; set; }//时间
        public string BloodType { get; set; }//血型
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BMI { get; set; }
        public string Waist { get; set; }

        #region 生化项目47

        //20
        public string FPGL { get; set; }//空腹血糖
        public string FPGDL { get; set; }//空腹血糖
        public string ALBUMIN { get; set; }//尿微量蛋白
        public string FOB { get; set; }//大便潜血1:阴性,2:阳性
        public string HBALC { get; set; }//糖化血红蛋白
        public string HBSAG { get; set; }//乙型肝炎表面抗原1:阴性,2:阳性
        public string SGPT { get; set; }//血清谷丙转氨酶
        public string GOT { get; set; }//血清谷草转氨酶
        public string BP { get; set; }//白蛋白
        public string TBIL { get; set; }//总胆红素
        public string CB { get; set; }//结合胆红素
        public string SCR { get; set; }//血清肌酐
        public string BUN { get; set; }//血尿素氮
        public string PC { get; set; }//血钾浓度
        public string HYPE { get; set; }//血钠浓度
        public string TC { get; set; }//总胆固醇
        public string TG { get; set; }//甘油三酯
        public string LDL_C { get; set; }//血清低密度脂蛋白胆固醇
        public string HDL_C { get; set; }//血清高密度脂蛋白胆固醇
        public string GT { get; set; }//谷氨酰转肽酶
        public string UA { get; set; }//尿酸

        //生化新增项目17
        public string HCY { get; set; }//同型半胱氨酸
        public string IBIL { get; set; }//间接胆红素
        public string TP { get; set; }//总蛋白
        public string GLB { get; set; }//球蛋白
        public string ALP { get; set; }//碱性磷酸酶
        public string CK { get; set; }//肌酸激酶
        public string CK_MB { get; set; }//肌酸激酶同工酶
        public string LDH { get; set; }//乳酸脱氢酶
        public string ESR { get; set; }//血沉
        public string ASO { get; set; }//抗零 1阴性2阳性3弱阳性
        public string CL { get; set; }//氯
        public string CA { get; set; }//钙
        public string MG { get; set; }//镁
        public string AMY { get; set; }//淀粉酶
        public string a_HBDH { get; set; }//a羟丁酸脱氢酶
        public string ASTALT { get; set; }//草丙比
        public string AG { get; set; }//白球比

        //1阴性2阳性3弱阳性10
        public string RF { get; set; }//类风湿因子
        public string HBSAB { get; set; }//乙肝表面抗体
        public string HBEAG { get; set; }//乙肝e抗原
        public string HBEAB { get; set; }//乙肝e抗体
        public string HBCAB { get; set; }//乙肝核心抗体
        public string HCV_AB { get; set; }//丙肝抗体
        public string HIV { get; set; }//艾滋抗体
        public string TPP { get; set; }//梅毒抗体
        public string MP_IGM { get; set; }//支原体抗体
        public string HP_AB { get; set; }//胃幽门抗体

        #endregion

        #region 血球项目26

        //3
        public string HB { get; set; }//血红蛋白
        public string WBC { get; set; }//白细胞
        public string PLT { get; set; }//血小板

        //血球新增项目23个
        public string MID_B { get; set; }//中间细胞百分比
        public string MID_N { get; set; }//中间细胞数目
        public string NEU_B { get; set; }//中性粒细胞百分比
        public string LYMPH_B { get; set; }//淋巴细胞百分比
        public string MON_B { get; set; }//单核细胞百分比
        public string EOS_B { get; set; }//嗜酸性粒细胞百分比
        public string BAS_B { get; set; }//嗜碱性粒细胞百分比

        public string NEU_N { get; set; }//中性粒细胞数目
        public string LYMPH_N { get; set; }//淋巴细胞数目
        public string MON_N { get; set; }//单核细胞数目
        public string EOS_N { get; set; }//嗜酸性粒细胞数目
        public string BAS_N { get; set; }//嗜碱性粒细胞数目

        public string RBC { get; set; }//红细胞数目
        public string HCT { get; set; }//红细胞压积
        public string MCV { get; set; }//平均红细胞体积
        public string MCH { get; set; }//平均红细胞血红蛋白含量
        public string MCHC { get; set; }//平均红细胞血红蛋白浓度

        public string RDW_CV { get; set; }//红细胞分布宽度变异系数
        public string RDW_SD { get; set; }//红细胞分布宽度标准差
        public string MPV { get; set; }//平均血小板体积
        public string PDW { get; set; }//血小板分布宽度
        public string PCT { get; set; }//血小板压积
        public string P_LCR { get; set; }//大血小板比率

        #endregion

        #region 尿检项目18

        //4
        public string PRO { get; set; }//尿蛋白
        public string GLU { get; set; }//尿糖        
        public string KET { get; set; }//尿胴体
        public string BLD { get; set; }//尿潜血

        //14
        public string LEU { get; set; }//尿白细胞
        public string NIT { get; set; }//亚硝酸盐
        public string UBG { get; set; }//尿胆原
        public string BIT_U { get; set; }//胆红素
        public string PH { get; set; }//PH
        public string SG { get; set; }//比重
        public string ASC_U { get; set; }//维生素C
        public string RBC_U { get; set; }//尿红细胞
        public string WBC_U { get; set; }//尿液白细胞
        public string JJ { get; set; }//结晶
        public string GX { get; set; }//管型
        public string SPXB { get; set; }//上皮细胞
        public string NYS { get; set; }//粘液丝
        public string NQ { get; set; }//脓球

        #endregion
    }
}
