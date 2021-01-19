using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;
using KangShuoTech.Utilities.CommonControl;
using KangShuoTech.Utilities.CommonUI;

namespace ArchiveInfo
{
    using CommonControl;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.IO;
    using AxHWPenSignLib;
    using System.Configuration;

    public partial class SignMaint : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private string SignS = ""; //症状
        private string SignS1 = ""; //一般状况
        private string SignS3 = ""; //生活方式
        private string SignS4 = ""; //脏器功能
        private string SignS5 = ""; //查体
        private string SignS6 = ""; //辅助检查
        private string SignS7 = ""; //现存主要健康问题
        private string SignS8 = ""; //住院治疗情况
        private string SignS9 = ""; //主要用药情况
        private string SignS10 = ""; //健康评价
        private string SignS11 = ""; //健康指导
        private string SignS13 = ""; //反馈人签字
        private string SignS16 = ""; //心电图
        private string SignS17 = ""; //B超
        private string SignS18 = ""; //中医体质
        private string SignS19 = ""; //B超其他
        private string SignS20 = ""; //心电医生签字
        private string SignS21 = ""; //血型，肝肾功能医生签字
        private string SignS22 = ""; //检查医生
        private string SignS23 = ""; //心电图检查医生
        private string SignS24 = "";//中医体质辨识
        private string area = ConfigHelper.GetSetNode("area");
        string community = ConfigHelper.GetSetNode("community");
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Year/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Year//"; //签名保存路径
        private string SignPath2 = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/" : ConfigurationManager.AppSettings["SignPath"].ToString(); // 体检签名保存路径

        public SignMaint()
        {
            InitializeComponent();
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            return ChildFormStatus.NoErrorInput;
        }

