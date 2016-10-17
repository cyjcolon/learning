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

namespace _02增删改查窗体设计
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 按键点击插入数据
        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("insert into Class values (N'{0}',N'{1}')", txtClassName.Text.Trim(), txtClassDes.Text.Trim());
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        this.Text = "插入成功！";
                    }
                    else
                    {
                        this.Text = "插入失败！";
                    }
                    //重新加载绑定
                    LoadData();
                }
            }
        }


        #endregion

        #region 按键点击修改
        private void button3_Click(object sender, EventArgs e)
        {
            string classname = txtEditClassName.Text.Trim();
            string classdes = txtEditClassDes.Text.Trim();
            int classid = Convert.ToInt32(txtEditClassID.Text.Trim());
            string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("update Class set ClassName = N'{0}',cDescription = N'{1}' where ClassID = {2}", classname, classdes, classid);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        this.Text = "修改成功！";
                    }
                    else
                    {
                        this.Text = "修改失败！";
                    }
                    //重新加载绑定
                    LoadData();
                }
            }
        }

        #endregion

        #region 按键点击删除
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                int classid = Convert.ToInt32(txtEditClassID.Text.Trim());
                string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql = string.Format("delete from Class where ClassID = {0}", classid);
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            this.Text = "删除成功！";
                        }
                        else
                        {
                            this.Text = "删除失败！";
                        }
                        //重新加载绑定
                        LoadData();
                    }
                }

            }
        }
        #endregion

        #region 显示列表
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            List<Class> list = new List<Class>();
            string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from Class";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader dataread = cmd.ExecuteReader())
                    {
                        //判断是否读到数据
                        if (dataread.HasRows)
                        {
                            //一条条读数据
                            while (dataread.Read())
                            {
                                Class classmodle = new Class();
                                classmodle.ClassID = dataread.GetInt32(0);
                                classmodle.ClassName = dataread.GetString(1);
                                classmodle.cDescription = dataread.IsDBNull(2) ? null : dataread.GetString(2);

                                list.Add(classmodle);//把classmodle对象加到list集合中
                            }
                        }
                    }

                }
            }
            //数据绑定只认“属性”，不认“字段”。内部通过反射来实现。
            this.dgvClass.DataSource = list;//数据绑定
        }
        #endregion

        #region 行获取焦点事件
        private void dgvClass_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前选中的行对象
            DataGridViewRow currentRow = this.dgvClass.Rows[e.RowIndex];
            //获取当前行中绑定的Class数据对象
            Class model = currentRow.DataBoundItem as Class;
            if (model != null)
            {
                txtEditClassID.Text = model.ClassID.ToString();
                txtEditClassName.Text = model.ClassName;
                txtEditClassDes.Text = model.cDescription;
            }

        }
        #endregion
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
