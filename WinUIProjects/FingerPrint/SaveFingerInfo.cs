using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerPrint
{
    public partial class SaveFingerInfo : Form
    {
        public SaveFingerInfo()
        {
            InitializeComponent();
        }

        public string IDCardNo { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveFingerInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
