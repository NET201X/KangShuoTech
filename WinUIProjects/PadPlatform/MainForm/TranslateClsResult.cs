using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommunicationData;

namespace KangShuo
{
    using System;
    using System.Data;
    using System.Text;

    internal class TranslateClsResult
    {
        public static void BUToMOdel(string strType, ref DeviceInfoModel devInfo)
        {
            switch (strType)
            {
                case "尿胆原":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.URO_NiaoDanYuan;
                    return;

                case "潜 血":
                    devInfo.Value2 = ClsResult.DeviceValue.QCTBU.BLD_QianXue;
                    return;

                case "胆红素":
                    devInfo.Value3 = ClsResult.DeviceValue.QCTBU.BIL_DanHongSu;
                    return;

                case "尿酮体":
                    devInfo.Value4 = ClsResult.DeviceValue.QCTBU.KET_TongTi;
                    return;

                case "葡萄糖":
                    devInfo.Value5 = ClsResult.DeviceValue.QCTBU.GLU_PuTaoTang;
                    return;

                case "蛋白质":
                    devInfo.Value6 = ClsResult.DeviceValue.QCTBU.PRO_DanBaiZhi;
                    return;

                case "PH值":
                    devInfo.Value7 = ClsResult.DeviceValue.QCTBU.PH;
                    return;

                case "亚硝酸盐":
                    devInfo.Value8 = ClsResult.DeviceValue.QCTBU.NIT_XiaoSuanYan;
                    return;

                case "白细胞":
                    devInfo.Value9 = ClsResult.DeviceValue.QCTBU.LEU_BaiXiBao;
                    return;

                case "比重":
                    devInfo.Value10 = ClsResult.DeviceValue.QCTBU.SG_BiZhong;
                    return;

                case "维生素C":
                    devInfo.Value11 = ClsResult.DeviceValue.QCTBU.VC;
                    return;

                case "胆固醇":
                case "总胆固醇":
                    devInfo.DeviceName = "血总胆固醇";
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.DanGuChun;
                    devInfo.DeviceType = "35";
                    return;

                case "甘油三酯":
                    devInfo.DeviceName = "血甘油三脂";
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.GanYouSanZhi;
                    devInfo.DeviceType = "35";
                    return;

                case "血清高密度脂蛋白胆固醇":
                case "高密度脂蛋白":
                    devInfo.DeviceName = "血高密度脂蛋白";
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.GaoMiDu;
                    devInfo.DeviceType = "35";
                    return;

                case "血酮体":
                    devInfo.DeviceName = "血酮体";
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.XueTongTi;
                    devInfo.DeviceType = "35";
                    return;

                case "血糖":
                    devInfo.DeviceName = "血糖";
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.XueTang;
                    devInfo.Value3 = "0";
                    devInfo.DeviceType = "35";
                    return;

                case "低密度脂蛋白":
                    devInfo.DeviceName = "低密度脂蛋白";
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.DiMiDu;
                    devInfo.DeviceType = "35";
                    return;

                case "肌酐":
                    devInfo.DeviceName = "肌酐";
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBU.JiGan;
                    devInfo.DeviceType = "35";
                    return;
            }
        }

        private static string DDwidth(string str)
        {
            int byteCount = Encoding.Default.GetByteCount(str);
            string str2 = str;
            int num2 = 0x12;
            if (byteCount < num2)
            {
                for (int i = 0; i < (num2 - byteCount); i++)
                {
                    str2 = str2 + " ";
                }
            }
            return str2;
        }

