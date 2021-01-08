namespace KangShuoTech.DataAccessProjects.Model
{
    using System;

     [Serializable]
    public class WomenGravidaTwoToFiveVisitModel
    {
          public int ID { get; set; } 
		  public string CustomerID { get; set; } 
		  public string RecordID { get; set; }  
		  public string IDCardNo { get; set; }  
		  public decimal? Times { get; set; } 
		  public DateTime? FollowupDate { get; set; } 
		  public decimal? PregancyWeeks { get; set; } 
		  public string ChiefComPlaint { get; set; }  
		  public decimal? Weight { get; set; } 
		  public decimal? UteruslowHeight { get; set; } 
		  public decimal? AbdominalCirumference { get; set; } 
		  public string FetusPosition { get; set; }  
		  public decimal? FHR { get; set; } 
		  public decimal? HBloodPressure { get; set; } 
		  public decimal? LBloodPressure { get; set; } 
		  public decimal? HB { get; set; } 
		  public string AssistanTexam { get; set; }  
		  public string Classification { get; set; }  
		  public string ClassificationEx { get; set; }  
		  public string Advising { get; set; }  
		  public string AdvisingOther { get; set; }  
		  public string Referral { get; set; }  
		  public string ReferralReason { get; set; }  
		  public string ReferralOrg { get; set; }  
		  public DateTime? NextFollowupDate { get; set; }  
		  public string FollowUpDoctor { get; set; }  
		  public decimal? CreatedBy { get; set; }
          public string PRO { get; set; }  
		  public DateTime? CreatedDate { get; set; } 
		  public decimal? LastUpdateBy { get; set; } 
		  public DateTime? LastUpdateDate { get; set; } 
		  public string IsDel { get; set; }

          public string FollowupWay { get; set; }//随访方式
          public string PrenatalOrg { get; set; }//产前检查机构
          public string ReferralContacts { get; set; }//转诊联系人
          public string ReferralContactsTel { get; set; }//转诊联系人电话
          public string ReferralResult { get; set; }//转诊结果
          public string FreeSerumCheck { get; set; }//是否免费血清检查
          public string SerumCheckResult { get; set; }//血清检查结果
    }
}

