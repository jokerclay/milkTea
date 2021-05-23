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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        public DashBoard(String user)
        {
            InitializeComponent();
            if (user == "Order")
            {
                // 当参数为 Order 时，隐藏其他三项
                btnAdd.Hide();
                btnUpdate.Hide();
                btnRemove.Hide();

            }
            else if (user == "Admin")
            {
                btnAdd.Show();
                btnUpdate.Show();
                btnRemove.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = true;
            uC_AddItems1.BringToFront();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = false;
        }
    }
}
