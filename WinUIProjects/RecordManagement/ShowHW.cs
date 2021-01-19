using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using KangShuoTech.Utilities.CommunicationData;
using KangShuoTech.Utilities.CommonControl;
using System.Configuration;

namespace ArchiveInfo
{
    public partial class ShowHW : Form
    {
        private System.Timers.Timer time;
        private Thread rThread;

        struct controlStyle//设置按钮默认的样式
        {
            public string Txt;
            public System.Drawing.Color col;
        }

        void time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

        }

        #region 界面显示设置====================================
        /// <summary>
        /// 设置设备名称等其他信息
        /// </summary>
        /// <param name="str"></param>
        private void settext(string str, Label lb)//设备名称
        {
            Action<string, Label> setLb = new Action<string, Label>(settext);
            if (lb.InvokeRequired)
            {
                lb.Invoke(setLb, new object[] { str, lb });
            }
            else
            {
                lb.Text = str;
            }
        }

        /// <summary>
        /// 设置数据信息
        /// </summary>
        /// <param name="strMsg"></param>
        private void setValue(string strMsg)//结果信息
        {
            if (!txtResult.IsDisposed)
            {
                Action<string> showMsg = new Action<string>(setValue);
                if (txtResult.InvokeRequired)
                {
                    txtResult.Invoke(showMsg, new object[] { strMsg });
                }
                else
                {
                    if (strMsg == "")
                    {
                        this.txtResult.Text = strMsg;
                    }
                    else
                    {
                        this.txtResult.AppendText(strMsg + "\r");
                        this.txtResult.ScrollToCaret();
                    }

                }
            }
        }

        private void setProcess(int strMsg)//进度条
        {
            if (strMsg > progressBar1.Maximum)
            {
                strMsg = progressBar1.Maximum;
            }
            if (strMsg < progressBar1.Minimum)
            {
                strMsg = progressBar1.Minimum;
            }

            if (!progressBar1.IsDisposed)
            {
                Action<int> showMsg = new Action<int>(setProcess);
                if (progressBar1.InvokeRequired)
                {
                    progressBar1.Invoke(showMsg, new object[] { strMsg });
                }
                else
                {
                    progressBar1.Value = strMsg;

                }
            }
        }
        #region 设置按钮是否可用====================================

        private void setControl(bool flag, Control ct)
        {
            if (ct.InvokeRequired)
            {
                Action<bool, Control> act = new Action<bool, Control>(
                    delegate(bool b, Control ct2)
                    {
                          ct2.Enabled = b;
                    });
                this.Invoke(act, new object[] { flag, ct });
            }
            else
            {
                {
                    ct.Enabled = flag;
                }
               
            }
        }

        #endregion

        #endregion

        public ShowHW()
        {
            InitializeComponent();
            time = new System.Timers.Timer(1000);
            time.Elapsed += new System.Timers.ElapsedEventHandler(time_Elapsed);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSave_Click(object sender, EventArgs e)//保存
        {
            if (ClsResult.DeviceName != "")
            {
                ClsMsgWindow.SendString("硕康智能体检系统", 1, "FromCom:ok");
            }

            btnDrop_Click(null, null);
        }

        private void btnDrop_Click(object sender, EventArgs e)//退出
        {
            if (rThread != null && rThread.IsAlive)
            {
                try
                {
                    if (startcom.m_coms != null)
                    {
                        startcom.StopRead(rThread.Name); //因为需要判定设备中是否需要继续进行com口的处理，

                    }
                }
                catch (Exception de)
                {
                    
                }
             
                rThread.Join(10);
                rThread.Abort();
            }
            this.Close();
        }

        #region 选择设备====================================

        private void button3_Click(object sender, EventArgs e)//身高体重仪
        {
            StartRead("QCTAKHW", (Control)sender);
        }

        #endregion

        //开始读取数据
        private void StartRead(string strType, Control ct)
        {
            startcom.m_coms = new string[] { ConfigurationManager.AppSettings["QCCHW"] };

            settext(strType, lbDevName);
            if (string.IsNullOrEmpty(strType))
            {
                settext("未能找到该设备的相应信息", lbMessage);
                return;
            }
            if (rThread != null && rThread.IsAlive)
            {
                settext("正在获取测量结果，请稍候！", lbMessage);
            }
            else
            {
                settext(ct.Text, lbDevName);
                rThread = new Thread(new ThreadStart(thFun));
                rThread.Name = strType;
                rThread.IsBackground = true;
                setValue("正在检测，请稍候......");
                rThread.Start();
            }

        }

        ClsCommunicationComEx startcom = new ClsCommunicationComEx();

        public void thFun()
        {
            setControl(false, gpDev);
            setControl(false, btnSave);

            settext("", lbMessage);
            setValue("");
            setProcess(10);
            string devName = Thread.CurrentThread.Name;//使用线程名称传递参数

            Thread.Sleep(1000);
            setValue("等待测量结果........");

            setProcess(20);

            int readcount = 0;
            startcom.StartRead(devName);

            do
            {
                readcount++;
                setProcess(20 + (readcount * 70) / 5000);
                Thread.Sleep(20);

            } while (!ClsResult.ResultFlag && readcount < 5000);

            startcom.StopRead(devName);
            setValue("");
            setProcess(90);
            if (!ClsResult.ResultFlag)
            {
                setValue("设备连接超时，请重试！");
            }
            else
            {
                setValue("测量结果如下");
                setValue(TranslateClsResult.TranslateToStr());
            }

            settext("", lbMessage);

            setProcess(100);
            ClsResult.ResultFlag = false;
            setControl(true, gpDev);
            setControl(true, btnSave);
        }
    }
}