        private void SignMaint_Load(object sender, EventArgs e)
        {
            if (area.Equals("菏泽"))
            {
                this.dtPersonalFb.Visible = true;
                this.panel23.Visible = true;
                this.panel25.Visible = true;
            }

            if (community.Equals("顾官屯卫生院"))
            {
                this.panel35.Visible = true;
                this.panel37.Visible = true;
            }

            label24.Visible = true;
            dtpCheckDate.Visible = true;
            dtpCheckDate.Value = DateTime.Now.Date;

            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void InitEveryThing()
        {
            this.SignModel = new RecordsSignatureBLL().GetModelByOutKey(0, "签字维护");

            if (this.SignModel == null) this.SignModel = new RecordsSignatureModel();
            this.SignModel.IDCardNo = "签字维护";
            this.SignModel.ID = 0;

            this.txtSymptom.DataBindings.Add("Text", this.SignModel, "SymptomSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtGeneral.DataBindings.Add("Text", this.SignModel, "GeneralConditionSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtLife.DataBindings.Add("Text", this.SignModel, "LifeStyleSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtOrgans.DataBindings.Add("Text", this.SignModel, "OrgansFunctionSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtPEyebse.DataBindings.Add("Text", this.SignModel, "PEyebseSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtSkin.DataBindings.Add("Text", this.SignModel, "PSkinSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtPhysical.DataBindings.Add("Text", this.SignModel, "PhysicalQtSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtAMAU.DataBindings.Add("Text", this.SignModel, "AMAUSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtAECG.DataBindings.Add("Text", this.SignModel, "AECGSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtABtypeUltrasonic.DataBindings.Add("Text", this.SignModel, "ABtypeUltrasonicSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtABtypeQt.DataBindings.Add("Text", this.SignModel, "ABtypeQtSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtASmear.DataBindings.Add("Text", this.SignModel, "ASmearSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtAssistQt.DataBindings.Add("Text", this.SignModel, "AssistQtSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtInpatientCare.DataBindings.Add("Text", this.SignModel, "InpatientCareSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtHealthAssessment.DataBindings.Add("Text", this.SignModel, "HealthAssessmentSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtHealthGuidance.DataBindings.Add("Text", this.SignModel, "HealthGuidanceSn", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtPersonalFb.DataBindings.Add("Text", this.SignModel, "PersonalFb", false, DataSourceUpdateMode.OnPropertyChanged); this.txtExamineDoctor.DataBindings.Add("Text", this.SignModel, "ExamineDoctor", false, DataSourceUpdateMode.OnPropertyChanged); this.txtECGExamineDoctor.DataBindings.Add("Text", this.SignModel, "ECGExamineDoctor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtPhysiqueSn.DataBindings.Add("Text", this.SignModel, "PhysiqueSn", false, DataSourceUpdateMode.OnPropertyChanged);

            if (!Directory.Exists(SignPath))
            {
                Directory.CreateDirectory(SignPath);
            }

            this.SignS = string.Format("{0}_Doctor.png", this.SignPath);
            this.SignS1 = string.Format("{0}_Doctor1.png", this.SignPath);
            this.SignS3 = string.Format("{0}_Doctor3.png", this.SignPath);
            this.SignS4 = string.Format("{0}_Doctor4.png", this.SignPath);
            this.SignS5 = string.Format("{0}_Doctor5.png", this.SignPath);
            this.SignS6 = string.Format("{0}_Doctor6.png", this.SignPath);
            this.SignS7 = string.Format("{0}_Doctor7.png", this.SignPath);
            this.SignS8 = string.Format("{0}_Doctor8.png", this.SignPath);
            this.SignS9 = string.Format("{0}_Doctor9.png", this.SignPath);
            this.SignS10 = string.Format("{0}_Doctor10.png", this.SignPath);
            this.SignS11 = string.Format("{0}_Doctor11.png", this.SignPath);
            this.SignS13 = string.Format("{0}_Doctor13.png", this.SignPath);
            this.SignS16 = string.Format("{0}_Doctor16.png", this.SignPath);
            this.SignS17 = string.Format("{0}_Doctor17.png", this.SignPath);
            this.SignS18 = string.Format("{0}_Doctor18.png", this.SignPath);
            this.SignS19 = string.Format("{0}_Doctor19.png", this.SignPath);
            this.SignS20 = string.Format("{0}_Doctor20.png", this.SignPath);
            this.SignS21 = string.Format("{0}_Doctor21.png", this.SignPath);
            this.SignS22 = string.Format("{0}_Doctor22.png", this.SignPath);
            this.SignS23 = string.Format("{0}_Doctor23.png", this.SignPath);
            this.SignS24 = string.Format("{0}_Doctor24.png", this.SignPath);

            //症状
            if (File.Exists(this.SignS))
            {
                Image imgeb = Image.FromFile(this.SignS);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                pictureBox.Image = bmp;
                pictureBox.Show();
                imgeb.Dispose();
                this.linkLabel.Enabled = true;
                pictureBox.BackColor = Color.White;
            }
            //一般状况
            if (File.Exists(this.SignS1))
            {
                Image imgeb1 = Image.FromFile(this.SignS1);
                Image bmp1 = new System.Drawing.Bitmap(imgeb1);
                pictureBox1.Image = bmp1;
                pictureBox1.Show();
                imgeb1.Dispose();
                this.linkLabel1.Enabled = true;
                pictureBox1.BackColor = Color.White;
            }
            //生活方式
            if (File.Exists(this.SignS3))
            {
                Image imgeb3 = Image.FromFile(this.SignS3);
                Image bmp3 = new System.Drawing.Bitmap(imgeb3);
                pictureBox3.Image = bmp3;
                pictureBox3.Show();
                imgeb3.Dispose();
                this.linkLabel3.Enabled = true;
                pictureBox3.BackColor = Color.White;
            }
            //脏器功能
            if (File.Exists(this.SignS4))
            {
                Image imgeb4 = Image.FromFile(this.SignS4);
                Image bmp4 = new System.Drawing.Bitmap(imgeb4);
                pictureBox4.Image = bmp4;
                pictureBox4.Show();
                imgeb4.Dispose();
                this.linkLabel4.Enabled = true;
                pictureBox4.BackColor = Color.White;
            }
            //查体
            if (File.Exists(this.SignS5))
            {
                Image imgeb5 = Image.FromFile(this.SignS5);
                Image bmp5 = new System.Drawing.Bitmap(imgeb5);
                pictureBox5.Image = bmp5;
                pictureBox5.Show();
                imgeb5.Dispose();
                this.linkLabel5.Enabled = true;
                pictureBox5.BackColor = Color.White;
            }
            //辅助检查
            if (File.Exists(this.SignS6))
            {
                Image imgeb6 = Image.FromFile(this.SignS6);
                Image bmp6 = new System.Drawing.Bitmap(imgeb6);
                pictureBox6.Image = bmp6;
                pictureBox6.Show();
                imgeb6.Dispose();
                this.linkLabel6.Enabled = true;
                pictureBox6.BackColor = Color.White;
            }
            //现存主要健康问题
            if (File.Exists(this.SignS7))
            {
                Image imgeb7 = Image.FromFile(this.SignS7);
                Image bmp7 = new System.Drawing.Bitmap(imgeb7);
                pictureBox7.Image = bmp7;
                pictureBox7.Show();
                imgeb7.Dispose();
                this.linkLabel7.Enabled = true;
                pictureBox7.BackColor = Color.White;
            }
            //住院治疗情况
            if (File.Exists(this.SignS8))
            {
                Image imgeb8 = Image.FromFile(this.SignS8);
                Image bmp8 = new System.Drawing.Bitmap(imgeb8);
                pictureBox8.Image = bmp8;
                pictureBox8.Show();
                imgeb8.Dispose();
                this.linkLabel8.Enabled = true;
                pictureBox8.BackColor = Color.White;
            }
            //主要用药情况
            if (File.Exists(this.SignS9))
            {
                Image imgeb9 = Image.FromFile(this.SignS9);
                Image bmp9 = new System.Drawing.Bitmap(imgeb9);
                pictureBox9.Image = bmp9;
                pictureBox9.Show();
                imgeb9.Dispose();
                this.linkLabel9.Enabled = true;
                pictureBox9.BackColor = Color.White;
            }
            //健康评价
            if (File.Exists(this.SignS10))
            {
                Image imgeb10 = Image.FromFile(this.SignS10);
                Image bmp10 = new System.Drawing.Bitmap(imgeb10);
                pictureBox10.Image = bmp10;
                pictureBox10.Show();
                imgeb10.Dispose();
                this.linkLabel10.Enabled = true;
                pictureBox10.BackColor = Color.White;
            }
            //健康指导
            if (File.Exists(this.SignS11))
            {
                Image imgeb11 = Image.FromFile(this.SignS11);
                Image bmp11 = new System.Drawing.Bitmap(imgeb11);
                pictureBox11.Image = bmp11;
                pictureBox11.Show();
                imgeb11.Dispose();
                this.linkLabel11.Enabled = true;
                pictureBox11.BackColor = Color.White;
            }
            //反馈人签字
            if (File.Exists(this.SignS13))
            {
                Image imgeb13 = Image.FromFile(this.SignS13);
                Image bmp13 = new System.Drawing.Bitmap(imgeb13);
                pictureBox13.Image = bmp13;
                pictureBox13.Show();
                imgeb13.Dispose();
                this.linkLabel13.Enabled = true;
                pictureBox13.BackColor = Color.White;
            }
            //心电图
            if (File.Exists(this.SignS16))
            {
                Image imgeb16 = Image.FromFile(this.SignS16);
                Image bmp16 = new System.Drawing.Bitmap(imgeb16);
                pictureBox16.Image = bmp16;
                pictureBox16.Show();
                imgeb16.Dispose();
                this.linkLabel16.Enabled = true;
                pictureBox16.BackColor = Color.White;
            }
            //B超
            if (File.Exists(this.SignS17))
            {
                Image imgeb17 = Image.FromFile(this.SignS17);
                Image bmp17 = new System.Drawing.Bitmap(imgeb17);
                pictureBox17.Image = bmp17;
                pictureBox17.Show();
                imgeb17.Dispose();
                this.linkLabel17.Enabled = true;
                pictureBox17.BackColor = Color.White;
            }
            //中医体质
            if (File.Exists(this.SignS18))
            {
                Image imgeb18 = Image.FromFile(this.SignS18);
                Image bmp18 = new System.Drawing.Bitmap(imgeb18);
                pictureBox18.Image = bmp18;
                pictureBox18.Show();
                imgeb18.Dispose();
                this.linkLabel18.Enabled = true;
                pictureBox18.BackColor = Color.White;
            }
            //B超其他
            if (File.Exists(this.SignS19))
            {
                Image imgeb19 = Image.FromFile(this.SignS19);
                Image bmp19 = new System.Drawing.Bitmap(imgeb19);
                pictureBox19.Image = bmp19;
                pictureBox19.Show();
                imgeb19.Dispose();
                this.linkLabel19.Enabled = true;
                pictureBox19.BackColor = Color.White;
            }
            //心电医生签字
            if (File.Exists(this.SignS20))
            {
                Image imgeb20 = Image.FromFile(this.SignS20);
                Image bmp20 = new System.Drawing.Bitmap(imgeb20);
                pictureBox20.Image = bmp20;
                pictureBox20.Show();
                imgeb20.Dispose();
                this.linkLabel20.Enabled = true;
                pictureBox20.BackColor = Color.White;
            }
            //检查医生
            if (File.Exists(this.SignS22))
            {
                Image imgeb22 = Image.FromFile(this.SignS22);
                Image bmp22 = new System.Drawing.Bitmap(SignS22);
                pictureBox22.Image = bmp22;
                pictureBox22.Show();
                imgeb22.Dispose();
                this.linkLabel22.Enabled = true;
                pictureBox22.BackColor = Color.White;
            }
            //检查医生
            if (File.Exists(this.SignS23))
            {
                Image imgeb23 = Image.FromFile(this.SignS23);
                Image bmp23 = new System.Drawing.Bitmap(SignS23);
                pictureBox23.Image = bmp23;
                pictureBox23.Show();
                imgeb23.Dispose();
                this.linkLabel23.Enabled = true;
                pictureBox23.BackColor = Color.White;
            }
            if (area.Equals("菏泽"))
            {
                this.txbXGS.DataBindings.Add("Text", this.SignModel, "BloodLiverKidneySn", false, DataSourceUpdateMode.OnPropertyChanged);
                //血型，肝肾功能医生签字
                if (File.Exists(this.SignS21))
                {
                    Image imgeb21 = Image.FromFile(this.SignS21);
                    Image bmp21 = new System.Drawing.Bitmap(imgeb21);
                    pictureBox21.Image = bmp21;
                    pictureBox21.Show();
                    imgeb21.Dispose();
                    this.linkLabel21.Enabled = true;
                    pictureBox21.BackColor = Color.White;
                }
            }
            //中医体质辨识
            if (File.Exists(this.SignS24))
            {
                Image imgeb24 = Image.FromFile(this.SignS24);
                Image bmp24 = new System.Drawing.Bitmap(SignS24);
                pictureBox24.Image = bmp24;
                pictureBox24.Show();
                imgeb24.Dispose();
                this.linkLabel24.Enabled = true;
                pictureBox24.BackColor = Color.White;
            }
            this.EveryThingIsOk = true;
        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            string date = "";

            RecordsSignatureBLL SignatureBLL = new RecordsSignatureBLL();

            if (!SignatureBLL.Update(this.SignModel)) SignatureBLL.Add(this.SignModel);

            if (this.dtPersonalFb.Visible)
            {
                date = dtPersonalFb.Value.ToString("yyyy-MM-dd");

                if (!Directory.Exists(SignPath + date))
                {
                    Directory.CreateDirectory(SignPath + date);
                }
            }

            if (dtpCheckDate.Visible)
            {
                date = dtpCheckDate.Value.ToString("yyyy-MM-dd");

                if (!Directory.Exists(SignPath + date))
                {
                    Directory.CreateDirectory(SignPath + date);
                }

                SavePicture(pictureBox, "_Doctor");
                SavePicture(pictureBox1, "_Doctor1");
                SavePicture(pictureBox3, "_Doctor3");
                SavePicture(pictureBox4, "_Doctor4");
                SavePicture(pictureBox5, "_Doctor5");
                SavePicture(pictureBox6, "_Doctor6");
                SavePicture(pictureBox7, "_Doctor7");
                SavePicture(pictureBox8, "_Doctor8");
                SavePicture(pictureBox9, "_Doctor9");
                SavePicture(pictureBox10, "_Doctor10");
                SavePicture(pictureBox11, "_Doctor11");
                SavePicture(pictureBox13, "_Doctor13");
                SavePicture(pictureBox16, "_Doctor16");
                SavePicture(pictureBox17, "_Doctor17");
                SavePicture(pictureBox18, "_Doctor18");
                SavePicture(pictureBox19, "_Doctor19");
                SavePicture(pictureBox20, "_Doctor20");
                SavePicture(pictureBox22, "_Doctor22");
                SavePicture(pictureBox23, "_Doctor23");
                SavePicture(pictureBox24, "_Doctor24");

                if (area.Equals("菏泽")) SavePicture(pictureBox21, "_Doctor21");
                else if (area.Equals("禹城"))
                {
                    string[] files = Directory.GetFiles(SignPath2, "*_" + date.Replace("-", "") + "_F.png", SearchOption.AllDirectories);

                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileName = files[i];

                        pictureBox13.Image.Save(fileName);                        
                    }
                }
            }

            return true;
        }

        private void SavePicture(PictureBox p, string doctor)
        {
            doctor = doctor + ".png";

            if (p.Image == null) return;

            string path = SignPath + doctor;
            string date = dtpCheckDate.Value.ToString("yyyy-MM-dd");

            if (this.dtPersonalFb.Visible) date = dtPersonalFb.Value.ToString("yyyy-MM-dd");

            string dataPath = SignPath + date + "//" + doctor;

            if (File.Exists(path))
            {
                if (File.Exists(dataPath)) File.Delete(dataPath);

                File.Copy(path, dataPath);
            }
        }

        public void UpdataToModel()
        {
        }

        public bool HaveToSave { get; set; }

        public bool EveryThingIsOk { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsSignatureModel SignModel { get; set; }

        public string SaveDataInfo { get; set; }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor", pictureBox);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor1", pictureBox1);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor3", pictureBox3);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor4", pictureBox4);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor5", pictureBox5);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor6", pictureBox6);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor7", pictureBox7);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor8", pictureBox8);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor9", pictureBox9);
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor10", pictureBox10);
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor11", pictureBox11);
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor13", pictureBox13);
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor16", pictureBox16);
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor17", pictureBox17);
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor18", pictureBox18);
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor19", pictureBox19);
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor20", pictureBox20);
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor21", pictureBox21);
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor22", pictureBox22);
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor23", pictureBox23);
        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("//_Doctor24", pictureBox24);
        }

        private void Sign(string DaySign, PictureBox picture)
        {
            FingerPrint.SignForm loadForm = new FingerPrint.SignForm();
            string date = dtpCheckDate.Value.ToString("yyyy-MM-dd");
            if (!Directory.Exists(SignPath + date))
            {
                Directory.CreateDirectory(SignPath + date);
            }
            loadForm.IDCardNo = date;
            loadForm.SignPath = SignPath;
            loadForm.SignName = DaySign;
            if (loadForm.ShowDialog() == DialogResult.OK)
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
                string path = string.Format("{0}{1}{2}.png", SignPath, date, DaySign);
                string newpath = string.Format("{0}{1}.png", SignPath, DaySign);
                Image imgeb = Image.FromFile(path);
                Image bmp = new System.Drawing.Bitmap(imgeb);
                picture.Image = bmp;
                imgeb.Dispose();
                picture.BackColor = Color.White;
                if (File.Exists(path))
                {
                    File.Copy(path, newpath, true);
                }
            }
        }

        private void Clear(string DaySign, PictureBox picture)
        {
            try
            {
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                    string date = dtpCheckDate.Value.ToString("yyyy-MM-dd");
                    string path = SignPath + date + DaySign + ".png";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    string pPath = SignPath + DaySign + ".png";
                    if (File.Exists(pPath))
                    {
                        File.Delete(pPath);
                    }
                    picture.BackColor = Color.FromArgb(222, 248, 200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor", pictureBox);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor1", pictureBox1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor3", pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor4", pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor5", pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor6", pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor7", pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor8", pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor9", pictureBox9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor10", pictureBox10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor11", pictureBox11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor13", pictureBox13);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor16", pictureBox16);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor17", pictureBox17);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor18", pictureBox18);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor19", pictureBox19);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor20", pictureBox20);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor22", pictureBox22);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor23", pictureBox23);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor24", pictureBox24);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Sign("//_Doctor21", pictureBox21);
        }
    }
}