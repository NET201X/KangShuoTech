using KangShuoTech.Utilities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ArchiveInfo
{
    public partial class ECGShowM : Form
    {
        public ECGShowM()
        {
            InitializeComponent();
        }

        public string FilePath { get; set; }

        private void ECGShowM_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
            {
                pboxBShow.Image = Image.FromFile(FilePath);
            }
            else
            {
                btnPrint.Visible = false;
            }
        }

        
        private void btnPrint_Click(object sender, EventArgs e)
        {
           CommonExtensions.ShellExecute(IntPtr.Zero, "Print", FilePath, "", "", 0);


            /*Process pr = new Process();
            pr.StartInfo.FileName = "explorer.exe";
            pr.StartInfo.CreateNoWindow = true;
            pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pr.StartInfo.Verb = "Print";
            pr.StartInfo.Arguments = FilePath;

            pr.StartInfo.UseShellExecute = true;
            pr.Start();

            pr.WaitForExit();*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ECGShowM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
            {
                pboxBShow.Image.Dispose();
            }
        }
    }
}
