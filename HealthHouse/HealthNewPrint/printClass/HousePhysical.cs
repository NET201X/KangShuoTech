using System.Collections.Generic;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;
using System.Windows.Documents;
using ReportPrint;

namespace printClass
{
    public class HousePhysical : IGetReport
	{
        public string CardID
        {
            get;
            set;
        }
        public RecordsBaseInfoModel BaseModel
        {
            get;
            set;
        }
        public string PrintName
        {
            get
            {
                return "34健康小屋体检表.xps";
            }
        }
        public bool hasData()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                HealthHouseModel modelTem = new HealthHouseBLL().GetMaxData(this.CardID);
                if (modelTem!=null)
                {
                    return true;
                }
            }
            return false;
        }
        public FixedDocumentSequence getReport()
        {
            if (!string.IsNullOrEmpty(this.CardID))
            {
                RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.CardID);
                List<ListValue> list = new List<ListValue>
				{
					new ListValue
					{
						strMark = "$archiveid",
						strVal = model.RecordID
					},
					new ListValue
					{
						strMark = "$name",
						strVal = model.CustomerName
					}
				};
                HealthHouseModel Housemodel = new HealthHouseBLL().GetMaxData(this.CardID);
                if (Housemodel != null)
                {
                    list.Add(new ListValue
                    {
                        strMark = "$tjsj",
                        strVal = DrawItems.strToDate(Housemodel.CheckDate, 1)
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zrys",
                        strVal = Housemodel.Doctor
                    });
                    list.Add(new ListValue 
                    {
                        strMark = "$sg",
                        strVal=Housemodel.Height.ToString()
                    });
                    list.Add(new ListValue 
                    {
                        strMark="$tz",
                        strVal=Housemodel.Weight.ToString()
                    });
                    list.Add(new ListValue 
                    {
                        strMark = "$bmi",
                        strVal=Housemodel.BMI.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$ml",
                        strVal = Housemodel.PulseRate.ToString()
                    });
                    list.Add(new ListValue { 
                        strMark="$gy",
                        strVal=Housemodel.LeftHeight.ToString()
                    });
                    list.Add(new ListValue {
                        strMark = "$dy",
                        strVal=Housemodel.LeftPre.ToString()
                    });
                    list.Add(new ListValue {
                        strMark = "$rgy",
                        strVal=Housemodel.RightHeight.ToString()
                    });
                    list.Add(new ListValue {
                        strMark = "$rdy",
                        strVal=Housemodel.RightPre.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#gmd",
                        strVal = Housemodel.Result
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$gmdyc",
                        strVal = Housemodel.ResultEx
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#xxg",
                        strVal = Housemodel.CResult
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xxgyc",
                        strVal = Housemodel.CResultEx
                    });
                    list.Add(new ListValue
                    {
                        strMark = "#fgn",
                        strVal = Housemodel.LResult
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$fgnyc",
                        strVal = Housemodel.LResultEx
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$xy",
                        strVal = Housemodel.BloodOxygen
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$sf",
                        strVal = Housemodel.Water.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zf",
                        strVal = Housemodel.Fat.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$gl",
                        strVal = Housemodel.Skeleton.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$jr",
                        strVal = Housemodel.Muscle.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$kll",
                        strVal = Housemodel.Calorie.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zysl",
                        strVal = Housemodel.LeftView.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$yysl",
                        strVal = Housemodel.RightView.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$yyjz",
                        strVal = Housemodel.RightEyecorrect.ToString()
                    });
                    list.Add(new ListValue
                    {
                        strMark = "$zyjz",
                        strVal = Housemodel.LeftEyecorrect.ToString()
                    });

                    HealthHousePhysicalAssistCheckModel HHassist = new HealthHousePhysicalAssistCheckBLL().GetModel(Housemodel.ID);
                    if (HHassist != null)
                    {
                        list.Add(new ListValue { 
                           strMark="$ncdb",
                           strVal=HHassist.PRO
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncnt",
                            strVal = HHassist.GLU
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$nctt",
                            strVal = HHassist.KET
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncqx",
                            strVal = HHassist.BLD
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncdy",
                            strVal = HHassist.UBG
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncdh",
                            strVal = HHassist.BIL
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncxs",
                            strVal = HHassist.NIT
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$nbxb",
                            strVal = HHassist.LEU
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncbz",
                            strVal = HHassist.SG
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncph",
                            strVal = HHassist.PH
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$ncvx",
                            strVal = HHassist.VC
                        });
                        list.Add(new ListValue
                        {
                            strMark = "#xbx",
                            strVal = HHassist.CHESTX
                        });
                        list.Add(new ListValue
                        {
                            strMark = "$xbxyc",
                            strVal = HHassist.CHESTXEx
                        });
                      
                    }
                }
                return DrawItems.setPage("printXps\\"+PrintName, list);
            }
            return null;
        }
	}
}
