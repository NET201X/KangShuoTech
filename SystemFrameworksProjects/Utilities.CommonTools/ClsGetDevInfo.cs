using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonTools
{
    using Common;
    using System.Collections.Generic;

    public class ClsGetDevInfo
    {
        public static stru_result GetDevData(string IDCardNo, string DeviceType)
        {
            stru_result _result = new stru_result();
            string strWhere = "";
            if (DeviceType == "24")
            {
                strWhere = string.Format(" IDCardNo = '{0}' and (DeviceType = 24 or (DeviceType = 35 and DeviceName = '血糖' )) ", IDCardNo, DeviceType);
            }
            else
            {
                strWhere = string.Format(" IDCardNo = '{0}' and DeviceType = '{1}' ", IDCardNo, DeviceType);
            }
            strWhere = strWhere + " order by id desc ";
            List<DeviceInfoModel> modelList = new DeviceInfoBLL().GetModelList(strWhere);
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
            string strWhere = "";
            strWhere = string.Format(" IDCardNo = '{0}' and DeviceType = '{1}' ", IDCardNo, DeviceType);
            if (!string.IsNullOrEmpty(DeviceName))
            {
                strWhere = strWhere + string.Format("and DeviceName = '{0}' ", DeviceName);
            }
            strWhere = strWhere + " order by id desc ";
            List<DeviceInfoModel> modelList = new DeviceInfoBLL().GetModelList(strWhere);
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
                if (DeviceType == "35")
                {
                }
                return _result;
            }
            _result.HasValue = false;
            return _result;
        }
    }
}

