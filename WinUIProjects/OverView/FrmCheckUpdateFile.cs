using KangShuoTech.Utilities.Common;

namespace OverView
{
    
    using OverView.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;

    public class FrmCheckUpdateFile : Form
    {
        private int checkCount;
        public string checkResult = "";
        private const int checktimeout = 15;
        private IContainer components;
        private Label label1;
        private PictureBox pictureBox1;
        private int seconds;
        private System.Timers.Timer t_checkfile;
        public string upFileName;

        public FrmCheckUpdateFile()
        {
            this.InitializeComponent();
            this.t_checkfile = new System.Timers.Timer(2000.0);
            this.t_checkfile.Elapsed += new ElapsedEventHandler(this.t_checkfile_Elapsed);
        }

        private void CheckFile()
        {
            this.t_checkfile.Stop();
            string pValue = "";
            if (!ConfigHelper.GetNode("ftpUpdateFile", ref pValue))
            {
                pValue = "";
                ConfigHelper.WriteNode("ftpUpdateFile", pValue);
            }
            string requestUriString = string.Format(pValue, this.upFileName);
            LogHelper.LogInfo("数据上传文件:" + requestUriString);
            try
            {
                string str3 = new StreamReader(WebRequest.Create(requestUriString).GetResponse().GetResponseStream()).ReadToEnd();
                LogHelper.LogInfo("数据上传校验:" + str3);
                if (str3 == "err")
                {
                    this.setCtrText(this.label1, "上传数据失败，将会重新上传....");
                    this.checkResult = "0";
                }
                else if (str3 == "ok")
                {
                    this.setCtrText(this.label1, "上传成功,后台处理中.稍后登陆后台查询");
                    this.checkResult = "1";
                }
                else if (str3 == "empty")
                {
                    if (this.checkCount <= 15)
                    {
                        Thread.Sleep(0x3e8);
                        this.setCtrText(this.label1, "上传数据正在处理中...." + this.checkCount + "次");
                        this.t_checkfile.Start();
                        this.checkCount++;
                        return;
                    }
                    this.setCtrText(this.label1, "校验数据失败次数太多...." + this.checkCount + "次");
                    this.checkResult = "0";
                }
                else
                {
                    this.setCtrText(this.label1, "上传数据失败，将会重新上传....");
                    this.checkResult = "-1";
                }
            }
            catch (Exception exception)
            {
                this.setCtrText(this.label1, "校验数据有效性失败!");
                this.checkResult = "-1";
                LogHelper.LogError(exception);
            }
            this.seconds++;
            this.setCtrVisiable(this.pictureBox1, false);
            this.t_checkfile.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmCheckUpdateFile_Load(object sender, EventArgs e)
        {
            this.t_checkfile.Start();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(72, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "校验上传数据是否成功......";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OverView.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(34, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmCheckUpdateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 74);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCheckUpdateFile";
            this.Opacity = 0.8D;
            this.Text = "验证上传数据";
            this.Load += new System.EventHandler(this.FrmCheckUpdateFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void setCtrText(Control btn, string en)
        {
            Action<Control, string> method = new Action<Control, string>(this.setCtrText);
            if (btn.InvokeRequired)
            {
                btn.Invoke(method, new object[] { btn, en });
            }
            else
            {
                btn.Text = en;
            }
        }

        private void setCtrVisiable(Control ctr, bool vi)
        {
            Action<Control, bool> method = new Action<Control, bool>(this.setCtrVisiable);
            if (ctr.InvokeRequired)
            {
                ctr.Invoke(method, new object[] { ctr, vi });
            }
            else
            {
                ctr.Visible = vi;
            }
        }

        private void t_checkfile_Elapsed(object sender, ElapsedEventArgs e)
        {
            switch (this.seconds)
            {
                case 0:
                case 1:
                case 2:
                    this.seconds++;
                    return;

                case 3:
                    this.CheckFile();
                    return;

                case 4:
                    this.seconds++;
                    return;

                case 5:
                    this.t_checkfile.Stop();
                    base.DialogResult = DialogResult.OK;
                    return;
            }
        }
    }
}

