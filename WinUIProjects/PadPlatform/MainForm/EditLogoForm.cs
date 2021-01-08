using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;

namespace PadPlatform
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class EditLogoForm : Form
    {
        private Button btnCancel;
        private Button btnGetImage;
        private Button btnNoCard;
        private Button btnOk;
        private Button btnSetBGPNull;
        private Button btnSetCtrMiddle;
        private Button btnSetPicSize;
        private IContainer components;
        private Control currentControl;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lbImgSize;
        private Label lbMemo;
        private Label lbTitle;
        private ControlMove move_label;
        private ControlMove move_logo1;
        private ControlMove move_qc;
        private Panel panel1;
        private PictureBox picImgView;
        private PictureBox picLogo;
        private PictureBox picOthLogo;
        private TextBox tbControlText;
        private TextBox tbImgPath;
        private TextBox tbLocX;
        private TextBox tbLocY;
        private TextBox tbSizeHeight;
        private TextBox tbSizeWidth;
        private TextBox textBox1;

        public EditLogoForm()
        {
            this.InitializeComponent();
            this.LoadBackgroundImg();
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Multiselect = false,
                CheckPathExists = true,
                InitialDirectory = Application.StartupPath + @"\skin",
                Filter = "PNG files (*.PNG)|*.PNG",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream stream = dialog.OpenFile();
                    if (stream != null)
                    {
                        using (stream)
                        {
                            Image image = Image.FromStream(stream);
                            this.picImgView.BackgroundImage = image;
                            string fileName = dialog.FileName;
                            this.tbImgPath.Text = fileName;
                            string path = Application.StartupPath + @"\skin" + fileName.Substring(fileName.LastIndexOf(@"\"));
                            if (!fileName.Contains(Application.StartupPath))
                            {
                                if (File.Exists(path) && (MessageBox.Show("存在相同文件，是否替换？", "覆盖文件", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                                {
                                    return;
                                }
                                File.Copy(fileName, path, true);
                            }
                            if (this.currentControl != null)
                            {
                                this.currentControl.Tag = path;
                                this.currentControl.BackgroundImage = image;
                                this.currentControl.BackgroundImageLayout = ImageLayout.None;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + exception.Message);
                }
            }
        }

        private void btnMiddle_Click(object sender, EventArgs e)
        {
            this.lbTitle.Location = new Point((0x400 - this.lbTitle.Width) / 2, this.lbTitle.Location.Y);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.picLogo.Location.X < (this.lbTitle.Location.X + this.lbTitle.Width))
            {
                MessageBox.Show("主LOGO横坐标大于标题的横坐标!无法保存", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.picOthLogo.Location.X < (this.picLogo.Location.X + this.picLogo.Width))
            {
                MessageBox.Show("副LOGO越过了主LOGO的右侧边缘!无法保存", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if ((this.picOthLogo.Height > this.panel1.Height) || (this.picOthLogo.Width > 200))
            {
                MessageBox.Show("副LOGO尺寸过大!无法保存", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.lbTitle.Text == "")
            {
                MessageBox.Show("标题不能为空!无法保存", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.lbTitle.Text.Length > 0x10)
            {
                MessageBox.Show("标题不能字数不能超过16个!无法保存", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string path = Application.StartupPath + @"\ModuleManger.xml";
                if (File.Exists(path))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(path);
                    foreach (XmlNode node in document.DocumentElement["ControlSet"].ChildNodes)
                    {
                        XmlNode node2 = node.SelectSingleNode("Text");
                        XmlNode node3 = node.SelectSingleNode("LocationX");
                        XmlNode node4 = node.SelectSingleNode("LocationY");
                        XmlNode node5 = node.SelectSingleNode("Width");
                        XmlNode node6 = node.SelectSingleNode("Height");
                        XmlNode node7 = node.SelectSingleNode("BackGroundImage");
                        Control control = this.panel1.Controls[node.Attributes["category"].Value];
                        if (control != null)
                        {
                            node2.InnerText = control.Text;
                            node3.InnerText = control.Location.X.ToString();
                            node4.InnerText = control.Location.Y.ToString();
                            node5.InnerText = control.Width.ToString();
                            node6.InnerText = control.Height.ToString();
                            if (control.Tag != null)
                            {
                                node7.InnerText = control.Tag.ToString();
                            }
                        }
                    }
                    XmlTextWriter w = new XmlTextWriter(path, Encoding.Default) {
                        Formatting = Formatting.Indented
                    };
                    document.Save(w);
                    w.Close();
                    MessageBox.Show("保存成功", "保存", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("配置文件不存在!", "保存", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btnSetBGPNull_Click(object sender, EventArgs e)
        {
            if (this.currentControl != null)
            {
                this.currentControl.BackgroundImage = null;
                this.picImgView.BackgroundImage = null;
                this.tbImgPath.Text = "";
                this.currentControl.Tag = "";
            }
        }

        private void btnSetPicSize_Click(object sender, EventArgs e)
        {
            if ((this.currentControl.GetType().Equals(typeof(PictureBox)) && (this.currentControl != null)) && (this.currentControl.BackgroundImage != null))
            {
                this.currentControl.Size = new Size(this.currentControl.BackgroundImage.Width, this.currentControl.BackgroundImage.Height);
                this.currentControl.Refresh();
            }
        }

        private void control_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            this.currentControl = control;
            if (control.Name == "picOthLogo")
            {
                this.groupBox1.Text = "副Logo:属性";
            }
            if (control.Name == "picLogo")
            {
                this.groupBox1.Text = "主Logo:属性";
            }
            if (control.Name == this.lbMemo.Name)
            {
                this.lbMemo.Visible = true;
            }
            else
            {
                this.lbMemo.Visible = false;
            }
            this.textBox1.Text = control.Left.ToString();
            this.tbLocX.Text = control.Location.X.ToString();
            this.tbLocY.Text = control.Location.Y.ToString();
            this.tbSizeHeight.Text = control.Size.Height.ToString();
            this.tbSizeWidth.Text = control.Size.Width.ToString();
            this.tbControlText.Text = control.Text;
            bool flag = true;
            if (control.GetType().Equals(typeof(Label)))
            {
                this.picImgView.BackgroundImage = null;
                this.lbImgSize.Text = "";
            }
            else
            {
                flag = false;
                this.picImgView.BackgroundImage = control.BackgroundImage;
                if (control.BackgroundImage != null)
                {
                    this.lbImgSize.Text = control.BackgroundImage.Size.ToString();
                }
            }
            this.tbControlText.Enabled = flag;
            this.tbImgPath.Enabled = !flag;
            this.btnGetImage.Enabled = !flag;
            if (control.Name == "picLogo")
            {
                this.btnGetImage.Enabled = false;
            }
            this.btnSetCtrMiddle.Enabled = flag;
            this.btnSetPicSize.Enabled = !flag;
            this.btnSetBGPNull.Enabled = !flag;
        }

        private void control_LocationChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            this.tbLocX.Text = control.Location.X.ToString();
            this.tbLocY.Text = control.Location.Y.ToString();
        }

        private void control_SizeChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            this.tbSizeHeight.Text = control.Size.Height.ToString();
            this.tbSizeWidth.Text = control.Size.Width.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditLogoForm_Load(object sender, EventArgs e)
        {
            this.move_logo1 = new ControlMove(this.picOthLogo, true);
            Rectangle rectangle = new Rectangle {
                X = 860,
                Y = 10,
                Width = 0xa4,
                Height = 120
            };
            this.move_logo1.actArea = rectangle;
            this.move_qc = new ControlMove(this.picLogo, false);
            this.lbTitle.SizeChanged += new EventHandler(this.control_SizeChanged);
            this.lbTitle.LocationChanged += new EventHandler(this.control_LocationChanged);
            this.lbTitle.Click += new EventHandler(this.control_Click);
            this.picLogo.SizeChanged += new EventHandler(this.control_SizeChanged);
            this.picLogo.LocationChanged += new EventHandler(this.control_LocationChanged);
            this.picLogo.Click += new EventHandler(this.control_Click);
            this.picOthLogo.SizeChanged += new EventHandler(this.control_SizeChanged);
            this.picOthLogo.LocationChanged += new EventHandler(this.control_LocationChanged);
            this.picOthLogo.Click += new EventHandler(this.control_Click);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLogoForm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picOthLogo = new System.Windows.Forms.PictureBox();
            this.btnNoCard = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbMemo = new System.Windows.Forms.Label();
            this.tbControlText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSetBGPNull = new System.Windows.Forms.Button();
            this.btnSetPicSize = new System.Windows.Forms.Button();
            this.lbImgSize = new System.Windows.Forms.Label();
            this.picImgView = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetImage = new System.Windows.Forms.Button();
            this.tbImgPath = new System.Windows.Forms.TextBox();
            this.tbSizeWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSizeHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLocY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLocX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetCtrMiddle = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOthLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(334, 45);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(347, 35);
            this.lbTitle.TabIndex = 84;
            this.lbTitle.Text = "基本公共卫生服务平台";
            this.lbTitle.Click += new System.EventHandler(this.control_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(707, 45);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 79);
            this.picLogo.TabIndex = 83;
            this.picLogo.TabStop = false;
            // 
            // picOthLogo
            // 
            this.picOthLogo.BackColor = System.Drawing.Color.Transparent;
            this.picOthLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picOthLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOthLogo.Location = new System.Drawing.Point(863, 45);
            this.picOthLogo.Name = "picOthLogo";
            this.picOthLogo.Size = new System.Drawing.Size(142, 79);
            this.picOthLogo.TabIndex = 85;
            this.picOthLogo.TabStop = false;
            // 
            // btnNoCard
            // 
            this.btnNoCard.BackColor = System.Drawing.Color.Transparent;
            this.btnNoCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNoCard.FlatAppearance.BorderSize = 0;
            this.btnNoCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoCard.Location = new System.Drawing.Point(147, 27);
            this.btnNoCard.Name = "btnNoCard";
            this.btnNoCard.Size = new System.Drawing.Size(91, 97);
            this.btnNoCard.TabIndex = 86;
            this.btnNoCard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNoCard.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lbMemo);
            this.groupBox1.Controls.Add(this.tbControlText);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbSizeWidth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSizeHeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbLocY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLocX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSetCtrMiddle);
            this.groupBox1.Location = new System.Drawing.Point(0, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 482);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 274);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(116, 23);
            this.textBox1.TabIndex = 104;
            // 
            // lbMemo
            // 
            this.lbMemo.AutoSize = true;
            this.lbMemo.ForeColor = System.Drawing.Color.Red;
            this.lbMemo.Location = new System.Drawing.Point(25, 183);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(259, 14);
            this.lbMemo.TabIndex = 103;
            this.lbMemo.Text = "备注：字体个数不能超过16个且不能为空";
            this.lbMemo.Visible = false;
            // 
            // tbControlText
            // 
            this.tbControlText.Enabled = false;
            this.tbControlText.Location = new System.Drawing.Point(80, 149);
            this.tbControlText.Name = "tbControlText";
            this.tbControlText.Size = new System.Drawing.Size(262, 23);
            this.tbControlText.TabIndex = 102;
            this.tbControlText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbControlText_KeyPress);
            this.tbControlText.Leave += new System.EventHandler(this.tbControlText_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 101;
            this.label6.Text = "文字:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnSetBGPNull);
            this.groupBox2.Controls.Add(this.btnSetPicSize);
            this.groupBox2.Controls.Add(this.lbImgSize);
            this.groupBox2.Controls.Add(this.picImgView);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnGetImage);
            this.groupBox2.Controls.Add(this.tbImgPath);
            this.groupBox2.Location = new System.Drawing.Point(522, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 454);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 14);
            this.label7.TabIndex = 104;
            this.label7.Text = "所支持图片格式为PNG，背景透明";
            // 
            // btnSetBGPNull
            // 
            this.btnSetBGPNull.Enabled = false;
            this.btnSetBGPNull.Location = new System.Drawing.Point(238, 421);
            this.btnSetBGPNull.Name = "btnSetBGPNull";
            this.btnSetBGPNull.Size = new System.Drawing.Size(113, 27);
            this.btnSetBGPNull.TabIndex = 103;
            this.btnSetBGPNull.Text = "将背景设为空";
            this.btnSetBGPNull.UseVisualStyleBackColor = true;
            this.btnSetBGPNull.Click += new System.EventHandler(this.btnSetBGPNull_Click);
            // 
            // btnSetPicSize
            // 
            this.btnSetPicSize.Enabled = false;
            this.btnSetPicSize.Location = new System.Drawing.Point(357, 421);
            this.btnSetPicSize.Name = "btnSetPicSize";
            this.btnSetPicSize.Size = new System.Drawing.Size(126, 27);
            this.btnSetPicSize.TabIndex = 102;
            this.btnSetPicSize.Text = "控件大小如图片";
            this.btnSetPicSize.UseVisualStyleBackColor = true;
            this.btnSetPicSize.Click += new System.EventHandler(this.btnSetPicSize_Click);
            // 
            // lbImgSize
            // 
            this.lbImgSize.AutoSize = true;
            this.lbImgSize.BackColor = System.Drawing.Color.Transparent;
            this.lbImgSize.Location = new System.Drawing.Point(13, 426);
            this.lbImgSize.Name = "lbImgSize";
            this.lbImgSize.Size = new System.Drawing.Size(84, 14);
            this.lbImgSize.TabIndex = 101;
            this.lbImgSize.Text = "           ";
            // 
            // picImgView
            // 
            this.picImgView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picImgView.Location = new System.Drawing.Point(9, 51);
            this.picImgView.Name = "picImgView";
            this.picImgView.Size = new System.Drawing.Size(474, 364);
            this.picImgView.TabIndex = 100;
            this.picImgView.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 97;
            this.label5.Text = "路径:";
            // 
            // btnGetImage
            // 
            this.btnGetImage.Enabled = false;
            this.btnGetImage.Location = new System.Drawing.Point(357, 21);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(47, 23);
            this.btnGetImage.TabIndex = 99;
            this.btnGetImage.Text = "....";
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // tbImgPath
            // 
            this.tbImgPath.Enabled = false;
            this.tbImgPath.Location = new System.Drawing.Point(54, 22);
            this.tbImgPath.Name = "tbImgPath";
            this.tbImgPath.ReadOnly = true;
            this.tbImgPath.Size = new System.Drawing.Size(297, 23);
            this.tbImgPath.TabIndex = 98;
            // 
            // tbSizeWidth
            // 
            this.tbSizeWidth.Location = new System.Drawing.Point(80, 120);
            this.tbSizeWidth.Name = "tbSizeWidth";
            this.tbSizeWidth.ReadOnly = true;
            this.tbSizeWidth.Size = new System.Drawing.Size(116, 23);
            this.tbSizeWidth.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 95;
            this.label3.Text = "宽度:";
            // 
            // tbSizeHeight
            // 
            this.tbSizeHeight.Location = new System.Drawing.Point(80, 88);
            this.tbSizeHeight.Name = "tbSizeHeight";
            this.tbSizeHeight.ReadOnly = true;
            this.tbSizeHeight.Size = new System.Drawing.Size(116, 23);
            this.tbSizeHeight.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 93;
            this.label4.Text = "高度:";
            // 
            // tbLocY
            // 
            this.tbLocY.Location = new System.Drawing.Point(80, 59);
            this.tbLocY.Name = "tbLocY";
            this.tbLocY.ReadOnly = true;
            this.tbLocY.Size = new System.Drawing.Size(116, 23);
            this.tbLocY.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 91;
            this.label2.Text = "坐标Y:";
            // 
            // tbLocX
            // 
            this.tbLocX.Location = new System.Drawing.Point(80, 27);
            this.tbLocX.Name = "tbLocX";
            this.tbLocX.ReadOnly = true;
            this.tbLocX.Size = new System.Drawing.Size(116, 23);
            this.tbLocX.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 89;
            this.label1.Text = "坐标X:";
            // 
            // btnSetCtrMiddle
            // 
            this.btnSetCtrMiddle.Enabled = false;
            this.btnSetCtrMiddle.Location = new System.Drawing.Point(348, 145);
            this.btnSetCtrMiddle.Name = "btnSetCtrMiddle";
            this.btnSetCtrMiddle.Size = new System.Drawing.Size(125, 27);
            this.btnSetCtrMiddle.TabIndex = 88;
            this.btnSetCtrMiddle.Text = "将标题设置居中";
            this.btnSetCtrMiddle.UseVisualStyleBackColor = true;
            this.btnSetCtrMiddle.Click += new System.EventHandler(this.btnMiddle_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(786, 654);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 27);
            this.btnOk.TabIndex = 89;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(918, 654);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 90;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.picOthLogo);
            this.panel1.Controls.Add(this.btnNoCard);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 146);
            this.panel1.TabIndex = 91;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // EditLogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1280, 711);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditLogoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置标题和logo";
            this.Load += new System.EventHandler(this.EditLogoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOthLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LoadBackgroundImg()
        {
            string path = Application.StartupPath + @"\ModuleManger.xml";
            if (File.Exists(path))
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);
                foreach (XmlNode node in document.DocumentElement["ControlSet"].ChildNodes)
                {
                    XmlNode node2 = node.SelectSingleNode("Text");
                    XmlNode node3 = node.SelectSingleNode("LocationX");
                    XmlNode node4 = node.SelectSingleNode("LocationY");
                    XmlNode node5 = node.SelectSingleNode("Width");
                    XmlNode node6 = node.SelectSingleNode("Height");
                    XmlNode node7 = node.SelectSingleNode("BackGroundImage");
                    Control control = this.panel1.Controls[node.Attributes["category"].Value];
                    if (control != null)
                    {
                        control.Text = node2.InnerText;
                        control.Location = new Point(int.Parse(node3.InnerText), int.Parse(node4.InnerText));
                        control.Size = new Size(int.Parse(node5.InnerText), int.Parse(node6.InnerText));
                        if ((!string.IsNullOrEmpty(node7.InnerText) && File.Exists(node7.InnerText)) && (node.Attributes["category"].Value != "picLogo"))
                        {
                            control.BackgroundImage = Image.FromFile(node7.InnerText);
                            control.BackgroundImageLayout = ImageLayout.None;
                        }
                    }
                }
            }
            if (this.picOthLogo.BackgroundImage == null)
            {
                this.picLogo.Location = new Point(0x357, 0x23);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Blue) {
                DashStyle = DashStyle.Dot
            };
            e.Graphics.DrawRectangle(pen, this.move_logo1.actArea);
            e.Graphics.DrawString("副Logo活动区域", new Font("Arial", 8.5f), new SolidBrush(Color.Black), (PointF) this.move_logo1.actArea.Location);
        }

        private void tbControlText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.tbControlText.Enabled && !string.IsNullOrEmpty(this.tbControlText.Text.Trim())) && (e.KeyChar == '\r'))
            {
                this.lbTitle.Text = this.tbControlText.Text;
            }
        }

        private void tbControlText_Leave(object sender, EventArgs e)
        {
            if ((this.tbControlText.Enabled && !string.IsNullOrEmpty(this.tbControlText.Text.Trim())) && (this.lbTitle.Text != this.tbControlText.Text))
            {
                this.lbTitle.Text = this.tbControlText.Text;
            }
        }
    }
}

