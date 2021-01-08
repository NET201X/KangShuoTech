using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace HealthHouse
{    
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class PhysicalForm : MDIParentForm
    {
        public PhysicalForm(string idcard) : base(idcard)
        {
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x597:
                    (base.IMDIControler.IChildrens["一般情况"] as ChildContentForm).UpdateDeviceinfoContent(0x597);
                    return;

                case 0x598:
                    (base.IMDIControler.IChildrens["一般情况"] as ChildContentForm).UpdateDeviceinfoContent(0x598);
                    return;

                case 0x59a:
                    (base.IMDIControler.IChildrens["一般情况"] as ChildContentForm).UpdateDeviceinfoContent(0x59a);
                    return;

                case 0x59c:
                    (base.IMDIControler.IChildrens["一般情况"] as ChildContentForm).UpdateDeviceinfoContent(0x59c);
                    return;
            }

            base.DefWndProc(ref m);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}

