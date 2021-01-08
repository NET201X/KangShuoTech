using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KangShuoTech.Utilities.CommonControl
{
    public partial class ShijianUserControl : UserControl
    {
        public ShijianUserControl()
        {
            InitializeComponent();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            DateTime tm;
            if (!DateTime.TryParse(this.txtTime.Text, out tm))
            {
                this.txtTime.Text = string.Empty;
            }
        }

        private void dTPicker_ValueChanged(object sender, EventArgs e)
        {
            this.txtTime.Text = this.dTPicker.Value.ToLongDateString();
        }
    }
}
