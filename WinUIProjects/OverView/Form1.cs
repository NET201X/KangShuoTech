using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace OverView
{
    
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Form1 : ChildContentForm, IChildForm, IChildModel<RecordsBaseInfoModel>
    {
        private Button btnCanel;
        private IContainer components;
        private Label lbIdCard;
        private Label lbNavigation;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel topButtons;

        public Form1()
        {
            this.InitializeComponent();
        }

        public ChildFormStatus CheckErrorInput()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitEveryThing()
        {
            throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            this.splitContainer1 = new SplitContainer();
            this.topButtons = new FlowLayoutPanel();
            this.btnCanel = new Button();
            this.lbIdCard = new Label();
            this.lbNavigation = new Label();
            this.panel1 = new Panel();
            this.splitContainer1.BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            base.SuspendLayout();
            this.splitContainer1.BackColor = Color.Transparent;
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Orientation.Horizontal;
            this.splitContainer1.Panel1.Controls.Add(this.topButtons);
            this.splitContainer1.Panel1.Controls.Add(this.btnCanel);
            this.splitContainer1.Panel1.Controls.Add(this.lbIdCard);
            this.splitContainer1.Panel2.Controls.Add(this.lbNavigation);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new Size(0x3f8, 0x300);
            this.splitContainer1.SplitterDistance = 0x5b;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 14;
            this.topButtons.Location = new Point(12, 10);
            this.topButtons.Name = "topButtons";
            this.topButtons.Size = new Size(0x2b4, 0x4b);
            this.topButtons.TabIndex = 13;
            this.btnCanel.Location = new Point(0x3a6, 12);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new Size(0x42, 0x49);
            this.btnCanel.TabIndex = 11;
            this.btnCanel.Text = "返回";
            this.btnCanel.TextAlign = ContentAlignment.BottomCenter;
            this.btnCanel.UseVisualStyleBackColor = true;
            this.lbIdCard.AutoSize = true;
            this.lbIdCard.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lbIdCard.Location = new Point(0x2ff, 10);
            this.lbIdCard.Name = "lbIdCard";
            this.lbIdCard.Size = new Size(0x38, 0x10);
            this.lbIdCard.TabIndex = 10;
            this.lbIdCard.Text = "label1";
            this.lbNavigation.AutoSize = true;
            this.lbNavigation.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lbNavigation.Location = new Point(14, 0x28f);
            this.lbNavigation.Name = "lbNavigation";
            this.lbNavigation.Size = new Size(70, 14);
            this.lbNavigation.TabIndex = 1;
            this.lbNavigation.Text = "         ";
            this.panel1.BackColor = SystemColors.Window;
            this.panel1.Location = new Point(0x10, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x3d8, 640);
            this.panel1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x3f8, 0x300);
            base.Controls.Add(this.splitContainer1);
            base.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.EndInit();
            this.splitContainer1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void NotisfyChildStatus()
        {
            throw new NotImplementedException();
        }

        public bool SaveModelToDB()
        {
            throw new NotImplementedException();
        }

        public void UpdataToModel()
        {
            throw new NotImplementedException();
        }

        public bool EveryThingIsOk
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool HaveToSave
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public RecordsBaseInfoModel Model
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string SaveDataInfo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

