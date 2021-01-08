

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using KangShuoTech.Utilities.Common;
using System.IO;
using System.Configuration;

namespace FocusGroup.Kids
{
    public class FrmChlTcmhmOne : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ImageList imageList1;
        private List<KidsOneToTwoUserControl> OneToTwo;
        private List<KidsTcmhmOneToThreeModel> OneToTwoModels;
        private TabControl tabCtrOnetoTwo;
        private TabControl TabCWithinOne;
        private TabPage tabPage10;
        private TabPage tabPage4;
        private TabPage tabPage9;
        private TabPage TabPMon6;
        private List<KidsThreeToSixUserControl> ThreeToSix;
        private List<KidsTcmhmThreeToSixModel> ThreeToSixModels;
        private List<KidsTcmhmOneModel> withinOneModels;
        private TabPage TabPMon12;
        private TabPage TabPMon18;
        private List<KidsWithinOneUserControl> withOne;
        private string SignS6 = "";//6月家长签名
        private string SignDoc6 = "";//6月随访医生签名
        private string SignS12 = "";//12月家长签名
        private string SignDoc12 = "";//12月随访医生签名
        private string SignS18 = "";//18月家长签名
        private string SignDoc18 = "";//18月随访医生签名
        private string SignS24 = "";//24月家长签名
        private string SignDoc24 = "";//24月随访医生签名
        private string SignS30 = "";//30月家长签名
        private string SignDoc30 = "";//30月随访医生签名
        private string SignS36 = "";//36月家长签名
        private string SignDoc36 = "";//36月随访医生签名//24-36月随访医生签名
        private int HW_eOk = 0;
        private string SignPath = ConfigurationManager.AppSettings["SignPath"] == null ? @"Sign/Kids/" : ConfigurationManager.AppSettings["SignPath"].ToString() + "Kids//"; //签名保存路径

        public FrmChlTcmhmOne()
        {
            this.InitializeComponent();
            this.InitEveryOne();
            this.EveryThingIsOk = false;
        }

        public ChildFormStatus CheckErrorInput()
        {
            string str;
            bool flag = false;
            foreach (KidsWithinOneUserControl one in this.withOne)
            {
                if (one.CheckErrorInput(out str))
                {
                    flag = true;
                    FrmChlTcmhmOne one2 = this;
                    string str2 = one2.SaveDataInfo + str;
                    one2.SaveDataInfo = str2;
                }
            }
            foreach (KidsOneToTwoUserControl two in this.OneToTwo)
            {
                if (two.CheckErrorInput(out str))
                {
                    flag = true;
                    FrmChlTcmhmOne one3 = this;
                    string str3 = one3.SaveDataInfo + str;
                    one3.SaveDataInfo = str3;
                }
            }
            foreach (KidsThreeToSixUserControl six in this.ThreeToSix)
            {
                if (six.CheckErrorInput(out str))
                {
                    flag = true;
                    FrmChlTcmhmOne one4 = this;
                    string str4 = one4.SaveDataInfo + str;
                    one4.SaveDataInfo = str4;
                }
            }
            if (flag)
            {
                return ChildFormStatus.HasErrorInput;
            }
            return ChildFormStatus.NoErrorInput;
        }

        private void CreateOneToTwo(TabPage tp, int selIndex)
        {
           KidsTcmhmOneToThreeModel item = new KidsTcmhmOneToThreeModel {
                IDCardNo = this.Model.IDCardNo,
               RecordID = this.Model.RecordID,
                ModelState = RecordsStateModel.NoValue,
                CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                CreatedDate = new DateTime?(DateTime.Today),
                FollowupDate = new DateTime?(DateTime.Today),
                FollowupType = Convert.ToString((int) (selIndex + 1))
            };
            this.OneToTwoModels.Add(item);
            KidsOneToTwoUserControl two = new KidsOneToTwoUserControl {
                DataSrc = item,
                SelIndex = selIndex
            };
            two.InitUc();
            this.OneToTwo.Add(two);
            tp.Controls.Add(two);
            tp.ImageIndex = 1;
        }

        private void CreateThreeToSix(TabPage tp, int selIndex)
        {
            KidsTcmhmThreeToSixModel item = new KidsTcmhmThreeToSixModel{
                IDCardNo = this.Model.IDCardNo,
                RecordID = this.Model.RecordID,
                ModelState = RecordsStateModel.NoValue,
                CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                CreatedDate = new DateTime?(DateTime.Today),
                FollowupDate = new DateTime?(DateTime.Today),
                FollowupType = Convert.ToString((int) (selIndex + 1))
            };
            this.ThreeToSixModels.Add(item);
            KidsThreeToSixUserControl six = new KidsThreeToSixUserControl {
                DataSrc = item,
                SelIndex = selIndex
            };
            six.InitUc();
            this.ThreeToSix.Add(six);
            tp.Controls.Add(six);
            tp.ImageIndex = 1;
        }

