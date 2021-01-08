using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class FangYiUserControl : UserControl
    {
        private IContainer components;
        private DateTimePicker jiezhongshijian1;
        private bool nameEr;
        private bool orgEr;
        private RecordsInoculationHistoryModel source;
        private TextBox tbName;
        private TextBox tbOrgName;
        private bool UState;

        public FangYiUserControl()
        {
            this.InitializeComponent();
            this.jiezhongshijian1.Value = DateTime.Today;
            this.jiezhongshijian1.MaxDate = DateTime.Today;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.jiezhongshijian1 = new System.Windows.Forms.DateTimePicker();
            this.tbOrgName = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // jiezhongshijian1
            // 
            this.jiezhongshijian1.Enabled = false;
            this.jiezhongshijian1.Font = new System.Drawing.Font("宋体", 11.5F);
            this.jiezhongshijian1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jiezhongshijian1.Location = new System.Drawing.Point(198, 3);
            this.jiezhongshijian1.MaxDate = new System.DateTime(2099, 12, 18, 0, 0, 0, 0);
            this.jiezhongshijian1.Name = "jiezhongshijian1";
            this.jiezhongshijian1.Size = new System.Drawing.Size(172, 25);
            this.jiezhongshijian1.TabIndex = 1;
            // 
            // tbOrgName
            // 
            this.tbOrgName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbOrgName.Font = new System.Drawing.Font("宋体", 12F);
            this.tbOrgName.Location = new System.Drawing.Point(376, 2);
            this.tbOrgName.MaxLength = 20;
            this.tbOrgName.Name = "tbOrgName";
            this.tbOrgName.ReadOnly = true;
            this.tbOrgName.Size = new System.Drawing.Size(358, 26);
            this.tbOrgName.TabIndex = 2;
            this.tbOrgName.TextChanged += new System.EventHandler(this.tbOrgName_TextChanged);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName.Font = new System.Drawing.Font("宋体", 12F);
            this.tbName.Location = new System.Drawing.Point(3, 2);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(189, 26);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.txtfmyname1_TextChanged);
            // 
            // FangYiUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jiezhongshijian1);
            this.Controls.Add(this.tbOrgName);
            this.Controls.Add(this.tbName);
            this.Name = "FangYiUserControl";
            this.Size = new System.Drawing.Size(737, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SetEnabled(bool p_enabled)
        {
            if (this.UState != p_enabled)
            {
                this.tbOrgName.ReadOnly = !p_enabled;
                this.jiezhongshijian1.Enabled = p_enabled;
                if (!p_enabled)
                {
                    this.tbOrgName.Text = "";
                    this.jiezhongshijian1.Value = DateTime.Today;
                }
                this.UState = p_enabled;
            }
        }

        private void tbOrgName_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (Encoding.GetEncoding("GB2312").GetByteCount(box.Text) > 100)
            {
                this.orgEr = true;
                box.BackColor = Color.Salmon;
            }
            else
            {
                this.orgEr = false;
                box.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtfmyname1_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            bool flag = box.Text != "";
            if (Encoding.GetEncoding("GB2312").GetByteCount(box.Text) > 100)
            {
                this.nameEr = true;
                box.BackColor = Color.Salmon;
            }
            else
            {
                this.nameEr = false;
                box.BackColor = Color.WhiteSmoke;
            }
            this.SetEnabled(flag);
        }

        public void UpdateSource(string idcard)
        {
            if (this.source == null)
            {
                RecordsInoculationHistoryModel recordsInoculationHistoryModel = new RecordsInoculationHistoryModel
                {
                    ModelState = RecordsStateModel.NoValue
                };

                this.source = recordsInoculationHistoryModel;
            }
            this.source.IDCardNo = idcard;
            if (string.IsNullOrEmpty(this.tbName.Text.Trim()))
            {
                if (this.source.ModelState == RecordsStateModel.Unchanged)
                {
                    this.source.ModelState = RecordsStateModel.DeleteInDB;
                }
            }
            else
            {
                this.source.PillName = this.tbName.Text;
                this.source.InoculationHistory = this.tbOrgName.Text;
                this.source.InoculationDate = new DateTime?(this.jiezhongshijian1.Value);
                if (this.source.ModelState == RecordsStateModel.NoValue)
                {
                    this.source.ModelState = RecordsStateModel.AddToDB;
                }
                else
                {
                    this.source.ModelState = RecordsStateModel.UpdateInDB;
                }
            }
        }

        public bool ErrorInput
        {
            get
            {
                return (this.orgEr && this.nameEr);
            }
        }

        public string JZName
        {
            get
            {
                return this.tbName.Text;
            }
            set
            {
                this.tbName.Text = value;
            }
        }

        public string JZOrganization
        {
            get
            {
                return this.tbOrgName.Text;
            }
            set
            {
                this.tbOrgName.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RecordsInoculationHistoryModel Source
        {
            get
            {
                return this.source;
            }
            set
            {
                if (value == null)
                {
                    RecordsInoculationHistoryModel recordsInoculationHistoryModel = new RecordsInoculationHistoryModel
                    {
                        ModelState = RecordsStateModel.NoValue
                    };
                    this.source = recordsInoculationHistoryModel;
                }
                else
                {
                    this.source = value;
                    this.source.ModelState = RecordsStateModel.Unchanged;
                    this.tbName.Text = this.source.PillName;
                    this.tbOrgName.Text = this.source.InoculationHistory;
                    if (this.source.InoculationDate.HasValue)
                    {
                        this.jiezhongshijian1.Value = this.source.InoculationDate.Value;
                    }
                }
            }
        }

        public string StrTime
        {
            get
            {
                if (string.IsNullOrEmpty(this.JZName))
                {
                    return null;
                }
                return this.jiezhongshijian1.Value.ToShortDateString();
            }
            set
            {
                DateTime time;
                if (DateTime.TryParse(value, out time))
                {
                    this.jiezhongshijian1.Value = time;
                }
            }
        }
    }
}

