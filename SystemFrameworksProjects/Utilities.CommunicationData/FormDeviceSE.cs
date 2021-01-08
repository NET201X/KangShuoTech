using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using KangShuoTech.Utilities.CommunicationData.Properties;

namespace KangShuoTech.Utilities.CommunicationData
{
    public class FormDeviceSE : Form
    {
        private IContainer components;
        private Label label1;
        private Label lblMsg;
        private IntPtr m_hwnd;
        private int m_OnceCount = 200;
        private Queue<short[]> m_queue = new Queue<short[]>();
        private Thread m_splitTD;
        private PictureBox picCancel;
        private PictureBox picSave;

        public event savedata OnSaveData;

        public FormDeviceSE()
        {
            this.InitializeComponent();
            this.lblMsg.Visible = false;
            this.m_splitTD = new Thread(new ThreadStart(this.SplitData));
            this.m_splitTD.Name = "线程:解析数据并绘制";
            this.m_splitTD.IsBackground = true;
            this.m_splitTD.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private short[] EcgPacketAnalysis(byte[] packetsBuffer, uint offset, uint length)
        {
            if ((offset + length) > packetsBuffer.Length)
            {
                return null;
            }
            short[] numArray = new short[8];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    byte num3 = Convert.ToByte(Math.Pow(2.0, (double) j));
                    byte num4 = (byte) ((packetsBuffer[(int) ((IntPtr) (i + offset))] & num3) << (7 - j));
                    byte num5 = (byte) (packetsBuffer[(int) ((IntPtr) (((2 + (i * 7)) + j) + offset))] | num4);
                    packetsBuffer[(int) ((IntPtr) (((2 + (i * 7)) + j) + offset))] = num5;
                }
            }
            numArray[0] = (short) ((((short) (packetsBuffer[(int) ((IntPtr) (4 + offset))] & 15)) << 8) | packetsBuffer[(int) ((IntPtr) (5 + offset))]);
            numArray[1] = (short) ((((short) (packetsBuffer[(int) ((IntPtr) (6 + offset))] & 15)) << 8) | packetsBuffer[(int) ((IntPtr) (7 + offset))]);
            numArray[2] = (short) ((((short) (packetsBuffer[(int) ((IntPtr) (8 + offset))] & 15)) << 8) | packetsBuffer[(int) ((IntPtr) (9 + offset))]);
            numArray[3] = (short) ((((short) (packetsBuffer[(int) ((IntPtr) (10 + offset))] & 15)) << 8) | packetsBuffer[(int) ((IntPtr) (11 + offset))]);
            numArray[4] = (short) ((((short) (packetsBuffer[(int) ((IntPtr) (12 + offset))] & 15)) << 8) | packetsBuffer[(int) ((IntPtr) (13 + offset))]);
            numArray[5] = (short) ((((short) (packetsBuffer[(int) ((IntPtr) (14 + offset))] & 15)) << 8) | packetsBuffer[(int) ((IntPtr) (15 + offset))]);
            numArray[6] = (short) (((((ushort) (packetsBuffer[(int) ((IntPtr) (4 + offset))] & 240)) << 4) | ((ushort) (packetsBuffer[(int) ((IntPtr) (6 + offset))] & 240))) | (((ushort) (packetsBuffer[(int) ((IntPtr) (8 + offset))] & 240)) >> 4));
            numArray[7] = (short) (((((ushort) (packetsBuffer[(int) ((IntPtr) (10 + offset))] & 240)) << 4) | ((ushort) (packetsBuffer[(int) ((IntPtr) (12 + offset))] & 240))) | (((ushort) (packetsBuffer[(int) ((IntPtr) (14 + offset))] & 240)) >> 4));
            int num6 = 30;
            numArray[0] = (short) (((double) ((numArray[0] - 0x800) * num6)) / 327.68);
            numArray[1] = (short) (((double) ((numArray[1] - 0x800) * num6)) / 327.68);
            numArray[2] = (short) (((double) ((numArray[2] - 0x800) * num6)) / 327.68);
            numArray[3] = (short) (((double) ((numArray[3] - 0x800) * num6)) / 327.68);
            numArray[4] = (short) (((double) ((numArray[4] - 0x800) * num6)) / 327.68);
            numArray[5] = (short) (((double) ((numArray[5] - 0x800) * num6)) / 327.68);
            numArray[6] = (short) (((double) ((numArray[6] - 0x800) * num6)) / 327.68);
            numArray[7] = (short) (((double) ((numArray[7] - 0x800) * num6)) / 327.68);
            return numArray;
        }

