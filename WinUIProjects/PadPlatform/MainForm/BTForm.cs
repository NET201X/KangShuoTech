using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using Utilities.BlueToothTools.MsBluetooth;

namespace PadPlatform
{

    public class BTForm : Form
    {
        private BluetoothWin32Authentication _win32Auth;
        private Button btnBTAuto;
        private Button btnCancel;
        private Button btnDelBTDev;
        private Button btnRefresh;
        private IContainer components;
        private IEnumerable<BLUETOOTH_DEVICE_INFO> devices;
        private GroupBox groupBox1;
        private ImageList imglistBT;
        private ListView listView1;
        private TextBox tbBTInfo;
        private TextBox tbOut;

        public BTForm()
        {
            this.InitializeComponent();
        }

        private void auth_callback(string s1, string s2)
        {
            this.authTextbox(s1 + "配.");
        }

        private bool auth_callback_ex(IntPtr pvParam, ref BLUETOOTH_DEVICE_INFO authParams)
        {
            NativeMethods.BluetoothUpdateDeviceRecord(ref authParams);
            string szName = authParams.szName;
            string pszPasskey = "0000";
            int num = NativeMethods.BluetoothSendAuthenticationResponse(pvParam, ref authParams, pszPasskey);
            if (num == 0)
            {
                this.authTextbox(szName + "配对成功");
                this.QueryDevice();
                this.start_auth();
            }
            else
            {
                this.authTextbox(szName + "--f" + num.ToString());
                this.start_auth();
            }
            return true;
        }

        private void authTextbox(string str)
        {
            Action<string> method = new Action<string>(this.authTextbox);
            if (this.tbOut.InvokeRequired)
            {
                this.tbOut.Invoke(method, new object[] { str });
            }
            else
            {
                this.tbOut.AppendText(str + "\r\n");
            }
        }

        private void bthAuthCallback(string str1, string str2)
        {
            this.authTextbox(str1 + ":" + str2);
            long num = long.Parse(str2);
            byte[] array = new byte[8];
            BitConverter.GetBytes(num).CopyTo(array, (long) 0L);
            string str = string.Format("{0}:{1}:{2}:{3}:{4}:{5}", new object[] { array[5].ToString("x2"), array[4].ToString("x2"), array[3].ToString("x2"), array[2].ToString("x2"), array[1].ToString("x2"), array[0].ToString("x2") });
            string.Format("设备名:{0},地址:{1}。配对成功", str1, str);
            this.UpdateListview();
        }

        private void bthAuthResult(string str, bool result)
        {
        }

        private void btnBTAuto_Click(object sender, EventArgs e)
        {
            if (this._win32Auth == null)
            {
                this.authTextbox("自动配对.......");
                this.start_auth_open();
                this._win32Auth = new BluetoothWin32Authentication(new Action<string, string>(this.bthAuthCallback), new Action<string, bool>(this.bthAuthResult));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this._win32Auth != null)
            {
                this._win32Auth.Dispose();
            }
            base.Close();
        }

