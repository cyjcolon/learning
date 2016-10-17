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

namespace _07通过Ado.Net调用存储过程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int pageSize = 7;//每页显示条数
        private int pageIndex = 1;//当前查看页数
        private int pageCount;//总页数
        private int recordCount;//总条数

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //根据pageIndex来加载数据
            string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security =True";
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("usp_DataByPage",constr))
            {
                //告诉SqlDataAdapter对象，执行的是存储过程非SQL语句
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                //        //增加参数
                //        /************
                //        @pagesize int=7,--每页记录条数
                //        @pageindex int=1,--当前位于第几页
                //        @recordcount int OUTPUT,--总的记录条数
                //        @pagecount int OUTPUT--总页数
                //        **************/
                SqlParameter[] par = new SqlParameter[] {
                            new SqlParameter("@pagesize",SqlDbType.Int) { Value = pageSize },
                            new SqlParameter("@pageindex",SqlDbType.Int) { Value = pageIndex },
                            new SqlParameter("@recordcount",SqlDbType.Int) { Direction = ParameterDirection.Output},
                            new SqlParameter("@pagecount",SqlDbType.Int) { Direction = ParameterDirection.Output}
                        };
                adapter.SelectCommand.Parameters.AddRange(par);
                adapter.Fill(dt);

                //数据绑定
                this.dataGridView1.DataSource = dt;
                label_currentPage.Text = "当前页：" + par[1].Value.ToString();
                label_recordCount.Text = "总条数：" + par[2].Value.ToString();
                label_pageCount.Text = "总页数：" + par[3].Value.ToString();
                recordCount = (int)par[2].Value;
                pageCount = (int)par[3].Value;
            }
            #region 1
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    //将SQL语句变成存储过程
            //    string str = "exec usp_DataByPage ";
            //    using (SqlCommand cmd = new SqlCommand(str,con))
            //    {
            //        //告诉SqlCommand对象，执行的是存储过程非SQL语句
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        //增加参数
            //        /************
            //        @pagesize int=7,--每页记录条数
            //        @pageindex int=1,--当前位于第几页
            //        @recordcount int OUTPUT,--总的记录条数
            //        @pagecount int OUTPUT--总页数
            //        **************/
            //        SqlParameter[] par = new SqlParameter[] {
            //            new SqlParameter("@pagesize",SqlDbType.Int) { Value = 7},
            //            new SqlParameter("@pageindex",SqlDbType.Int) { Value = 1},
            //            new SqlParameter("@recordcount",SqlDbType.Int) { Direction = ParameterDirection.Output},
            //            new SqlParameter("@pagecount",SqlDbType.Int) { Direction = ParameterDirection.Output}
            //        };
            //        cmd.Parameters.AddRange(par);
            //        //打开链接
            //        con.Open();
            //        //执行
                //}
            //}
            #endregion
        }

        private void Pageup_Click(object sender, EventArgs e)
        {

            pageIndex--;
            if (pageIndex < 1)
            {
                pageIndex = pageCount;
            }
            LoadData();
        }

        private void Pagedown_Click(object sender, EventArgs e)
        {
            pageIndex++;
            if (pageIndex > pageCount)
            {
                pageIndex = 1;
            }
            LoadData();
        }
    }
}