        private void FormDeviceSE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_splitTD != null)
            {
                this.m_splitTD.Abort();
            }
        }

        private void FormDeviceSE_Shown(object sender, EventArgs e)
        {
            this.m_hwnd = base.Handle;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.picSave = new System.Windows.Forms.PictureBox();
            this.picCancel = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "I";
            // 
            // picSave
            // 
            this.picSave.BackgroundImage = Resources.up_baocun;
            this.picSave.Location = new System.Drawing.Point(56, 671);
            this.picSave.Name = "picSave";
            this.picSave.Size = new System.Drawing.Size(111, 38);
            this.picSave.TabIndex = 5;
            this.picSave.TabStop = false;
            this.picSave.Click += new System.EventHandler(this.picSave_Click);
            // 
            // picCancel
            // 
            this.picCancel.BackgroundImage = Resources.drop;
            this.picCancel.Location = new System.Drawing.Point(821, 671);
            this.picCancel.Name = "picCancel";
            this.picCancel.Size = new System.Drawing.Size(108, 38);
            this.picCancel.TabIndex = 6;
            this.picCancel.TabStop = false;
            this.picCancel.Click += new System.EventHandler(this.picDrop_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(342, 689);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(330, 20);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "正 在 保 存 数 据, 请 稍 候...";
            this.lblMsg.Visible = false;
            // 
            // FormDeviceSE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1009, 721);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.picCancel);
            this.Controls.Add(this.picSave);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDeviceSE";
            this.Text = "FormDeviceSE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDeviceSE_FormClosing);
            this.Shown += new System.EventHandler(this.FormDeviceSE_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void OperatePoint(short[] data)
        {
            if (this.m_queue.Count < 0x8ca0)
            {
                this.m_queue.Enqueue(data);
            }
            else
            {
                this.m_queue.Dequeue();
                this.m_queue.Enqueue(data);
            }
        }

        private void picDrop_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void picSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.OnSaveData != null)
                {
                    this.OnSaveData();
                }
                if (this.m_splitTD != null)
                {
                    this.m_splitTD.Abort();
                }
                this.saveFile();
                base.DialogResult = DialogResult.Cancel;
            }
            catch (Exception exception)
            {
                MessageBox.Show("存储心电波形错误." + exception.Message);
            }
        }

        private void saveFile()
        {
            try
            {
                string executablePath = Application.ExecutablePath;
                int num = executablePath.LastIndexOf(@"\");
                string str2 = executablePath.Substring(0, num + 1);
                if (!Directory.Exists(str2 + "sixparam"))
                {
                    Directory.CreateDirectory(str2 + "sixparam");
                }
                FileStream stream = new FileStream(str2 + @"sixparam\result.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter writer = new StreamWriter(stream);
                stream.SetLength(0L);
                while (this.m_queue.Count > 0)
                {
                    foreach (short num2 in this.m_queue.Dequeue())
                    {
                        writer.Write(num2.ToString() + " ");
                    }
                }
                writer.Flush();
                writer.Close();
                if (File.Exists(str2 + @"sixparam\result.txt"))
                {
                    this.lblMsg.Visible = true;
                    this.lblMsg.Refresh();
                    Thread thread = new Thread(new ThreadStart(this.UpdateEcg)) {
                        Name = "赛尔福心电上传线程"
                    };
                    thread.Start();
                    int num3 = 0;
                    while (thread.IsAlive)
                    {
                        num3++;
                        Thread.Sleep(0x3e8);
                        if (num3 > 20)
                        {
                            thread.Abort();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("存储心电文件失败!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("存储心电文件错误!" + exception.Message);
            }
        }

        private void SplitData()
        {
            int num = 0x400;
            int num2 = 80;
            int num3 = 80;
            short[] numArray = new short[8];
            new Pen(Color.FromArgb(0xdd, 210, 0), 1.5f);
            Pen pen = new Pen(Color.Green, 1f);
            Bitmap image = new Bitmap(0x400, 720);
            Point point = new Point(0, 0);
            int x = -1;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            byte[] destinationArray = new byte[0x19];
            Graphics graphics = null;
            Graphics graphics2 = null;
            int num13 = this.m_OnceCount / 0x19;
            while (this.m_hwnd == IntPtr.Zero)
            {
                ClsResult.OperatePointSE(null, false);
            }
            if (this.m_hwnd != IntPtr.Zero)
            {
                graphics = Graphics.FromHwnd(this.m_hwnd);
                graphics2 = Graphics.FromImage(image);
            }
            while (true)
            {
                byte[] sourceArray = ClsResult.OperatePointSE(null, false);
                if (sourceArray != null)
                {
                    if (sourceArray.Length != this.m_OnceCount)
                    {
                        Trace.WriteLine("============error:data.length != " + this.m_OnceCount.ToString());
                    }
                    else
                    {
                        if ((x >= 0) && (x < (num - num13)))
                        {
                            graphics2.FillRectangle(Brushes.OldLace, x, 0, num13 + 2, 700);
                        }
                        else
                        {
                            graphics2.FillRectangle(Brushes.OldLace, x, 0, num13 + 2, 700);
                            graphics2.FillRectangle(Brushes.OldLace, 0, 0, ((num13 + 2) - num) + x, 700);
                        }
                        for (int i = 0; i < num13; i++)
                        {
                            Array.Copy(sourceArray, i * 0x19, destinationArray, 0, 0x19);
                            short[] data = this.EcgPacketAnalysis(destinationArray, 6, 0x13);
                            this.OperatePoint(data);
                            if (data == null)
                            {
                                data = numArray;
                            }
                            if (x == (num - 1))
                            {
                                x = -1;
                            }
                            graphics2.DrawLine(pen, x, num2 - num5, x + 1, num2 - data[0]);
                            graphics2.DrawLine(pen, x, (num2 + num3) - num6, x + 1, (num2 + num3) - data[1]);
                            graphics2.DrawLine(pen, x, (num2 + (num3 * 2)) - num7, x + 1, (num2 + (num3 * 2)) - data[2]);
                            graphics2.DrawLine(pen, x, (num2 + (num3 * 3)) - num8, x + 1, (num2 + (num3 * 3)) - data[3]);
                            graphics2.DrawLine(pen, x, (num2 + (num3 * 4)) - num9, x + 1, (num2 + (num3 * 4)) - data[4]);
                            graphics2.DrawLine(pen, x, (num2 + (num3 * 5)) - num10, x + 1, (num2 + (num3 * 5)) - data[5]);
                            graphics2.DrawLine(pen, x, (num2 + (num3 * 6)) - num11, x + 1, (num2 + (num3 * 6)) - data[6]);
                            graphics2.DrawLine(pen, x, (num2 + (num3 * 7)) - num12, x + 1, (num2 + (num3 * 7)) - data[7]);
                            num5 = data[0];
                            num6 = data[1];
                            num7 = data[2];
                            num8 = data[3];
                            num9 = data[4];
                            num10 = data[5];
                            num11 = data[6];
                            num12 = data[7];
                            x++;
                        }
                        graphics.DrawImage(image, point);
                    }
                }
            }
        }

        private void UpdateEcg()
        {
            //DataSender.UpdateSafeHeart();
        }

        public delegate void savedata();
    }
}

