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
            txyItemName.Text = text;
        }


        
    }
}
