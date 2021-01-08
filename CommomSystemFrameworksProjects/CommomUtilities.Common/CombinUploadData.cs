using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Data;

namespace CommomUtilities.Common
{
    public class CombinUploadData
    {
        public DataTable dtData;

        public CombinUploadData()
        {
            this.dtData = new DataTable();
            dtData.Columns.Add("Name", typeof(String));
            dtData.Columns.Add("IDCardNo", typeof(String));
            dtData.Columns.Add("Error", typeof(String));
        }

        public void ConbinData(RecordsBaseInfoModel BaseModel, string idCardNo, string error)
        {
            if (BaseModel != null)
            {
                DataRow dr2 = this.dtData.NewRow();

                dr2[0] = BaseModel.CustomerName;
                dr2[1] = BaseModel.IDCardNo;
                dr2[2] = error;

                this.dtData.Rows.Add(dr2);
            }
            else
            {
                DataRow dr2 = this.dtData.NewRow();

                dr2[0] = "";
                dr2[1] = idCardNo;
                dr2[2] = "没有基本资料";

                this.dtData.Rows.Add(dr2);
            }
        }
    }
}
