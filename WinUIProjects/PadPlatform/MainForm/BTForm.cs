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

namespace KangShuo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbBTInfo = new System.Windows.Forms.TextBox();
            this.imglistBT = new System.Windows.Forms.ImageList(this.components);
            this.btnBTAuto = new System.Windows.Forms.Button();
            this.btnDelBTDev = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbOut = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbBTInfo);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "蓝牙设备";
            // 
            // tbBTInfo
            // 
            this.tbBTInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbBTInfo.Location = new System.Drawing.Point(392, 16);
            this.tbBTInfo.Multiline = true;
            this.tbBTInfo.Name = "tbBTInfo";
            this.tbBTInfo.ReadOnly = true;
            this.tbBTInfo.Size = new System.Drawing.Size(235, 187);
            this.tbBTInfo.TabIndex = 7;
            // 
            // imglistBT
            // 
            this.imglistBT.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistBT.ImageStream")));
            this.imglistBT.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistBT.Images.SetKeyName(0, "drop kbtobexclient.png");
            // 
            // btnBTAuto
            // 
            this.btnBTAuto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBTAuto.Location = new System.Drawing.Point(502, 267);
            this.btnBTAuto.Name = "btnBTAuto";
            this.btnBTAuto.Size = new System.Drawing.Size(140, 34);
            this.btnBTAuto.TabIndex = 1;
            this.btnBTAuto.Text = "自动配对";
            this.btnBTAuto.UseVisualStyleBackColor = true;
            this.btnBTAuto.Click += new System.EventHandler(this.btnBTAuto_Click);
            // 
            // btnDelBTDev
            // 
            this.btnDelBTDev.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelBTDev.Location = new System.Drawing.Point(502, 307);
            this.btnDelBTDev.Name = "btnDelBTDev";
            this.btnDelBTDev.Size = new System.Drawing.Size(140, 34);
            this.btnDelBTDev.TabIndex = 2;
            this.btnDelBTDev.Text = "删除设备";
            this.btnDelBTDev.UseVisualStyleBackColor = true;
            this.btnDelBTDev.Click += new System.EventHandler(this.btnDelBTDev_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(502, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 34);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbOut
            // 
            this.tbOut.Location = new System.Drawing.Point(12, 227);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOut.Size = new System.Drawing.Size(474, 164);
            this.tbOut.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(502, 227);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 34);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新列表";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imglistBT;
            this.listView1.Location = new System.Drawing.Point(6, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(380, 179);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // BTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 400);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelBTDev);
            this.Controls.Add(this.btnBTAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BTForm";
            this.ShowIcon = false;
            this.Text = "蓝牙";
            this.Load += new System.EventHandler(this.BTForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

