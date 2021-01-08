using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrintPlatform.Properties;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;
using System.Xml;


namespace PrintPlatform
{
    public class ECGPrintFactory : ChildFormFactory
    {
        public ECGPrintFactory()
        {
            this.ItemParamters = new List<ItemParamters>();
            this.ItemParamters.Add(new ItemParamters("心电打印", new Image[] { Resources.btnxindian01, Resources.btnxindian01, Resources.btnxindian01 }));
        }

        public override IChildForm CreateChildForm(string name)
        {
            IChildForm form = null;
            string str = name;

            if (str != null)
            {
                if (str == "心电打印")
                {
                    string ectType = "1";

                    XmlDocument document = new XmlDocument();
                    document.Load(Environment.CurrentDirectory + @"\ECGconfig.xml");
                    XmlNode node = document.SelectSingleNode("//ECGType");

                    if (node != null)
                    {
                        ectType = node.InnerText.Trim();
                    }

                    if (ectType == "2")
                    {
                        form = new frmECGPrintM();
                    }
                    else
                    {
                        form = new frmECGPrint();
                    }

                    (form as IChildModel<RecordsBaseInfoModel>).Model = ((IParentModel<RecordsBaseInfoModel>)this.MControler.IParentFrm).Model;
                }
            }

            (form as Form).Text = name;
            form.HaveToSave = false;
            return form;
        }

        public override List<ItemParamters> ItemParamters
        {
            get;
            set;
        }

        public override IMDIControler MControler
        {
            get;
            set;
        }
        public override string MDIFrmText
        {
            get
            {
                return "心电打印";
            }
            set
            {
                base.MDIFrmText = value;
            }
        }
    }
}
