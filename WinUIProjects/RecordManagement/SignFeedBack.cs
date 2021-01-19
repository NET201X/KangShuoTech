using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;
using System.IO;
using AxHWPenSignLib;
using System.Threading;
using System.Configuration;

namespace ArchiveInfo
{
    public partial class SignFeedBack : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private string YSignSelfPath = "";
        private string YSignJsPath = "";
        private string YSignFkrPath = "";
        private string YSignYsPath = "";//医生签名
        private string BaseSelPath = "";//基本信息中本人签字
        private string PersonalPath = "";//反馈人签字
        private string DependentPath = "";//基本信息中家属签字
        Thread m_WorkerThread = null;
        bool m_bStop = false;
        FTRSCAN_IMAGE_SIZE m_ImageSize;
        byte[] m_pImage = null;
        private string FingerInfo = "";// 指纹信息
        byte[] m_pTemplate = null;
        byte m_byFingerPosition = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); //签名保存路径
        private string FingerPath = ConfigurationManager.AppSettings["FingerPath"] == null ? @"Finger/" : ConfigurationManager.AppSettings["FingerPath"].ToString(); //指纹采集路径
        private string area = ConfigHelper.GetSetNode("area");
        BioneFPAPILib.FPAPICtrlClass fp;
        string sb1, sb2;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (m_WorkerThread != null) //关闭指纹设备
            {
                try
                {
                    m_WorkerThread.Abort();
                    m_WorkerThread.Join();
                }
                catch (Exception ex)
                {
                    Thread.ResetAbort();
                }
            }

            if (fp != null)//关闭指纹设备
            {
                fp.StopGetTemplate();
                fp.CloseDevice();
                fp.UnInitDevice();
            }
            base.Dispose(disposing);
        }

        public SignFeedBack()
        {
            InitializeComponent();
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        private void SignFeedBack_Load(object sender, EventArgs e)
        {
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void InitEveryThing()
        {
            if (!Directory.Exists(FingerPath))
            {
                Directory.CreateDirectory(FingerPath);
            }

            this.SignModel = new RecordsSignatureBLL().GetModelByOutKey(PhysicalInfoFactory.ID, this.Model.IDCardNo);

            if (this.SignModel == null) this.SignModel = new RecordsSignatureModel();

            if (this.SignModel.FeedbackDate.HasValue && PhysicalInfoFactory.falgID != 0)
            {
                this.dtFeedbackDate.Value = this.SignModel.FeedbackDate.Value;
            }
            else
            {
                // 菏泽，济宁，聊城，泰安 反馈时间取医生签名中的反馈时间
                if (area.Equals("菏泽") || area.Equals("济宁") || area.Equals("聊城") || area.Equals("泰安"))
                {
                    this.dtFeedbackDate.Value = DateTime.Now.AddDays(3);
                    this.SignModel.FeedbackDate = DateTime.Now.AddDays(3);
                }
                else
                {
                    this.dtFeedbackDate.Value = DateTime.Now;
                    this.SignModel.FeedbackDate = DateTime.Now;
                }

                this.txtDoctor.Text = Model.Doctor;
            }

            // 取得签字维护中的反馈人签字
            this.SignModel2 = new RecordsSignatureBLL().GetModelByOutKey(0, "签字维护");

            if (this.SignModel2 != null && string.IsNullOrEmpty(this.SignModel.PersonalFb))
            {
                this.SignModel.PersonalFb = this.SignModel2.PersonalFb;
                this.SignModel.DependentSn = this.SignModel2.DependentSn;
            }

            this.txtDoctor.DataBindings.Add("Text", this.SignModel, "DoctorSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtPersonalFb.DataBindings.Add("Text", this.SignModel, "PersonalFb", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtDependent.DataBindings.Add("Text", this.SignModel, "DependentSn", false, DataSourceUpdateMode.OnPropertyChanged);

            string strFeedBackDate = RecordsManageMentModel.CheckDate.ToString("yyyyMMdd");

            string strSign1_Self = string.Format("{0}{1}_{2}_B.png", SignPath, this.Model.IDCardNo, strFeedBackDate);
            this.YSignSelfPath = strSign1_Self;
            string strSign1_Js = string.Format("{0}{1}_{2}_J.png", SignPath, this.Model.IDCardNo, strFeedBackDate);
            this.YSignJsPath = strSign1_Js;
            string strSign1_Fkr = string.Format("{0}{1}_{2}_F.png", SignPath, this.Model.IDCardNo, strFeedBackDate);
            this.YSignFkrPath = strSign1_Fkr;
            string strSign1_Ys = string.Format("{0}{1}_{2}_Doc.png", SignPath, this.Model.IDCardNo, strFeedBackDate);
            this.YSignYsPath = strSign1_Ys;
            string strSign1_B = string.Format("{0}{1}_B.png", SignPath, this.Model.IDCardNo);//基本信息中的本人签字
            string strPersonal = SignPath + "Year//_Doctor13.png";// 签字维护中的反馈人签字

            if (area.Equals("菏泽"))
            {
                string date = SignModel.FeedbackDate.Value.ToString("yyyy-MM-dd");
                strPersonal = string.Format("{0}{1}//_Doctor13.png", SignPath + "Year//", date);
            }

            string strDependent = string.Format("{0}{1}_J.png", SignPath, this.Model.IDCardNo);//基本信息中的家属签字

            if (File.Exists(strSign1_Self) && PhysicalInfoFactory.falgID != 0) //新增的时并且当天没体检过的人群不显示不出来签名
            {
                Image imgej = Image.FromFile(strSign1_Self);
                Image bmp = new System.Drawing.Bitmap(imgej);
                PBoxSel_B.Image = bmp;
                PBoxSel_B.Show();
                imgej.Dispose();
                PBoxSel_B.BackColor = Color.White;
            }
            else if (File.Exists(strSign1_B))
            {
                this.BaseSelPath = strSign1_B;
                Image imgej = Image.FromFile(strSign1_B);
                Image bmp = new System.Drawing.Bitmap(imgej);
                PBoxSel_B.Image = bmp;
                PBoxSel_B.Show();
                imgej.Dispose();
                PBoxSel_B.BackColor = Color.White;
            }

            if (File.Exists(strSign1_Js) && PhysicalInfoFactory.falgID != 0)
            {
                Image imgej = Image.FromFile(strSign1_Js);
                Image bmp = new System.Drawing.Bitmap(imgej);
                PBoxJs_J.Image = bmp;
                PBoxJs_J.Show();
                imgej.Dispose();
                PBoxJs_J.BackColor = Color.White;
            }
            else if (File.Exists(strDependent))
            {
                this.DependentPath = strDependent;
                Image imgej = Image.FromFile(strDependent);
                Image bmp = new System.Drawing.Bitmap(imgej);
                PBoxJs_J.Image = bmp;
                PBoxJs_J.Show();
                imgej.Dispose();
                PBoxJs_J.BackColor = Color.White;
            }

            if (File.Exists(YSignFkrPath) )
            {
                Image imgej = Image.FromFile(YSignFkrPath);
                Image bmp = new System.Drawing.Bitmap(imgej);
                PBoxFkr.Image = bmp;
                PBoxFkr.Show();
                imgej.Dispose();
                PBoxFkr.BackColor = Color.White;
            }
            else if (area.Equals("菏泽") && File.Exists(strPersonal))
            {
                this.PersonalPath = strPersonal;
                Image imgej = Image.FromFile(strPersonal);
                Image bmp = new System.Drawing.Bitmap(imgej);
                PBoxFkr.Image = bmp;
                PBoxFkr.Show();
                imgej.Dispose();
                PBoxFkr.BackColor = Color.White;
            }
            else
            {
                if (area.Equals("禹城"))
                {
                    //取签字维护下指定体检日期的反馈人图片
                    string SignMaintPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//";
                    strSign1_Fkr = String.Format("{0}{1}/_Doctor13.png", SignMaintPath, RecordsManageMentModel.CheckDate.ToShortDateString());
                    this.YSignFkrPath = strSign1_Fkr;
                    if (File.Exists(strSign1_Fkr))
                    {
                        Image imgej = Image.FromFile(strSign1_Fkr);
                        Image bmp = new System.Drawing.Bitmap(imgej);
                        PBoxFkr.Image = bmp;
                        PBoxFkr.Show();
                        imgej.Dispose();
                        PBoxFkr.BackColor = Color.White;
                    }
                    else
                    {
                        //取签字维护外围的反馈人图片
                        SignMaintPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//";
                        strSign1_Fkr = String.Format("{0}/_Doctor13.png", SignMaintPath);
                        this.YSignFkrPath = strSign1_Fkr;
                        if (File.Exists(strSign1_Fkr))
                        {
                            Image imgej = Image.FromFile(strSign1_Fkr);
                            Image bmp = new System.Drawing.Bitmap(imgej);
                            PBoxFkr.Image = bmp;
                            PBoxFkr.Show();
                            imgej.Dispose();
                            PBoxFkr.BackColor = Color.White;
                        }
                    }
                }
            }

            if (File.Exists(strSign1_Ys) && PhysicalInfoFactory.falgID != 0)
            {
                Image imgej = Image.FromFile(strSign1_Ys);
                Image bmp = new System.Drawing.Bitmap(imgej);
                PBoxYs.Image = bmp;
                PBoxYs.Show();
                imgej.Dispose();
                PBoxYs.BackColor = Color.White;
            }

            //显示指纹
            string strFingerPath = string.Format("{0}{1}{2}_Finger.png", FingerPath, this.Model.IDCardNo, RecordsManageMentModel.CheckDate.ToString("yyyyMMdd"));
            string strBaseFingerPath = string.Format("{0}{1}_Finger.png", FingerPath, this.Model.IDCardNo);

            if (File.Exists(strFingerPath))
            {
                Image imgFinger = Image.FromFile(strFingerPath);
                Image bmp = new System.Drawing.Bitmap(imgFinger);
                pictureFinger.Image = bmp;
                pictureFinger.Show();
                imgFinger.Dispose();
            }
            else if (File.Exists(strBaseFingerPath))
            {
                Image imgFinger = Image.FromFile(strBaseFingerPath);
                Image bmp = new System.Drawing.Bitmap(imgFinger);
                pictureFinger.Image = bmp;
                pictureFinger.Show();
                imgFinger.Dispose();
            }

            this.EveryThingIsOk = true;
        }
        
        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            this.SignModel.FeedbackDate = new DateTime?(this.dtFeedbackDate.Value.Date);
            this.SignModel.SelfSn = Model.CustomerName;

            if (PhysicalInfoFactory.ID == -1) return true;

            string strFeedBackDate = Convert.ToDateTime(this.SignModel.FeedbackDate).ToString("yyyyMMdd");

            string strSelfPath = String.Format("{0}{1}_{2}_B.png", SignPath, this.Model.IDCardNo, strFeedBackDate);
            string strJsPath = String.Format("{0}{1}_{2}_J.png", SignPath, this.Model.IDCardNo, strFeedBackDate);
            string strFkrPath = String.Format("{0}{1}_{2}_F.png", SignPath, this.Model.IDCardNo, strFeedBackDate);
            string strYsPath = String.Format("{0}{1}_{2}_Doc.png", SignPath, this.Model.IDCardNo, strFeedBackDate);

            RecordsSignatureBLL SignatureBLL = new RecordsSignatureBLL();
            this.SignModel.OutKey = PhysicalInfoFactory.ID;

            if (!SignatureBLL.Update(this.SignModel))
            {
                SignatureBLL.Add(this.SignModel);
            }

            if (!File.Exists(strSelfPath) && File.Exists(this.BaseSelPath))
            {
                File.Copy(this.BaseSelPath, strSelfPath, true);
            }
          
            if (!File.Exists(strFkrPath) && File.Exists(this.PersonalPath))
            {
                File.Copy(this.PersonalPath, strFkrPath, true);
            }

            if (!File.Exists(strJsPath) && File.Exists(this.DependentPath))
            {
                File.Copy(this.DependentPath, strJsPath, true);
            }

            //保存指纹
            if (pictureFinger.Image != null)
            {
                Image img = pictureFinger.Image;
                img.Save(String.Format("{0}{1}{2}_Finger.png", FingerPath, this.Model.IDCardNo, RecordsManageMentModel.CheckDate.ToString("yyyyMMdd")));
            }

            return true;
        }        

        public void UpdataToModel()
        {
            this.SignModel.IDCardNo = this.Model.IDCardNo;
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsSignatureModel SignModel { get; set; }

        public RecordsSignatureModel SignModel2 { get; set; }

        public string SaveDataInfo { get; set; }

        private void btnSelfResetSign_Click(object sender, EventArgs e) //本人重新签字
        {
            Clear("_B", PBoxSel_B);
        }

        private void BtnFkrReseetSign_Click(object sender, EventArgs e) //反馈人重新签字
        {
            Clear("_F", PBoxFkr);
        }

        private void btnjsResetSign_Click(object sender, EventArgs e) //家属重新签字
        {
            Clear("_J", PBoxJs_J);
        }

        private void btnYsResetSign_Click(object sender, EventArgs e)//医生重新签名
        {
            Clear("_Doc", PBoxYs);
        } 

        /// <summary>
        /// 指纹采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            string FingerType = ConfigHelper.GetSetNode("IsNewFinger");
            if (FingerType.Equals("N"))
            {
                OldFinger();
            }
            else
            {
                NewFinger();
            }

        }

        /// <summary>
        /// 旧指纹机
        /// </summary>
        private void OldFinger()
        {
            if (fp != null)//关闭指纹设备
            {
                fp.StopGetTemplate();
                fp.CloseDevice();
                fp.UnInitDevice();
            }

            IniFingerPrint();

            lblResult.Text = "请刷取指纹";
            lblResult.Left = 16;

            int r = fp.StartGetTemplate();

            btnFingerPrint.Enabled = false;
        }

        /// <summary>
        /// 新指纹机
        /// </summary>
        private void NewFinger()
        {
            if (m_WorkerThread != null) //关闭设备
            {
                try
                {
                    m_WorkerThread.Abort();
                    m_WorkerThread.Join();
                }
                catch (Exception ex)
                {
                    Thread.ResetAbort();
                }
            }
            StartThread(true);
            lblResult.Left = 16;
            btnFingerPrint.Enabled = false;
        }

        private void StartThread(bool isLogin)
        {
            m_WorkerThread = new Thread(new ThreadStart(delegate
            {
                ReadThreadProc(isLogin);
            }));
            m_WorkerThread.SetApartmentState(ApartmentState.STA);
            m_WorkerThread.Start();
        }

        private void ReadThreadProc(bool isLogin)
        {
            m_bStop = false;

            while (!m_bStop)
            {
                IntPtr hDevice = OpenDevice();

                if (hDevice != IntPtr.Zero)
                {
                    if (DoScan(hDevice))
                    {
                        // 为录入指纹状态时
                        if (!isLogin)
                        {
                            lblResult.Text = "注册成功";
                            FingerInfo = Convert.ToBase64String(m_pTemplate);

                            this.DialogResult = DialogResult.OK;
                        }

                        m_bStop = true;
                    }

                    ftrNativeLib.ftrScanCloseDevice(hDevice);
                    hDevice = IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// 开启设备
        /// </summary>
        /// <returns></returns>
        private IntPtr OpenDevice()
        {
            IntPtr hDevice = IntPtr.Zero;

            // 开启设备
            hDevice = ftrNativeLib.ftrScanOpenDevice();

            if (hDevice == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            m_ImageSize = new FTRSCAN_IMAGE_SIZE();

            if (!ftrNativeLib.ftrScanGetImageSize(hDevice, ref m_ImageSize))
            {
                ftrNativeLib.ftrScanCloseDevice(hDevice);
                return IntPtr.Zero;
            }

            m_pImage = new byte[m_ImageSize.nImageSize];

            for (int i = 0; i < m_pImage.Length; i++)
            {
                m_pImage[i] = (byte)(255 - m_pImage[i]);
            }

            return hDevice;
        }

        private bool DoScan(IntPtr hDevice)
        {
            bool bRC = false;
            int nOutTemplateSize = 0;

            byte[] pbyBaseTemplate = null;

            pbyBaseTemplate = new byte[ftrNativeLib.ftrAnsiSdkGetMaxTemplateSize()];

            // 取得指纹机中按下指纹
            bRC = ftrNativeLib.ftrAnsiSdkCreateTemplate(hDevice, m_byFingerPosition, m_pImage, pbyBaseTemplate, ref nOutTemplateSize);

            if (bRC)
            {
                for (int i = 0; i < m_pImage.Length; i++)
                {
                    m_pImage[i] = (byte)(255 - m_pImage[i]);
                }
            }

            // Update finger image
            if (m_pImage != null)
            {
                MyBitmapFile myFile = new MyBitmapFile(m_ImageSize.nWidth, m_ImageSize.nHeight, m_pImage);
                MemoryStream BmpStream = new MemoryStream(myFile.BitmatFileData);
                Bitmap Bmp = new Bitmap(BmpStream);
                pictureFinger.Image = Bmp;
            }
            else pictureFinger.Image = null;

            return bRC;
        }

        private void IniFingerPrint()
        {
            // 实例化指纹接口
            fp = new BioneFPAPILib.FPAPICtrlClass();
            // 指纹比对取特征的时候，当特征抽取成功后调用次回调
            fp.FeatureCallbackOfBae64 += new BioneFPAPILib._IFPAPICtrlEvents_FeatureCallbackOfBae64EventHandler(aa_FeatureCallbackOfBae64);
            // 刷取每一幅图像过程中，进行指纹特征抽取的回调
            fp.FingerPrintStateOfBae64 += new BioneFPAPILib._IFPAPICtrlEvents_FingerPrintStateOfBae64EventHandler(aa_FingerPrintStateOfBae64);
            // 指纹注册取模板的时候，当模板合成成功后调用此回调
            fp.TemplateCallbackOfBae64 += new BioneFPAPILib._IFPAPICtrlEvents_TemplateCallbackOfBae64EventHandler(aa_TemplateCallbackOfBae64);
            // 自动选取一个设备
            int result = fp.AutoSelectDevice();

            if (result != 0)
            {
                MessageBox.Show("指纹机连接异常！");
                return;
            }

            // 初始化设备
            result = fp.InitDevice();
            if (result != 0)
            {
                MessageBox.Show("指纹机连接异常！");
                return;
            }
            // 打开设备
            result = fp.OpenDevice();
            if (result != 0)
            {
                MessageBox.Show("指纹机连接异常！");
                return;
            }
        }

        /// <summary>
        /// 指纹比对取特征的时候，当特征抽取成功后调用次回调
        /// </summary>
        /// <param name="featureDataBuf"></param>
        /// <param name="featureSize"></param>
        /// <param name="pressTimes"></param>
        /// <param name="featureNum"></param>
        /// <param name="gType"></param>
        void aa_FeatureCallbackOfBae64(string featureDataBuf, short featureSize, short pressTimes, short featureNum, short gType)
        {
            sb2 = featureDataBuf;
            MessageBox.Show(" 获取到了要比对的特征");
        }

        /// <summary>
        /// 刷取每一幅图像过程中，进行指纹特征抽取的回调
        /// </summary>
        /// <param name="imgDataBuf"></param>
        /// <param name="imgDataBufLength"></param>
        /// <param name="imgWidth"></param>
        /// <param name="imgHeight"></param>
        /// <param name="nowStep"></param>
        /// <param name="nowState"></param>
        void aa_FingerPrintStateOfBae64(string imgDataBuf, uint imgDataBufLength, short imgWidth, short imgHeight, short nowStep, short nowState)
        {
            if (nowStep != -1)
            {
                char[] charBuffer = imgDataBuf.ToCharArray();
                byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);

                Bitmap bmp = CreateBitmap(bytes, imgWidth, imgHeight);
                pictureFinger.Image = bmp;

                lblResult.Invoke(new MethodInvoker(delegate
                {
                    lblResult.Text = "请再按一次";
                }));
            }
        }

        /// <summary>
        /// 指纹注册取模板的时候，当模板合成成功后调用此回调
        /// </summary>
        /// <param name="featureDataBuf"></param>
        /// <param name="featureSize"></param>
        /// <param name="pressTimes"></param>
        /// <param name="featureNum"></param>
        /// <param name="gType"></param>
        void aa_TemplateCallbackOfBae64(string featureDataBuf, short featureSize, short pressTimes, short featureNum, short gType)
        {
            sb1 = featureDataBuf;

            lblResult.Invoke(new MethodInvoker(delegate
            {
                lblResult.Text = "注册成功";
            }));
        }

        /// <summary>
        /// 使用byte[]数据，生成256色灰度　BMP 位图
        /// </summary>
        /// <param name="originalImageData"></param>
        /// <param name="originalWidth"></param>
        /// <param name="originalHeight"></param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(byte[] originalImageData, int originalWidth, int originalHeight)
        {
            //指定8位格式，即256色
            Bitmap resultBitmap = new Bitmap(originalWidth, originalHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            //将该位图存入内存中
            MemoryStream curImageStream = new MemoryStream();
            resultBitmap.Save(curImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
            curImageStream.Flush();

            //由于位图数据需要DWORD对齐（4byte倍数），计算需要补位的个数
            int curPadNum = ((originalWidth * 8 + 31) / 32 * 4) - originalWidth;

            //最终生成的位图数据大小
            int bitmapDataSize = ((originalWidth * 8 + 31) / 32 * 4) * originalHeight;

            //数据部分相对文件开始偏移，具体可以参考位图文件格式
            int dataOffset = ReadData(curImageStream, 10, 4);


            //改变调色板，因为默认的调色板是32位彩色的，需要修改为256色的调色板
            int paletteStart = 54;
            int paletteEnd = dataOffset;
            int color = 0;

            for (int i = paletteStart; i < paletteEnd; i += 4)
            {
                byte[] tempColor = new byte[4];
                tempColor[0] = (byte)color;
                tempColor[1] = (byte)color;
                tempColor[2] = (byte)color;
                tempColor[3] = (byte)0;
                color++;

                curImageStream.Position = i;
                curImageStream.Write(tempColor, 0, 4);
            }

            //最终生成的位图数据，以及大小，高度没有变，宽度需要调整
            byte[] destImageData = new byte[bitmapDataSize];
            int destWidth = originalWidth + curPadNum;

            //生成最终的位图数据，注意的是，位图数据 从左到右，从下到上，所以需要颠倒
            for (int originalRowIndex = originalHeight - 1; originalRowIndex >= 0; originalRowIndex--)
            {
                int destRowIndex = originalHeight - originalRowIndex - 1;

                for (int dataIndex = 0; dataIndex < originalWidth; dataIndex++)
                {
                    //同时还要注意，新的位图数据的宽度已经变化destWidth，否则会产生错位
                    destImageData[destRowIndex * destWidth + dataIndex] = originalImageData[originalRowIndex * originalWidth + dataIndex];
                }
            }


            //将流的Position移到数据段   
            curImageStream.Position = dataOffset;

            //将新位图数据写入内存中
            curImageStream.Write(destImageData, 0, bitmapDataSize);

            curImageStream.Flush();

            //将内存中的位图写入Bitmap对象
            try
            {
                resultBitmap = new Bitmap(curImageStream);
                return resultBitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 从内存流中指定位置，读取数据
        /// </summary>
        /// <param name="curStream"></param>
        /// <param name="startPosition"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int ReadData(MemoryStream curStream, int startPosition, int length)
        {
            int result = -1;

            byte[] tempData = new byte[length];
            curStream.Position = startPosition;
            curStream.Read(tempData, 0, length);
            result = BitConverter.ToInt32(tempData, 0);

            return result;
        }

        private void Clear(string DaySign, PictureBox picture)
        {
            try
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                    string date = RecordsManageMentModel.CheckDate.ToString("yyyyMMdd");
                    string path = SignPath + Model.IDCardNo + "_" + date + DaySign + ".png";

                    if (File.Exists(path)) File.Delete(path);

                    picture.BackColor = Color.FromArgb(222, 248, 200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PBoxSelf_Click(object sender, EventArgs e)
        {
            Sign("_B", PBoxSel_B);
        }

        private void PBoxJs_Click(object sender, EventArgs e)
        {
            Sign("_J", PBoxJs_J);
        }

        private void PBoxFkr_Click(object sender, EventArgs e)
        {
            Sign("_F", PBoxFkr);
        }

        private void PBoxYs_Click(object sender, EventArgs e)
        {
            Sign("_Doc", PBoxYs);
        }

        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();

            string date = RecordsManageMentModel.CheckDate.ToString("yyyyMMdd");

            if (!Directory.Exists(SignPath + date))
            {
                Directory.CreateDirectory(SignPath + date);
            }

            loadForm.IDCardNo = Model.IDCardNo + "_" + date;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;

            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }

                string path = string.Format("{0}{1}{2}.png", SignPath, Model.IDCardNo + "_" + date, DaySign);
                Image imgeb = Image.FromFile(path);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picture.Image = bmp;
                imgeb.Dispose();
                picture.BackColor = Color.White;
            }
        }
    }
}
