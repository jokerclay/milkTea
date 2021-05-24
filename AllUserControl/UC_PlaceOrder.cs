using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace milkTea.AllUserControl
{
    public partial class UC_PlaceOrder : UserControl
    {
        function fn = new function();
        string query;

        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 从textBox 种提取每一条
            string category = comboCategory.Text;
            query = "select name from items where category = '" + category + "'";
            showItemList(query);

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
         
            // 从搜索出其中一条
            string category = comboCategory.Text;
            query = "select name from items where category = '" + category + "' and name like '"+ txtSearch.Text+"%'";
            showItemList(query);
        }

        private void showItemList(String query)
        {
            listBox1.Items.Clear(); // 清除之前的选项

            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

        }

        // 当点击选出的某个饮品
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 清空数据
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;
            // 选择价格
            query = "select price from items where name = '"+text+"'";
            DataSet ds = fn.getData(query);

            try
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }

        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            // 将数量中的数字转换为字符串
           Int64 quan = Int64.Parse(txtQuantityUpDown.Value.ToString());

            // 将价格中的数字给变量 price
            Int64 price = Int64.Parse(txtPrice.Text);

            // 合计
            txtTotal.Text = (quan * price).ToString();


        }

        // 添加到列表
        protected int n, total = 0;

        // 移除事件
        int amount;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 选择的某行
                amount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // 移除类表中的数据
                guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
            }
            catch { }
            // 当移除某条时，在总合计中减去
            total -= amount;
            labelTotalAmount.Text = "￥" + total;
        }

        // 打印订单
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "用户订单";
            printer.SubTitle = string.Format("日期： {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags=StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "合计共消费 ：" + labelTotalAmount.Text + "元";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);

            total = 0;
            guna2DataGridView1.Rows.Clear();
            labelTotalAmount.Text = "￥" + total;

        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = txtItemName.Text;
                guna2DataGridView1.Rows[n].Cells[1].Value = txtPrice.Text;
                guna2DataGridView1.Rows[n].Cells[2].Value = txtQuantityUpDown.Text;
                guna2DataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;

                // 计算总价
                total = total + int.Parse(txtTotal.Text);
                labelTotalAmount.Text = "￥" + total;
            }

            else {
                MessageBox.Show("数量不可为 0 ","消息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
