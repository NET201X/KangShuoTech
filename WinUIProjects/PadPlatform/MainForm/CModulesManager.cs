
using PadPlatform.Properties;
using KangShuoTech.Utilities.Common;

namespace PadPlatform
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Windows.Forms;
    using System.Xml;

    public class CModulesManager
    {
        private string fm_set;
        private List<CModule> Modules;
        public Action<CModule> myCall;
        private int pic_count;
        private readonly int pic_width = 306;
        private readonly int pic_height = 84;
        private readonly int pic_x_jianju = 140;
        private readonly int pic_y_jianju = 220;
        private readonly int pic_y_st = 0x36;

        public event EventHandler my_cancelCall;

        public CModulesManager(Action<CModule> act, EventHandler cancelClick, int height, int width)
        {
            this.Lev2Status = false;
            this.Modules = new List<CModule>();
            this.myCall = act;
            this.my_cancelCall = cancelClick;
            this.fm_set = ConfigHelper.GetNode("fsset");

            if (string.IsNullOrEmpty(this.fm_set))
            {
                this.fm_set = "111111111";
                ConfigHelper.WriteNode("fsset", this.fm_set);
            }

            char[] chArray = this.fm_set.ToArray<char>();
            string path = Application.StartupPath + @"\ModuleManger.xml";
            int index = 0;

            if (File.Exists(path))
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);

                foreach (XmlNode node in document.DocumentElement["ModuleStore"].ChildNodes)
                {
                    bool flag = true;

                    if (chArray.Length >= index)
                    {
                        flag = chArray[index].ToString() == "1";
                    }

                    index++;

                    if (flag)
                    {
                        CModule moduleInfo = this.GetModuleInfo(node);

                        if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\" + moduleInfo.FileName))
                        {
                            Assembly sampleAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\" + moduleInfo.FileName);

                            if (sampleAssembly != null)
                            {
                                moduleInfo.ModuleAssembly = sampleAssembly;
                                //Button button = this.CreatePicbox(moduleInfo, sampleAssembly);

                                //if (button != null) moduleInfo.C_Btn = button;

                                moduleInfo.ModuleCall = (EventHandler)Delegate.Combine(moduleInfo.ModuleCall, new EventHandler(this.moduleCall));
                                moduleInfo.ModuleCancelClick += new EventHandler(this.moduleCancelClick);

                                this.Modules.Add(moduleInfo);
                            }
                        }
                    }
                }
            }

            pic_height = height / this.Modules.Count;
            pic_width = width;

            foreach (CModule moduleInfo2 in this.Modules)
            {
                Assembly sampleAssembly = moduleInfo2.ModuleAssembly;

                Button button = this.CreatePicbox(moduleInfo2, sampleAssembly);
                moduleInfo2.C_Btn = button;
            }
        }

        private Button CreatePicbox(CModule mo, Assembly SampleAssembly)
        {
            try
            {
                Button button = null;

                if (SampleAssembly != null)
                {
                    Bitmap bitmap;

                    if (mo.ImgName == "档案信息")
                    {
                        bitmap = Resources.btndangan00;
                    }
                    else if (mo.ImgName == "随访人群")
                    {
                        bitmap = Resources.btnrenqun00;
                    }
                    else if (mo.ImgName == "医疗服务")
                    {
                        bitmap = Resources.btnyiliaofuwu00;
                    }
                    else if (mo.ImgName == "数据同步")
                    {
                        bitmap = Resources.btnshujutongbu0;
                    }
                    else if (mo.ImgName == "纸质档案")
                    {
                        bitmap = Resources.btnzhizhidangan00;
                    }
                    else if (mo.ImgName == "综合查询")
                    {
                        bitmap = Resources.btnchaxun00;
                    }
                    else if (mo.ImgName == "拍取照片")
                    {
                        bitmap = Resources.btnpaizhao00;
                    }
                    else
                    {
                        bitmap = Resources.未找到;
                    }

                    button = new Button
                    {
                        BackColor = Color.Transparent,
                        BackgroundImage = bitmap,
                        BackgroundImageLayout = ImageLayout.Zoom,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134),
                        TextAlign = ContentAlignment.BottomCenter,
                        Text = "",
                        Margin = new Padding(0, 0, 0, 0),
                        Location = this.GetPicPosition(this.pic_count++),
                        Name = mo.Name,
                        //Size = new Size(this.pic_width, pic_height),
                        Size = new Size(257, 96),
                        Tag = mo.ImgName,
                        TabStop = false
                    };

                    button.FlatAppearance.BorderSize = 0;

                    string.IsNullOrEmpty(mo.StrMainItems);
                }

                return button;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            return null;
        }

        public void FnButtonCall(Keys k)
        {
            string fnText = "";
            switch (k)
            {
                case Keys.F13:
                    fnText = "档案信息";
                    break;

                case Keys.F14:
                    fnText = "纸质档案";
                    break;

                case Keys.F15:
                    fnText = "综合查询";
                    break;

                case Keys.F19:
                    fnText = "随访人群";
                    break;

                case Keys.F20:
                    fnText = "数据同步";
                    break;

                case Keys.F21:
                    fnText = "多参数仪";
                    break;
            }

            if (!string.IsNullOrEmpty(fnText))
            {
                CModule module = this.Modules.First<CModule>(t => t.ImgName == fnText);
                if ((module != null) && (this.myCall != null))
                {
                    this.myCall(module);
                }
            }
        }

        private Bitmap GetBitmap(Assembly ass, string name)
        {
            Bitmap bitmap = null;
            Assembly assembly = ass;
            foreach (string str in assembly.GetManifestResourceNames())
            {
                foreach (DictionaryEntry entry in new ResourceReader(assembly.GetManifestResourceStream(str)))
                {
                    if (entry.Key.ToString() == name)
                    {
                        Bitmap bitmap2 = entry.Value as Bitmap;
                        if (bitmap2 != null)
                        {
                            bitmap = Image.FromHbitmap(bitmap2.GetHbitmap());
                        }
                    }
                }
            }
            return bitmap;
        }

        private CModule GetModuleInfo(XmlNode node)
        {
            CModule module = new CModule
            {
                Name = node.Name
            };
            foreach (XmlNode node2 in node.ChildNodes)
            {
                if (node2.Name == "fileName")
                {
                    module.FileName = node2.InnerText;
                }
                if (node2.Name == "mainItem")
                {
                    module.StrMainItems = node2.InnerText;
                }
                if (node2.Name == "mainForm")
                {
                    module.StrMainForms = node2.InnerText;
                }
                if (node2.Name == "itemPic")
                {
                    module.ImgName = node2.InnerText;
                }
                if (node2.Name == "formFactory")
                {
                    module.StrFactory = node2.InnerText;
                }
                if (node2.Name == "LcdOrder")
                {
                    module.LcdOrder = node2.InnerText;
                }
                if (node2.InnerText.Contains("OverView"))
                {
                    module.FileName = "RecordManagement.exe";
                    module.StrMainItems = "RecordManagement.MainItemUserControl";
                }
            }
            return module;
        }

        private Point GetPicPosition(int cnt)
        {
            if (cnt == 0)
            {
                return new Point(0, 5);
            }
            else if (cnt == 1)
            {
                return new Point(0, 101);
            }
            else if (cnt == 2)
            {
                return new Point(0, 197);
            }
            else if (cnt == 3)
            {
                return new Point(0, 293);
            }
            else if (cnt == 4)
            {
                return new Point(0, 389);
            }
            else if (cnt == 5)
            {
                return new Point(0, 485);
            }
            else if (cnt == 6)
            {
                return new Point(0, 583);
            }
            else if (cnt == 7)
            {
                return new Point(0, 675);
            }
            else
            {
                return new Point(0, 675);
                //return new Point(((0x520 - ((4 * this.pic_width) + (3 * this.pic_x_jianju))) / 2) + ((cnt % 4) * (this.pic_width + this.pic_x_jianju)), (cnt >= 4) ? (this.pic_y_jianju + this.pic_y_st) : this.pic_y_st);
            }
        }

        public void moduleCall(object sender, EventArgs e)
        {
            if (this.myCall != null)
            {
                this.myCall((CModule)sender);
            }
        }

        public void moduleCancelClick(object sender, EventArgs e)
        {
            if (this.my_cancelCall != null)
            {
                this.my_cancelCall(sender, e);
            }
        }

        public Button[] ArryModules
        {
            get
            {
                if (this.Modules != null)
                {
                    List<Button> list = new List<Button>();
                    foreach (CModule module in this.Modules)
                    {
                        list.Add(module.C_Btn);
                    }
                    if (list.Count > 0)
                    {
                        return list.ToArray();
                    }
                }
                return null;
            }
        }

        public int Count
        {
            get
            {
                return this.Modules.Count;
            }
        }

        public bool Lev2Status { get; set; }
    }
}

