using System;
using System.ComponentModel;
using System.Drawing;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuo
{
    public class ShowErrorMessageForm : Form
    {
        private Button btnContinue;
        private Button btnExit;
        private Button btnReport;
        private IContainer components;
        public string ecInfo;
        public Exception exp;
        private Label label1;
        private StringBuilder reportContent = new StringBuilder();
        private TextBox tbErrorInfo;

        public ShowErrorMessageForm()
        {
            this.InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Sdddd();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ShowErrorMessageForm_Load(object sender, EventArgs e)
        {
            this.tbErrorInfo.Text = this.ecInfo;
            this.reportContent.Append("组织机构:" + ConfigHelper.GetNode("orgName") + " 编号:" + ConfigHelper.GetNode("orgCode") + "\r\n");
            Ping ping = new Ping();
            try
            {
                if ((PadForm.netStatus == "1") && (ping.Send("smtp.163.com").Status == IPStatus.Success))
                {
                    this.btnReport.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
            if (!this.btnReport.Enabled)
            {
                SystemErrorLogBLL report = new SystemErrorLogBLL();
                report.CheckTable("SystemErrorLog");
                SystemErrorLogModel model = new SystemErrorLogModel
                {
                    CreateDate = new DateTime?(DateTime.Now),
                    IDCardNo = PadForm.idNo,
                    LogData = this.exp.ToString(),
                    Message = this.exp.Message,
                    SendEd = "0",
                    StackTrace = this.exp.StackTrace,
                    TargetSite = this.exp.TargetSite.ToString()
                };
                report.Add(model);
            }
        }

        private string GetServerInfo()
        {
            string str = "";
            ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            Ping ping = new Ping();
            try
            {
                if (ping.Send("www.baidu.com").Status == IPStatus.Success)
                {
                    return "true";
                }
            }
            catch (Exception)
            {
            }
            foreach (ManagementObject obj2 in instances)
            {
                if (Convert.ToBoolean(obj2["ipEnabled"]))
                {
                    obj2["Caption"].ToString();
                    string[] strArray = obj2["DefaultIPGateway"] as string[];
                    if (strArray != null)
                    {
                        str = strArray[0];
                    }
                }
            }
            string.IsNullOrWhiteSpace(str);
            NetworkInterface.GetIsNetworkAvailable();
            try
            {
                IPStatus status = ping.Send(str).Status;
            }
            catch (Exception)
            {
            }
            return "true";
        }

        private void InitializeComponent()
        {
            this.tbErrorInfo = new TextBox();
            this.btnReport = new Button();
            this.label1 = new Label();
            this.btnContinue = new Button();
            this.btnExit = new Button();
            base.SuspendLayout();
            this.tbErrorInfo.Location = new Point(12, 0x1a);
            this.tbErrorInfo.Multiline = true;
            this.tbErrorInfo.Name = "tbErrorInfo";
            this.tbErrorInfo.ReadOnly = true;
            this.tbErrorInfo.Size = new Size(0x223, 0x83);
            this.tbErrorInfo.TabIndex = 0;
            this.btnReport.Location = new Point(0x1ca, 0xa6);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new Size(0x65, 0x17);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "发送错误报告";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new EventHandler(this.btnReport_Click);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.label1.Location = new Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "抱歉，程序崩溃了";
            this.btnContinue.Location = new Point(0x128, 0xa6);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new Size(0x4b, 0x17);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "继 续";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new EventHandler(this.btnContinue_Click);
            this.btnExit.Location = new Point(0x179, 0xa6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x23b, 0xc9);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnContinue);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.btnReport);
            base.Controls.Add(this.tbErrorInfo);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Name = "ShowErrorMessageForm";
            this.Text = "错误报告";
            base.Load += new EventHandler(this.ShowErrorMessageForm_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Sdddd()
        {
            this.reportContent.Append("Info:\r\n" + this.exp.ToString());
            this.reportContent.Append("Message:\r\n" + this.exp.Message);
            this.reportContent.Append("StackTrace:\r\n" + this.exp.StackTrace);
            this.reportContent.Append("TargetSite:\r\n" + this.exp.TargetSite);
            MailAddress address = new MailAddress("qinchengtech@163.com", "PAD");
            MailMessage message = new MailMessage {
                Subject = "错误报告",
                From = address
            };
            string str = "menglingwei@qinchengkeji.com";
            string displayName = "menglingwei";
            message.To.Add(new MailAddress(str, displayName));
            message.Body = this.reportContent.ToString();
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            new SmtpClient { Host = "smtp.163.com", UseDefaultCredentials = false, Credentials = new NetworkCredential("qinchengtech", "qincheng850706"), DeliveryMethod = SmtpDeliveryMethod.Network }.Send(message);
            MessageBox.Show("发送成功！");
        }
    }
}

