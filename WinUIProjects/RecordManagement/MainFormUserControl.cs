using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{

    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using KangShuoTech.DataAccessProjects.Model;
    using KangShuoTech.DataAccessProjects.BLL;
    using System.Drawing;
    using System.Data;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using KangShuoTech.Utilities.CommonControl;

    public class MainFormUserControl : UserControl
    {
        private PictureBox PersonRecordPictureBox;
        private PictureBox FamilyRecordPictureBox;
        private PictureBox HealthCheckPictureBox;
        private PictureBox pictureBox1;
        private PictureBox SignMaintPictureBox;
        private IContainer components;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HealthCheckPictureBox = new System.Windows.Forms.PictureBox();
            this.FamilyRecordPictureBox = new System.Windows.Forms.PictureBox();
            this.PersonRecordPictureBox = new System.Windows.Forms.PictureBox();
            this.SignMaintPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthCheckPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyRecordPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonRecordPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignMaintPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RecordManagement.Properties.Resources.档案查询小;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(723, 194);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 210);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // HealthCheckPictureBox
            // 
            this.HealthCheckPictureBox.BackgroundImage = global::RecordManagement.Properties.Resources.健康体检;
            this.HealthCheckPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HealthCheckPictureBox.Location = new System.Drawing.Point(501, 194);
            this.HealthCheckPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.HealthCheckPictureBox.Name = "HealthCheckPictureBox";
            this.HealthCheckPictureBox.Size = new System.Drawing.Size(210, 210);
            this.HealthCheckPictureBox.TabIndex = 39;
            this.HealthCheckPictureBox.TabStop = false;
            this.HealthCheckPictureBox.Click += new System.EventHandler(this.HealthCheckPictureBox_Click);
            // 
            // FamilyRecordPictureBox
            // 
            this.FamilyRecordPictureBox.BackgroundImage = global::RecordManagement.Properties.Resources.家庭档案;
            this.FamilyRecordPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FamilyRecordPictureBox.Location = new System.Drawing.Point(280, 194);
            this.FamilyRecordPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.FamilyRecordPictureBox.Name = "FamilyRecordPictureBox";
            this.FamilyRecordPictureBox.Size = new System.Drawing.Size(210, 210);
            this.FamilyRecordPictureBox.TabIndex = 38;
            this.FamilyRecordPictureBox.TabStop = false;
            this.FamilyRecordPictureBox.Click += new System.EventHandler(this.FamilyRecordPictureBox_Click);
            // 
            // PersonRecordPictureBox
            // 
            this.PersonRecordPictureBox.BackgroundImage = global::RecordManagement.Properties.Resources.个人档案;
            this.PersonRecordPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PersonRecordPictureBox.Location = new System.Drawing.Point(62, 194);
            this.PersonRecordPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonRecordPictureBox.Name = "PersonRecordPictureBox";
            this.PersonRecordPictureBox.Size = new System.Drawing.Size(210, 210);
            this.PersonRecordPictureBox.TabIndex = 37;
            this.PersonRecordPictureBox.TabStop = false;
            this.PersonRecordPictureBox.Click += new System.EventHandler(this.PersonRecordPictureBox_Click);
            // 
            // SignMaintPictureBox
            // 
            this.SignMaintPictureBox.BackgroundImage = global::RecordManagement.Properties.Resources.签字维护;
            this.SignMaintPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SignMaintPictureBox.Location = new System.Drawing.Point(945, 194);
            this.SignMaintPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.SignMaintPictureBox.Name = "SignMaintPictureBox";
            this.SignMaintPictureBox.Size = new System.Drawing.Size(210, 210);
            this.SignMaintPictureBox.TabIndex = 41;
            this.SignMaintPictureBox.TabStop = false;
            this.SignMaintPictureBox.Click += new System.EventHandler(this.SignMaintPictureBox_Click);
            // 
            // MainFormUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SignMaintPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HealthCheckPictureBox);
            this.Controls.Add(this.FamilyRecordPictureBox);
            this.Controls.Add(this.PersonRecordPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFormUserControl";
            this.Size = new System.Drawing.Size(1369, 709);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthCheckPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FamilyRecordPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonRecordPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignMaintPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        public string IDCardNo { get; set; }

        private void PersonRecordPictureBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            using (PBControler controler = new PBControler(new PersonForm(this.IDCardNo), new PersonInfoFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }
            GC.Collect();
        }

        private void HealthCheckPictureBox_Click(object sender, EventArgs e) //健康体检
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            //DateTime checkdt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(-3);
            DataSet customerds = new RecordsCustomerBaseInfoBLL().GetList(string.Format(" IDCardNo='{0}' and CheckDate between '{1}' and '{2}' order by CheckDate DESC ", this.IDCardNo, DateTime.Today.ToString("yyyy-01-01"), DateTime.Today.Date.ToString("yyyy-12-31")));
            // DataSet customerds = new RecordsCustomerBaseInfoBLL().GetList(string.Format(" IDCardNo='{0}' order by CheckDate desc  ", this.IDCardNo));
            
            if (customerds.Tables[0].Rows.Count > 0)
            {
                DataRow row = customerds.Tables[0].Rows[0];
                string strchekdate = DateTime.Parse(row["CheckDate"].ToString()).ToString("yyyy-MM-dd");
                if (MessageBox.Show("此人于'" + strchekdate + "'已体检，是否继续体检", "继续体检", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
            }

            PhysicalInfoFactory.ID = 0;
            PhysicalInfoFactory.NewAdd = true;
            using (PEControler controler = new PEControler(new PhysicalForm(this.IDCardNo), new PhysicalInfoFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }
            GC.Collect();
        }

        private void FamilyRecordPictureBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IDCardNo))
            {
                new MessageForm("请先刷身份证或输入身份证登录系统！") { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
                return;
            }
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new FamilyFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }
            GC.Collect();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new QueryInfoFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }

            GC.Collect();
        }

        private void SignMaintPictureBox_Click(object sender, EventArgs e)
        {
          
            using (Controler controler = new Controler(new MDIParentForm(this.IDCardNo), new SignMaintFactory()))
            {
                controler.IParentFrm.IShowDialog();
            }

            GC.Collect();
         
        }


    }

    public class PersonForm : MDIParentForm
    {
        public RecordsBaseInfoModel RecordBaseInfo { get; set; }
        private LinkLabel lklbRequired;
        public List<RecordsRequiredModel> Archive_requireds { get; set; }

        public PersonForm(string idcard)
            : base(idcard)
        {
            RecordBaseInfo = new RecordsBaseInfoBLL().GetModel(this.Model.IDCardNo);

            if (RecordBaseInfo == null)
            {
                RecordBaseInfo = new RecordsBaseInfoModel { IDCardNo = this.Model.IDCardNo };
            }

            lklbRequired = new LinkLabel();

            this.lklbRequired.BackColor = Color.Transparent;
            this.lklbRequired.ForeColor = Color.Red;
            this.lklbRequired.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lklbRequired.FlatStyle = FlatStyle.Flat;
            this.lklbRequired.ImageAlign = ContentAlignment.MiddleRight;
            this.lklbRequired.Location = new Point(0xd6, 3);
            this.lklbRequired.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lklbRequired.Name = "lklbRequired";
            this.lklbRequired.AutoSize = true;
            this.lklbRequired.TabIndex = 80;
            this.lklbRequired.Text = "必填项设置";
            this.lklbRequired.Click += new EventHandler(this.btnBtx_Click);
            base.flowLayoutPanel1.Controls.Add(this.lklbRequired);
        }

        private void btnBtx_Click(object sender, EventArgs e)
        {
            PersonFileRequiredForm personfilerequire = new PersonFileRequiredForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            if (personfilerequire.ShowDialog() == DialogResult.OK)
            {
                DataSet set = new DataSet();
                set.ReadXml(Application.StartupPath + @"\requiredPersonFile.xml");
                this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataSet set = new DataSet();
            set.ReadXml(Application.StartupPath + @"\requiredPersonFile.xml");
            this.Archive_requireds = new RecordsRequiredBLL().DataTableToList(set.Tables[0]);
        }
    }

    public class PBControler : Controler
    {
        public PBControler(PersonForm iparent, ChildFormFactory factory)
            : base(iparent, factory)
        {

        }
        /*
        public override bool DoSave()
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            PhysicalForm iParentFrm = base.IParentFrm as PhysicalForm;
            bool flag = true;
            base.SaveDataInfo = "保存失败！\r\n";

            IEnumerable<IGrouping<string, RecordsRequiredModel>> enumerable = from a in iParentFrm.Archive_requireds group a by a.BTable;

            foreach (KeyValuePair<string, IChildForm> pair in base.IChildrens)
            {
                if (pair.Value.EveryThingIsOk)
                {
                    pair.Value.SaveDataInfo = "";
                    pair.Value.UpdataToModel();
                    foreach (PropertyInfo info in pair.Value.GetType().GetProperties(bindingAttr))
                    {
                        if (info.PropertyType.Name.Contains("Records"))
                        {
                            using (IEnumerator<IGrouping<string, RecordsRequiredModel>> enumerator = enumerable.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    Predicate<RecordsRequiredModel> match = null;
                                    IGrouping<string, RecordsRequiredModel> tmp_model = enumerator.Current;
                                    if ((info.PropertyType.Name == tmp_model.Key) && ((pair.Key != "一般情况") || (tmp_model.Key != "RecordsPhysicalExamModel")))
                                    {
                                        object obj2 = info.GetValue(pair.Value, null);
                                        if (match == null)
                                        {
                                            match = req => req.BTable == tmp_model.Key;
                                        }
                                        foreach (RecordsRequiredModel archive_required in iParentFrm.Archive_requireds.FindAll(match))
                                        {
                                            decimal? nullable = archive_required.IsRequired;
                                            if (((nullable.GetValueOrDefault() != 0M) ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
                                            {
                                                PropertyInfo property = obj2.GetType().GetProperty(archive_required.Name, bindingAttr);
                                                if (property != null)
                                                {
                                                    object obj3 = property.GetValue(obj2, null);
                                                    if (obj3 == null)
                                                    {
                                                        PBControler controler = this;
                                                        string str = controler.SaveDataInfo + archive_required.Comment + " :必填\r\n";
                                                        controler.SaveDataInfo = str;
                                                        flag = false;
                                                    }
                                                    else if (string.IsNullOrEmpty(obj3.ToString()))
                                                    {
                                                        PBControler controler2 = this;
                                                        string str2 = controler2.SaveDataInfo + archive_required.Comment + " :必填\r\n";
                                                        controler2.SaveDataInfo = str2;
                                                        flag = false;
                                                    }
                                                }
                                                else
                                                {
                                                    PBControler controler3 = this;
                                                    string str3 = controler3.SaveDataInfo + archive_required.Comment + " :必填\r\n";
                                                    controler3.SaveDataInfo = str3;
                                                    flag = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!flag)
                    {
                        return false;
                    }
                    if (pair.Value.CheckErrorInput() == ChildFormStatus.HasErrorInput)
                    {
                        flag = false;
                        base.IParentFrm.ChildStatus(pair.Key, ChildFormStatus.HasErrorInput);
                        PBControler controler4 = this;
                        string str4 = controler4.SaveDataInfo + pair.Value.SaveDataInfo;
                        controler4.SaveDataInfo = str4;
                    }
                }
            }
            if (!flag)
            {
                return false;
            }
            foreach (KeyValuePair<string, IChildForm> pair2 in base.IChildrens)
            {
                if (pair2.Value.EveryThingIsOk)
                {
                    flag = pair2.Value.SaveModelToDB();
                }
            }
            if (!flag)
            {
                return false;
            }
            IParentModel<RecordsBaseInfoModel> model = base.IParentFrm as IParentModel<RecordsBaseInfoModel>;
            if (model != null)
            {
                model.SaveModel();
            }
            return flag;
        }
         * */
    }
}