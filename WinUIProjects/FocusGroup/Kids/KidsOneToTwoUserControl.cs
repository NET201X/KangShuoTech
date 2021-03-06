using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;

namespace FocusGroup.Kids
{
    using KangShuoTech.Utilities.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Configuration;

    public class KidsOneToTwoUserControl : UserControl
    {
        private ManyCheckboxs<KidsTcmhmOneToThreeModel> baojian;
        private CheckBox chk1;
        private CheckBox chk2;
        private CheckBox chk3;
        private CheckBox chk4;
        private IContainer components;
        private DateTimePicker dtpNextVisitDate;
        private DateTimePicker dtpVisitDate;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbBaojianOth;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label54;
        private LinkLabel lkJs;
        private PictureBox picSignJs;
        private Label label65;
        private TextBox tbDoctor;
        private string SignS = "";//家长签名
        private string SignDoc = "";//随访医生签名
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public KidsOneToTwoUserControl()
        {
            this.InitializeComponent();
        }

        public bool CheckErrorInput(out string saveinfo)
        {
            bool flag = false;
            saveinfo = "";
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.tbDoctor.Text) > 50)
            {
                flag = true;
                string str = saveinfo;
                str = str + "医生签名过长!\r\n";
                this.tbDoctor.BackColor = Color.Salmon;
            }
            else
            {
                this.tbDoctor.BackColor = Color.WhiteSmoke;
            }
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.tbBaojianOth.Text) > 0xff)
            {
                flag = true;
                string str3 = saveinfo;
                str3 = str3 + "其他信息太长!\r\n";
                this.tbBaojianOth.BackColor = Color.Salmon;
            }
            else
            {
                this.tbBaojianOth.BackColor = Color.WhiteSmoke;
            }
            if (this.dtpVisitDate.Value.Date > DateTime.Today)
            {
                flag = true;
                string str5 = saveinfo;
                str5 = str5 + "随访日期不能晚于当前日期!\r\n";
            }
            if (this.dtpNextVisitDate.Value.Date < this.dtpVisitDate.Value.Date)
            {
                flag = true;
                string str7 = saveinfo;
                str7 = str7 + "下次随访日期不能小于当前随访日期!\r\n";
            }
            if (flag)
            {
                TabPage parent = base.Parent as TabPage;
                if (parent != null)
                {
                    parent.ImageIndex = 2;
                }
                saveinfo = parent.Text + ":" + saveinfo;
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

        private void InitializeComponent()
        {
            this.dtpNextVisitDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbBaojianOth = new System.Windows.Forms.TextBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lkYs = new System.Windows.Forms.LinkLabel();
            this.picSignYs = new System.Windows.Forms.PictureBox();
            this.label54 = new System.Windows.Forms.Label();
            this.lkJs = new System.Windows.Forms.LinkLabel();
            this.picSignJs = new System.Windows.Forms.PictureBox();
            this.label65 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpNextVisitDate
            // 
            this.dtpNextVisitDate.Location = new System.Drawing.Point(915, 7);
            this.dtpNextVisitDate.Name = "dtpNextVisitDate";
            this.dtpNextVisitDate.Size = new System.Drawing.Size(200, 30);
            this.dtpNextVisitDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(769, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "下次随访日期:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(528, 9);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(167, 30);
            this.tbDoctor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "随访医生签名:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbBaojianOth);
            this.groupBox1.Controls.Add(this.chk4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chk3);
            this.groupBox1.Controls.Add(this.chk2);
            this.groupBox1.Controls.Add(this.chk1);
            this.groupBox1.Location = new System.Drawing.Point(13, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1287, 91);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "中医药健康管理服务";
            // 
            // tbBaojianOth
            // 
            this.tbBaojianOth.Location = new System.Drawing.Point(72, 52);
            this.tbBaojianOth.MaxLength = 20;
            this.tbBaojianOth.Name = "tbBaojianOth";
            this.tbBaojianOth.ReadOnly = true;
            this.tbBaojianOth.Size = new System.Drawing.Size(536, 30);
            this.tbBaojianOth.TabIndex = 4;
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(668, 24);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(68, 24);
            this.chk4.TabIndex = 3;
            this.chk4.Text = "其他";
            this.chk4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "其他:";
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(423, 24);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(208, 24);
            this.chk3.TabIndex = 2;
            this.chk3.Text = "传授摩腹、捏脊方法";
            this.chk3.UseVisualStyleBackColor = true;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(210, 24);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(188, 24);
            this.chk2.TabIndex = 1;
            this.chk2.Text = "中医起居调摄指导";
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(9, 24);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(188, 24);
            this.chk1.TabIndex = 0;
            this.chk1.Text = "中医饮食调养指导";
            this.chk1.UseVisualStyleBackColor = true;
            // 
            // dtpVisitDate
            // 
            this.dtpVisitDate.Location = new System.Drawing.Point(119, 9);
            this.dtpVisitDate.Name = "dtpVisitDate";
            this.dtpVisitDate.Size = new System.Drawing.Size(200, 30);
            this.dtpVisitDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "随访日期：";
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(359, 169);
            this.lkYs.Name = "lkYs";
            this.lkYs.Size = new System.Drawing.Size(89, 20);
            this.lkYs.TabIndex = 206;
            this.lkYs.TabStop = true;
            this.lkYs.Text = "重置签名";
            this.lkYs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkYs_LinkClicked);
            // 
            // picSignYs
            // 
            this.picSignYs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignYs.Location = new System.Drawing.Point(168, 146);
            this.picSignYs.Name = "picSignYs";
            this.picSignYs.Size = new System.Drawing.Size(181, 50);
            this.picSignYs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignYs.TabIndex = 204;
            this.picSignYs.TabStop = false;
            this.picSignYs.Click += new System.EventHandler(this.picSignYs_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 15F);
            this.label54.Location = new System.Drawing.Point(63, 148);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(99, 20);
            this.label54.TabIndex = 203;
            this.label54.Text = "医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(898, 169);
            this.lkJs.Name = "lkJs";
            this.lkJs.Size = new System.Drawing.Size(89, 20);
            this.lkJs.TabIndex = 202;
            this.lkJs.TabStop = true;
            this.lkJs.Text = "重置签名";
            this.lkJs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkJs_LinkClicked);
            // 
            // picSignJs
            // 
            this.picSignJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(248)))), ((int)(((byte)(200)))));
            this.picSignJs.Location = new System.Drawing.Point(707, 146);
            this.picSignJs.Name = "picSignJs";
            this.picSignJs.Size = new System.Drawing.Size(181, 50);
            this.picSignJs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSignJs.TabIndex = 200;
            this.picSignJs.TabStop = false;
            this.picSignJs.Click += new System.EventHandler(this.picSignJs_Click);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("宋体", 15F);
            this.label65.Location = new System.Drawing.Point(602, 146);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(99, 20);
            this.label65.TabIndex = 199;
            this.label65.Text = "家长签名:";
            // 
            // KidsOneToTwoUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lkYs);
            this.Controls.Add(this.picSignYs);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.lkJs);
            this.Controls.Add(this.picSignJs);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.dtpNextVisitDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDoctor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpVisitDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "KidsOneToTwoUserControl";
            this.Size = new System.Drawing.Size(1353, 236);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void InitUc()
        {
            if (string.IsNullOrEmpty(this.DataSrc.FollowUpDoctor))
            {
                this.tbDoctor.Text = ConfigHelper.GetNode("doctorName");
            }
            else
            {
                this.tbDoctor.Text = this.DataSrc.FollowUpDoctor;
            }
            if (this.DataSrc == null)
            {
                throw new Exception("DataSrc 为Null");
            }
            this.baojian = new ManyCheckboxs<KidsTcmhmOneToThreeModel>(this.DataSrc);
            this.baojian.AddCk(new CheckBox[] { this.chk1, this.chk2, this.chk3 });
            this.baojian.AddCk(this.chk4, this.tbBaojianOth);
            this.baojian.BindingProperty("Tcmhm", "TcmhmOther");
            if (this.DataSrc.FollowupDate.HasValue)
            {
                this.dtpVisitDate.Value = this.DataSrc.FollowupDate.Value;
            }

            if (this.DataSrc.NextFollowupDate.HasValue)
            {
                this.dtpNextVisitDate.Value = this.DataSrc.NextFollowupDate.Value;
            }

            this.SignS = string.Format("{0}{1}_Mec12.png", this.SignPath, this.DataSrc.IDCardNo);
            this.SignDoc = string.Format("{0}{1}_Mec12_Doc.png", this.SignPath, this.DataSrc.IDCardNo);
            this.srcData = GlbTools.DeepCopy(this.DataSrc);
            switch (this.SelIndex)
            {
                case 1:
                    this.chk3.Text = "传授按揉迎香穴、足三里穴方法";
                    this.SignS = string.Format("{0}{1}_Mec18.png", this.SignPath, this.DataSrc.IDCardNo);
                    this.SignDoc = string.Format("{0}{1}_Mec18_Doc.png", this.SignPath, this.DataSrc.IDCardNo);
                    break;

                case 2:
                    this.chk3.Text = "传授按揉迎香穴、足三里穴方法";
                    this.SignS = string.Format("{0}{1}_Mec24.png", this.SignPath, this.DataSrc.IDCardNo);
                    this.SignDoc = string.Format("{0}{1}_Mec24_Doc.png", this.SignPath, this.DataSrc.IDCardNo);
                    break;

                case 3:
                    this.chk3.Text = "传授按揉四神聪穴方法";
                    this.SignS = string.Format("{0}{1}_Mec30.png", this.SignPath, this.DataSrc.IDCardNo);
                    this.SignDoc = string.Format("{0}{1}_Mec30_Doc.png", this.SignPath, this.DataSrc.IDCardNo);
                    break;
            }
            //签名初始化
            if (File.Exists(this.SignS))
            {
                Image imgeb = Image.FromFile(SignS);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignJs.Image = bmp;
                picSignJs.Show();
                imgeb.Dispose();
                this.lkJs.Enabled = true;
                picSignJs.BackColor = Color.White;
            }
            if (File.Exists(this.SignDoc))
            {
                Image imgeb = Image.FromFile(SignDoc);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picSignYs.Image = bmp;
                picSignYs.Show();
                imgeb.Dispose();
                this.lkYs.Enabled = true;
                picSignYs.BackColor = Color.White;
            }
        }

        private void IniPenSignByContrl(AxHWPenSignLib.AxHWPenSign axHWPenSign)
        {
            const UInt32 intColor = 0xC8F8DE;
            axHWPenSign.HWSetBkColor(intColor);
            axHWPenSign.HWSetCtlFrame(2, 0x000000);
            axHWPenSign.HWSetExtWndHandle(this.Handle.ToInt32());
            axHWPenSign.HWSetPenWidth(1);
        }
        public bool SaveUc()
        {
            if (GlbTools.IsChanged(this.srcData, this.DataSrc, new string[] { "ModelState", "VisitDoctor" }))
            {
                KidsTcmhmOneToThreeBLL child_tcmhm_onethree = new KidsTcmhmOneToThreeBLL();
                if (this.DataSrc.ModelState == RecordsStateModel.AddToDB)
                {
                    child_tcmhm_onethree.Add(this.DataSrc);
                }
                else if (this.DataSrc.ModelState == RecordsStateModel.UpdateInDB)
                {
                    child_tcmhm_onethree.Update(this.DataSrc);
                }
               
            }
            return true;
        }

        public bool UpdateUc()
        {
            this.DataSrc.FollowupDate = new DateTime?(this.dtpVisitDate.Value.Date);
            this.DataSrc.NextFollowupDate = new DateTime?(this.dtpNextVisitDate.Value.Date);
            this.DataSrc.FollowUpDoctor = this.tbDoctor.Text;
            if ((this.DataSrc.ModelState == RecordsStateModel.NoValue) && !string.IsNullOrEmpty(this.DataSrc.Tcmhm + this.DataSrc.TcmhmOther))
            {
                this.DataSrc.ModelState = RecordsStateModel.AddToDB;
            }
            if (this.DataSrc.ModelState == RecordsStateModel.Unchanged)
            {
                this.DataSrc.ModelState = RecordsStateModel.UpdateInDB;
            }
            return true;
        }

        public KidsTcmhmOneToThreeModel DataSrc { get; set; }

        public int SelIndex { get; set; }

        public object srcData { get; set; }
        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            loadForm.IDCardNo = this.DataSrc.IDCardNo;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;
            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
                string path = string.Format("{0}{1}{2}.png", SignPath, this.DataSrc.IDCardNo, DaySign);
                Image imgeb = Image.FromFile(path);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picture.Image = bmp;
                imgeb.Dispose();
                picture.BackColor = Color.White;
            }
        }
        private void Clear(string DaySign, PictureBox picture)
        {
            try
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                    string path = SignPath + this.DataSrc.IDCardNo + DaySign + ".png";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    picture.BackColor = Color.FromArgb(222, 248, 200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (this.SelIndex)
            {
                case 0:
                    Clear("_Mec12_Doc", picSignYs);
                    break;
                case 1:
                    Clear("_Mec18_Doc", picSignYs);
                    break;

                case 2:
                    Clear("_Mec24_Doc", picSignYs);
                    break;

                case 3:
                    Clear("_Mec30_Doc", picSignYs);
                    break;
            }
        }

        private void lkJs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (this.SelIndex)
            {
                case 0:
                    Clear("_Mec12", picSignJs);
                    break;
                case 1:
                    Clear("_Mec18", picSignJs);
                    break;
                case 2:
                    Clear("_Mec24", picSignJs);
                    break;
                case 3:
                    Clear("_Mec30", picSignJs);
                    break;
            }
        }

        private void picSignYs_Click(object sender, EventArgs e)
        {
            switch (this.SelIndex)
            {
                case 0:
                    Sign("_Mec12_Doc", picSignYs);
                    break;
                case 1:
                    Sign("_Mec18_Doc", picSignYs);
                    break;
                case 2:
                    Sign("_Mec24_Doc", picSignYs);
                    break;
                case 3:
                    Sign("_Mec30_Doc", picSignYs);
                    break;
            }
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            switch (this.SelIndex)
            {
                case 0:
                    Sign("_Mec12", picSignJs);
                    break;
                case 1:
                    Sign("_Mec18", picSignJs);
                    break;
                case 2:
                    Sign("_Mec24", picSignJs);
                    break;
                case 3:
                    Sign("_Mec30", picSignJs);
                    break;
            }
        }
    }
}

