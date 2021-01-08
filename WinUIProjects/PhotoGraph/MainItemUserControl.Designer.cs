namespace PhotoGraph
{
    partial class MainItemUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxList = new System.Windows.Forms.PictureBox();
            this.pictureBoxPrint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxList
            // 
            this.pictureBoxList.BackgroundImage = global::Properties.Resources.清单查询;
            this.pictureBoxList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxList.Location = new System.Drawing.Point(437, 215);
            this.pictureBoxList.Name = "pictureBoxList";
            this.pictureBoxList.Size = new System.Drawing.Size(210, 210);
            this.pictureBoxList.TabIndex = 1;
            this.pictureBoxList.TabStop = false;
            this.pictureBoxList.Click += new System.EventHandler(this.pictureBoxQuery_Click);
            // 
            // pictureBoxPrint
            // 
            this.pictureBoxPrint.BackgroundImage = global::Properties.Resources.拍取照片;
            this.pictureBoxPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPrint.Location = new System.Drawing.Point(167, 215);
            this.pictureBoxPrint.Name = "pictureBoxPrint";
            this.pictureBoxPrint.Size = new System.Drawing.Size(210, 210);
            this.pictureBoxPrint.TabIndex = 0;
            this.pictureBoxPrint.TabStop = false;
            this.pictureBoxPrint.Click += new System.EventHandler(this.pictureBoxPrint_Click);
            // 
            // MainItemUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBoxList);
            this.Controls.Add(this.pictureBoxPrint);
            this.Name = "MainItemUserControl";
            this.Size = new System.Drawing.Size(1013, 528);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPrint;
        private System.Windows.Forms.PictureBox pictureBoxList;
    }
}
