using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace milkTea
{
    class function
    {
        // 连接数据库
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =LAPTOP-TUR9S4O9; database = milkTea; integrated security = True";
            return con;
        }

        ////
        //      从数据库中获取数据
        ////
        public DataSet getData(String query)
        {
            // 将数据库连接
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            // query 为 SQL语句
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            // 显示完成信息
            MessageBox.Show("数据成功写入！","完成",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
