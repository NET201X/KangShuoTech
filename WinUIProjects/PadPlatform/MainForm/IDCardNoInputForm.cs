using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace PadPlatform
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class IDCardNoInputForm : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lbInfo;
        private MaskedTextBox mtbIdCard;
        private PictureBox pbxSearch;
        private TextBox tbAddress;
        private TextBox tbName;

        public string IDCardNo { get; set; }

        public IDCardNoInputForm()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int num;
            if (string.IsNullOrWhiteSpace(this.mtbIdCard.Text))
            {
                return;
            }
            bool flag = true;
            RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();

            if (this.inputIdCardInfo == null)
            {
                this.inputIdCardInfo = archive_baseinfo.GetModel(this.mtbIdCard.Text.Trim());
            }

            if (this.inputIdCardInfo == null)
            {
                if (!CheckIDCard(mtbIdCard.Text.Trim()))
                {
                    MessageBox.Show("身份证格式不正确，请重新输入！");
                    mtbIdCard.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.tbName.Text.Trim()))
                {
                    flag = false;
                    this.tbName.BackColor = Color.LightSalmon;
                }
                if (string.IsNullOrEmpty(this.mtbIdCard.Text.Trim()))
                {
                    flag = false;
                    this.mtbIdCard.BackColor = Color.LightSalmon;
                }
                else if (!this.mtbIdCard.MaskCompleted)
                {
                    flag = false;
                    this.mtbIdCard.BackColor = Color.LightSalmon;
                }
                if (!flag)
                {
                    return;
                }

                this.inputIdCardInfo = new RecordsBaseInfoModel();
                this.inputIdCardInfo.IDCardNo = this.mtbIdCard.Text.Trim();
                this.inputIdCardInfo.Address = this.tbAddress.Text.Trim();
                this.inputIdCardInfo.HouseHoldAddress = this.tbAddress.Text.Trim();
                this.inputIdCardInfo.CustomerName = this.tbName.Text.Trim();

                int id = int.Parse(mtbIdCard.Text.Substring(mtbIdCard.Text.Length - 2, 1));

                if (id % 2 == 0)
                {
                    this.inputIdCardInfo.Sex = "2";
                }
                else
                {
                    this.inputIdCardInfo.Sex = "1";
                }

                DataSender.UserName = this.tbName.Text.Trim();
                goto Label_0434;
            }

            if (((this.inputIdCardInfo.HouseHoldAddress == this.tbAddress.Text.Trim())
                && (this.inputIdCardInfo.HouseHoldAddress == this.tbAddress.Text.Trim())))
            {

                //if (((!bIRTHDAY.HasValue ? 0 : ((bIRTHDAY.GetValueOrDefault() == date) ? 1 : 0)) != 0) 
                //    && (this.inputIdCardInfo.Sex == Convert.ToString(this.cbSex.SelectedValue)))
                //{
                //    num = (this.inputIdCardInfo.CustomerName == this.tbName.Text) ? 1 : 0;
                //    goto Label_016A;
                //}
            }
            num = 0;
        Label_016A:
        //if ((num == 0) && (MessageBox.Show("当前输入信息和原身份信息不一致，是否替换？", "输入不一致", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
        //{
        //    if (this.tbName.Text.Trim() == "")
        //    {
        //        MessageBox.Show("身份证姓名不能为空！无法替换原信息", "替换信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //        return;
        //    }
        //    this.inputIdCardInfo.IDCardNo = this.mtbIdCard.Text.Trim();
        //    this.inputIdCardInfo.Address = this.tbAddress.Text.Trim();
        //    this.inputIdCardInfo.HouseHoldAddress = this.tbAddress.Text.Trim();
        //    this.inputIdCardInfo.CustomerName = this.tbName.Text.Trim();
        //    DataSender.UserName = this.tbName.Text.Trim();
        //}
        Label_0434:
            this.inputIdCardInfo.CustomerName = this.tbName.Text.Trim();
            base.DialogResult = DialogResult.OK;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmInputIDCard_KeyUp(object sender, KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode != Keys.F17)
            {
                if (keyCode != Keys.F23)
                {
                    return;
                }
            }
            else
            {
                this.btnOK.PerformClick();
                return;
            }
            this.btnCancel.PerformClick();
        }

        private void FrmInputIDCard_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IDCardNo))
            {
                this.mtbIdCard.Text = IDCardNo;
                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                if (!string.IsNullOrEmpty(this.mtbIdCard.Text))
                {
                    RecordsBaseInfoModel model = archive_baseinfo.GetModel(this.mtbIdCard.Text);

                    if (model != null)
                    {
                        this.inputIdCardInfo = model;
                        this.tbName.Text = this.inputIdCardInfo.CustomerName;
                        this.tbAddress.Text = this.inputIdCardInfo.HouseHoldAddress;
                    }
                    else
                    {
                        this.hadFoundIt(false);
                    }
                }
            }
        }

        private void hadFoundIt(bool p_result)
        {
            this.tbName.ReadOnly = p_result;
            this.tbAddress.ReadOnly = p_result;
            this.mtbIdCard.ReadOnly = p_result;

            //if (p_result)
            //{
            //    this.rd15.Enabled = false;
            //    this.rd18.Enabled = false;
            //}
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDCardNoInputForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.mtbIdCard = new System.Windows.Forms.MaskedTextBox();
            this.pbxSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "身 份 证:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓    名:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("宋体", 12F);
            this.tbName.Location = new System.Drawing.Point(107, 72);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 26);
            this.tbName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "户籍住址:";
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("宋体", 12F);
            this.tbAddress.Location = new System.Drawing.Point(107, 120);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(367, 26);
            this.tbAddress.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F);
            this.btnOK.Location = new System.Drawing.Point(122, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 31);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "登录";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F);
            this.btnCancel.Location = new System.Drawing.Point(268, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 31);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.ForeColor = System.Drawing.Color.Red;
            this.lbInfo.Location = new System.Drawing.Point(1, 237);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(53, 19);
            this.lbInfo.TabIndex = 14;
            this.lbInfo.Text = "    ";
            // 
            // mtbIdCard
            // 
            this.mtbIdCard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mtbIdCard.Location = new System.Drawing.Point(107, 29);
            this.mtbIdCard.Name = "mtbIdCard";
            this.mtbIdCard.Size = new System.Drawing.Size(200, 26);
            this.mtbIdCard.TabIndex = 0;
            this.mtbIdCard.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbIdCard.Leave += new System.EventHandler(this.mtbIdCard_Leave);
            // 
            // pbxSearch
            // 
            this.pbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("pbxSearch.Image")));
            this.pbxSearch.Location = new System.Drawing.Point(442, 23);
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Size = new System.Drawing.Size(32, 32);
            this.pbxSearch.TabIndex = 22;
            this.pbxSearch.TabStop = false;
            this.pbxSearch.Visible = false;
            this.pbxSearch.Click += new System.EventHandler(this.pbxSearch_Click);
            // 
            // IDCardNoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::PadPlatform.Properties.Resources.logindialogbg600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(507, 212);
            this.ControlBox = false;
            this.Controls.Add(this.pbxSearch);
            this.Controls.Add(this.mtbIdCard);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IDCardNoInputForm";
            this.ShowInTaskbar = false;
            this.Text = "IDCardNoInputForm";
            this.Load += new System.EventHandler(this.FrmInputIDCard_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmInputIDCard_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void mtbIdCard_Leave(object sender, EventArgs e)
        {
            //if (!CheckIDCard(mtbIdCard.Text.Trim()))
            //{
            //    MessageBox.Show("身份证格式不正确，请重新输入！");
            //    mtbIdCard.Focus();
            //    return;
            //}

            if (this.mtbIdCard.MaskCompleted)
            {
                DateTime time;
                this.mtbIdCard.Text = this.mtbIdCard.Text;
               // string str = this.mtbIdCard.Text.Substring(6, 8);

                //if (this.rd15.Checked)
                //{
                //    string str2 = this.mtbIdCard.Text.Substring(6, 6);
                //    int num = DateTime.Now.Year - 0x7d0;
                //    str = (int.Parse(str2.Substring(0, 2)) <= num) ? ("20" + str2) : ("19" + str2);
                //}
                //if (this.rd18.Checked)
                //{
                //    str = this.mtbIdCard.Text.Substring(6, 8);
                //}

                RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
                if (!string.IsNullOrEmpty(this.mtbIdCard.Text))
                {
                    RecordsBaseInfoModel model = archive_baseinfo.GetModel(this.mtbIdCard.Text);

                    if (model != null)
                    {
                        this.inputIdCardInfo = model;
                        this.tbName.Text = this.inputIdCardInfo.CustomerName;
                        this.tbAddress.Text = this.inputIdCardInfo.HouseHoldAddress;
                        //this.hadFoundIt(true);
                    }
                    else
                    {
                        this.hadFoundIt(false);
                    }
                }
            }
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {
            RecordsBaseInfoBLL archive_baseinfo = new RecordsBaseInfoBLL();
            if (!string.IsNullOrEmpty(this.mtbIdCard.Text))
            {
                RecordsBaseInfoModel model = archive_baseinfo.GetModel(this.mtbIdCard.Text);
                if (model != null)
                {
                    int num2;
                    this.inputIdCardInfo = model;
                    this.tbName.Text = this.inputIdCardInfo.CustomerName;
                    this.tbAddress.Text = this.inputIdCardInfo.HouseHoldAddress;
                    this.hadFoundIt(true);
                }
                else
                {
                    this.hadFoundIt(false);
                }
            }
        }

        public RecordsBaseInfoModel inputIdCardInfo { get; set; }

        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        public bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 18位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        private bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 15位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
        private bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
    }
}

