using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace milkTea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashBoard ds = new DashBoard("Order");
            ds.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "管理员" && txtPassword.Text == "password")
            {
                DashBoard ds = new DashBoard("Admin");
                ds.Show();
                this.Hide();
            }
            else if(txtUsername.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("请输入用户名和密码！");
            }
            else 
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }
    }
}
