
namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]

    public static class RecordsManageMentModel
    {
        public static decimal? BMI { get; set; } //体质指数
        public static decimal? LeftHeight { get; set; } //血压
        public static decimal? LeftPre { get; set; }
        public static decimal? RightHeight { get; set; }
        public static decimal? RightPre { get; set; }
        public static decimal? Waistline { get; set; } //腰围
        public static decimal? PulseRate { get; set; } //脉率

        public static string HBSAG { get; set; } //乙型肝炎表面抗原
        public static string ECG { get; set; } //心电
        public static string ECGEx { get; set; }
        public static string BCHAO { get; set; } //B超
        public static string BCHAOEx { get; set; }

        public static string PRO { get; set; }  //尿蛋白
        public static string GLU { get; set; }  //尿糖
        public static string KET { get; set; }  //尿酮体
        public static string BLD { get; set; }  //尿潜血
        public static string UrineOther { get; set; }  //尿常规其他

        public static decimal? HB { get; set; } //血红蛋白
        public static decimal? WBC { get; set; }//白细胞
        public static decimal? PLT { get; set; }//血小板

        public static decimal? SGPT { get; set; } //血清谷丙转氨酶
        public static decimal? GOT { get; set; }//血清谷草转氨酶
        public static decimal? BP { get; set; }//白蛋白
        public static decimal? TBIL { get; set; }//总胆红素
        public static decimal? CB { get; set; }//结合胆红素 
        public static decimal? GT { get; set; }//谷氨酰转肽酶

        public static decimal? SCR { get; set; }//血清肌酐
        public static decimal? BUN { get; set; }//血尿素氮
        public static decimal? PC { get; set; }//血钾浓度
        public static decimal? HYPE { get; set; }//血钠浓度

        public static decimal? TC { get; set; }//总胆固醇
        public static decimal? TG { get; set; }//甘油三酯
        public static decimal? LowCho { get; set; }//血清低密度脂蛋白胆固醇
        public static decimal? HeiCho { get; set; }//血清高密度脂蛋白胆固醇

        public static decimal? FPGL { get; set; }//空腹血糖
        public static decimal? HCY { get; set; }//同型半胱氨酸
        public static string UA { get; set; }//血清尿酸

        public static string DrinkRate { get; set; }//饮酒
        public static decimal? Height { get; set; } //身高
        public static string SmokeCondition { get; set; }//吸烟
        public static string ExerciseRate { get; set; } // 锻炼频率
        public static string DietaryHabit { get; set; } // 饮食习惯
        public static string ExerciseTimes { get; set; }//锻炼时间

        public static int PhysicalInfoFactoryID { get; set; }//判断是直接进入健康体检还是通过档案查询进入的页面

        //HeartOther- 心血管疾病  ElseOther - 其他系统疾病其它
        public static string BrainDis { get; set; }           //脑血管疾病
        public static string RenalDis { get; set; }          //肾脏疾病肾脏疾病
        public static string HeartDis { get; set; }          //心血管疾病
        public static string EyeDis { get; set; }   //眼部疾病
        public static string NerveDis { get; set; }   //神经系统疾病
        public static string ElseDis { get; set; }   //其他系统疾病
        public static string BrainOther { get; set; }   //脑血管疾病其他
        public static string RenalOther { get; set; }   //肾脏疾病其他
        public static string HeartOther { get; set; }   //心脏疾病其他
        public static string VesselOther { get; set; }   //血管其他疾病
        public static string EyeOther { get; set; }   //眼部其他疾病
        public static string NerveOther { get; set; }   //神经系统疾病其它
        public static string ElseOther { get; set; }   //其他系统疾病其它

        public static decimal? Weight { get;set;}//体重

        public static decimal? HearRate { get; set; }//心率

        public static DateTime CheckDate { get; set; }

        public static string OldSelfCareability { get; set; }//老年人自理能力评估
        public static string Symptom { get; set; }// 症状
        public static string SymptomOther { get; set; }// 症状其他
        public static string Other { get; set; }
        public static string IsDrinkForbiddon { get; set; }//是否戒酒

        /// <summary>
        /// 山东需求判断B超异常带有 不齐字段时，查体信息心律改为不齐
        /// </summary>
        public static string ECGExx { get; set; }

        public static string BarrelChest { get; set; }//桶状胸
        public static string BreathSounds { get; set; }//呼吸音
        public static string Rale { get; set; }//罗音
        public static string HeartRhythm { get; set; }//心律
        public static string Noise { get; set; }//杂音
        /// <summary>
        /// 杂音其他
        /// </summary>
        public static string NoiseEx { get; set; }
        public static string PressPain { get; set; }//压痛
        public static string EnclosedMass { get; set; }//包块
        public static string Liver { get; set; }//肝大
        public static string Spleen { get; set; }//脾大
        public static string Voiced { get; set; }//移动性浊音
        public static string FootBack { get; set; }//足背动脉搏动
        public static string Edema { get; set; }// 下肢水肿
        public static decimal? LeftView { get; set; }//左眼视力
        public static decimal? RightView { get; set; }//右眼视力
        /// <summary>
        /// 心率
        /// </summary>
        public static string HeartRate { get; set; }

        /// <summary>
        /// 听力
        /// </summary>
        public static string Listen { get; set; }

        /// <summary>
        /// 运动能力
        /// </summary>
        public static string SportFunction { get; set; }
    }
}
