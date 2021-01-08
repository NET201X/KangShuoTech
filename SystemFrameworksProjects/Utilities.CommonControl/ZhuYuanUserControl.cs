using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class ZhuYuanUserControl : UserControl
    {
        private IContainer components;
        private bool errorinput;
        private RecordsFamilyBedHistoryModel famSouce;
        public List<InputRangeStr> inputrange_str = new List<InputRangeStr>();
        private RecordsHospitalHistoryModel perSource;
        private Panel panel1;
        private Label label233;
        private DateTimePicker dtpEd;
        private DateTimePicker dtpSt;
        private TextBox tbNo;
        private TextBox tbOrgrationName;
        private TextBox tbReason;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private bool UState;
        string IDCardType = ConfigHelper.GetNode("IdCardType");
        public ZhuYuanUserControl()
        {
            this.InitializeComponent();
            if (IDCardType.Equals("3"))//二代机
            {
                SetFont(this);
            }
            this.inputrange_str.Add(new InputRangeStr("tbOrgrationName", 100));
            this.inputrange_str.Add(new InputRangeStr("tbNo", 50));
            this.inputrange_str.Add(new InputRangeStr("tbReason", 100));
            this.tbNo.TextChanged += new EventHandler(this.tbNo_TextChanged);
            this.tbReason.TextChanged += new EventHandler(this.tbReason_TextChanged);
        }
        private void SetFont(Control controls)
        {
            controls.Font = new System.Drawing.Font("宋体", 15F);
            foreach (Control ct in controls.Controls)
            {
                ct.Font = new System.Drawing.Font("宋体", 15F);
                SetFont(ct);
            }
        }
        private void bd_ParseStr(object sender, ConvertEventArgs e)
        {
            string s = e.Value as string;
            Binding bd = sender as Binding;
            InputRangeStr str2 = this.inputrange_str.Find(c => c.Name == bd.BindingMemberInfo.BindingField);
            if (str2 != null)
            {
                if (Encoding.GetEncoding("GB2312").GetByteCount(s) > str2.BytesCount)
                {
                    str2.ErrorInput = true;
                    bd.Control.BackColor = Color.Salmon;
                }
                else
                {
                    str2.ErrorInput = false;
                    bd.Control.BackColor = Color.WhiteSmoke;
                }
            }
        }

        public bool CheckInput()
        {
            bool flag = true;
            if (this.dtpSt.Value > this.dtpEd.Value)
            {
                flag = false;
                this.ErrorInput = true;
            }
            else
            {
                this.ErrorInput = false;
            }
            base.Invalidate();
            return flag;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpEd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpSt.MaxDate = this.dtpEd.Value.Date;
        }

        private void dtpSt_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEd.MinDate = this.dtpSt.Value.Date;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label233 = new System.Windows.Forms.Label();
            this.dtpEd = new System.Windows.Forms.DateTimePicker();
            this.dtpSt = new System.Windows.Forms.DateTimePicker();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.tbOrgrationName = new System.Windows.Forms.TextBox();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label233);
            this.panel1.Controls.Add(this.dtpEd);
            this.panel1.Controls.Add(this.dtpSt);
            this.panel1.Controls.Add(this.tbNo);
            this.panel1.Controls.Add(this.tbOrgrationName);
            this.panel1.Controls.Add(this.tbReason);
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 30);
            this.panel1.TabIndex = 20;
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label233.Location = new System.Drawing.Point(118, 8);
            this.label233.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(14, 14);
            this.label233.TabIndex = 25;
            this.label233.Text = "-";
            // 
            // dtpEd
            // 
            this.dtpEd.Enabled = false;
            this.dtpEd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEd.Location = new System.Drawing.Point(138, 5);
            this.dtpEd.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEd.Name = "dtpEd";
            this.dtpEd.Size = new System.Drawing.Size(109, 23);
            this.dtpEd.TabIndex = 21;
            // 
            // dtpSt
            // 
            this.dtpSt.Enabled = false;
            this.dtpSt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSt.Location = new System.Drawing.Point(5, 5);
            this.dtpSt.Margin = new System.Windows.Forms.Padding(2);
            this.dtpSt.Name = "dtpSt";
            this.dtpSt.Size = new System.Drawing.Size(109, 23);
            this.dtpSt.TabIndex = 20;
            // 
            // tbNo
            // 
            this.tbNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbNo.Location = new System.Drawing.Point(629, 5);
            this.tbNo.Margin = new System.Windows.Forms.Padding(2);
            this.tbNo.MaxLength = 20;
            this.tbNo.Name = "tbNo";
            this.tbNo.Size = new System.Drawing.Size(124, 23);
            this.tbNo.TabIndex = 24;
            // 
            // tbOrgrationName
            // 
            this.tbOrgrationName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbOrgrationName.Location = new System.Drawing.Point(449, 5);
            this.tbOrgrationName.Margin = new System.Windows.Forms.Padding(2);
            this.tbOrgrationName.MaxLength = 50;
            this.tbOrgrationName.Name = "tbOrgrationName";
            this.tbOrgrationName.Size = new System.Drawing.Size(175, 23);
            this.tbOrgrationName.TabIndex = 23;
            this.tbOrgrationName.TextChanged += new System.EventHandler(this.tbOrgrationName_TextChanged);
            // 
            // tbReason
            // 
            this.tbReason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbReason.Location = new System.Drawing.Point(252, 5);
            this.tbReason.Margin = new System.Windows.Forms.Padding(2);
            this.tbReason.MaxLength = 100;
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(188, 23);
            this.tbReason.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 26);
            this.panel2.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "病案号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "医疗机构名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "原因";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "入/出院时间";
            // 
            // ZhuYuanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "ZhuYuanUserControl";
            this.Size = new System.Drawing.Size(758, 61);
            this.Load += new System.EventHandler(this.ZhuYuan_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ZhuYuan_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void SetEnabled(bool p_enabled)
        {
            if (this.UState != p_enabled)
            {
                this.dtpEd.Enabled = p_enabled;
                this.dtpSt.Enabled = p_enabled;
                if (!p_enabled)
                {
                    this.dtpSt.MaxDate = DateTime.Today;
                    this.dtpSt.Value = DateTime.Today;
                    this.dtpEd.MaxDate = DateTime.Today;
                    this.dtpEd.Value = DateTime.Today;
                }
                this.UState = p_enabled;
            }
        }

        private void tbNo_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            InputRangeStr str = this.inputrange_str.Find(c => c.Name == tb.Name);
            if (Encoding.GetEncoding("GB2312").GetByteCount(tb.Text) > str.BytesCount)
            {
                str.ErrorInput = true;
                tb.BackColor = Color.Salmon;
            }
            else
            {
                str.ErrorInput = false;
                tb.BackColor = Color.WhiteSmoke;
            }
        }

        private void tbOrgrationName_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            InputRangeStr str = this.inputrange_str.Find(c => c.Name == tb.Name);
            if (Encoding.GetEncoding("GB2312").GetByteCount(tb.Text) > str.BytesCount)
            {
                str.ErrorInput = true;
                tb.BackColor = Color.Salmon;
            }
            else
            {
                str.ErrorInput = false;
                tb.BackColor = Color.WhiteSmoke;
            }
            this.SetEnabled(tb.Text != "");
        }

        private void tbReason_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            InputRangeStr str = this.inputrange_str.Find(c => c.Name == tb.Name);
            if (Encoding.GetEncoding("GB2312").GetByteCount(tb.Text) > str.BytesCount)
            {
                str.ErrorInput = true;
                tb.BackColor = Color.Salmon;
            }
            else
            {
                str.ErrorInput = false;
                tb.BackColor = Color.WhiteSmoke;
            }
        }

        public void UpdateFam(string idcard)
        {
            if (this.famSouce == null)
            {
                RecordsFamilyBedHistoryModel recordsFamilyBedHistoryModel = new RecordsFamilyBedHistoryModel
                {
                    ModelState = RecordsStateModel.NoValue
                };

                this.famSouce = recordsFamilyBedHistoryModel;
            }
            this.famSouce.IDCardNo = idcard;
            if (string.IsNullOrEmpty(this.tbOrgrationName.Text.Trim()))
            {
                if (this.famSouce.ModelState == RecordsStateModel.Unchanged)
                {
                    this.famSouce.ModelState = RecordsStateModel.DeleteInDB;
                }
            }
            else
            {
                this.famSouce.Reasons = this.tbReason.Text;
                this.famSouce.IllcaseNums = this.tbNo.Text;
                this.famSouce.HospitalName = this.tbOrgrationName.Text;
                this.famSouce.InHospitalDate = new DateTime?(this.dtpSt.Value.Date);
                this.famSouce.OutHospitalDate = new DateTime?(this.dtpEd.Value.Date);
                if (this.famSouce.ModelState == RecordsStateModel.NoValue)
                {
                    this.famSouce.ModelState = RecordsStateModel.AddToDB;
                }
                else
                {
                    this.famSouce.ModelState = RecordsStateModel.UpdateInDB;
                }
            }
        }

        public void UpdatePer(string idcard)
        {
            if (this.perSource == null)
            {
                RecordsHospitalHistoryModel recordsHospitalHistoryModel = new RecordsHospitalHistoryModel
                {
                    ModelState = RecordsStateModel.NoValue
                };
                this.perSource = recordsHospitalHistoryModel;
            }
            this.perSource.IDCardNo = idcard;
            if (string.IsNullOrEmpty(this.tbOrgrationName.Text.Trim()))
            {
                if (this.perSource.ModelState == RecordsStateModel.Unchanged)
                {
                    this.perSource.ModelState = RecordsStateModel.DeleteInDB;
                }
            }
            else
            {
                this.perSource.Reason = this.tbReason.Text;
                this.perSource.IllcaseNum = this.tbNo.Text;
                this.perSource.HospitalName = this.tbOrgrationName.Text;
                this.perSource.InHospitalDate = new DateTime?(this.dtpSt.Value.Date);
                this.perSource.OutHospitalDate = new DateTime?(this.dtpEd.Value.Date);
                if (this.perSource.ModelState == RecordsStateModel.NoValue)
                {
                    this.perSource.ModelState = RecordsStateModel.AddToDB;
                }
                else
                {
                    this.perSource.ModelState = RecordsStateModel.UpdateInDB;
                }
            }
        }

        private void ZhuYuan_Load(object sender, EventArgs e)
        {
            this.dtpSt.MaxDate = DateTime.Today;
            this.dtpEd.MaxDate = DateTime.Today;
            if (!showPanel2)
            {
                this.panel2.Visible = false;
                this.panel1.Location = new System.Drawing.Point(4, 5);
                if (IDCardType.Equals("3"))//二代机
                {
                    SetFont(this);
                }
                else
                {
                    this.Size = new System.Drawing.Size(874, 37);
                    this.Size = new System.Drawing.Size(1079, 43);
                }
             
            }
            this.ErrorInput = false;
        }

        private void ZhuYuan_Paint(object sender, PaintEventArgs e)
        {
            if (this.ErrorInput)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(3, 4, 280, 0x19));
            }
        }

        public bool ErrorInput
        {
            get
            {
                bool flag = false;
                for (int i = 0; i < this.inputrange_str.Count; i++)
                {
                    if (this.inputrange_str[i].ErrorInput)
                    {
                        flag = true;
                        break;
                    }
                }
                this.errorinput = flag;
                return this.errorinput;
            }
            set
            {
                this.errorinput = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RecordsFamilyBedHistoryModel FamSource
        {
            get
            {
                return this.famSouce;
            }
            set
            {
                if (value == null)
                {
                    RecordsFamilyBedHistoryModel recordsFamilyBedHistoryModel = new RecordsFamilyBedHistoryModel
                    {
                        ModelState = RecordsStateModel.NoValue
                    };
                    this.famSouce = recordsFamilyBedHistoryModel;
                }
                else
                {
                    this.famSouce = value;
                    this.famSouce.ModelState = RecordsStateModel.Unchanged;
                }
                this.tbReason.Text = this.famSouce.Reasons;
                this.tbNo.Text = this.famSouce.IllcaseNums;
                this.tbOrgrationName.Text = this.famSouce.HospitalName;
                if (this.famSouce.InHospitalDate.HasValue)
                {
                    this.dtpSt.Value = this.famSouce.InHospitalDate.Value;
                }
                if (this.famSouce.OutHospitalDate.HasValue)
                {
                    this.dtpEd.Value = this.famSouce.OutHospitalDate.Value;
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RecordsHospitalHistoryModel PerSource
        {
            get
            {
                return this.perSource;
            }
            set
            {
                if (value == null)
                {
                    RecordsHospitalHistoryModel recordsHospitalHistoryModel = new RecordsHospitalHistoryModel
                    {
                        ModelState = RecordsStateModel.NoValue
                    };
                    this.perSource = recordsHospitalHistoryModel;
                }
                else
                {
                    this.perSource = value;
                    this.perSource.ModelState = RecordsStateModel.Unchanged;
                }
                this.tbReason.Text = this.perSource.Reason;
                this.tbNo.Text = this.perSource.IllcaseNum;
                this.tbOrgrationName.Text = this.perSource.HospitalName;
                if (this.perSource.InHospitalDate.HasValue)
                {
                    this.dtpSt.Value = this.perSource.InHospitalDate.Value;
                }
                if (this.perSource.OutHospitalDate.HasValue)
                {
                    this.dtpEd.Value = this.perSource.OutHospitalDate.Value;
                }
            }
        }
        public bool showPanel2 = false;

        //获取默认项内容 
        public string GetDefault()
        {
            string strRe = "";
            if (tbOrgrationName.Text != "")
            {
                strRe += dtpSt.Value.ToShortDateString() + ";" + dtpEd.Value.ToShortDateString() + ";"
                    + tbReason.Text + ";" + tbOrgrationName.Text + ";" + tbNo.Text;
            }
            return strRe;
        }

    }
}

