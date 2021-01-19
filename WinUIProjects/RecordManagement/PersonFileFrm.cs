﻿using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;


namespace ArchiveInfo
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class PersonFileFrm : MDIParentForm
    {
        private LinkLabel lklbRequired;

        public PersonFileFrm(string idcard)
            : base(idcard)
        {
            this.ModelCopy = new RecordsBaseInfoBLL().GetModel(base.Model.IDCardNo);

            if (this.ModelCopy == null)
            {
                RecordsBaseInfoModel recordsBaseInfoMode = new RecordsBaseInfoModel
                {
                    IDCardNo = base.Model.IDCardNo
                };
                this.ModelCopy = recordsBaseInfoMode;
            }

            this.lklbRequired = new LinkLabel();
            this.lklbRequired.BackColor = Color.Transparent;
            this.lklbRequired.ForeColor = Color.Red;
            this.lklbRequired.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lklbRequired.FlatStyle = FlatStyle.Flat;
            this.lklbRequired.ImageAlign = ContentAlignment.MiddleRight;
            this.lklbRequired.Location = new Point(0xd6, 3);
            this.lklbRequired.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lklbRequired.Name = "lklbRequired";
            this.lklbRequired.AutoSize = true;
            this.lklbRequired.TabIndex = 80;
            this.lklbRequired.Text = "必填项设置";
            this.lklbRequired.Click += new EventHandler(this.btnBtx_Click);
            base.flowLayoutPanel1.Controls.Add(this.lklbRequired);
        }

        private void btnBtx_Click(object sender, EventArgs e)
        {
            //RequiredFieldForm required = new RequiredFieldForm {
            //    StartPosition = FormStartPosition.CenterParent
            //};

            PersonFileRequiredForm personfilerequire = new PersonFileRequiredForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (personfilerequire.ShowDialog() == DialogResult.OK)
            {
                DataSet set = new DataSet();
                set.ReadXml(Application.StartupPath + @"\requiredPersonFile.xml");
                this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x597:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x597);
                    return;

                case 0x598:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x598);
                    return;

                case 0x599:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x599);
                    return;

                case 0x59a:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59a);
                    return;

                case 0x59b:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59b);
                    return;

                case 0x59c:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59c);
                    return;

                case 0x59d:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59d);
                    return;

                case 0x59e:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59e);
                    return;

                case 0x59f:
                    (base.IMDIControler.IChildrens["详细信息"] as ChildContentForm).UpdateDeviceinfoContent(0x59f);
                    return;
            }
            base.DefWndProc(ref m);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataSet set = new DataSet();
            set.ReadXml(Application.StartupPath + @"\required.xml");
            this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
        }

        public List<RecordsRequiredModel> Archive_requireds { get; set; }

        public RecordsBaseInfoModel ModelCopy { get; set; }
    }
}
