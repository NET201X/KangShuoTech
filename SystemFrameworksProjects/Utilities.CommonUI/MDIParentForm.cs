using KangShuoTech.DataAccessProjects.BLL;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.Common;

namespace KangShuoTech.Utilities.CommonUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class MDIParentForm : Form, IParentForm, IParentModel<RecordsBaseInfoModel>
    {
        private Button btnCanel;
        private Button btnSave;
        private IContainer components;
        private Dictionary<string, Button> dicButton;
        protected FlowLayoutPanel flowLayoutPanel1;
        private string IDCard;
        private Label lbIdCard;
        private Label lbNavigation;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel topButtons;

        public MDIParentForm(string idcard)
        {
            this.InitializeComponent();
            this.dicButton = new Dictionary<string, Button>();
            this.IDCard = idcard;
            this.lbIdCard.Text = this.IDCard;
            this.Model = new KangShuoTech.DataAccessProjects.BLL.RecordsBaseInfoBLL().GetModel(this.IDCard);
            this.RecordsCard = new KangShuoTech.DataAccessProjects.BLL.RecordsCardBLL().GetModel(this.IDCard);
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            base.Close();
            if (this.FrmClose != null)
            {
                this.FrmClose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IMDIControler.DoSave())
            {
                MessageBox.Show("保存成功", "保存数据", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.btnSave.Enabled = false;
                base.DialogResult = DialogResult.OK;
                if (this.FrmClose != null)
                {
                    this.FrmClose();
                }
            }
            else
            {
                MessageBox.Show(this.IMDIControler.SaveDataInfo, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (this.IMDIControler != null)
            {
                Button button = sender as Button;

                if (!this.dicButton.ContainsKey(button.Text))
                {
                    this.dicButton.Add(button.Text, button);
                }

                this.IMDIControler.Call_Child(sender, e);
            }
        }

        public void ChildStatus(string child, ChildFormStatus status)
        {
            Button button;
            if (this.dicButton.TryGetValue(child, out button))
            {
                if (status == ChildFormStatus.HasErrorInput)
                {
                    button.ImageIndex = 2;
                }
                else if (status == ChildFormStatus.NoErrorInput)
                {
                    button.ImageIndex = 0;
                }
                else if (status == ChildFormStatus.Activity)
                {
                    try
                    {
                        IEnumerable<KeyValuePair<string, Button>> source = from c in this.dicButton
                            where c.Value.ImageIndex == 1
                            select c;
                        if (source.Count<KeyValuePair<string, Button>>() > 0)
                        {
                            source.First<KeyValuePair<string, Button>>().Value.ImageIndex = 0;
                            this.panel1.Controls[0].Hide();
                        }
                    }
                    catch (Exception exception)
                    {
                        LogHelper.LogError(exception);
                    }
                    button.ImageIndex = 1;
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

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.topButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCanel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbNavigation = new System.Windows.Forms.Label();
            this.lbIdCard = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BackgroundImage = global::KangShuoTech.Utilities.CommonUI.Properties.Resources.childmain;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.BackgroundImage = global::KangShuoTech.Utilities.CommonUI.Properties.Resources.childmain;
            this.splitContainer1.Panel1.Controls.Add(this.topButtons);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnCanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.lbIdCard);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1600, 900);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 13;
            // 
            // topButtons
            // 
            this.topButtons.BackColor = System.Drawing.Color.Transparent;
            this.topButtons.Location = new System.Drawing.Point(12, 4);
            this.topButtons.Name = "topButtons";
            this.topButtons.Size = new System.Drawing.Size(1143, 130);
            this.topButtons.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::KangShuoTech.Utilities.CommonUI.Properties.Resources.btnbaocun001;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(1275, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 101);
            this.btnSave.TabIndex = 12;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCanel
            // 
            this.btnCanel.BackgroundImage = global::KangShuoTech.Utilities.CommonUI.Properties.Resources.btnguanbi001;
            this.btnCanel.FlatAppearance.BorderSize = 0;
            this.btnCanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanel.Location = new System.Drawing.Point(1371, 6);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(76, 101);
            this.btnCanel.TabIndex = 11;
            this.btnCanel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.lbNavigation);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 724);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(308, 28);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // lbNavigation
            // 
            this.lbNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNavigation.AutoSize = true;
            this.lbNavigation.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNavigation.ForeColor = System.Drawing.SystemColors.Window;
            this.lbNavigation.Location = new System.Drawing.Point(3, 0);
            this.lbNavigation.Name = "lbNavigation";
            this.lbNavigation.Size = new System.Drawing.Size(0, 21);
            this.lbNavigation.TabIndex = 1;
            // 
            // lbIdCard
            // 
            this.lbIdCard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIdCard.Location = new System.Drawing.Point(365, 723);
            this.lbIdCard.Name = "lbIdCard";
            this.lbIdCard.Size = new System.Drawing.Size(544, 29);
            this.lbIdCard.TabIndex = 11;
            this.lbIdCard.Text = "label1";
            this.lbIdCard.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbIdCard.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(12, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1580, 690);
            this.panel1.TabIndex = 0;
            // 
            // MDIParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MDIParentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MDIParentForm_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void IShowDialog()
        {
            base.StartPosition = FormStartPosition.CenterScreen;
            base.ShowDialog();
        }

        private void MDIParentForm_KeyUp(object sender, KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            if (keyCode != Keys.F17)
            {
                if (keyCode != Keys.F23)
                {
                    return;
                }
            }
            else
            {
                this.btnSave.PerformClick();
                return;
            }
            this.btnCanel.PerformClick();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            if (this.IMDIControler != null)
            {
                Button button = this.dicButton.Values.First<Button>();
                if (button != null)
                {
                    this.IMDIControler.Call_Child(button, e);
                }
            }
        }

        public virtual bool SaveModel()
        {
            return true;
        }

        public void SetChildrenButton(List<ItemParamters> strs)
        {
            for (int i = 0; i < strs.Count; i++)
            {
                Button button = new Button {
                    Size = new Size(110, 127),
                    Name = strs[i].Text,
                    Text = "",
                    ImageList = strs[i].Images,
                    ImageIndex = 0,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleCenter,
                    UseVisualStyleBackColor = false
                };

                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                button.FlatAppearance.MouseOverBackColor = Color.Transparent;
                button.Click += new EventHandler(this.button_Click);
                this.topButtons.Controls.Add(button);
                this.dicButton.Add(strs[i].Text, button);
            }
        }

        public void SetFrmText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                this.Text = text;
            }
        }

        public void SetStateInfo(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (this.lbIdCard.InvokeRequired)
                {
                    this.lbIdCard.Invoke(new Action<string>(this.SetStateInfo), new object[] { str });
                }
                else
                {
                    this.lbIdCard.Visible = true;
                    this.lbIdCard.Text = str;
                }
            }
        }

        public void ShowChild(IChildForm child)
        {
            if (child != null)
            {
                Form form = child as Form;
                form.BackColor = Color.White;
                form.TopLevel = false;
                form.Location = new Point(0, 0);
                this.lbNavigation.Text = this.Text + ">" + form.Text;

                if (!this.panel1.Controls.Contains((Control) child))
                {
                    this.panel1.Controls.Add(form);
                }

                this.panel1.Controls.SetChildIndex(form, 0);
                if (!child.HaveToSave)
                {
                    this.btnSave.Visible = false;
                }
                else
                {
                    this.btnSave.Visible = true;
                }

                form.Show();
            }
        }

        public RecordsCardModel RecordsCard { get; set; }

        public Action FrmClose { get; set; }

        public IMDIControler IMDIControler { get; set; }

        public RecordsBaseInfoModel Model { get; set; }

        public RecordsBaseInfoBLL ModelOper { get; set; }
    }
}