        private void CreateWithinOne(TabPage tp, int selIndex)
        {
            KidsTcmhmOneModel item = new KidsTcmhmOneModel {
                IDCardNo = this.Model.IDCardNo,
                RecordID = this.Model.RecordID,
                ModelState = RecordsStateModel.NoValue,
                CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                CreatedDate = new DateTime?(DateTime.Today),
                FollowupDate = new DateTime?(DateTime.Today),
                FollowupType = Convert.ToString((int) (selIndex + 1))
            };
            this.withinOneModels.Add(item);
            KidsWithinOneUserControl one = new KidsWithinOneUserControl {
                DataSrc = item,
                SelIndex = selIndex
            };
            one.InitUc();
            this.withOne.Add(one);
            tp.Controls.Add(one);
            tp.ImageIndex = 1;
        }
        private void CreateWithinTwentyfourtoThirtysixh(TabPage tp, int selIndex)
        {
            if (selIndex == 0)//24月龄
            {
                KidsTcmhmOneToThreeModel item = new KidsTcmhmOneToThreeModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    ModelState = RecordsStateModel.NoValue,
                    CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                    CreatedDate = new DateTime?(DateTime.Today),
                    FollowupDate = new DateTime?(DateTime.Today),
                    FollowupType = "3"
                };
                this.OneToTwoModels.Add(item);
                KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                {
                    DataSrc = item,
                    SelIndex = 2
                };
                two.InitUc();
                this.OneToTwo.Add(two);
                tp.Controls.Add(two);
                tp.ImageIndex = 1;
            }
            else if (selIndex == 1)//30月龄
            {
                KidsTcmhmOneToThreeModel item = new KidsTcmhmOneToThreeModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    ModelState = RecordsStateModel.NoValue,
                    CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                    CreatedDate = new DateTime?(DateTime.Today),
                    FollowupDate = new DateTime?(DateTime.Today),
                    FollowupType = "4"
                };
                this.OneToTwoModels.Add(item);
                KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                {
                    DataSrc = item,
                    SelIndex = 3
                };
                two.InitUc();
                this.OneToTwo.Add(two);
                tp.Controls.Add(two);
                tp.ImageIndex = 1;
            }
            else if (selIndex == 2)//36月龄
            {
                KidsTcmhmThreeToSixModel item = new KidsTcmhmThreeToSixModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    ModelState = RecordsStateModel.NoValue,
                    CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                    CreatedDate = new DateTime?(DateTime.Today),
                    FollowupDate = new DateTime?(DateTime.Today),
                    FollowupType = "1"
                };
                this.ThreeToSixModels.Add(item);
                KidsThreeToSixUserControl six = new KidsThreeToSixUserControl
                {
                    DataSrc = item,
                    SelIndex = 0
                };
                six.InitUc();
                this.ThreeToSix.Add(six);
                tp.Controls.Add(six);
                tp.ImageIndex = 1;
            }
        }
        private void CreateWithinSixtoEighteenMoth(TabPage tp, int selIndex)
        {
            if (selIndex == 0)//6个月龄
            {
                KidsTcmhmOneModel item = new KidsTcmhmOneModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    ModelState = RecordsStateModel.NoValue,
                    CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                    CreatedDate = new DateTime?(DateTime.Today),
                    FollowupDate = new DateTime?(DateTime.Today),
                    FollowupType = "3"
                };
                this.withinOneModels.Add(item);
                KidsWithinOneUserControl one = new KidsWithinOneUserControl
                {
                    DataSrc = item,
                    SelIndex = selIndex
                };
                one.InitUc();
                this.withOne.Add(one);
                tp.Controls.Add(one);
                tp.ImageIndex = 1;
            }
            else if(selIndex == 1)//12月龄
            {
                KidsTcmhmOneToThreeModel item = new KidsTcmhmOneToThreeModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    ModelState = RecordsStateModel.NoValue,
                    CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                    CreatedDate = new DateTime?(DateTime.Today),
                    FollowupDate = new DateTime?(DateTime.Today),
                    FollowupType = "1"
                };
                this.OneToTwoModels.Add(item);
                KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                {
                    DataSrc = item,
                    SelIndex = 0
                };
                two.InitUc();
                this.OneToTwo.Add(two);
                tp.Controls.Add(two);
                tp.ImageIndex = 1;
            }
            else if (selIndex == 2)//18月龄
            {
                KidsTcmhmOneToThreeModel item = new KidsTcmhmOneToThreeModel
                {
                    IDCardNo = this.Model.IDCardNo,
                    RecordID = this.Model.RecordID,
                    ModelState = RecordsStateModel.NoValue,
                    CreatedBy = new decimal?(ConfigHelper.GetNodeDec("doctor")),
                    CreatedDate = new DateTime?(DateTime.Today),
                    FollowupDate = new DateTime?(DateTime.Today),
                    FollowupType = "2"
                };
                this.OneToTwoModels.Add(item);
                KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                {
                    DataSrc = item,
                    SelIndex = 1
                };
                two.InitUc();
                this.OneToTwo.Add(two);
                tp.Controls.Add(two);
                tp.ImageIndex = 1;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmChlTcmhmOne_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.SignPath))
            {
                Directory.CreateDirectory(this.SignPath);
            }
            if (!this.EveryThingIsOk)
            {
                this.InitEveryThing();
            }
        }

        public void InitEveryOne()
        {
            this.withOne = new List<KidsWithinOneUserControl>();
            this.OneToTwo = new List<KidsOneToTwoUserControl>();
            this.ThreeToSix = new List<KidsThreeToSixUserControl>();
        }

        public void InitEveryThing()
        {
            this.withinOneModels = new KidsTcmhmOneBLL().GetModelList(" IDCardNo ='" + this.Model.IDCardNo+"'");
            if (this.withinOneModels.Count<KidsTcmhmOneModel>(af => (af.FollowupType == "3")) == 0)
            {
                this.CreateWithinOne(this.TabPMon6, 2);
            }
            for (int i = 0; i < this.withinOneModels.Count; i++)
            {
                this.withinOneModels[i].LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.withinOneModels[i].LastUpdateDate = new DateTime?(DateTime.Today);
                int num2 = int.Parse(this.withinOneModels[i].FollowupType) - 1;
                if (num2 != 2)
                {
                    continue;
                }
                 if ((this.withinOneModels[i].ModelState != RecordsStateModel.NoValue))
                 {
                KidsWithinOneUserControl item = new KidsWithinOneUserControl
                {
                    DataSrc = this.withinOneModels[i],
                    SelIndex = num2
                };
                item.InitUc();
                this.withOne.Add(item);
                this.TabCWithinOne.TabPages[0].Controls.Add(item);
                this.TabCWithinOne.TabPages[0].ImageIndex = (this.withinOneModels[i].ModelState != RecordsStateModel.NoValue) ? 0 : 1;
                 }
            }
            this.OneToTwoModels = new KidsTcmhmOneToThreeBLL().GetModelList(" IDCardNo ='" + this.Model.IDCardNo + "'");
            if (this.OneToTwoModels.Count<KidsTcmhmOneToThreeModel>(af => (af.FollowupType == "3")) == 0)
            {
                this.CreateWithinTwentyfourtoThirtysixh(this.tabCtrOnetoTwo.TabPages[0],0);
            }
            for (int j = 0; j < this.OneToTwoModels.Count; j++)
            {
                this.OneToTwoModels[j].LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.OneToTwoModels[j].LastUpdateDate = new DateTime?(DateTime.Today);
                int num5 = int.Parse(this.OneToTwoModels[j].FollowupType) - 1;
                if ((this.OneToTwoModels[j].ModelState != RecordsStateModel.NoValue))
                {
                    if (num5 == 0)
                    {
                        KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                        {
                            DataSrc = this.OneToTwoModels[j],
                            SelIndex = num5
                        };
                        two.InitUc();
                        this.OneToTwo.Add(two);
                        this.TabCWithinOne.TabPages[1].Controls.Add(two);
                        this.TabCWithinOne.TabPages[1].ImageIndex = (this.OneToTwoModels[j].ModelState != RecordsStateModel.NoValue) ? 0 : 1;
                    }
                    else if (num5 == 1)
                    {
                        KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                        {
                            DataSrc = this.OneToTwoModels[j],
                            SelIndex = num5
                        };
                        two.InitUc();
                        this.OneToTwo.Add(two);
                        this.TabCWithinOne.TabPages[2].Controls.Add(two);
                        this.TabCWithinOne.TabPages[2].ImageIndex = (this.OneToTwoModels[j].ModelState != RecordsStateModel.NoValue) ? 0 : 1;
                    }
                    else if (num5 == 2)
                    {
                        KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                        {
                            DataSrc = this.OneToTwoModels[j],
                            SelIndex = num5
                        };
                        two.InitUc();
                        this.OneToTwo.Add(two);
                        this.tabCtrOnetoTwo.TabPages[0].Controls.Add(two);
                        this.tabCtrOnetoTwo.TabPages[0].ImageIndex = (this.OneToTwoModels[j].ModelState != RecordsStateModel.NoValue) ? 0 : 1;
                    }
                    else if (num5 == 3)
                    {
                        KidsOneToTwoUserControl two = new KidsOneToTwoUserControl
                        {
                            DataSrc = this.OneToTwoModels[j],
                            SelIndex = num5
                        };
                        two.InitUc();
                        this.OneToTwo.Add(two);
                        this.tabCtrOnetoTwo.TabPages[1].Controls.Add(two);
                        this.tabCtrOnetoTwo.TabPages[1].ImageIndex = (this.OneToTwoModels[j].ModelState != RecordsStateModel.NoValue) ? 0 : 1;
                    }
                }
                //for (int n = 0; n < this.tabCtrOnetoTwo.TabPages.Count; n++)
                //{
                //    if ((this.OneToTwoModels[j].ModelState != RecordsStateModel.NoValue) && (num5 == n))
                //    {
                //        KidsOneToTwoUserControl two = new KidsOneToTwoUserControl {
                //            DataSrc = this.OneToTwoModels[j],
                //            SelIndex = num5
                //        };
                //        two.InitUc();
                //        this.OneToTwo.Add(two);
                //        this.tabCtrOnetoTwo.TabPages[n].Controls.Add(two);
                //        this.tabCtrOnetoTwo.TabPages[n].ImageIndex = (this.OneToTwoModels[j].ModelState != RecordsStateModel.NoValue) ? 0 : 1;
                //    }
                //}
            }
            this.ThreeToSixModels = new KidsTcmhmThreeToSixBLL().GetModelList(" IDCardNo ='" + this.Model.IDCardNo + "'");
            //if (this.ThreeToSixModels.Count<KidsTcmhmThreeToSixModel>(af => (af.FollowupType == "1")) == 0)
            //{
            //    this.CreateThreeToSix(this.tabCtrThreeToSix.TabPages[0], 0);
            //}
            for (int k = 0; k < this.ThreeToSixModels.Count; k++)
            {
                this.ThreeToSixModels[k].LastUpdateBy = new decimal?(ConfigHelper.GetNodeDec("doctor"));
                this.ThreeToSixModels[k].LastUpdateDate = new DateTime?(DateTime.Today);
                int num8 = int.Parse(this.ThreeToSixModels[k].FollowupType) - 1;
                if (num8 != 0)//3岁
                {
                    continue;
                }
                if ((this.ThreeToSixModels[k].ModelState != RecordsStateModel.NoValue))
                {
                    KidsThreeToSixUserControl six = new KidsThreeToSixUserControl
                    {
                        DataSrc = this.ThreeToSixModels[k],
                        SelIndex = num8
                    };
                    six.InitUc();
                    this.ThreeToSix.Add(six);
                    this.tabCtrOnetoTwo.TabPages[2].Controls.Add(six);
                    this.tabCtrOnetoTwo.TabPages[2].ImageIndex = (this.ThreeToSixModels[k].ModelState != RecordsStateModel.NoValue) ? 0 : 1;
                }
            }

            this.SignS6 = string.Format("{0}{1}_Mec6.png", this.SignPath, this.Model.IDCardNo);
            this.SignDoc6 = string.Format("{0}{1}_Mec6_Doc.png", this.SignPath, this.Model.IDCardNo);
            this.SignS12 = string.Format("{0}{1}_Mec12.png", this.SignPath, this.Model.IDCardNo);
            this.SignDoc12 = string.Format("{0}{1}_Mec12_Doc.png", this.SignPath, this.Model.IDCardNo);
            this.SignS18 = string.Format("{0}{1}_Mec18.png", this.SignPath, this.Model.IDCardNo);
            this.SignDoc18 = string.Format("{0}{1}_Mec18_Doc.png", this.SignPath, this.Model.IDCardNo);
            this.SignS24 = string.Format("{0}{1}_Mec24.png", this.SignPath, this.Model.IDCardNo);
            this.SignDoc24 = string.Format("{0}{1}_Mec24_Doc.png", this.SignPath, this.Model.IDCardNo);
            this.SignS30 = string.Format("{0}{1}_Mec30.png", this.SignPath, this.Model.IDCardNo);
            this.SignDoc30 = string.Format("{0}{1}_Mec30_Doc.png", this.SignPath, this.Model.IDCardNo);

            //签名初始化
            //if (File.Exists(this.SignS6))
            //{
            //    Image imgeb = Image.FromFile(SignS6);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignJs6.Image = bmp;
            //    picSignJs6.Show();
            //    imgeb.Dispose();
            //    this.lkJs6.Enabled = true;
            //    this.axHWPenSignJs6.Visible = false;
            //}
            //if (File.Exists(this.SignDoc6))
            //{
            //    Image imgeb = Image.FromFile(SignDoc6);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignYs6.Image = bmp;
            //    picSignYs6.Show();
            //    imgeb.Dispose();
            //    this.lkYs6.Enabled = true;
            //    this.axHWPenSignYs6.Visible = false;
            //}
            //if (File.Exists(this.SignS12))
            //{
            //    Image imgeb = Image.FromFile(SignS12);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignJs12.Image = bmp;
            //    picSignJs12.Show();
            //    imgeb.Dispose();
            //    this.lkJs12.Enabled = true;
            //    this.axHWPenSignJs12.Visible = false;
            //}
            //if (File.Exists(this.SignDoc12))
            //{
            //    Image imgeb = Image.FromFile(SignDoc12);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignYs12.Image = bmp;
            //    picSignYs12.Show();
            //    imgeb.Dispose();
            //    this.lkYs12.Enabled = true;
            //    this.axHWPenSignYs12.Visible = false;
            //}
            //if (File.Exists(this.SignS18))
            //{
            //    Image imgeb = Image.FromFile(SignS18);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignJs18.Image = bmp;
            //    picSignJs18.Show();
            //    imgeb.Dispose();
            //    this.lkJs18.Enabled = true;
            //    this.axHWPenSignJs18.Visible = false;
            //}
            //if (File.Exists(this.SignDoc18))
            //{
            //    Image imgeb = Image.FromFile(SignDoc18);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignYs18.Image = bmp;
            //    picSignYs18.Show();
            //    imgeb.Dispose();
            //    this.lkYs18.Enabled = true;
            //    this.axHWPenSignYs18.Visible = false;
            //}
            //if (File.Exists(this.SignS24))
            //{
            //    Image imgeb = Image.FromFile(SignS24);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignJs24.Image = bmp;
            //    picSignJs24.Show();
            //    imgeb.Dispose();
            //    this.lkJs24.Enabled = true;
            //    this.axHWPenSignJs24.Visible = false;
            //}
            //if (File.Exists(this.SignDoc24))
            //{
            //    Image imgeb = Image.FromFile(SignDoc24);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignYs24.Image = bmp;
            //    picSignYs24.Show();
            //    imgeb.Dispose();
            //    this.lkYs24.Enabled = true;
            //    this.axHWPenSignYs24.Visible = false;
            //}
            //if (File.Exists(this.SignS30))
            //{
            //    Image imgeb = Image.FromFile(SignS30);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignJs30.Image = bmp;
            //    picSignJs30.Show();
            //    imgeb.Dispose();
            //    this.lkJs30.Enabled = true;
            //    this.axHWPenSignJs30.Visible = false;
            //}
            //if (File.Exists(this.SignDoc30))
            //{
            //    Image imgeb = Image.FromFile(SignDoc30);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignYs30.Image = bmp;
            //    picSignYs30.Show();
            //    imgeb.Dispose();
            //    this.lkYs30.Enabled = true;
            //    this.axHWPenSignYs30.Visible = false;
            //}
            //if (File.Exists(this.SignS36))
            //{
            //    Image imgeb = Image.FromFile(SignS36);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignJs36.Image = bmp;
            //    picSignJs36.Show();
            //    imgeb.Dispose();
            //    this.lkJs36.Enabled = true;
            //    this.axHWPenSignJs36.Visible = false;
            //}
            //if (File.Exists(this.SignDoc36))
            //{
            //    Image imgeb = Image.FromFile(SignDoc36);
            //    Image bmp = new System.Drawing.Bitmap(imgeb);
            //    picSignYs36.Image = bmp;
            //    picSignYs36.Show();
            //    imgeb.Dispose();
            //    this.lkYs36.Enabled = true;
            //    this.axHWPenSignYs36.Visible = false;
            //}
            IniPenSign();
            this.EveryThingIsOk = true;
        }
        private void IniPenSign()
        {
            //IniPenSignByContrl(axHWPenSignJs6);
            //IniPenSignByContrl(axHWPenSignYs6);
            //IniPenSignByContrl(axHWPenSignJs12);
            //IniPenSignByContrl(axHWPenSignYs12);
            //IniPenSignByContrl(axHWPenSignJs18);
            //IniPenSignByContrl(axHWPenSignYs18);
            //IniPenSignByContrl(axHWPenSignJs24);
            //IniPenSignByContrl(axHWPenSignYs24);
            //IniPenSignByContrl(axHWPenSignJs30);
            //IniPenSignByContrl(axHWPenSignYs30);
            //IniPenSignByContrl(axHWPenSignJs36);
            //IniPenSignByContrl(axHWPenSignYs36);
        }

        private void IniPenSignByContrl(AxHWPenSignLib.AxHWPenSign axHWPenSign)
        {
            const UInt32 intColor = 0xC8F8DE;
            axHWPenSign.HWSetBkColor(intColor);
            axHWPenSign.HWSetCtlFrame(2, 0x000000);
            axHWPenSign.HWSetExtWndHandle(this.Handle.ToInt32());
            axHWPenSign.HWSetPenWidth(1);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChlTcmhmOne));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TabCWithinOne = new System.Windows.Forms.TabControl();
            this.TabPMon6 = new System.Windows.Forms.TabPage();
            this.TabPMon12 = new System.Windows.Forms.TabPage();
            this.TabPMon18 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabCtrOnetoTwo = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.TabCWithinOne.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabCtrOnetoTwo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TabCWithinOne);
            this.groupBox1.Location = new System.Drawing.Point(117, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1328, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "6-18月龄儿童中医药管理服务";
            // 
            // TabCWithinOne
            // 
            this.TabCWithinOne.Controls.Add(this.TabPMon6);
            this.TabCWithinOne.Controls.Add(this.TabPMon12);
            this.TabCWithinOne.Controls.Add(this.TabPMon18);
            this.TabCWithinOne.ImageList = this.imageList1;
            this.TabCWithinOne.Location = new System.Drawing.Point(6, 22);
            this.TabCWithinOne.Name = "TabCWithinOne";
            this.TabCWithinOne.SelectedIndex = 0;
            this.TabCWithinOne.Size = new System.Drawing.Size(1254, 244);
            this.TabCWithinOne.TabIndex = 0;
            this.TabCWithinOne.SelectedIndexChanged += new System.EventHandler(this.TabCWithinOne_SelectedIndexChanged);
            // 
            // TabPMon6
            // 
            this.TabPMon6.Location = new System.Drawing.Point(4, 31);
            this.TabPMon6.Name = "TabPMon6";
            this.TabPMon6.Size = new System.Drawing.Size(1246, 209);
            this.TabPMon6.TabIndex = 2;
            this.TabPMon6.Text = "6月龄";
            this.TabPMon6.UseVisualStyleBackColor = true;
            // 
            // TabPMon12
            // 
            this.TabPMon12.Location = new System.Drawing.Point(4, 31);
            this.TabPMon12.Name = "TabPMon12";
            this.TabPMon12.Size = new System.Drawing.Size(1005, 209);
            this.TabPMon12.TabIndex = 4;
            this.TabPMon12.Text = "12月龄";
            this.TabPMon12.UseVisualStyleBackColor = true;
            // 
            // TabPMon18
            // 
            this.TabPMon18.Location = new System.Drawing.Point(4, 31);
            this.TabPMon18.Name = "TabPMon18";
            this.TabPMon18.Size = new System.Drawing.Size(1005, 209);
            this.TabPMon18.TabIndex = 5;
            this.TabPMon18.Text = "18月龄";
            this.TabPMon18.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "well.png");
            this.imageList1.Images.SetKeyName(1, "add.png");
            this.imageList1.Images.SetKeyName(2, "warning.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabCtrOnetoTwo);
            this.groupBox2.Location = new System.Drawing.Point(117, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1328, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "24-36月龄儿童中医药健康管理服务";
            // 
            // tabCtrOnetoTwo
            // 
            this.tabCtrOnetoTwo.Controls.Add(this.tabPage9);
            this.tabCtrOnetoTwo.Controls.Add(this.tabPage10);
            this.tabCtrOnetoTwo.Controls.Add(this.tabPage4);
            this.tabCtrOnetoTwo.ImageList = this.imageList1;
            this.tabCtrOnetoTwo.Location = new System.Drawing.Point(6, 22);
            this.tabCtrOnetoTwo.Name = "tabCtrOnetoTwo";
            this.tabCtrOnetoTwo.SelectedIndex = 0;
            this.tabCtrOnetoTwo.Size = new System.Drawing.Size(1250, 242);
            this.tabCtrOnetoTwo.TabIndex = 1;
            this.tabCtrOnetoTwo.SelectedIndexChanged += new System.EventHandler(this.tabCtrOnetoTwo_SelectedIndexChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 31);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1242, 207);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "24月龄";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 31);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1005, 207);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "30月龄";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1005, 207);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "36月龄";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // FrmChlTcmhmOne
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1540, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Name = "FrmChlTcmhmOne";
            this.Text = "FrmChlTcmhmOne";
            this.Load += new System.EventHandler(this.FrmChlTcmhmOne_Load);
            this.groupBox1.ResumeLayout(false);
            this.TabCWithinOne.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabCtrOnetoTwo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void NotisfyChildStatus()
        {
        }

        public bool SaveModelToDB()
        {
            foreach (KidsWithinOneUserControl one in this.withOne)
            {
                one.SaveUc();
            }
            foreach (KidsOneToTwoUserControl two in this.OneToTwo)
            {
                two.SaveUc();
            }
            foreach (KidsThreeToSixUserControl six in this.ThreeToSix)
            {
                six.SaveUc();
            }

            ////保存签名
            //if (this.picSignJs6.Image == null)//6个月家长签名
            //{
            //    axHWPenSignJs6.HWSetFilePath(this.SignS6);
            //    long result6 = axHWPenSignJs6.HWSaveFile();
            //    if (result6 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignS6);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            //if (this.picSignYs6.Image == null)//6个月随访医生签名
            //{
            //    axHWPenSignYs6.HWSetFilePath(this.SignDoc6);
            //    long result6 = axHWPenSignYs6.HWSaveFile();
            //    if (result6 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignDoc6);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            //if (this.picSignJs12.Image == null)//12个月家长签名
            //{
            //    axHWPenSignJs12.HWSetFilePath(this.SignS12);
            //    long result12 = axHWPenSignJs12.HWSaveFile();
            //    if (result12 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignS12);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            //if (this.picSignYs12.Image == null)//12个月随访医生签名
            //{
            //    axHWPenSignYs12.HWSetFilePath(this.SignDoc12);
            //    long result12 = axHWPenSignYs12.HWSaveFile();
            //    if (result12 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignDoc12);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}

            //if (this.picSignJs18.Image == null)//18个月家长签名
            //{
            //    axHWPenSignJs18.HWSetFilePath(this.SignS18);
            //    long result18 = axHWPenSignJs18.HWSaveFile();
            //    if (result18 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignS18);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            //if (this.picSignYs18.Image == null)//18个月随访医生签名
            //{
            //    axHWPenSignYs18.HWSetFilePath(this.SignDoc18);
            //    long result18 = axHWPenSignYs18.HWSaveFile();
            //    if (result18 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignDoc18);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}

            
            ////保存签名
            //if (this.picSignJs24.Image == null)//24个月家长签名
            //{
            //    axHWPenSignJs24.HWSetFilePath(this.SignS24);
            //    long result1 = axHWPenSignJs24.HWSaveFile();
            //    if (result1 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignS24);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            //if (this.picSignYs24.Image == null)//24个月随访医生签名
            //{
            //    axHWPenSignYs24.HWSetFilePath(this.SignDoc24);
            //    long result1 = axHWPenSignYs24.HWSaveFile();
            //    if (result1 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignDoc24);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}

            ////保存签名
            //if (this.picSignJs30.Image == null)//30个月家长签名
            //{
            //    axHWPenSignJs30.HWSetFilePath(this.SignS30);
            //    long result1 = axHWPenSignJs30.HWSaveFile();
            //    if (result1 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignS30);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            //if (this.picSignYs30.Image == null)//30个月随访医生签名
            //{
            //    axHWPenSignYs30.HWSetFilePath(this.SignDoc30);
            //    long result1 = axHWPenSignYs30.HWSaveFile();
            //    if (result1 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignDoc30);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}

            //if (this.picSignJs36.Image == null)//36个月家长签名
            //{
            //    axHWPenSignJs36.HWSetFilePath(this.SignS36);
            //    long result1 = axHWPenSignJs36.HWSaveFile();
            //    if (result1 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignS36);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            //if (this.picSignYs36.Image == null)//36个月随访医生签名
            //{
            //    axHWPenSignYs36.HWSetFilePath(this.SignDoc36);
            //    long result1 = axHWPenSignYs36.HWSaveFile();
            //    if (result1 == -5)
            //    {
            //        try
            //        {

            //            File.Delete(this.SignDoc36);//删除原有的签名
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
            return true;
        }

        private void tabCtrOnetoTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl control = sender as TabControl;
            TabPage tp = control.TabPages[control.SelectedIndex];
            if (tp.Controls.Count == 0)
            {
                //this.CreateOneToTwo(tp, control.SelectedIndex);
                this.CreateWithinTwentyfourtoThirtysixh(tp, control.SelectedIndex);
            }
        }

        private void tabCtrThreeToSix_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl control = sender as TabControl;
            TabPage tp = control.TabPages[control.SelectedIndex];
            if (tp.Controls.Count == 0)
            {
                this.CreateThreeToSix(tp, control.SelectedIndex);
            }
        }

        private void TabCWithinOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl control = sender as TabControl;
            TabPage tp = control.TabPages[control.SelectedIndex];
            if (tp.Controls.Count == 0)
            {
                //this.CreateWithinOne(tp, control.SelectedIndex);
                this.CreateWithinSixtoEighteenMoth(tp, control.SelectedIndex);
            }
        }

        public void UpdataToModel()
        {
            foreach (KidsWithinOneUserControl one in this.withOne)
            {
                one.UpdateUc();
            }
            foreach (KidsOneToTwoUserControl two in this.OneToTwo)
            {
                two.UpdateUc();
            }
            foreach (KidsThreeToSixUserControl six in this.ThreeToSix)
            {
                six.UpdateUc();
            }
        }

        public bool EveryThingIsOk { get; set; }

        public bool HaveToSave { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public string SaveDataInfo { get; set; }

        //private void axHWPenSignYs1_Enter(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    int res = axHWPenSignT.HWInitialize();
        //    if (res != HW_eOk)
        //    {
        //        //MessageBox.Show("Failed to open device");
        //    }
        //}

        //private void axHWPenSignYs1_Leave(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    axHWPenSignT.HWFinalize();
        //}

        //private void axHWPenSignJs1_Leave(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    axHWPenSignT.HWFinalize();
        //}

        //private void axHWPenSignJs1_Enter(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    int res = axHWPenSignT.HWInitialize();
        //    if (res != HW_eOk)
        //    {
        //        //MessageBox.Show("Failed to open device");
        //    }
        //}

        //private void axHWPenSignYs2_Enter(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    int res = axHWPenSignT.HWInitialize();
        //    if (res != HW_eOk)
        //    {
        //        //MessageBox.Show("Failed to open device");
        //    }
        //}

        //private void axHWPenSignYs2_Leave(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    axHWPenSignT.HWFinalize();
        //}

        //private void axHWPenSignJs2_Enter(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    int res = axHWPenSignT.HWInitialize();
        //    if (res != HW_eOk)
        //    {
        //        //MessageBox.Show("Failed to open device");
        //    }
        //}

        //private void axHWPenSignJs2_Leave(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    axHWPenSignT.HWFinalize();
        //}

        //private void lkYs1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignYs6.Image != null)
        //        {
        //            this.picSignYs6.Image.Dispose();
        //            this.picSignYs6.Image = null;
        //        }

        //        this.picSignYs6.Visible = false;
        //        axHWPenSignYs6.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkYs2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignYs24.Image != null)
        //        {
        //            this.picSignYs24.Image.Dispose();
        //            this.picSignYs24.Image = null;
        //        }

        //        this.picSignYs24.Visible = false;
        //        axHWPenSignYs24.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkJs1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignJs6.Image != null)
        //        {
        //            this.picSignJs6.Image.Dispose();
        //            this.picSignJs6.Image = null;
        //        }

        //        this.picSignJs6.Visible = false;
        //        axHWPenSignJs6.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkJs2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignJs24.Image != null)
        //        {
        //            this.picSignJs24.Image.Dispose();
        //            this.picSignJs24.Image = null;
        //        }

        //        this.picSignJs24.Visible = false;
        //        axHWPenSignJs24.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkYs12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignYs12.Image != null)
        //        {
        //            this.picSignYs12.Image.Dispose();
        //            this.picSignYs12.Image = null;
        //        }

        //        this.picSignYs12.Visible = false;
        //        axHWPenSignYs12.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkJs12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignJs24.Image != null)
        //        {
        //            this.picSignJs24.Image.Dispose();
        //            this.picSignJs24.Image = null;
        //        }

        //        this.picSignJs24.Visible = false;
        //        axHWPenSignJs24.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkYs18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignYs18.Image != null)
        //        {
        //            this.picSignYs18.Image.Dispose();
        //            this.picSignYs18.Image = null;
        //        }

        //        this.picSignYs18.Visible = false;
        //        axHWPenSignYs18.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkJs18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignJs18.Image != null)
        //        {
        //            this.picSignJs18.Image.Dispose();
        //            this.picSignJs18.Image = null;
        //        }

        //        this.picSignJs18.Visible = false;
        //        axHWPenSignJs18.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkYs30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignYs30.Image != null)
        //        {
        //            this.picSignYs30.Image.Dispose();
        //            this.picSignYs30.Image = null;
        //        }

        //        this.picSignYs30.Visible = false;
        //        axHWPenSignYs30.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkJs30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignJs30.Image != null)
        //        {
        //            this.picSignJs30.Image.Dispose();
        //            this.picSignJs30.Image = null;
        //        }

        //        this.picSignJs30.Visible = false;
        //        axHWPenSignJs30.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkYs36_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignYs36.Image != null)
        //        {
        //            this.picSignYs36.Image.Dispose();
        //            this.picSignYs36.Image = null;
        //        }

        //        this.picSignYs36.Visible = false;
        //        axHWPenSignYs36.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void lkJs36_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (picSignJs36.Image != null)
        //        {
        //            this.picSignJs36.Image.Dispose();
        //            this.picSignJs36.Image = null;
        //        }

        //        this.picSignJs36.Visible = false;
        //        axHWPenSignJs36.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void axHWPenSignYs12_Enter(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    int res = axHWPenSignT.HWInitialize();
        //    if (res != HW_eOk)
        //    {
        //        //MessageBox.Show("Failed to open device");
        //    }
        //}

        //private void axHWPenSignYs12_Leave(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    axHWPenSignT.HWFinalize();
        //}

        //private void axHWPenSignJs12_Enter(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    int res = axHWPenSignT.HWInitialize();
        //    if (res != HW_eOk)
        //    {
        //        //MessageBox.Show("Failed to open device");
        //    }
        //}

        //private void axHWPenSignJs12_Leave(object sender, EventArgs e)
        //{
        //    AxHWPenSignLib.AxHWPenSign axHWPenSignT = (sender) as AxHWPenSignLib.AxHWPenSign;

        //    int res = axHWPenSignT.HWInitialize();
        //    if (res != HW_eOk)
        //    {
        //        //MessageBox.Show("Failed to open device");
        //    }
        //}
    }
}

