using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClsGetDevInfo
    {
        public static stru_result GetDevData(string IDCardNo, string DeviceType)
        {
            stru_result _result = new stru_result();
            List<DeviceInfoModel> modelList = new DeviceInfoBLL().GetModelList((!(DeviceType == "24") ? 
                string.Format(" IDCardNo = '{0}' and DeviceType = '{1}' ", IDCardNo, DeviceType) : 
                string.Format(" IDCardNo = '{0}' and (DeviceType = 24 or (DeviceType = 35 and DeviceName = '血糖' )) ", IDCardNo, DeviceType)) + 
                " order by id desc ");
            if ((modelList != null) && (modelList.Count > 0))
            {
                _result.type = DeviceType;
                _result.HasValue = true;
                _result.datetime = modelList[0].UpdateData;
                _result.value1 = modelList[0].Value1;
                if (DeviceType == "20")
                {
                    _result.value2 = modelList[0].Value2;
                    _result.value3 = modelList[0].Value3;
                }
                if (DeviceType == "39")
                {
                    _result.value2 = modelList[0].Value2;
                    _result.value3 = modelList[0].Value3;
                }
                if (DeviceType == "33")
                {
                    _result.value2 = modelList[0].Value2;
                    _result.value3 = modelList[0].Value3;
                    _result.value4 = modelList[0].Value4;
                    _result.value5 = modelList[0].Value5;
                    _result.value6 = modelList[0].Value6;
                    _result.value7 = modelList[0].Value7;
                    _result.value8 = modelList[0].Value8;
                    _result.value9 = modelList[0].Value9;
                    _result.value10 = modelList[0].Value10;
                    _result.value11 = modelList[0].Value11;
                }
                if (DeviceType == "32")
                {
                    _result.value2 = modelList[0].Value2;
                }
                return _result;
            }
            _result.HasValue = false;
            return _result;
        }

        public static stru_result GetDevData(string IDCardNo, string DeviceType, string DeviceName)
        {
            stru_result _result = new stru_result();
            string str = string.Format(" IDCardNo = '{0}' and DeviceType = '{1}' ", IDCardNo, DeviceType);

            if (DeviceType == "20")
            {
                if (DeviceName == "心率")
                {
                    str = str + string.Format(" and Value3 != '' ", new object[0]);
                }
                if (DeviceName == "血压")
                {
                    str = str + string.Format(" and Value1 != '' ", new object[0]);
                }
            }
            List<DeviceInfoModel> modelList = new DeviceInfoBLL().GetModelList(str + " order by id desc ");
            if ((modelList != null) && (modelList.Count > 0))
            {
                _result.type = DeviceType;
                _result.HasValue = true;
                _result.datetime = modelList[0].UpdateData;
                _result.value1 = modelList[0].Value1;
                if (DeviceType == "20")
                {
                    if (DeviceName == "血压")
                    {
                        DeviceInfoModel deviceinfo = modelList.First<DeviceInfoModel>(mc => !string.IsNullOrEmpty(mc.Value1 + mc.Value2));
                        if (deviceinfo != null)
                        {
                            _result.value1 = deviceinfo.Value1;
                            _result.value2 = deviceinfo.Value2;
                            _result.value3 = deviceinfo.Value3;
                        }
                    }
                    else if (DeviceName == "心率")
                    {
                        DeviceInfoModel deviceinfo2 = modelList.First<DeviceInfoModel>(mc => !string.IsNullOrEmpty(mc.Value3));
                        if (deviceinfo2 != null)
                        {
                            _result.value3 = deviceinfo2.Value3;
                        }
                    }
                    else
                    {
                        _result.value2 = modelList[0].Value2;
                        _result.value3 = modelList[0].Value3;
                    }
                }
                if (DeviceType == "33")
                {
                    _result.value2 = modelList[0].Value2;
                    _result.value3 = modelList[0].Value3;
                    _result.value4 = modelList[0].Value4;
                    _result.value5 = modelList[0].Value5;
                    _result.value6 = modelList[0].Value6;
                    _result.value7 = modelList[0].Value7;
                    _result.value8 = modelList[0].Value8;
                    _result.value9 = modelList[0].Value9;
                    _result.value10 = modelList[0].Value10;
                    _result.value11 = modelList[0].Value11;
                }
                if (DeviceType == "32")
                {
                    _result.value2 = modelList[0].Value2;
                }
                if (!(DeviceType == "35"))
                {
                }
                return _result;
            }
            _result.HasValue = false;
            return _result;
        }
    }
}

