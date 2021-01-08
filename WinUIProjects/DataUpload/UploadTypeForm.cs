using System;
using System.Configuration;
using System.Windows.Forms;

namespace DataUpload
{
    public partial class UploadTypeForm : Form
    {
        public string Type { get; set; }//0代表生化，1代表血球
        
        public string Protocol { get; set; }

        public string IP { get; set; }

        public string Port { get; set; }

        public UploadTypeForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.tbIP.Text == "" || this.tbPort.Text == "")
            {
                MessageBox.Show("请输入ip地址及端口号");
                return;
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings[Protocol] != null) config.AppSettings.Settings[Protocol].Value = "Y";
                else config.AppSettings.Settings.Add(Protocol, "Y");

                if (config.AppSettings.Settings[IP] != null) config.AppSettings.Settings[IP].Value = this.tbIP.Text.Trim();
                else config.AppSettings.Settings.Add(IP, this.tbIP.Text.Trim());

                if (config.AppSettings.Settings[Port] != null) config.AppSettings.Settings[Port].Value = this.tbPort.Text.Trim();
                else config.AppSettings.Settings.Add(Port, this.tbPort.Text.Trim());

                config.Save(ConfigurationSaveMode.Full);

                ConfigurationManager.RefreshSection("appSettings");

                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //if (config.AppSettings.Settings[Protocol] != null) config.AppSettings.Settings[Protocol].Value = "N";
                //else config.AppSettings.Settings.Add(Protocol, "N");

                //if (config.AppSettings.Settings[IP] != null) config.AppSettings.Settings[IP].Value = "";
                //else config.AppSettings.Settings.Add(IP, "");

                //if (config.AppSettings.Settings[Port] != null) config.AppSettings.Settings[Port].Value = "";
                //else config.AppSettings.Settings.Add(Port, "");

                //config.Save(ConfigurationSaveMode.Full);

                //ConfigurationManager.RefreshSection("appSettings");
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadTypeForm_Load(object sender, EventArgs e)
        {
            Protocol = ""; IP = ""; Port = "";

            if (Type == "0")//生化
            {
                Protocol = "SHUploadIsScoketProtocol";
                IP = "SHIPAddress";
                Port = "SHPort";
            }
            else if (Type == "1")//血球
            {
                Protocol = "XQUploadIsScoketProtocol";
                IP = "XQIPAddress";
                Port = "XQPort";
            }
            else if (Type == "2")//尿检
            {
                Protocol = "NJUploadIsScoketProtocol";
                IP = "NJIPAddress";
                Port = "NJPort";
            }
            else if (Type == "3")//电解质
            {
                Protocol = "DJZUploadIsScoketProtocol";
                IP = "DJZIPAddress";
                Port = "DJZPort";
            }
            else if (Type == "4")//血球
            {
                Protocol = "XQUploadIsScoketProtocol2";
                IP = "XQIPAddress2";
                Port = "XQPort2";
            }

            string checkType = ConfigurationManager.AppSettings[Protocol].ToString();

            if (checkType == "Y")
            {
                tbIP.Text = ConfigurationManager.AppSettings[IP].ToString();
                tbPort.Text = ConfigurationManager.AppSettings[Port].ToString();
            }
        }
    }
}
