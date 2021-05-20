using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 食堂统计系统
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool is_succeed = false;
        private void button1_Click(object sender, EventArgs e)
        {

            if (username.Text == "admin" && password.Text == "admin")
            {
                DialogResult = DialogResult.Yes;
                is_succeed = true;
                Close();
            }
            else
            {
                MessageBox.Show("用户名或密码不正确，请检查后重试！", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!is_succeed) DialogResult = DialogResult.No;
        }
    }
}
