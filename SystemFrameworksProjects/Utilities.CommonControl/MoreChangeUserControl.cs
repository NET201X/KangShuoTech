namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [Designer(typeof(MoreChangeUserControl.MyControlDesigner)), DesignTimeVisible(true)]
    public class MoreChangeUserControl : UserControl
    {
        private CheckedListBox checkedListBox1;
        private string[] citems;
        private IContainer components;
        private bool controlFlag;
        private string gCaption;
        private GroupBox groupBox1;
        private bool groupBoxVisiable = true;
        private TextBox tbOther;

        public MoreChangeUserControl()
        {
            this.InitializeComponent();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox box = this.checkedListBox1;
            if (box != null)
            {
                TextBox tbOther = this.tbOther;
                if (!this.controlFlag)
                {
                    if (e.CurrentValue == CheckState.Indeterminate)
                    {
                        e.NewValue = CheckState.Indeterminate;
                    }
                    else if (e.Index == 0)
                    {
                        this.controlFlag = true;
                        if (e.NewValue == CheckState.Unchecked)
                        {
                            for (int i = 1; i < box.Items.Count; i++)
                            {
                                box.SetItemCheckState(i, CheckState.Unchecked);
                            }
                        }
                        else
                        {
                            for (int j = 1; j < box.Items.Count; j++)
                            {
                                box.SetItemCheckState(j, CheckState.Indeterminate);
                            }
                            tbOther.ReadOnly = true;
                            tbOther.Text = "";
                        }
                        this.controlFlag = false;
                    }
                    else if (e.Index == (box.Items.Count - 1))
                    {
                        this.controlFlag = true;
                        if (e.NewValue == CheckState.Checked)
                        {
                            tbOther.ReadOnly = false;
                        }
                        else
                        {
                            tbOther.ReadOnly = true;
                            tbOther.Text = "";
                        }
                        this.controlFlag = false;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GetResult()
        {
            string str = "";
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                if ((this.checkedListBox1.GetItemCheckState(i) != CheckState.Indeterminate) && this.checkedListBox1.GetItemChecked(i))
                {
                    str = str + this.checkedListBox1.Items[i].ToString() + ";";
                }
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.checkedListBox1 = new CheckedListBox();
            this.tbOther = new TextBox();
            this.groupBox1 = new GroupBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.checkedListBox1.BackColor = Color.WhiteSmoke;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Dock = DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new Point(3, 0x11);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new Size(0x174, 100);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.ItemCheck += new ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.tbOther.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.tbOther.Location = new Point(0x110, 0x5e);
            this.tbOther.Name = "tbOther";
            this.tbOther.ReadOnly = true;
            this.tbOther.Size = new Size(100, 0x15);
            this.tbOther.TabIndex = 0;
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.tbOther);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x17a, 0x79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.groupBox1);
            base.Name = "MoreChange";
            base.Size = new Size(0x17a, 0x79);
            base.Load += new EventHandler(this.MoreChange_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void MoreChange_Load(object sender, EventArgs e)
        {
            this.tbOther.Focus();
        }

        public void TransInfo(string info, string other)
        {
            if (!string.IsNullOrEmpty(info))
            {
                string[] strArray = info.Split(new char[] { ';' });
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (this.checkedListBox1.Items[i].ToString() == strArray[j])
                        {
                            this.checkedListBox1.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(other))
                {
                    this.tbOther.Text = other;
                }
            }
        }

        public string[] CItems
        {
            get
            {
                return this.citems;
            }
            set
            {
                this.citems = value;
                this.checkedListBox1.DataSource = this.citems;
            }
        }

        public string GCaption
        {
            get
            {
                return this.gCaption;
            }
            set
            {
                this.gCaption = value;
                this.groupBox1.Text = value;
            }
        }

        public bool GroupBoxVisiable
        {
            set
            {
                this.groupBoxVisiable = value;
                base.SuspendLayout();
                base.Controls.Add(this.checkedListBox1);
                base.Controls.Add(this.tbOther);
                this.groupBox1.Controls.Clear();
                this.groupBox1.Visible = false;
                base.ResumeLayout();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GroupBox MyGroupBox
        {
            get
            {
                return this.groupBox1;
            }
        }

        public string Other
        {
            get
            {
                return this.tbOther.Text;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public TextBox TbOther
        {
            get
            {
                return this.tbOther;
            }
        }

        internal class MyControlDesigner : ControlDesigner
        {
            private MoreChangeUserControl morechange;

            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                this.morechange = (MoreChangeUserControl) component;
                base.EnableDesignMode(this.morechange.TbOther, "tbOther");
            }
        }
    }
}

