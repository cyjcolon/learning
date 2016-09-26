using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04封装SQLHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from [user] where uUserName = @LoginID and uPwd = @Pwd";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@LoginID",SqlDbType.NVarChar,20) { Value = txtLoginID.Text.Trim()},
                new SqlParameter("@Pwd",SqlDbType.VarChar,10) { Value = txtPwd.Text }
            };
            int r = (int) SQLHelper.ExecuteScaler(sql, pms);
            if (r>0)
            {
                this.Text = "登陆成功";
            }
            else
            {
                this.Text = "登陆失败";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select * from [user]";
            List<user> list = new List<user>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user user1 = new user();
                        user1.uId = reader.GetInt32(0);
                        user1.uUserName = reader.GetString(1);
                        user1.uPwd = reader.GetString(2);
                        list.Add(user1);
                    }
                }
            } 
            this.dataGridView1.DataSource = list;
        }
    }
}
