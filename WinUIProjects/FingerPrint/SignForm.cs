using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FingerPrint
{
    public partial class SignForm : Form
    {
        public string IDCardNo { get; set; }

        public string SignPath { get; set; }

        public string SignName { get; set; }

        public SignForm()
        {
            InitializeComponent();
        }

        private void SignForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(SignPath))
                {
                    Directory.CreateDirectory(SignPath);
                }

                IniPenSign();

                axHWPenSign1.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniPenSign()
        {
            IniPenSignByContrl(axHWPenSign1);
        }

        private void IniPenSignByContrl(AxHWPenSignLib.AxHWPenSign axHWPenSign)
        {
            const UInt32 intColor = 0xC8F8DE;
            axHWPenSign.HWSetBkColor(intColor);
            axHWPenSign.HWSetCtlFrame(2, 0x000000);
            axHWPenSign.HWSetExtWndHandle(this.Handle.ToInt32());
            axHWPenSign.HWSetPenWidth(1);
            int res = axHWPenSign.HWInitialize();
        }

        private void axHWPenSign1_Enter(object sender, EventArgs e)
        {
            AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

            int res = axHWPenSignT.HWInitialize();
        }

        private void axHWPenSign1_Leave(object sender, EventArgs e)
        {
            AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

            axHWPenSignT.HWFinalize();
        }
                
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefine_Click(object sender, EventArgs e)
        {
            axHWPenSign1.HWSetFilePath(string.Format("{0}{1}{2}.png", SignPath, this.IDCardNo, this.SignName));
            axHWPenSign1.HWSaveFile();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
