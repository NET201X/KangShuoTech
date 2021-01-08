namespace HealthHouse
{

    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Data;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using KangShuoTech.Utilities.CommonUI;
    using System.Diagnostics;
    using KangShuoTech.DataAccessProjects.Model;
    using KangShuoTech.DataAccessProjects.BLL;
    using KangShuoTech.Utilities.CommonControl;

    public class MainFormUserControl : UserControl
    {
        private PictureBox HealthCheckPictureBox;
        private PictureBox QueryPictureBox;
        private PictureBox PrintPictureBox;
        private PictureBox HealthEvaluationPictureBox;
        private PictureBox GuidePictureBox;
        private PictureBox pictureBox3;
        private IContainer components;
        public Process SingleProcess;

        public event EventHandler Cancel_Click;

        public MainFormUserControl()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.GuidePictureBox = new System.Windows.Forms.PictureBox();
            this.HealthEvaluationPictureBox = new System.Windows.Forms.PictureBox();
            this.PrintPictureBox = new System.Windows.Forms.PictureBox();
            this.QueryPictureBox = new System.Windows.Forms.PictureBox();
            this.HealthCheckPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuidePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthEvaluationPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthCheckPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::HealthHouse.Properties.Resources.远程诊疗;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(432, 245);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(135, 169);
            this.pictureBox3.TabIndex = 43;
            this.pictureBox3.TabStop = false;
            // 
            // GuidePictureBox
            // 
            this.GuidePictureBox.BackgroundImage = global::HealthHouse.Properties.Resources.健康指导;
            this.GuidePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GuidePictureBox.Location = new System.Drawing.Point(432, 54);
            this.GuidePictureBox.Name = "GuidePictureBox";
            this.GuidePictureBox.Size = new System.Drawing.Size(135, 169);
            this.GuidePictureBox.TabIndex = 43;
            this.GuidePictureBox.TabStop = false;
            this.GuidePictureBox.Click += new System.EventHandler(this.GuidePictureBox_Click);
            // 
            // HealthEvaluationPictureBox
            // 
            this.HealthEvaluationPictureBox.BackgroundImage = global::HealthHouse.Properties.Resources.健康评估;
            this.HealthEvaluationPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HealthEvaluationPictureBox.Location = new System.Drawing.Point(262, 54);
            this.HealthEvaluationPictureBox.Name = "HealthEvaluationPictureBox";
            this.HealthEvaluationPictureBox.Size = new System.Drawing.Size(135, 169);
            this.HealthEvaluationPictureBox.TabIndex = 42;
            this.HealthEvaluationPictureBox.TabStop = false;
            this.HealthEvaluationPictureBox.Click += new System.EventHandler(this.HealthEvaluationPictureBox_Click);
            // 
            // PrintPictureBox
            // 
            this.PrintPictureBox.BackgroundImage = global::HealthHouse.Properties.Resources.报告打印;
            this.PrintPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrintPictureBox.Location = new System.Drawing.Point(262, 245);
            this.PrintPictureBox.Name = "PrintPictureBox";
            this.PrintPictureBox.Size = new System.Drawing.Size(135, 169);
            this.PrintPictureBox.TabIndex = 41;
            this.PrintPictureBox.TabStop = false;
            this.PrintPictureBox.Click += new System.EventHandler(this.PrintPictureBox_Click);
            // 
            // QueryPictureBox
            // 
            this.QueryPictureBox.BackgroundImage = global::HealthHouse.Properties.Resources.健康查询;
            this.QueryPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QueryPictureBox.Location = new System.Drawing.Point(92, 245);
            this.QueryPictureBox.Name = "QueryPictureBox";
            this.QueryPictureBox.Size = new System.Drawing.Size(135, 169);
            this.QueryPictureBox.TabIndex = 40;
            this.QueryPictureBox.TabStop = false;
            this.QueryPictureBox.Click += new System.EventHandler(this.QueryPictureBox_Click);
            // 
            // HealthCheckPictureBox
            // 
            this.HealthCheckPictureBox.BackgroundImage = global::HealthHouse.Properties.Resources.健康体检;
            this.HealthCheckPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HealthCheckPictureBox.Location = new System.Drawing.Point(92, 54);
            this.HealthCheckPictureBox.Name = "HealthCheckPictureBox";
            this.HealthCheckPictureBox.Size = new System.Drawing.Size(135, 169);
            this.HealthCheckPictureBox.TabIndex = 39;
            this.HealthCheckPictureBox.TabStop = false;
            this.HealthCheckPictureBox.Click += new System.EventHandler(this.HealthCheckPictureBox_Click);
            // 
            // MainFormUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.GuidePictureBox);
            this.Controls.Add(this.HealthEvaluationPictureBox);
            this.Controls.Add(this.PrintPictureBox);
            this.Controls.Add(this.QueryPictureBox);
            this.Controls.Add(this.HealthCheckPictureBox);
            this.Name = "MainFormUserControl";
            this.Size = new System.Drawing.Size(804, 485);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuidePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthEvaluationPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthCheckPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        public string IDCardNo { get; set; }
        
        /// <summary>
        /// 健康体检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HealthCheckPictureBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            HealthHouseFactory.ID = 0;
            using (Controler controler = new Controler(new PhysicalForm(this.IDCardNo), new HealthHouseFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }

            GC.Collect();
        }
        
        /// <summary>
        /// 健康评估
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HealthEvaluationPictureBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }

            HealthHouseModel houseModel = new HealthHouseBLL().GetMaxData(this.IDCardNo);
            if (houseModel == null)
            {
                MessageBox.Show("人员未做体检，请先体检！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            HealthAssessFactory.ID = 0;
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new HealthAssessFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }
            
            GC.Collect();
        }

        /// <summary>
        /// 健康指导
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuidePictureBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            HealthHouseModel houseModel = new HealthHouseBLL().GetMaxData(this.IDCardNo);
            if (houseModel == null)
            {
                MessageBox.Show("人员未做体检，请先体检！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            HealthGuideFactory.ViewState = "新增";
            HealthGuideFactory.ID = 0;
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new HealthGuideFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }

            GC.Collect();
        }

        /// <summary>
        /// 健康查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryPictureBox_Click(object sender, EventArgs e)
        {
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new QueryInfoFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }

            GC.Collect();
        }

        /// <summary>
        /// 报告打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintPictureBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }

            SingleProcess = new Process { StartInfo = { FileName = @"HealthNewPrint.exe", Arguments = IDCardNo } };
            SingleProcess.Start();
        }
    }
}