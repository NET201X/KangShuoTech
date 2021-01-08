namespace KangShuoTech.Utilities.CommonControl
{
    partial class DoseVisitUserControl
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
            this.tbName = new Femiani.Forms.UI.Input.CoolTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUseCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtjixing = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tbName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(13, 3);
            this.tbName.Name = "tbName";
            this.tbName.Padding = new System.Windows.Forms.Padding(4);
            this.tbName.PopupWidth = 120;
            this.tbName.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.tbName.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.tbName.Size = new System.Drawing.Size(172, 24);
            this.tbName.TabIndex = 0;
            this.tbName.SelectListItem += new System.EventHandler(this.tbName_SelectListItem);
            this.tbName.AutoTextChanged += new System.EventHandler(this.tbName_AutoTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(194, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "用法：每日(月)";
            // 
            // tbUseCount
            // 
            this.tbUseCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUseCount.Location = new System.Drawing.Point(293, 3);
            this.tbUseCount.Name = "tbUseCount";
            this.tbUseCount.ReadOnly = true;
            this.tbUseCount.Size = new System.Drawing.Size(52, 23);
            this.tbUseCount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(344, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "次";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(377, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "每次剂量";
            // 
            // tbDose
            // 
            this.tbDose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDose.Location = new System.Drawing.Point(438, 3);
            this.tbDose.Name = "tbDose";
            this.tbDose.ReadOnly = true;
            this.tbDose.Size = new System.Drawing.Size(50, 23);
            this.tbDose.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(488, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "mg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(520, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "剂型";
            // 
            // txtjixing
            // 
            this.txtjixing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjixing.Location = new System.Drawing.Point(551, 3);
            this.txtjixing.Name = "txtjixing";
            this.txtjixing.ReadOnly = true;
            this.txtjixing.Size = new System.Drawing.Size(130, 23);
            this.txtjixing.TabIndex = 8;
            // 
            // DoseVisitUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtjixing);
            this.Controls.Add(this.tbDose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUseCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Name = "DoseVisitUserControl";
            this.Size = new System.Drawing.Size(688, 30);
            this.Load += new System.EventHandler(this.DoseVisitUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Femiani.Forms.UI.Input.CoolTextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUseCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtjixing;
    }
}
