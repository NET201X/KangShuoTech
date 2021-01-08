using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KangShuoTech.DataAccessProjects.Model
{
     [Serializable]
    public class RecordsxqModel
    {
         public int ID { get; set; }
         public string IDCardNo { get; set; }
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
         public string FPGL { get; set; }//空腹血糖
         public string SGPT { get; set; }//血清谷丙转氨酶
         public string GOT { get; set; }//血清谷草转氨酶
         public string TBIL { get; set; }//总胆红素
         public string SCR { get; set; }//血清肌酐
         public string BUN { get; set; }//血尿素氮
         public string TC { get; set; }//总胆固醇
         public string TG { get; set; }//甘油三酯
         public string LDL_C { get; set; }//血清低密度脂蛋白胆固醇
         public string HDL_C { get; set; }//血清高密度脂蛋白胆固醇
    }
}
