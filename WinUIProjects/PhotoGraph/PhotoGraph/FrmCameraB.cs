
namespace PhotoGraph
{
    using dshow;
    using dshow.Core;
    using motion;
    using KangShuoTech.CommomDataAccessProjects.CommonBLL;
    using KangShuoTech.CommomDataAccessProjects.CommonModel;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Timers;
    using System.Windows.Forms;
    using VideoSource;

    public class FrmCameraB : Form
    {
        private Button btnSave;
        private Button btnShoot;
        private CameraWindow cameraWindow;
        private IContainer components;
        private TextBox fpsPanel;
        private int intervalsToSave;
        private PictureBox pictureBox1;
        private int[] statCount = new int[15];
        private int statIndex;
        private const int statLength = 15;
        private int statReady;
        private PictureBox pictureBox2;
        private System.Timers.Timer timer;
        private int cameraId = 0;
        private Button btnCancle;

        public FrmCameraB()
        {
            this.InitializeComponent();
            this.timer = new System.Timers.Timer();
            this.timer.Interval = 1000.0;
            this.timer.SynchronizingObject = this;
            this.timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);
        }

        private void btnSave_Click(object sender, EventArgs e) //保存功能
        {
            RecordsBaseInfoModel model = new RecordsBaseInfoBLL().GetModel(this.IDCardNo);

            if (this.pictureBox1.Image != null)
            {
                string path = @"D:\QCSoft\photos\" + this.IDCardNo +  ".jpg";

                if (File.Exists(this.SavePath))
                {
                    if (MessageBox.Show(this.SavePath + "\r\n已经存在，是否覆盖？", "覆盖照片", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        File.Delete(this.SavePath);
                        this.pictureBox1.Image.Save(this.SavePath);
                        MessageBox.Show("照片保存至:" + this.SavePath);
                    }
                }
                else
                {
                    this.pictureBox1.Image.Save(this.SavePath);
                    MessageBox.Show("照片保存至:" + this.SavePath);
                }

                // 更新基本信息中的照片路径
                new CommonClassBLL().Update(this.IDCardNo, SavePath);
            }
        }

        private void btnShoot_Click(object sender, EventArgs e) //获取功能
        {
            Bitmap imageByArea = this.cameraWindow.Camera.GetImageByArea();
            this.pictureBox1.Image = imageByArea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void camera_Alarm(object sender, EventArgs e)
        {
            this.intervalsToSave = (int)(5.0 * (1000.0 / this.timer.Interval));
        }

        private void cameraWindow_Paint(object sender, PaintEventArgs e)
        {
            this.DrawCatchArea(e.Graphics);
        }

        private void CloseFile()
        {
            Camera camera = this.cameraWindow.Camera;
            if (camera != null)
            {
                this.cameraWindow.Camera = null;
                camera.SignalToStop();
                camera.WaitForStop();
                camera = null;
            }
            this.intervalsToSave = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawCatchArea(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 0.2f)
            {
                DashStyle = DashStyle.Dash
            };
            g.DrawRectangle(pen, (float)200f, (float)20f, (float)240f, (float)300f);
            float num = 200f;
            float num2 = 20f;
            g.DrawLine(pen, new PointF(42.5f + num, 7f + num2), new PointF(197.5f + num, 7f + num2));
            g.DrawLine(pen, new PointF(42.5f + num, 21f + num2), new PointF(197.5f + num, 21f + num2));
            g.DrawLine(pen, new PointF(0f + num, 250f + num2), new PointF(25f + num, 250f + num2));
            g.DrawLine(pen, new PointF(240f + num, 250f + num2), new PointF(215f + num, 250f + num2));
            g.DrawLine(pen, new PointF(120f + num, 28f + num2), new PointF(120f + num, 178f + num2));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                this.IDCardNo = "370921198606073310";
            }

            try
            {
                FilterCollection filters = new FilterCollection(FilterCategory.VideoInputDevice);
                if (filters.Count != 0)
                {
                    CaptureDevice source = new CaptureDevice
                    {
                        VideoSource = filters[cameraId].MonikerString
                    };
                    this.OpenVideoSource(source);
                }
            }
            catch (ApplicationException exception)
            {
                this.btnSave.Enabled = false;
                this.btnShoot.Enabled = false;
                MessageBox.Show(exception.Message);
            }
            catch (Exception)
            {
                this.btnSave.Enabled = false;
                this.btnShoot.Enabled = false;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCamera));
            this.fpsPanel = new System.Windows.Forms.TextBox();
            this.btnShoot = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.cameraWindow = new motion.CameraWindow();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpsPanel
            // 
            this.fpsPanel.Location = new System.Drawing.Point(767, 687);
            this.fpsPanel.Name = "fpsPanel";
            this.fpsPanel.Size = new System.Drawing.Size(129, 34);
            this.fpsPanel.TabIndex = 2;
            // 
            // btnShoot
            // 
            this.btnShoot.BackColor = System.Drawing.Color.Goldenrod;
            this.btnShoot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShoot.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnShoot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShoot.Location = new System.Drawing.Point(1113, 671);
            this.btnShoot.Margin = new System.Windows.Forms.Padding(5);
            this.btnShoot.Name = "btnShoot";
            this.btnShoot.Size = new System.Drawing.Size(100, 45);
            this.btnShoot.TabIndex = 15;
            this.btnShoot.Text = "获  取";
            this.btnShoot.UseVisualStyleBackColor = false;
            this.btnShoot.Click += new System.EventHandler(this.btnShoot_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(1235, 671);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 45);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(915, 638);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 83);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(767, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(418, 512);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(116)))), ((int)(((byte)(39)))));
            this.btnCancle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancle.FlatAppearance.BorderSize = 0;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnCancle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancle.Location = new System.Drawing.Point(1235, 12);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(100, 45);
            this.btnCancle.TabIndex = 16;
            this.btnCancle.Text = "关  闭";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // cameraWindow
            // 
            this.cameraWindow.BackColor = System.Drawing.Color.GhostWhite;
            this.cameraWindow.BackgroundImage = global::Properties.Resources.小边底;
            this.cameraWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cameraWindow.Camera = null;
            this.cameraWindow.Location = new System.Drawing.Point(12, 12);
            this.cameraWindow.Name = "cameraWindow";
            this.cameraWindow.Size = new System.Drawing.Size(730, 610);
            this.cameraWindow.TabIndex = 0;
            this.cameraWindow.Text = "cameraWindow1";
            this.cameraWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.cameraWindow_Paint);
            // 
            // FrmCamera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Properties.Resources.小边底;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1381, 758);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnShoot);
            this.Controls.Add(this.fpsPanel);
            this.Controls.Add(this.cameraWindow);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拍照";
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void OpenVideoSource(IVideoSource source)
        {
            this.Cursor = Cursors.WaitCursor;
            this.CloseFile();
            Camera camera = new Camera(source);
            camera.Start();
            this.cameraWindow.Camera = camera;
            this.statIndex = this.statReady = 0;
            this.timer.Start();
            this.Cursor = Cursors.Default;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Camera camera = this.cameraWindow.Camera;
            if (camera != null)
            {
                this.statCount[this.statIndex] = camera.FramesReceived;
                if (++this.statIndex >= 15)
                {
                    this.statIndex = 0;
                }
                if (this.statReady < 15)
                {
                    this.statReady++;
                }
                float num = 0f;
                for (int i = 0; i < this.statReady; i++)
                {
                    num += this.statCount[i];
                }
                num /= (float)this.statReady;
                this.statCount[this.statIndex] = 0;
                this.fpsPanel.Text = num.ToString("F2") + " fps";
            }
            int intervalsToSave = this.intervalsToSave;
        }

        public string IDCardNo { get; set; }

        public string SavePath { get; set; }

        /// <summary>
        /// 照相按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {

                FilterCollection filters = new FilterCollection(FilterCategory.VideoInputDevice); //调用本机摄像头
                if (filters.Count != 0)
                {
                    if (filters.Count == 2)
                    {
                        if (cameraId == 0)
                        {
                            cameraId = 1;
                        }
                        else
                        {
                            cameraId = 0;
                        }
                    }

                    CaptureDevice source = new CaptureDevice
                    {
                        VideoSource = filters[cameraId].MonikerString
                    };
                    this.OpenVideoSource(source);
                }
            }
            catch (ApplicationException exception)
            {
                this.btnSave.Enabled = false;
                this.btnShoot.Enabled = false;
                MessageBox.Show(exception.Message);
            }
            catch (Exception)
            {
                this.btnSave.Enabled = false;
                this.btnShoot.Enabled = false;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}