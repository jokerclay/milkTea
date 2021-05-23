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
    public partial class UC_AddItems : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddItems()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // 插入数据库语句
            query = "insert into items (name,category,price) values('" + txtItemName.Text + "','" + txtCategory.Text + "','" + txtPrice.Text + "')";    
            fn.setData(query);
            clearAll();
        }

        // 清除文本框中的内容方法
        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();

        }

        // 当离开 AddItems 时，清空用户输入
        private void UC_AddItems_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
