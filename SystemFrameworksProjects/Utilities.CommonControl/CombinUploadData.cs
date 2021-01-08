using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KangShuoTech.Utilities.CommonControl
{
    public class CombinUploadData
    {
        public DataTable dtData;
        public CombinUploadData()
        {
            this.dtData = new DataTable();
            dtData.Columns.Add("Name", typeof(String));
            dtData.Columns.Add("IDCardNo", typeof(String));
        }

        public void ConbinData(string idcardno)
        {
            RecordsBaseInfoModel BaseModel = new RecordsBaseInfoBLL().GetModel(idcardno);
            if (BaseModel != null)
            {
                DataRow dr2 = this.dtData.NewRow();
                dr2[0] = BaseModel.CustomerName;
                dr2[1] = BaseModel.IDCardNo;
                this.dtData.Rows.Add(dr2);
            }
            else
            {
                DataRow dr2 = this.dtData.NewRow();
                dr2[0] = "";
                dr2[1] = idcardno;
                this.dtData.Rows.Add(dr2);
            }
        }

        public void ConbinData(string idcardno,string name)
        {
            DataRow dr2 = this.dtData.NewRow();
            dr2[0] = name;
            dr2[1] = idcardno;
            this.dtData.Rows.Add(dr2);
        }
    }
}
