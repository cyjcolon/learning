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

namespace _06SqlDataAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string constr = "Data Source = CHEN0; Initial Catalog = ITcast; Integrated Security = True";
            //string sql = "select * from [user]";
            //DataTable dt = new DataTable();
            //using (SqlDataAdapter DataAdapter = new SqlDataAdapter(sql, constr))
            //{
            //    DataAdapter.Fill(dt);
            //}
            //this.dataGridView1.DataSource = dt;

            string sql = "select * from [user]";

            this.dataGridView1.DataSource = SQLHelper.SQLHelper.ExecuteDataTable(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //创建DataSet，内存数据库
            DataSet ds = new DataSet("School");
            //创建一个表
            DataTable dt = new DataTable("Student");
            //创建列的3中方法
            //（1）
            DataColumn dcAutoID = new DataColumn("AutoID", typeof(int));
            dcAutoID.AutoIncrement = true;
            dcAutoID.AutoIncrementSeed = 1;
            dcAutoID.AutoIncrementStep = 1;
            dt.Columns.Add(dcAutoID);
            //（2）
            DataColumn dcUserName = dt.Columns.Add("UserName", typeof(string));
            dcUserName.AllowDBNull = false;
            //（3）
            dt.Columns.Add("UserAge", typeof(int));
            //增加行数据
            DataRow dr1 = dt.NewRow();
            dr1["UserName"] = "苍井空";
            dr1["UserAge"] = 33;
            dt.Rows.Add(dr1);
            //增加行数据
            DataRow dr2 = dt.NewRow();
            dr2["UserName"] = "大桥未久";
            dr2["UserAge"] = 29;
            dt.Rows.Add(dr2);
            //把dt加到ds中
            ds.Tables.Add(dt);

            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
