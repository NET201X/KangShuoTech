
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.Common;
using System.IO;
using System.Configuration;

namespace FocusGroup.Kids
{
    public class KidsWithinOneUserControl : UserControl
    {
        private ManyCheckboxs<KidsTcmhmOneModel> baojian;
        private CheckBox chk1;
        private CheckBox chk2;
        private CheckBox chk3;
        private CheckBox chk4;
        private IContainer components;
        private DateTimePicker dtpNextVisitDate;
        private DateTimePicker dtpVisitDate;
        private GroupBox groupBox1;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label lbOther;
        private TextBox tbBaojianOth;
        private LinkLabel lkYs;
        private PictureBox picSignYs;
        private Label label54;
        private LinkLabel lkJs;
        private PictureBox picSignJs;
        private Label label65;
        private TextBox tbDoctor;
        private string SignS = "";//6月家长签名
        private string SignDoc = "";//6月随访医生签名
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public KidsWithinOneUserControl()
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this.lbOther = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbBaojianOth = new System.Windows.Forms.TextBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.dtpNextVisitDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "随访日期：";
            // 
            // dtpVisitDate
            // 
            this.dtpVisitDate.Location = new System.Drawing.Point(136, 9);
            this.dtpVisitDate.Name = "dtpVisitDate";
            this.dtpVisitDate.Size = new System.Drawing.Size(200, 30);
            this.dtpVisitDate.TabIndex = 1;
            // 
            // lbOther
            // 
            this.lbOther.AutoSize = true;
            this.lbOther.Location = new System.Drawing.Point(6, 60);
            this.lbOther.Name = "lbOther";
            this.lbOther.Size = new System.Drawing.Size(59, 20);
            this.lbOther.TabIndex = 2;
            this.lbOther.Text = "其他:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbBaojianOth);
            this.groupBox1.Controls.Add(this.chk4);
            this.groupBox1.Controls.Add(this.lbOther);
            this.groupBox1.Controls.Add(this.chk3);
            this.groupBox1.Controls.Add(this.chk2);
            this.groupBox1.Controls.Add(this.chk1);
            this.groupBox1.Location = new System.Drawing.Point(26, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1249, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "中医药健康管理服务";
            // 
            // tbBaojianOth
            // 
            this.tbBaojianOth.Location = new System.Drawing.Point(68, 58);
            this.tbBaojianOth.MaxLength = 20;
            this.tbBaojianOth.Multiline = true;
            this.tbBaojianOth.Name = "tbBaojianOth";
            this.tbBaojianOth.ReadOnly = true;
            this.tbBaojianOth.Size = new System.Drawing.Size(536, 25);
            this.tbBaojianOth.TabIndex = 4;
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(646, 23);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(68, 24);
            this.chk4.TabIndex = 3;
            this.chk4.Text = "其他";
            this.chk4.UseVisualStyleBackColor = true;
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(423, 23);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(208, 24);
            this.chk3.TabIndex = 2;
            this.chk3.Text = "传授摩腹、捏脊方法";
            this.chk3.UseVisualStyleBackColor = true;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(216, 23);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(188, 24);
            this.chk2.TabIndex = 1;
            this.chk2.Text = "中医起居调摄指导";
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(9, 23);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(188, 24);
            this.chk1.TabIndex = 0;
            this.chk1.Text = "中医饮食调养指导";
            this.chk1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "随访医生签名:";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(550, 9);
            this.tbDoctor.MaxLength = 20;
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(167, 30);
            this.tbDoctor.TabIndex = 3;
            // 
            // dtpNextVisitDate
            // 
            this.dtpNextVisitDate.Location = new System.Drawing.Point(927, 7);
            this.dtpNextVisitDate.Name = "dtpNextVisitDate";
            this.dtpNextVisitDate.Size = new System.Drawing.Size(200, 30);
            this.dtpNextVisitDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(779, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "下次随访日期:";
            // 
            // lkYs
            // 
            this.lkYs.AutoSize = true;
            this.lkYs.Location = new System.Drawing.Point(334, 170);
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
            this.picSignYs.Location = new System.Drawing.Point(143, 147);
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
            this.label54.Location = new System.Drawing.Point(29, 155);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(99, 20);
            this.label54.TabIndex = 203;
            this.label54.Text = "医生签名:";
            // 
            // lkJs
            // 
            this.lkJs.AutoSize = true;
            this.lkJs.Location = new System.Drawing.Point(905, 170);
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
            this.picSignJs.Location = new System.Drawing.Point(714, 147);
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
            this.label65.Location = new System.Drawing.Point(606, 153);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(99, 20);
            this.label65.TabIndex = 199;
            this.label65.Text = "家长签名:";
            // 
            // KidsWithinOneUserControl
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
            this.Name = "KidsWithinOneUserControl";
            this.Size = new System.Drawing.Size(1353, 236);
            this.Load += new System.EventHandler(this.KidsWithinOneUserControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSignYs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSignJs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void InitUc()
        {
            if (string.IsNullOrEmpty(this.DataSrc.FollowDoctor))
            {
                this.tbDoctor.Text = ConfigHelper.GetNode("doctorName");
            }
            else
            {
                this.tbDoctor.Text = this.DataSrc.FollowDoctor;
            }
            if (this.DataSrc == null)
            {
                throw new Exception("DataSrc 为Null");
            }
            this.baojian = new ManyCheckboxs<KidsTcmhmOneModel>(this.DataSrc);
            this.baojian.AddCk(new CheckBox[] { this.chk1, this.chk2, this.chk3 });
            this.baojian.AddCk(this.chk4, this.tbBaojianOth);
            this.baojian.BindingProperty("Tcmhm", "TcmhmOther");
            if (this.DataSrc.FollowupDate.HasValue)
            {
                this.dtpVisitDate.Value = this.DataSrc.FollowupDate.Value;
            }

            if (this.DataSrc.NextFollowDate.HasValue)
            {
                this.dtpNextVisitDate.Value = this.DataSrc.NextFollowDate.Value;
            }

            this.srcData = GlbTools.DeepCopy(this.DataSrc);
            if (this.SelIndex != 2)
            {
                this.tbBaojianOth.ReadOnly = false;
                this.baojian.MVisiable = false;
                this.lbOther.Visible = false;
                this.tbBaojianOth.Size = new Size(this.tbBaojianOth.Size.Width, this.tbBaojianOth.Size.Height * 2);
                this.tbBaojianOth.Dock = DockStyle.Fill;
            }
            if (this.SelIndex == 2)//6个月
            {
                this.SignS = string.Format("{0}{1}_Mec6.png", this.SignPath, this.DataSrc.IDCardNo);
                this.SignDoc = string.Format("{0}{1}_Mec6_Doc.png", this.SignPath, this.DataSrc.IDCardNo);
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
            if (GlbTools.IsChanged(this.DataSrc, this.srcData, new string[] { "ModelState", "VisitDoctor" }))
            {
                KidsTcmhmOneBLL kidsTcmhmOneBLL = new KidsTcmhmOneBLL();
                if (this.DataSrc.ModelState == RecordsStateModel.AddToDB)
                {
                    kidsTcmhmOneBLL.Add(this.DataSrc);
                }
                else if (this.DataSrc.ModelState == RecordsStateModel.UpdateInDB)
                {
                    kidsTcmhmOneBLL.Update(this.DataSrc);
                }
               
            }
            return true;
        }

        public bool UpdateUc()
        {
            this.DataSrc.FollowupDate = new DateTime?(this.dtpVisitDate.Value.Date);
            this.DataSrc.NextFollowDate = new DateTime?(this.dtpNextVisitDate.Value.Date);
            this.DataSrc.FollowDoctor = this.tbDoctor.Text;
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

        public KidsTcmhmOneModel DataSrc { get; set; }

        public int SelIndex { get; set; }

        public object srcData { get; set; }


        private void lkYs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_Mec6_Doc", picSignYs);
        }

        private void lkJs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("_Mec6", picSignJs);
        }

        private void KidsWithinOneUserControl_Load(object sender, EventArgs e)
        {

        }
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
        private void picSignYs_Click(object sender, EventArgs e)
        {
            Sign("_Mec6_Doc", picSignYs);
        }

        private void picSignJs_Click(object sender, EventArgs e)
        {
            Sign("_Mec6", picSignJs);
        }
    }
}

