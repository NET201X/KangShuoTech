using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Remoting;
using CommomUtilities.Common;
using System.Reflection;

namespace DataUpload
{
    public partial class MainControl : UserControl
    {
        // 取得屏幕分辨率的宽高
        private int SW = Screen.PrimaryScreen.Bounds.Width;
        private int SH = Screen.PrimaryScreen.Bounds.Height;
        private DataSet dsResult = new DataSet();
        private readonly int pic_width = 190;
        private readonly int pic_height = 190;
        private int count = 0;

        // 一行5个按钮
        int butCount = 5;

        public MainControl()
        {
            InitializeComponent();
            ConfigHelper.Init();

            //if (SW > 1400)
            //{
            //    this.SW -= 270;
            //    this.pic_width = 210;
            //    this.pic_height = 210;
            //}
            //this.SH -= 200;

            //this.ClientSize = new Size(SW, SH);

            this.dsResult.ReadXml(Application.StartupPath + @"\DataUploadManger.xml");

            DataTable dt = this.dsResult.Tables[0];
            DataView dv = dt.DefaultView;
            dv.RowFilter = "IsDisplay='true'";
            dv.Sort = "Order";

            dt = dv.ToTable();

            // 计算可显示行数否则按一行6个按钮显示
            count = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(dt.Rows.Count) / butCount)); // 计算可显示行数

            // 超过三行计算按钮高度
            if (count == 3) pic_height = 190;

            int row = 0;    // 当前是第几行

            // 循环生成按钮
            for (int i = 0; i < dt.Rows.Count; i += butCount)
            {
                int num = 0;    // 当前是第几个按钮

                while (num < butCount)
                {
                    if (i + num < dt.Rows.Count)
                    {
                        PictureBox btn = CreatePicbox(dt.Rows[i + num]["ItemPic"].ToString(), dt.Rows[i + num]["FileName"].ToString(), num, row);
                        btn.Click += new EventHandler(MenuClicked);

                        this.Controls.Add(btn);
                    }

                    num++;
                }

                row++;
            }
        }

        /// <summary>
        /// 生成按钮属性
        /// </summary>
        /// <param name="imgName"></param>
        /// <param name="fileName"></param>
        /// <param name="num">当前是第几个按钮</param>
        /// <param name="row">当前是第几行</param>
        /// <returns></returns>
        private PictureBox CreatePicbox(string imgName, string fileName, int num, int row)
        {
            PictureBox button = null;

            Bitmap bitmap = new Bitmap("Imgs\\" + imgName + ".png");

            button = new PictureBox
            {
                BackColor = Color.Transparent,
                BackgroundImage = bitmap,
                BackgroundImageLayout = ImageLayout.Stretch,
                Text = imgName,
                Tag = fileName,
                Margin = new Padding(0, 0, 0, 0),
                Location = this.GetPicPosition(num, row),
                Size = new Size(this.pic_width, pic_height),
                TabStop = false
            };

            return button;
        }

        /// <summary>
        /// 计算按钮位置
        /// </summary>
        /// <param name="num">当前是第几个按钮</param>
        /// <param name="row">当前是第几行</param>
        /// <returns></returns>
        private Point GetPicPosition(int num, int row)
        {
            int firstTop = 60, firstLeft = 10;  // 首行首列的顶部及左侧距离
            int top = 60, left = 10; // 距顶部距离及距左侧距离

            // 按钮总行数大于2行时，距顶部距离及距左侧距离稍小些
            if (count == 2)
            {
                firstTop = 60; firstLeft = 10;
            }
            else if (count == 3)
            {
                firstTop = 60; firstLeft = 10;
            }

            // 一行6个按钮时
            if (butCount == 6) firstLeft = 10;

            switch (row)
            {
                // 当为第一行
                case 0:
                    top = firstTop;

                    // 第一行第一个按钮时
                    if (num == 0) left = firstLeft;
                    else left = num * pic_width + firstLeft + 10 * num;

                    break;

                default:
                    if (count == 3) top = row * pic_height + firstTop + 20 * row;
                    else top = row * pic_height + firstTop + 30 * row;

                    // 其他第一个按钮时，距离左侧空白可大一些
                    if (num == 0) left = firstLeft;
                    else left = num * pic_width + firstLeft + 10 * num;

                    break;
            }

            return new Point(left, top);
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuClicked(object sender, EventArgs e)
        {
            string version = ConfigHelper.GetSetNode("versionNo");
            PictureBox btn = (PictureBox)sender;
            string assemblyName = "", typeName = "";

            if (btn.Tag.ToString().Equals("frmHealthRefresh"))//|| btn.Tag.ToString().Equals("frmFollowDataUpdate")
            {
                assemblyName = "RecordManagement";
                typeName = "RecordManagement.";
            }

            if (assemblyName == "RecordManagement")
            {
                try
                {
                    Assembly sampleAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\" + "RecordManagement.exe");

                    if (sampleAssembly != null)
                    {
                        Form loadForm = (Form)sampleAssembly.CreateInstance("RecordManagement."+btn.Tag.ToString());

                        loadForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    DataUploadUI form = new DataUploadUI();
                    form.WindowTitle = btn.Text;
                    form.DataType = btn.Tag.ToString();

                    if (form.ShowDialog() == DialogResult.Cancel)
                    {
                        form.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