        public static string GetDeviceCName(string name)
        {
            switch (name)
            {
                case "QCTBG":
                    return "血糖";

                case "QCTBH":
                    return "身高";

                case "QCTBP":
                    return "血压";

                case "CHITBP":
                    return "血压";

                case "QCTBT":
                    return "血氧饱和仪";

                case "QCTBU":
                    return "干式血生化";

                case "QCTBM":
                    return "体重";

                case "QCTTF":
                    return "体温";

                case "QCTUI":
                case "EMPUI":
                    return "尿液";

                case "QCTUR":
                    return "33";

                case "QCTBC":
                    return "综合采集";

                case "QCTBE":
                    return "单导心电";

                case "QCTHB":
                    return "血红蛋白仪";

                case "QCTZQ":
                    return "中旗心电图机";
            }
            return "";
        }

        public static string GetDeviceType(string name)
        {
            switch (name)
            {
                case "QCTBG":
                    return "24";

                case "QCTBH":
                    return "39";

                case "QCTBP":
                    return "20";

                case "CHITBP":
                    return "20";

                case "QCTBT":
                    return "32";

                case "QCTBU":
                    return "33";

                case "QCTBM":
                    return "22";

                case "QCTTF":
                    return "40";

                case "QCTUI":
                case "EMPUI":
                    return "33";

                case "QCTUR":
                    return "33";

                case "QCTBC":
                    return "34";

                case "QCTBE":
                    return "41";

                case "QCTHB":
                    return "52";

                case "QCTZQ":
                    return "97";
            }
            return "";
        }

        public static string GetTableColumn(DeviceInfoModel dev, string name, out string col_value)
        {
            string str = "";
            switch (name)
            {
                case "尿胆原":
                    str = "Value1";
                    col_value = dev.Value1;
                    return str;

                case "潜 血":
                    str = "Value2";
                    col_value = dev.Value2;
                    return str;

                case "胆红素":
                    str = "Value3";
                    col_value = dev.Value3;
                    return str;

                case "尿酮体":
                    str = "Value4";
                    col_value = dev.Value4;
                    return str;

                case "葡萄糖":
                    str = "Value5";
                    col_value = dev.Value5;
                    return str;

                case "蛋白质":
                    str = "Value6";
                    col_value = dev.Value6;
                    return str;

                case "PH值":
                    str = "Value7";
                    col_value = dev.Value7;
                    return str;

                case "亚硝酸盐":
                    str = "Value8";
                    col_value = dev.Value8;
                    return str;

                case "白细胞":
                    str = "Value9";
                    col_value = dev.Value9;
                    return str;

                case "比重":
                    str = "Value10";
                    col_value = dev.Value10;
                    return str;

                case "维生素C":
                    str = "Value11";
                    col_value = dev.Value11;
                    return str;
            }
            col_value = "0";
            return str;
        }

        public static void set_tj_content(DeviceInfoModel devinfo)
        {
            ClsMsgWindow.MSG_BT bG = ClsMsgWindow.MSG_BT.BG;
            string str = "";
            switch (ClsResult.DeviceName)
            {
                case "QCTBG":
                    bG = ClsMsgWindow.MSG_BT.BG;
                    str = "辅助检查";
                    break;

                case "QCTBH":
                    bG = ClsMsgWindow.MSG_BT.BH;
                    str = "一般情况";
                    break;

                case "QCTBP":
                    bG = ClsMsgWindow.MSG_BT.BP;
                    str = "一般情况";
                    break;

                case "CHITBP":
                    bG = ClsMsgWindow.MSG_BT.BP;
                    str = "一般情况";
                    break;

                case "QCTBT":
                    bG = ClsMsgWindow.MSG_BT.BT;
                    str = "一般情况";
                    break;

                case "QCTBU":
                    bG = ClsMsgWindow.MSG_BT.BU;
                    str = "辅助检查";
                    break;

                case "QCTBM":
                    bG = ClsMsgWindow.MSG_BT.BW;
                    str = "一般情况";
                    break;

                case "QCTTF":
                    bG = ClsMsgWindow.MSG_BT.TF;
                    str = "一般情况";
                    break;

                case "QCTUI":
                case "EMPUI":
                    bG = ClsMsgWindow.MSG_BT.UI;
                    str = "辅助检查";
                    break;

                case "QCTUR":
                    bG = ClsMsgWindow.MSG_BT.UI;
                    str = "辅助检查";
                    break;

                case "QCTZQ":
                    bG = ClsMsgWindow.MSG_BT.ZQ;
                    str = "辅助检查";
                    break;
            }

            if (!string.IsNullOrEmpty(str))
            {
                ClsMsgWindow.postMsgToWnd("体检档案", (int) bG);
            }
        }

