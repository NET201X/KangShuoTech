using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace NewPrint
{
	public class mainFrom : Form
	{
		private IContainer components;
		public string IDCard
		{
			get;
			set;
		}
		public mainFrom()
		{
			this.InitializeComponent();
		}
		[DllImport("User32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr handle);
		private void mainFrom_Load(object sender, EventArgs e)
		{
			IntPtr intPtr = mainFrom.FindWindow(null, "居民健康档案打印");
			if (intPtr != IntPtr.Zero)
			{
				mainFrom.SetForegroundWindow(intPtr);
			}

			else
			{
				string arg_27_0 = Application.ExecutablePath;
				Process.Start("NewPrint.exe", this.IDCard);
			}
			base.Close();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(284, 88);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "mainFrom";
			base.ShowInTaskbar = false;
			this.Text = "mainFrom";
			base.WindowState = FormWindowState.Minimized;
			base.Load += new EventHandler(this.mainFrom_Load);
			base.ResumeLayout(false);
		}
	}
}