        private void btnDelBTDev_Click(object sender, EventArgs e)
        {
            ListViewItem focusedItem = this.listView1.FocusedItem;
            if ((focusedItem != null) && (focusedItem.Tag != null))
            {
                BLUETOOTH_DEVICE_INFO tag = (BLUETOOTH_DEVICE_INFO) focusedItem.Tag;
                byte[] array = new byte[8];
                BitConverter.GetBytes(tag.Address).CopyTo(array, (long) 0L);
                NativeMethods.BluetoothRemoveDevice(array);
            }
            Cursor.Current = Cursors.WaitCursor;
            this.listView1.Items.Clear();
            this.QueryDevice();
            Cursor.Current = Cursors.Default;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            this.QueryDevice();
            Cursor.Current = Cursors.Default;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void BTForm_Load(object sender, EventArgs e)
        {
            object powerStatus = BTPowerManager.GetPowerStatus();
            if (powerStatus != null)
            {
                if (powerStatus.ToString() == "0")
                {
                    this.tbOut.AppendText("节电模式关闭\r\n");
                }
                else
                {
                    this.tbOut.AppendText("节电模式开启\r\n");
                    BTPowerManager.SetPowerState();
                    this.tbOut.AppendText("关闭节电模式，重启电脑生效!\r\n");
                }
            }
            else
            {
                BTPowerManager.SetPowerState();
                this.tbOut.AppendText("******关闭节电模式，重启生效!\r\n");
            }
            new Action(this.SetBthService).BeginInvoke(new AsyncCallback(this.QueryDevice), null);
            this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTForm));
            this.groupBox1 = new GroupBox();
            this.tbBTInfo = new TextBox();
            this.listView1 = new ListView();
            this.imglistBT = new ImageList(this.components);
            this.btnBTAuto = new Button();
            this.btnDelBTDev = new Button();
            this.btnCancel = new Button();
            this.tbOut = new TextBox();
            this.btnRefresh = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.tbBTInfo);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.groupBox1.Location = new Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x279, 0xd1);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "蓝牙设备";
            this.tbBTInfo.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.tbBTInfo.Location = new Point(0x188, 0x10);
            this.tbBTInfo.Multiline = true;
            this.tbBTInfo.Name = "tbBTInfo";
            this.tbBTInfo.ReadOnly = true;
            this.tbBTInfo.Size = new Size(0xeb, 0xbb);
            this.tbBTInfo.TabIndex = 7;
           
            this.listView1.LargeImageList = this.imglistBT;
            this.listView1.Location = new Point(6, 0x16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(380, 0xb3);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.imglistBT.ImageStream = (ImageListStreamer)resources.GetObject("imglistBT.ImageStream");
            this.imglistBT.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistBT.Images.SetKeyName(0, "drop kbtobexclient.png");
            this.btnBTAuto.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnBTAuto.Location = new Point(0x1f6, 0x10b);
            this.btnBTAuto.Name = "btnBTAuto";
            this.btnBTAuto.Size = new Size(140, 0x22);
            this.btnBTAuto.TabIndex = 1;
            this.btnBTAuto.Text = "自动配对";
            this.btnBTAuto.UseVisualStyleBackColor = true;
            this.btnBTAuto.Click += new EventHandler(this.btnBTAuto_Click);
            this.btnDelBTDev.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnDelBTDev.Location = new Point(0x1f6, 0x133);
            this.btnDelBTDev.Name = "btnDelBTDev";
            this.btnDelBTDev.Size = new Size(140, 0x22);
            this.btnDelBTDev.TabIndex = 2;
            this.btnDelBTDev.Text = "删除设备";
            this.btnDelBTDev.UseVisualStyleBackColor = true;
            this.btnDelBTDev.Click += new EventHandler(this.btnDelBTDev_Click);
            this.btnCancel.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnCancel.Location = new Point(0x1f6, 0x15b);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(140, 0x22);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.tbOut.Location = new Point(12, 0xe3);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ScrollBars = ScrollBars.Vertical;
            this.tbOut.Size = new Size(0x1da, 0xa4);
            this.tbOut.TabIndex = 5;
            this.btnRefresh.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnRefresh.Location = new Point(0x1f6, 0xe3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(140, 0x22);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新列表";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x291, 400);
            base.Controls.Add(this.btnRefresh);
            base.Controls.Add(this.tbOut);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnDelBTDev);
            base.Controls.Add(this.btnBTAuto);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "BTForm";
            base.ShowIcon = false;
            this.Text = "蓝牙";
            base.Load += new EventHandler(this.BTForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.listView1.Items.Count > 0) && (this.listView1.FocusedItem != null))
            {
                BLUETOOTH_DEVICE_INFO tag = (BLUETOOTH_DEVICE_INFO) this.listView1.FocusedItem.Tag;
                this.tbBTInfo.Text = string.Format("蓝牙{0},地址为：{1}\r\n", tag.szName, tag.Address.ToString());
                this.tbBTInfo.AppendText(string.Format("最近活动日期{0}-{1}-{2} {3}:{4}:{5}", new object[] { tag.LastSeen.Year, tag.LastSeen.Month, tag.LastSeen.Day, tag.LastSeen.Hour, tag.LastSeen.Minute, tag.LastSeen.Second }));
            }
        }

        private void QueryDevice()
        {
            this.setButtonEnabled(false);
            this.devices = NativeMethods.GetDeviceInfos(true, true, true, true, true, 2);
            this.UpdateListview();
            this.setButtonEnabled(true);
        }

        private void QueryDevice(IAsyncResult result)
        {
            Action asyncDelegate = (Action) ((AsyncResult) result).AsyncDelegate;
            this.authTextbox("获取当前蓝牙设备信息,请稍后....");
            this.QueryDevice();
            asyncDelegate.EndInvoke(result);
            this.authTextbox("获取当前蓝牙设备信息成功");
        }

        private void SetBthService()
        {
            string name = @"SYSTEM\CurrentControlSet\Services\BthServ";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(name, true);
            int result = -1;
            if (int.TryParse(key.GetValue("Start").ToString(), out result) && (result != 2))
            {
                key.SetValue("Start", 2);
            }
            ServiceController controller = new ServiceController("Bluetooth Support Service");
            if (controller.Status == ServiceControllerStatus.Stopped)
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(5000.0);
                this.authTextbox("启动蓝牙服务.....");
                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running, timeout);
                Thread.Sleep(500);
            }
        }

        private void setButtonEnabled(bool enable)
        {
            Action<bool> method = new Action<bool>(this.setButtonEnabled);
            if (this.btnRefresh.InvokeRequired)
            {
                this.btnRefresh.Invoke(method, new object[] { enable });
            }
            else
            {
                this.btnRefresh.Enabled = enable;
                this.btnBTAuto.Enabled = enable;
                this.btnDelBTDev.Enabled = enable;
            }
        }

        private void start_auth()
        {
            BluetoothAuthenticationRegistrationHandle phRegHandle = null;
            NativeMethods.BluetoothFindRadioParams @params;
            @params.size = 4;
            IntPtr zero = IntPtr.Zero;
            NativeMethods.BluetoothFindFirstRadio(ref @params, out zero);
            if (!NativeMethods.BluetoothEnableDiscovery(zero, true))
            {
                this.authTextbox("错误2:设置蓝牙适配器可见失败!\r\n");
            }
            else if (!NativeMethods.BluetoothEnableIncomingConnections(zero, true))
            {
                this.authTextbox("错误3:设置蓝牙适配器可连接失败!\r\n");
            }
            else
            {
                BLUETOOTH_DEVICE_INFO pbtdi = new BLUETOOTH_DEVICE_INFO(0L);
                if (NativeMethods.BluetoothRegisterForAuthentication(ref pbtdi, out phRegHandle, new NativeMethods.BluetoothAuthenticationCallback(this.auth_callback_ex), IntPtr.Zero) == 0)
                {
                    this.authTextbox("自动配对.......");
                }
            }
        }

        private void start_auth_open()
        {
            NativeMethods.BluetoothFindRadioParams @params;
            @params.size = 4;
            IntPtr zero = IntPtr.Zero;
            NativeMethods.BluetoothFindFirstRadio(ref @params, out zero);
            if (!NativeMethods.BluetoothEnableDiscovery(zero, true))
            {
                this.authTextbox("错误2:设置蓝牙适配器可见失败!\r\n");
            }
            else if (!NativeMethods.BluetoothEnableIncomingConnections(zero, true))
            {
                this.authTextbox("错误3:设置蓝牙适配器可连接失败!\r\n");
            }
        }

        private void UpdateListview()
        {
            Action method = new Action(this.UpdateListview);
            if (this.listView1.InvokeRequired)
            {
                this.listView1.Invoke(method);
            }
            else
            {
                this.listView1.Items.Clear();
                foreach (BLUETOOTH_DEVICE_INFO bluetooth_device_info in this.devices)
                {
                    if (bluetooth_device_info.fRemembered)
                    {
                        ListViewItem item = new ListViewItem(bluetooth_device_info.szName) {
                            ImageIndex = 0,
                            Tag = bluetooth_device_info
                        };
                        this.listView1.Items.Add(item);
                    }
                }
                this.listView1.Refresh();
            }
        }
    }
}

