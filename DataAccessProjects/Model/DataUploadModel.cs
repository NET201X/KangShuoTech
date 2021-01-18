
namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

    [Serializable]

    public class DataUploadModel
    {
        public int ID { get; set; }

        /// <summary>
        /// ARCHIVE_CUSTOMERBASEINFO
        /// </summary>
        /// 
        //ID,IDCardNo,RecordDate,Symptom,SymptomEx,
        public string IDCardNo { get; set; }
        public string RecordDate { get; set; }
        public string Symptom { get; set; } //症状
        public string SymptomEx { get; set; }//

        /// <summary>
        /// ARCHIVE_GENERALCONDITION
        /// </summary>
        /// 
        //OldRecognise,OldEmotion,InterScore,GloomyScore,WaistIp,OldHealthStaus,OldSelfCareability
        public string OldRecognise { get; set; }
        public string OldEmotion { get; set; }
        public string InterScore { get; set; }
        public string GloomyScore { get; set; }
        public string WaistIp { get; set; }
        public string OldHealthStaus { get; set; }
        public string OldSelfCareability { get; set; }

        /// <summary>
        /// ARCHIVE_LIFESTYLE
        /// </summary>
        /// 
        //ExerciseRate,ExerciseTimes,ExcisepersistTime,ExerciseExistense,DietaryHabit,SmokeCondition,SmokeDayNum,
        //SmokeAgeStart,SmokeAgeForbiddon,DrinkRate,DayDrinkVolume,IsDrinkForbiddon,IsDrinkForbiddonEx,DrinkStartAge,
        //DrinkThisYear,DrinkType,CareerHarmFactorHistory,WorkType,WorkTime,Dust,DustProtect,Radiogen,RadiogenProtect,
        //Physical,PhysicalProtect,Chem,ChemProtect,Other,OtherProtect,DrinkTypeEx,DustProtectEx,RadiogenProtectEx,
        //PhysicalProtectEx,ChemProtectEx,OtherProtectEx,35
        public string ExerciseRate { get; set; }//体育锻炼-锻炼频率
        public string ExerciseTimes { get; set; }//体育锻炼-每次锻炼多少分钟
        public string ExcisepersistTime { get; set; }//体育锻炼-坚持锻炼几年
        public string ExerciseExistense { get; set; }//体育锻炼-锻炼方式有哪些
        public string ExerciseExistenseEx { get; set; }//体育锻炼-锻炼方式其他
        public string DietaryHabit { get; set; }//饮食习惯有哪些
        public string SmokeCondition { get; set; }//吸烟状况
        public string SmokeDayNum { get; set; }//平均日吸烟几支
        public string SmokeAgeStart { get; set; }//开始吸烟年龄
        public string SmokeAgeForbiddon { get; set; }//戒烟年龄
        public string DrinkRate { get; set; }//饮酒频率
        public string DayDrinkVolume { get; set; }//平均每天喝几两酒
        public string IsDrinkForbiddon { get; set; }//是否戒酒
        public string IsDrinkForbiddonEx { get; set; }//
        public string DrinkStartAge { get; set; }//开始饮酒年龄
        public string DrinkThisYear { get; set; }//一年内是否有醉酒
        public string DrinkType { get; set; }//饮酒种类有哪些
        public string CareerHarmFactorHistory { get; set; }//
        public string WorkType { get; set; }//
        public string WorkTime { get; set; }//
        public string Dust { get; set; }//
        public string DustProtect { get; set; }//
        public string Radiogen { get; set; }//
        public string RadiogenProtect { get; set; }//
        public string Physical { get; set; }//
        public string PhysicalProtect { get; set; }//
        public string Chem { get; set; }//
        public string ChemProtect { get; set; }//
        public string Other { get; set; }//
        public string OtherProtect { get; set; }//
        public string DrinkTypeEx { get; set; }//
        public string DustProtectEx { get; set; }//
        public string RadiogenProtectEx { get; set; }//
        public string PhysicalProtectEx { get; set; }//
        public string ChemProtectEx { get; set; }//
        public string OtherProtectEx { get; set; }//

        /// <summary>
        /// ARCHIVE_ASSISTCHECK
        /// </summary>
        /// 
        //ARCHIVE_ASSISTCHECK,CHESTX,BCHAO,CERVIX,CHESTXEx,BCHAOEx,CERVIXEx,6
        public string CHESTX { get; set; }//
        public string BCHAO { get; set; }//
        public string CERVIX { get; set; }//
        public string CHESTXEx { get; set; }//
        public string BCHAOEx { get; set; }//
        public string CERVIXEx { get; set; }//

        /// <summary>
        /// ARCHIVE_HEALTHQUESTION
        /// </summary>
        /// 
        //ARCHIVE_HEALTHQUESTION,BrainDis,RenalDis,HeartDis,VesselDis,EyeDis,NerveDis,ElseDis,BrainDisEx,
        //RenalDisEx,HeartDisEx,VesselDisEx,EyeDisEx,NerveDisEx,ElseDisEx,14
        public string BrainDis { get; set; }//健康问题-脑血管疾病
        public string RenalDis { get; set; }//健康问题-肾脏疾病
        public string HeartDis { get; set; }//健康问题-心脏疾病
        public string VesselDis { get; set; }//健康问题-血管疾病
        public string EyeDis { get; set; }//健康问题-眼部疾病
        public string NerveDis { get; set; }//健康问题-神经系统疾病
        public string ElseDis { get; set; }//健康问题-其他系统疾病
        public string BrainDisEx { get; set; }//
        public string RenalDisEx { get; set; }//
        public string HeartDisEx { get; set; }//
        public string VesselDisEx { get; set; }//
        public string EyeDisEx { get; set; }//
        public string NerveDisEx { get; set; }//
        public string ElseDisEx { get; set; }//

        /// <summary>
        /// ARCHIVE_VISCERAFUNCTION
        /// </summary>
        /// 
        //ARCHIVE_VISCERAFUNCTION,Lips,ToothResides,Pharyngeal,LeftView,RightView,LeftEyecorrect,RightEyecorrect,Listen,
        //SportFunction,HypodontiaEx,SaprodontiaEx,DentureEx,12
        public string Lips { get; set; }//口腔-口唇
        public string ToothResides { get; set; }//口腔-齿列
        public string Pharyngeal { get; set; }//口腔-咽部
        public string LeftView { get; set; }//
        public string RightView { get; set; }//
        public string LeftEyecorrect { get; set; }//
        public string RightEyecorrect { get; set; }//
        public string Listen { get; set; }//听力
        public string SportFunction { get; set; }//运动功能
        public string HypodontiaEx { get; set; }//
        public string SaprodontiaEx { get; set; }//
        public string DentureEx { get; set; }//

        /// <summary>
        /// ARCHIVE_PHYSICALEXAM
        /// </summary>
        /// 
        //ARCHIVE_PHYSICALEXAM,EyeRound,Skin,Sclere,Lymph,BarrelChest,BreathSounds,Rale,HeartRate,HeartRhythm,Noise,PressPain,EnclosedMass,
        //Liver,Spleen,Voiced,Edema,FootBack,SkinEx,SclereEx,LymphEx,RaleEx,NoiseEx,LiverEx,SpleenEx,VoicedEx,
        //BarrelChestEx,BreathSoundsEx,PressPainEx,EnclosedMassEx,29
        public string EyeRound { get; set; }//
        public string Skin { get; set; }//
        public string Sclere { get; set; }//
        public string Lymph { get; set; }//
        public string BarrelChest { get; set; }//肺-桶状胸
        public string BreathSounds { get; set; }//肺-呼吸音
        public string Rale { get; set; }//肺-罗音
        public string HeartRate { get; set; }//
        public string HeartRhythm { get; set; }//心脏-心律
        public string Noise { get; set; }//心脏-杂音
        public string PressPain { get; set; }//腹部-压痛
        public string EnclosedMass { get; set; }//腹部-包块
        public string Liver { get; set; }//)腹部-肝大
        public string Spleen { get; set; }//腹部-脾大
        public string Voiced { get; set; }//腹部-移动性浊音
        public string Edema { get; set; }//下肢水肿
        public string FootBack { get; set; }//足背动脉搏动
        public string SkinEx { get; set; }//
        public string SclereEx { get; set; }//
        public string LymphEx { get; set; }//
        public string RaleEx { get; set; }//
        public string NoiseEx { get; set; }//
        public string LiverEx { get; set; }//
        public string SpleenEx { get; set; }//
        public string VoicedEx { get; set; }//
        public string BarrelChestEx { get; set; }//肺-桶状胸
        public string BreathSoundsEx { get; set; }//肺-呼吸音
        public string PressPainEx { get; set; }//腹部-压痛
        public string EnclosedMassEx { get; set; }//腹部-包块
    }

    public class History
    {
        /// <summary>
        /// tbl_recordshistory
        /// </summary>
        /// 
        //InDate,Reason,IllcaseNum,Name,OutDate,InoculationHistory
        public string Type { get; set; }
        public string InDate { get; set; }
        public string Reason { get; set; }
        public string IllcaseNum { get; set; }
        public string Name { get; set; }
        public string OutDate { get; set; }
        public string InoculationHistory { get; set; }
        public int OutKey { get; set; }
    }
}