        public static bool TranslateToModel(DeviceInfoModel devInfo, RecordsBaseInfoModel baseinfo)
        {
            bool flag = false;
            devInfo.DeviceName = ClsResult.DeviceFriendName;
            devInfo.DeviceType = GetDeviceType(ClsResult.DeviceName);
            devInfo.FirstName = ClsResult.DeviceName;
            switch (ClsResult.DeviceName)
            {
                case "QCTBG":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBG.XueTang;
                    return flag;

                case "QCTBH":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBH.ShenGao;
                    devInfo.Value2 = ClsResult.DeviceValue.QCTBH.TiZhong;
                    devInfo.Value3 = ClsResult.DeviceValue.QCTBH.ZhiShu;
                    return flag;

                case "QCTBP":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBP.GaoYa;
                    devInfo.Value2 = ClsResult.DeviceValue.QCTBP.DiYa;
                    devInfo.Value3 = ClsResult.DeviceValue.QCTBP.XinLv;
                    return flag;

                case "CHITBP":
                    devInfo.Value1 = ClsResult.DeviceValue.CHITBP.GaoYa;
                    devInfo.Value2 = ClsResult.DeviceValue.CHITBP.DiYa;
                    devInfo.Value3 = ClsResult.DeviceValue.CHITBP.XinLv;
                    return flag;

                case "QCTBT":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBT.XueYang;
                    devInfo.Value2 = ClsResult.DeviceValue.QCTBT.MaiLv;
                    ClsResult.DeviceValue.QCTBT.XueYang = string.Empty;
                    ClsResult.DeviceValue.QCTBT.MaiLv = string.Empty;
                    return flag;

                case "QCTBPT":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBPT.GaoYa;
                    devInfo.Value2 = ClsResult.DeviceValue.QCTBPT.DiYa;
                    devInfo.Value3 = ClsResult.DeviceValue.QCTBPT.XinLv;
                    devInfo.Value4 = ClsResult.DeviceValue.QCTBPT.XueYang;
                    devInfo.Value5 = ClsResult.DeviceValue.QCTBPT.MaiLv;
                    return flag;

                case "QCTBU":
                    if (!(ClsResult.DeviceFriendName == "尿液"))
                    {
                        if (ClsResult.DeviceFriendName == "血液")
                        {
                            devInfo.DeviceName = ClsResult.DeviceValue.QCTBU.ChildType;
                        }
                        break;
                    }
                    devInfo.DeviceName = "尿液";
                    devInfo.ChildTypeBu = ClsResult.DeviceValue.QCTBU.ChildType;
                    break;

                case "QCTCOMBU":
                case "QCTAKBU":
                    if (!(ClsResult.DeviceFriendName == "血生化"))
                    {
                        return flag;
                    }
                    devInfo.DeviceName = ClsResult.DeviceValue.QCTBU.ChildType;
                    if ((ClsResult.m_UnitList != null) && (ClsResult.m_UnitList.Count > 0))
                    {
                        foreach (TYPEANDVALUE typeandvalue in ClsResult.m_UnitList)
                        {
                            BUToMOdel(typeandvalue.ChildType, ref devInfo);
                            new DeviceInfoBLL().Add(devInfo);
                        }
                    }
                    return true;

                case "QCTBM":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTBM.TiZhong;
                    return flag;

                case "QCTTF":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTTF.TiWen;
                    return flag;

                case "QCTUI":
                case "EMPUI":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTUI.URO_NiaoDanYuan;
                    devInfo.Value2 = ClsResult.DeviceValue.QCTUI.BLD_QianXue;
                    devInfo.Value3 = ClsResult.DeviceValue.QCTUI.BIL_DanHongSu;
                    devInfo.Value4 = ClsResult.DeviceValue.QCTUI.KET_TongTi;
                    devInfo.Value5 = ClsResult.DeviceValue.QCTUI.GLU_PuTaoTang;
                    devInfo.Value6 = ClsResult.DeviceValue.QCTUI.PRO_DanBaiZhi;
                    devInfo.Value7 = ClsResult.DeviceValue.QCTUI.PH;
                    devInfo.Value8 = ClsResult.DeviceValue.QCTUI.NIT_XiaoSuanYan;
                    devInfo.Value9 = ClsResult.DeviceValue.QCTUI.LEU_BaiXiBao;
                    devInfo.Value10 = ClsResult.DeviceValue.QCTUI.SG_BiZhong;
                    devInfo.Value11 = ClsResult.DeviceValue.QCTUI.VC;
                    return flag;

                case "QCTHB":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTHB.HB;
                    devInfo.Value2 = ClsResult.DeviceValue.QCTHB.HTC;
                    return flag;

                case "QCTZQ":
                    devInfo.Value1 = ClsResult.DeviceValue.QCTZQ.result;
                    return flag;

                default:
                    return flag;
            }
            BUToMOdel(ClsResult.DeviceValue.QCTBU.ChildType, ref devInfo);
            return flag;
        }

