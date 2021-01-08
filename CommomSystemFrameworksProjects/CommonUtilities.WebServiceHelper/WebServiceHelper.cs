using System;
using System.Collections.Generic;
using System.Text;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml;

namespace CommonUtilities.WebServiceHelper
{
    public class WebServiceHelper
    {
        public object send(List<PhysicalModel> models)
        {
            object result = null;
            try
            {
                string currentConfig = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"CommonUtilities.WebServiceHelper.dll.config";

                WebService.MedivaService med = new WebService.MedivaService();
                med.Url = GetAttributeValue(currentConfig);

                object strdata = CombinData(models);
                //Deserialize(strdata);
                result = med.SetMedicalReport(strdata);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        /// <summary>   
       /// 获取配置文件的属性   
       /// </summary>   
       /// <param name="key"></param>   
       /// <returns></returns>   
       private static string GetAttributeValue(string file)  
       {  
           string value = string.Empty;  
  
           try  
           {  
               if (File.Exists(file))  
               {  
                   XmlDocument xml = new XmlDocument();  
  
                   xml.Load(file);

                   XmlNode xNode = xml.SelectSingleNode("//applicationSettings");  
                   value = xNode.InnerText;  
               }  
           }  
           catch { }  
  
           return value;  
       }     
 
        public object CombinData(List<PhysicalModel> models)
        {
            string strcombin = "";
            strcombin += "{Total:" + models.Count.ToString() + "," +
                      "SubmitTime:" + DateTime.Now.Date.ToString("yyyyMMdd") + "," +
                      "MedicalReport:" +
                      "[";
            foreach (PhysicalModel ph in models)
            {
                string strxd = "", strB = "";
                if (ph.ECG == "2")
                {
                    strxd = ph.ECGEx;
                }
                else
                {
                    strxd = ph.ECG;
                }
                if (ph.BCHAO == "2")
                {
                    strB = ph.BCHAOEx;
                }
                else
                {
                    strB = ph.BCHAO;
                }
                strcombin += "{" +
                           "IDNumber:" + "'"+ph.IDCardNo + "'," +
                           "MedicalTime:" + "'" + ph.CheckDate + "'," +
                           "Height:" + "'" + ph.Height + "'," +
                           "Weight:" + "'" + ph.Weight + "'," +
                           "WeightIndex:" + "'" + ph.BMI + "'," +
                           "WaistPerimeter:" + "'" + ph.Waistline + "'," +
                           "LeftBloodPress:" + "'" + ph.LeftHeight +"/" +ph.LeftPre + "'," +
                           "RightBloodPress:" + "'" + ph.RightHeight + "/" + ph.RightPre + "'," +
                           "HGB:" + "'" + ph.HB + "'," +
                           "WBC:" + "'" + ph.WBC + "'," +
                           "PLT:" + "'" + ph.PLT + "'," +
                           "BloodType:" + "'" + ph.BloodType + "'," +
                           "UrineProtein:" + "'" + ph.PRO + "'," +
                           "UrineSugar:" + "'" + ph.GLU + "'," +
                           "KET:" + "'" + ph.KET + "'," +
                           "Hematuria:" + "'" + ph.BLD + "'," +
                           "BeforeBloodSugar:" + "'" + ph.FPGDL + "'," +
                           "AfterBloodSugar:" + "'" + ph.AFPGDL + "'," +
                           "ALT:" + "'" + ph.SGPT + "'," +
                           "AST:" + "'" + ph.GOT + "'," +
                           "Alb:" + "'" + ph.BP + "'," +
                           "STB:" + "'" + ph.TBIL + "'," +
                           "DBIL:" + "'" + ph.CB + "'," +
                           "Cr:" + "'" + ph.SCR + "'," +
                           "BUN:" + "'" + ph.BUN + "'," +
                           "Blood_K:" + "'" + ph.PC + "'," +
                           "Blood_Na:" + "'" + ph.HYPE + "'," +
                           "TC:" + "'" + ph.TC + "'," +
                           "TG:" + "'" + ph.TG + "'," +
                           "HDL_C:" + "'" + ph.HeiCho + "'," +
                           "LDL_C:" + "'" + ph.LowCho + "'," +
                           "ECG:" + "'" +strxd + "'," +
                           "BScan:" + "'" + strB +"',"+
                           "Remark:"+ "'" + ph.Remark +"',"+
                           "DoctorName:" + "'" + ph.DoctorName + "'," +
                           "MedicalResults:" + "'" + ph.MedicalResults + "'," +
                            "Skin:" + "'" + ph.Skin + "'," +
                            "SkinEx:" + "'" + ph.SkinEx + "'," +
                            "Sclera:" + "'" + ph.Sclera + "'," +
                            "ScleraEx:" + "'" + ph.ScleraEx + "'," +
                            "Lymph:" + "'" + ph.Lymph + "'," +
                            "LymphEx:" + "'" + ph.LymphEx + "'," +
                            "BarrelChest:" + "'" + ph.BarrelChest + "'," +
                            "BreathSounds:" + "'" + ph.BreathSounds + "'," +
                            "BreathSoundsEx:" + "'" + ph.BreathSoundsEx + "'," +
                            "Rale:" + "'" + ph.Rale + "'," +
                            "RaleEx:" + "'" + ph.RaleEx + "'," +
                            "HeartRate:" + "'" + ph.HeartRate + "'," +
                            "HeartRhythm:" + "'" + ph.HeartRhythm + "'," +
                            "Noise:" + "'" + ph.Noise + "'," +
                            "NoiseEx:" + "'" + ph.NoiseEx + "'," +
                            "PressPain:" + "'" + ph.PressPain + "'," +
                            "PressPainEx:" + "'" + ph.PressPainEx + "'," +
                            "EnclosedMass:" + "'" + ph.EnclosedMass + "'," +
                            "EnclosedMassEx:" + "'" + ph.EnclosedMassEx + "'," +
                            "Liver:" + "'" + ph.Liver + "'," +
                            "LiverEx:" + "'" + ph.LiverEx + "'," +
                            "Spleen:" + "'" + ph.Spleen + "'," +
                            "SpleenEx:" + "'" + ph.SpleenEx + "'," +
                            "Voiced:" + "'" + ph.Voiced + "'," +
                            "VoicedEx:" + "'" + ph.VoicedEx + "'," +
                            "Edema:" + "'" + ph.Edema + "'," +
                            "FootBack:" + "'" + ph.FootBack + "'," +
                            "CHESTX:" + "'" + ph.CHESTX + "'," +
                            "CHESTXEx:" + "'" + ph.CHESTXEx + "'," +
                            "Address:" + "'" + ph.Address + "'," +
                            "Phone:" + "'" + ph.Phone + "'," +
                            "WorkUnit:" + "'" + ph.WorkUnit + "'," +
                            "Cervix:" + "'" + ph.CERVIX + "'," +
                            "CervixEx:" + "'" + ph.CERVIXEx + "'," +
                            "Breast:" + "'" + ph.Breast + "'," +
                            "Vulva:" + "'" + ph.Vulva + "'," +
                            "Vagina:" + "'" + ph.Vagina + "'," +
                            "CervixUteri:" + "'" + ph.CervixUteri + "'," +
                            "Corpus:" + "'" + ph.Corpus + "'," +
                            "Attach:" + "'" + ph.Attach + "'," +
                            "BreastEx:" + "'" + ph.BreastEx + "'," +
                            "CervixUteriEx:" + "'" + ph.CervixUteriEx + "'," +
                            "CorpusEx:" + "'" + ph.CorpusEx + "'," +
                            "AttachEx:" + "'" + ph.AttachEx + "'," +
                            "VulvaEx:" + "'" + ph.VulvaEx + "'," +
                            "VaginaEx:" + "'" + ph.VaginaEx + "'," +
                            "ToothResides:" + "'" + ph.ToothResides + "'," +
                            "HypodontiaEx:" + "'" + ph.HypodontiaEx + "'," +
                            "SaprodontiaEx:" + "'" + ph.SaprodontiaEx + "'," +
                            "DentureEx:" + "'" + ph.DentureEx + "'," +
                            "LeftView:" + "'" + ph.LeftView + "'," +
                            "RightView:" + "'" + ph.RightView + "'," +
                            "LeftEyecorrect:" + "'" + ph.LeftEyecorrect + "'," +
                            "RightEyecorrect:" + "'" + ph.RightEyecorrect + "'" +
                           " },";
            }
            strcombin = strcombin.Remove(strcombin.Length - 1);
            strcombin += "]}";

            return strcombin;   
        }

        /// <summary>  
        /// 生成Json格式  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
        public string GetJson(object obj)
        {
            if (obj == null)
                return "";

            DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Position = 0;
                json.WriteObject(stream, obj);
                string szJson = Encoding.UTF8.GetString(stream.ToArray());
                return szJson;
            }
        }

        //反序列化
        public WebResult Deserialize(object obj)
        {
            string toDes = GetJson(obj);//生成Json格式
            WebResult webre = new WebResult();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                ms.Position = 0;
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(WebResult));
                webre = (WebResult)deseralizer.ReadObject(ms);
            }
            return webre;
        }
    }
}
