using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    public partial class frmCreateRecordCount : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        public frmCreateRecordCount()
        {
            InitializeComponent();
        }

        public RecordsBaseInfoModel Model
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ChildFormStatus CheckErrorInput()
        {
            throw new NotImplementedException();
        }

        public void InitEveryThing()
        {
            throw new NotImplementedException();
        }

        public bool SaveModelToDB()
        {
            throw new NotImplementedException();
        }

        public void NotisfyChildStatus()
        {
            throw new NotImplementedException();
        }

        public void UpdataToModel()
        {
            throw new NotImplementedException();
        }

        public bool EveryThingIsOk
        {
            get;
            set;
        }

        public bool HaveToSave
        {
            get;
            set;
        }

        public string SaveDataInfo
        {
            get;
            set;
        }
    }
}
