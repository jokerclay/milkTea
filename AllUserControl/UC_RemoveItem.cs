using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace milkTea.AllUserControl
{
    public partial class UC_RemoveItem : UserControl
    {
        function fn = new function();
        string query;
        public UC_RemoveItem()
        {
            InitializeComponent();
        }

        private void UC_RemoveItem_Load(object sender, EventArgs e)
        {
            Dellable.Text = "如何删除条目？";
            Dellable.ForeColor = Color.Blue;
            loadData();

        }
        public void loadData()
        {
            query = "select * from items";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from items where name like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("确定删除该饮品吗 ？", "再次确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from items where iid = '" + id + "'";
                fn.setData(query);
                loadData();
            }
        }

        private void Dellable_Click(object sender, EventArgs e)
        {
            Dellable.ForeColor = Color.Red;
            Dellable.Text = "点击饮品所在的行删除饮品";
        }

        private void UC_RemoveItem_Enter(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
