using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.DataAccessProjects.BLL;

namespace PadPlatform
{
    public partial class ModifyPassWord : Form
    {
        private SysUserModel sysmodel;
        private string ID;
        public ModifyPassWord(string DocId)
        {
            InitializeComponent();
            ID = DocId;
        }

        private void ModifyPassWord_Load(object sender, EventArgs e)
        {
            sysmodel = new SysUserBLL().GetModel(ID);
            if (sysmodel == null)
            {
                MessageBox.Show("医生不存在，请重新登陆！");
            }
            else
            {
                lblname.Text = sysmodel.UserName;
            }
        }

    
        private void txtoldPass_Leave(object sender, EventArgs e)
        {
            if (txtoldPass.Text.ToString()!=""&&txtoldPass.Text.ToString() != sysmodel.PassWord)
            {
                MessageBox.Show("原密码输入错误，请重新输入！");
                txtoldPass.Focus();
                return;
            }
        }

        private void txtSurePass_Leave(object sender, EventArgs e)
        {
            if (txtSurePass.Text.ToString() != txtNewPass.Text.ToString())
            {
                MessageBox.Show("两次输入的密码一致，请重新输入！");
                txtSurePass.Focus();
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtoldPass.Text.ToString() == "")
            {
                MessageBox.Show("请输入原密码！");
                txtoldPass.Focus();
                return;
            }
            if (txtNewPass.Text.ToString() == "")
            {
                MessageBox.Show("新密码不允许为空！");
                txtNewPass.Focus();
                return;
            }
            if (txtSurePass.Text.ToString() == "")
            {
                MessageBox.Show("密码确认不允许为空！");
                txtSurePass.Focus();
                return;
            }

            this.sysmodel.PassWord = txtNewPass.Text.ToString();
            bool result = new SysUserBLL().Update(this.sysmodel);
            if (result)
            {
                MessageBox.Show("修改成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