        public static string TranslateToStr()
        {
            StringBuilder builder = new StringBuilder();
            switch (ClsResult.DeviceName)
            {
                case "QCTBG":
                    builder.Append("血糖 " + ClsResult.DeviceValue.QCTBG.XueTang + " mmol/L");
                    goto Label_0DF9;

                case "QCTBH":
                    builder.Append("身高 " + ClsResult.DeviceValue.QCTBH.ShenGao + " cm");
                    goto Label_0DF9;

                case "QCTBE":
                    builder.Append("单导心电");
                    builder.Append("#" + ClsResult.DeviceValue.QCTBE.pointValue + "\r");
                    goto Label_0DF9;

                case "QCTBF":
                    builder.Append("BMI " + ClsResult.DeviceValue.QCTBF.BMI + "\r");
                    builder.Append("骨量 " + ClsResult.DeviceValue.QCTBF.GuLiang + "\r\n");
                    builder.Append("基础代谢 " + ClsResult.DeviceValue.QCTBF.JiChuDaiXie + "\r");
                    builder.Append("肌肉 " + ClsResult.DeviceValue.QCTBF.JiRou + "\r\n");
                    builder.Append("内脂 " + ClsResult.DeviceValue.QCTBF.NeiZhi + "\r");
                    builder.Append("水分 " + ClsResult.DeviceValue.QCTBF.ShuiFen + "\r\n");
                    builder.Append("体重 " + ClsResult.DeviceValue.QCTBF.TiZhong + "\r");
                    builder.Append("脂肪 " + ClsResult.DeviceValue.QCTBF.ZhiFang + "\r\n");
                    builder.Append("KCAL " + ClsResult.DeviceValue.QCTBF.ZuKang + "\r");
                    goto Label_0DF9;

                case "QCTBP":
                    builder.Append("收缩压 " + ClsResult.DeviceValue.QCTBP.GaoYa + "mmHg\r\n");
                    builder.Append("舒张压 " + ClsResult.DeviceValue.QCTBP.DiYa + "mmHg\r\n");
                    builder.Append("心率 " + ClsResult.DeviceValue.QCTBP.XinLv + "次/分钟\r\n");
                    goto Label_0DF9;

                case "CHITBP":
                    builder.Append("收缩压 " + ClsResult.DeviceValue.CHITBP.GaoYa + "mmHg\r\n");
                    builder.Append("舒张压 " + ClsResult.DeviceValue.CHITBP.DiYa + "mmHg\r\n");
                    builder.Append("心率 " + ClsResult.DeviceValue.CHITBP.XinLv + "次/分钟\r\n");
                    goto Label_0DF9;

                case "QCTBT":
                    builder.Append("血氧 " + ClsResult.DeviceValue.QCTBT.XueYang + "\r\n");
                    builder.Append("脉率 " + ClsResult.DeviceValue.QCTBT.MaiLv + "\r\n");
                    goto Label_0DF9;

                case "QCTBPT":
                    builder.Append("收缩压 " + ClsResult.DeviceValue.QCTBPT.GaoYa + "mmHg\r\n");
                    builder.Append("舒张压 " + ClsResult.DeviceValue.QCTBPT.DiYa + "mmHg\r\n");
                    builder.Append("心率 " + ClsResult.DeviceValue.QCTBPT.XinLv + "\r\n");
                    builder.Append("血氧 " + ClsResult.DeviceValue.QCTBPT.XueYang + "\r\n");
                    builder.Append("脉率 " + ClsResult.DeviceValue.QCTBPT.MaiLv + "\r\n");
                    goto Label_0DF9;

                case "QCTCOMBU":
                case "QCTAKBU":
                    if (ClsResult.m_UnitList.Count > 0)
                    {
                        foreach (TYPEANDVALUE typeandvalue in ClsResult.m_UnitList)
                        {
                            if (typeandvalue.ChildType != "低密度脂蛋白")
                            {
                                builder.Append(typeandvalue.ChildType + "  " + typeandvalue.Value + "\r\n");
                            }
                        }
                    }
                    goto Label_0DF9;

                case "QCTBU":
                    switch (ClsResult.DeviceValue.QCTBU.ChildType)
                    {
                        case "尿胆原":
                            builder.Append("尿胆原UBG " + ClsResult.DeviceValue.QCTBU.URO_NiaoDanYuan + "\r\n");
                            break;

                        case "潜 血":
                            builder.Append("潜血BLD " + ClsResult.DeviceValue.QCTBU.BLD_QianXue + "\r\n");
                            break;

                        case "胆红素":
                            builder.Append("胆红素BIL " + ClsResult.DeviceValue.QCTBU.BIL_DanHongSu + "\r\n");
                            break;

                        case "尿酮体":
                            builder.Append("酮体KET " + ClsResult.DeviceValue.QCTBU.KET_TongTi + "\r\n");
                            break;

                        case "葡萄糖":
                            builder.Append("葡萄糖GLU " + ClsResult.DeviceValue.QCTBU.GLU_PuTaoTang + "\r\n");
                            break;

                        case "蛋白质":
                            builder.Append("蛋白质PRO " + ClsResult.DeviceValue.QCTBU.PRO_DanBaiZhi + "\r\n");
                            break;

                        case "PH值":
                            builder.Append("PH " + ClsResult.DeviceValue.QCTBU.PH + "\r\n");
                            break;

                        case "亚硝酸盐":
                            builder.Append("硝酸盐NIT " + ClsResult.DeviceValue.QCTBU.NIT_XiaoSuanYan + "\r\n");
                            break;

                        case "白细胞":
                            builder.Append("白细胞LEU " + ClsResult.DeviceValue.QCTBU.LEU_BaiXiBao + "\r\n");
                            break;

                        case "比重":
                            builder.Append("比重SG " + ClsResult.DeviceValue.QCTBU.SG_BiZhong + "\r\n");
                            break;

                        case "维生素C":
                            builder.Append("VC " + ClsResult.DeviceValue.QCTBU.VC + "\r\n");
                            break;

                        case "胆固醇":
                            builder.Append("胆固醇 " + ClsResult.DeviceValue.QCTBU.DanGuChun + "\r\n");
                            break;

                        case "甘油三酯":
                            builder.Append("甘油三酯 " + ClsResult.DeviceValue.QCTBU.GanYouSanZhi + "\r\n");
                            break;

                        case "血清高密度脂蛋白胆固醇":
                            builder.Append("血清高密度脂蛋白胆固醇 " + ClsResult.DeviceValue.QCTBU.GaoMiDu + "\r\n");
                            break;

                        case "血酮体":
                            builder.Append("血酮体 " + ClsResult.DeviceValue.QCTBU.XueTongTi + "\r\n");
                            break;

                        case "血糖":
                            builder.Append("血糖 " + ClsResult.DeviceValue.QCTBU.XueTang + "\r\n");
                            break;
                    }
                    goto Label_0DF9;

                case "QCTBM":
                    builder.Append("体重 " + ClsResult.DeviceValue.QCTBM.TiZhong + "Kg\r\n");
                    goto Label_0DF9;

                case "QCTTF":
                    builder.Append("体温 " + ClsResult.DeviceValue.QCTTF.TiWen + "℃\r\n");
                    goto Label_0DF9;

                case "QCTUI":
                    builder.Append(DDwidth("尿胆原URO " + ClsResult.DeviceValue.QCTUI.URO_NiaoDanYuan));
                    builder.Append("潜血BLD " + ClsResult.DeviceValue.QCTUI.BLD_QianXue + "\r\n");
                    builder.Append(DDwidth("胆红素BIL " + ClsResult.DeviceValue.QCTUI.BIL_DanHongSu));
                    builder.Append("酮体KET " + ClsResult.DeviceValue.QCTUI.KET_TongTi + "\r\n");
                    builder.Append(DDwidth("白细胞LEU " + ClsResult.DeviceValue.QCTUI.LEU_BaiXiBao));
                    builder.Append("葡萄糖GLU " + ClsResult.DeviceValue.QCTUI.GLU_PuTaoTang + "\r\n");
                    builder.Append(DDwidth("蛋白质PRO " + ClsResult.DeviceValue.QCTUI.PRO_DanBaiZhi));
                    builder.Append("PH " + ClsResult.DeviceValue.QCTUI.PH + "\r\n");
                    builder.Append(DDwidth("亚硝酸盐NIT " + ClsResult.DeviceValue.QCTUI.NIT_XiaoSuanYan));
                    builder.Append("比重SG " + ClsResult.DeviceValue.QCTUI.SG_BiZhong + "\r\n");
                    builder.Append(DDwidth("VC " + ClsResult.DeviceValue.QCTUI.VC + " "));
                    goto Label_0DF9;

                case "QCTHB":
                    builder.Append("HB:" + ClsResult.DeviceValue.QCTHB.HB + "g/dL\r\n");
                    builder.Append("HTC:" + ClsResult.DeviceValue.QCTHB.HTC + "\r\n");
                    goto Label_0DF9;

                case "QCTZQ":
                    builder.Append("结果:" + ClsResult.DeviceValue.QCTZQ.result + "\r\n");
                    goto Label_0DF9;

                default:
                    goto Label_0DF9;
            }
            string dataType = ClsResult.DeviceValue.QCTBC.DataType;
            if (dataType != null)
            {
                if (!(dataType == "幽门螺杆菌"))
                {
                    if (dataType == "身高")
                    {
                        builder.Append("身高（CM）： " + ClsResult.DeviceValue.QCTBC.Height);
                    }
                    else if (dataType == "三围")
                    {
                        builder.Append("胸围 " + ClsResult.DeviceValue.QCTBC.Xiongwei + "\r\n");
                        builder.Append("腰围 " + ClsResult.DeviceValue.QCTBC.Yaowei + "\r\n");
                        builder.Append("臀围 " + ClsResult.DeviceValue.QCTBC.Tunwei);
                    }
                }
                else
                {
                    builder.Append("幽门螺杆菌/HP： " + ClsResult.DeviceValue.QCTBC.HP_YouMen);
                }
            }
        Label_0DF9:
            return builder.ToString();
        }
    }
}

