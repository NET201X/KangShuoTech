using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class OtherIllnessUserControl : UserControl
    {
        private IContainer components;
        private DateTimePicker dtpTime1;
        private DateTimePicker dtpTime2;
        private bool er_input1;
        private bool er_input2;
        public string idcard;
        public List<RecordsIllnessHistoryInfoModel> illnesshistoryinfo;
        public string illtype;
        private Label label205;
        private Label label206;
        private Label label207;
        private Label label208;
        private int maxBytesCount;
        private RadioButton rdWu;
        private RadioButton rdYou;
        private TextBox tbName1;
        private TextBox tbName2;
        string IDCardType = ConfigHelper.GetNode("IdCardType");
        public OtherIllnessUserControl()
        {
            this.InitializeComponent();
            this.rdWu.CheckedChanged += new EventHandler(this.rdWu_CheckedChanged);
            this.rdYou.CheckedChanged += new EventHandler(this.rdYou_CheckedChanged);
            if (IDCardType.Equals("3"))//二代机
            {
                SetFont(this);
            }
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

        private bool archive_illnessoper()
        {
            bool flag = true;
            if ((this.illnesshistoryinfo == null) || (this.illnesshistoryinfo.Count == 0))
            {
                return false;
            }
            RecordsIllnessHistoryInfoBLL recordsIllnessHistoryInfoModel0 = new RecordsIllnessHistoryInfoBLL();
            foreach (RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel2 in this.illnesshistoryinfo)
            {
                recordsIllnessHistoryInfoModel2.RecordID = this.Model.RecordID;
                recordsIllnessHistoryInfoModel2.IDCardNo = this.Model.IDCardNo;
                if (recordsIllnessHistoryInfoModel2.RecordState == RecordsStateModel.AddToDB)
                {
                    if (recordsIllnessHistoryInfoModel0.Add(recordsIllnessHistoryInfoModel2) <= 0)
                    {
                        flag = false;
                    }
                }
                else if (recordsIllnessHistoryInfoModel2.RecordState == RecordsStateModel.DeleteInDB)
                {
                    if (!recordsIllnessHistoryInfoModel0.Delete(recordsIllnessHistoryInfoModel2.ID))
                    {
                        flag = false;
                    }
                }
                else if ((recordsIllnessHistoryInfoModel2.RecordState == RecordsStateModel.UpdateInDB) && !recordsIllnessHistoryInfoModel0.Update(recordsIllnessHistoryInfoModel2))
                {
                    flag = false;
                }
            }
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

        public void Init(string _idcard, string _illtype)
        {
            this.idcard = _idcard;
            this.illtype = _illtype;
            this.illnesshistoryinfo = new RecordsIllnessHistoryInfoBLL().GetModelList(string.Format(" IDCardNo = '{0}' AND IllnessType = '{1}' ", this.idcard, this.illtype));
            if (this.illnesshistoryinfo.Count == 0)
            {
                this.rdWu.Checked = true;
            }
            else
            {
                this.rdYou.Checked = true;
                RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel1 = this.illnesshistoryinfo.ElementAtOrDefault<RecordsIllnessHistoryInfoModel>(0);
                RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel2 = this.illnesshistoryinfo.ElementAtOrDefault<RecordsIllnessHistoryInfoModel>(1);
                if (recordsIllnessHistoryInfoModel1 != null)
                {
                    this.tbName1.Text = recordsIllnessHistoryInfoModel1.IllnessNameOther;

                    if (recordsIllnessHistoryInfoModel1.DiagnoseTime.HasValue)
                    {
                        this.dtpTime1.Value = recordsIllnessHistoryInfoModel1.DiagnoseTime.Value; ;
                       
                    }
                }
                if (recordsIllnessHistoryInfoModel2 != null)
                {
                    this.tbName2.Text = recordsIllnessHistoryInfoModel2.IllnessNameOther;
                    if (recordsIllnessHistoryInfoModel2.DiagnoseTime.HasValue)
                    {
                        this.dtpTime2.Value = recordsIllnessHistoryInfoModel2.DiagnoseTime.Value;                        
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.dtpTime2 = new System.Windows.Forms.DateTimePicker();
            this.rdYou = new System.Windows.Forms.RadioButton();
            this.dtpTime1 = new System.Windows.Forms.DateTimePicker();
            this.rdWu = new System.Windows.Forms.RadioButton();
            this.label205 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.tbName2 = new System.Windows.Forms.TextBox();
            this.tbName1 = new System.Windows.Forms.TextBox();
            this.label206 = new System.Windows.Forms.Label();
            this.label207 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpTime2
            // 
            this.dtpTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime2.Location = new System.Drawing.Point(759, 4);
            this.dtpTime2.Name = "dtpTime2";
            this.dtpTime2.Size = new System.Drawing.Size(104, 23);
            this.dtpTime2.TabIndex = 170;
            // 
            // rdYou
            // 
            this.rdYou.AutoSize = true;
            this.rdYou.Location = new System.Drawing.Point(55, 6);
            this.rdYou.Name = "rdYou";
            this.rdYou.Size = new System.Drawing.Size(46, 18);
            this.rdYou.TabIndex = 162;
            this.rdYou.Text = "有:";
            this.rdYou.UseVisualStyleBackColor = true;
            //this.rdYou.CheckedChanged += new System.EventHandler(this.rdYou_CheckedChanged_1);
            // 
            // dtpTime1
            // 
            this.dtpTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime1.Location = new System.Drawing.Point(365, 4);
            this.dtpTime1.Name = "dtpTime1";
            this.dtpTime1.Size = new System.Drawing.Size(104, 23);
            this.dtpTime1.TabIndex = 169;
            // 
            // rdWu
            // 
            this.rdWu.AutoSize = true;
            this.rdWu.Location = new System.Drawing.Point(8, 6);
            this.rdWu.Name = "rdWu";
            this.rdWu.Size = new System.Drawing.Size(39, 18);
            this.rdWu.TabIndex = 161;
            this.rdWu.Text = "无";
            this.rdWu.UseVisualStyleBackColor = true;
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label205.Location = new System.Drawing.Point(695, 8);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(49, 14);
            this.label205.TabIndex = 168;
            this.label205.Text = "时间2:";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label208.Location = new System.Drawing.Point(103, 8);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(49, 14);
            this.label208.TabIndex = 163;
            this.label208.Text = "原因1:";
            // 
            // tbName2
            // 
            this.tbName2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName2.ForeColor = System.Drawing.Color.Black;
            this.tbName2.Location = new System.Drawing.Point(548, 4);
            this.tbName2.MaxLength = 20;
            this.tbName2.Name = "tbName2";
            this.tbName2.ReadOnly = true;
            this.tbName2.Size = new System.Drawing.Size(139, 23);
            this.tbName2.TabIndex = 167;
            // 
            // tbName1
            // 
            this.tbName1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbName1.ForeColor = System.Drawing.Color.Black;
            this.tbName1.Location = new System.Drawing.Point(155, 4);
            this.tbName1.MaxLength = 20;
            this.tbName1.Name = "tbName1";
            this.tbName1.ReadOnly = true;
            this.tbName1.Size = new System.Drawing.Size(139, 23);
            this.tbName1.TabIndex = 164;
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label206.Location = new System.Drawing.Point(496, 8);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(49, 14);
            this.label206.TabIndex = 166;
            this.label206.Text = "原因2:";
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label207.Location = new System.Drawing.Point(304, 8);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(49, 14);
            this.label207.TabIndex = 165;
            this.label207.Text = "时间1:";
            // 
            // OtherIllnessUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpTime2);
            this.Controls.Add(this.rdYou);
            this.Controls.Add(this.dtpTime1);
            this.Controls.Add(this.rdWu);
            this.Controls.Add(this.label205);
            this.Controls.Add(this.label208);
            this.Controls.Add(this.tbName2);
            this.Controls.Add(this.tbName1);
            this.Controls.Add(this.label206);
            this.Controls.Add(this.label207);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "OtherIllnessUserControl";
            this.Size = new System.Drawing.Size(871, 30);
            this.Load += new System.EventHandler(this.uc_otherillness_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (Encoding.GetEncoding("GB2312").GetByteCount(box.Text) > this.MaxBytesCount)
            {
                if (box.Name == this.tbName1.Name)
                {
                    this.er_input1 = true;
                }
                else
                {
                    this.er_input2 = true;
                }
                box.BackColor = Color.Salmon;
            }
            else
            {
                if (box.Name == this.tbName1.Name)
                {
                    this.er_input1 = false;
                }
                else
                {
                    this.er_input2 = false;
                }
                box.BackColor = Color.WhiteSmoke;
            }
        }

        private void rdWu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdWu.Checked)
            {
                this.tbName1.Clear();
                this.tbName2.Clear();
                this.dtpTime1.Value = DateTime.Today;
                this.dtpTime2.Value = DateTime.Today;
                this.tbName1.ReadOnly = true;
                this.tbName2.ReadOnly = true;
                this.dtpTime1.Enabled = false;
                this.dtpTime2.Enabled = false;
            }
        }

        private void rdYou_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdYou.Checked)
            {
                this.tbName1.ReadOnly = false;
                this.tbName2.ReadOnly = false;
                this.dtpTime1.Enabled = true;
                this.dtpTime2.Enabled = true;
            }
        }

        public void SavetoDB()
        {
            RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel4;
            if (!this.rdYou.Checked)
            {
                if (this.rdWu.Checked)
                {
                    RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel7 = this.illnesshistoryinfo.ElementAtOrDefault<RecordsIllnessHistoryInfoModel>(0);
                    if (recordsIllnessHistoryInfoModel7 != null)
                    {
                        recordsIllnessHistoryInfoModel7.RecordState = RecordsStateModel.DeleteInDB;
                    }
                    RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel8 = this.illnesshistoryinfo.ElementAtOrDefault<RecordsIllnessHistoryInfoModel>(1);
                    if (recordsIllnessHistoryInfoModel8 != null)
                    {
                        recordsIllnessHistoryInfoModel8.RecordState = RecordsStateModel.DeleteInDB;
                    }
                }
                goto Label_0275;
            }
            RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel = this.illnesshistoryinfo.ElementAtOrDefault<RecordsIllnessHistoryInfoModel>(0);
            if (recordsIllnessHistoryInfoModel != null)
            {
                if (!(recordsIllnessHistoryInfoModel.IllnessNameOther != this.tbName1.Text))
                {
                    DateTime date = this.dtpTime1.Value.Date;
                    DateTime? dIAGNOSETIME = recordsIllnessHistoryInfoModel.DiagnoseTime;
                    if ((!dIAGNOSETIME.HasValue ? 1 : ((date != dIAGNOSETIME.GetValueOrDefault()) ? 1 : 0)) == 0)
                    {
                        goto Label_0118;
                    }
                }

                if (tbName1.Text != "")
                {
                    recordsIllnessHistoryInfoModel.IllnessNameOther = this.tbName1.Text.Trim();
                    recordsIllnessHistoryInfoModel.DiagnoseTime = new DateTime?(this.dtpTime1.Value.Date);
                    recordsIllnessHistoryInfoModel.RecordState = RecordsStateModel.UpdateInDB;
                }
                else
                {
                    recordsIllnessHistoryInfoModel.RecordState = RecordsStateModel.DeleteInDB;
                }

            }
            else
            {
                RecordsIllnessHistoryInfoModel item = new RecordsIllnessHistoryInfoModel
                {
                    RecordState = RecordsStateModel.AddToDB
                };
                item.IllnessType = this.illtype;

                if (tbName1.Text != "")
                {
                    item.IllnessNameOther = this.tbName1.Text.Trim();
                    item.DiagnoseTime = new DateTime?(this.dtpTime1.Value.Date);
                    this.illnesshistoryinfo.Add(item);
                }
            }
        Label_0118:
            recordsIllnessHistoryInfoModel4 = this.illnesshistoryinfo.ElementAtOrDefault<RecordsIllnessHistoryInfoModel>(1);
            if (recordsIllnessHistoryInfoModel4 != null)
            {
                if (!(recordsIllnessHistoryInfoModel4.IllnessNameOther != this.tbName2.Text))
                {
                    DateTime time2 = this.dtpTime2.Value.Date;
                    DateTime? nullable2 = recordsIllnessHistoryInfoModel4.DiagnoseTime;
                    if ((!nullable2.HasValue ? 1 : ((time2 != nullable2.GetValueOrDefault()) ? 1 : 0)) == 0)
                    {
                        goto Label_0275;
                    }
                }

                if (this.tbName2.Text.Trim() != "")
                {
                    recordsIllnessHistoryInfoModel4.IllnessNameOther = this.tbName2.Text.Trim();
                    recordsIllnessHistoryInfoModel4.DiagnoseTime = new DateTime?(this.dtpTime2.Value.Date);
                    recordsIllnessHistoryInfoModel4.RecordState = RecordsStateModel.UpdateInDB;
                }
                else
                {
                    recordsIllnessHistoryInfoModel4.RecordState = RecordsStateModel.DeleteInDB;
                }

            }
            else
            {
                RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel5 = new RecordsIllnessHistoryInfoModel
                {
                    RecordState = RecordsStateModel.AddToDB
                };
                recordsIllnessHistoryInfoModel5.IllnessType = this.illtype;

                if (this.tbName2.Text.Trim() != "")
                {
                    recordsIllnessHistoryInfoModel5.IllnessNameOther = this.tbName2.Text.Trim();
                    recordsIllnessHistoryInfoModel5.DiagnoseTime = new DateTime?(this.dtpTime2.Value.Date);
                    this.illnesshistoryinfo.Add(recordsIllnessHistoryInfoModel5);
                }
            }
        Label_0275:
            this.archive_illnessoper();
        }

        private void uc_otherillness_Load(object sender, EventArgs e)
        {
        }

        public bool ErrorInput
        {
            get
            {
                if (!this.er_input1)
                {
                    return this.er_input2;
                }
                return true;
            }
        }

        public int MaxBytesCount
        {
            get
            {
                return this.maxBytesCount;
            }
            set
            {
                if (value > 0)
                {
                    this.maxBytesCount = value;
                    this.tbName1.TextChanged += new EventHandler(this.Other_TextChanged);
                    this.tbName2.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public RecordsBaseInfoModel Model { get; set; }

        public string Name1
        {
            set
            {
                this.label208.Text = value;
            }
            get
            {
                return this.label208.Text;
            }
        }
        public string Name2
        {
            set
            {
                this.label206.Text = value;
            }
            get
            {
                return this.label206.Text;
            }
        }
        //获取默认项设置，字符串格式类型为：原因1;时间1&原因2;时间2
        public string GetDefault()
        {
            string strRe = "";
            if (this.rdYou.Checked)
            {
                if (!string.IsNullOrEmpty(tbName1.Text))
                {
                    strRe += tbName1.Text + ";" + dtpTime1.Value.ToShortDateString() + "&";
                }
                if (!string.IsNullOrEmpty(tbName2.Text))
                {
                    strRe += tbName2.Text + ";" + dtpTime2.Value.ToShortDateString() + "&";
                }
                strRe = strRe.Remove(strRe.Length - 1);
            }
            else
            {
                strRe = "无";
            }
            return strRe;
        }

        //显示上次的默认项
        public void SetDefault(string strRes)
        {
            if (string.IsNullOrEmpty(strRes))
            {
                return;
            }
            if (strRes == "无")
            {
                this.rdWu.Checked = true;
                return;
            }
            this.rdYou.Checked = true;
            string[] ReList = strRes.Split('&');
            if (ReList.Length == 1)
            {
                string[] temp = ReList[0].ToString().Split(';');
                this.tbName1.Text = temp[0].ToString();
                this.dtpTime1.Value = Convert.ToDateTime(temp[1].ToString());
            }
            else if (ReList.Length == 2)
            {
                for (int i = 0; i < ReList.Length; i++)
                {
                    string[] temp = ReList[i].ToString().Split(';');
                    if (i == 0)
                    {
                        this.tbName1.Text = temp[0].ToString();
                        this.dtpTime1.Value = Convert.ToDateTime(temp[1].ToString());
                    }
                    else
                    {
                        this.tbName2.Text = temp[0].ToString();
                        this.dtpTime2.Value = Convert.ToDateTime(temp[1].ToString());
                    }
                }
            }
        }
    }
}

