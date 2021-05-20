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
    public partial class ShowTableForm : Form
    {
        public ShowTableForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }
        DataTable dt;

        private void ShowTableForm_Load(object sender, EventArgs e)
        {
            dgv.DataSource = dt;
        }
    }
}
