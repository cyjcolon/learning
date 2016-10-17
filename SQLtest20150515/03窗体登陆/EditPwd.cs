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

namespace _03窗体登陆
{
    public partial class EditPwd : Form
    {
        public EditPwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string OldPwd = txtOriPwd.Text;
            string NewPwd = txtNewPwd.Text;
            string EntPwd = txtEntPwd.Text;
            string uName = user.uName;
            string uPwd = user.uPassword;
            if (checkOldPwd(OldPwd, uPwd))
            {
                if (NewPwd == EntPwd)
                {
                    if (UpdatePwd(uName, NewPwd))
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                    
                }
                else
                {
                    MessageBox.Show("两次密码输入不匹配！");
                }
            }
            else
            {
                MessageBox.Show("原密码错误！");
            }

            #region 没封装的修改
            //    string constr = "Data Source =CHEN0; Initial Catalog = Itcast; Integrated Security = True";
            //    string sql = string.Format("update [user] set uPwd = N'{0}' where uUserName = N'{1}'", NewPwd, uName);
            //    if (OldPwd == user.uPassword)
            //    {
            //        if (NewPwd == EntPwd)
            //        {
            //            using (SqlConnection con = new SqlConnection(constr))
            //            {

            //                using (SqlCommand cmd = new SqlCommand(sql, con))
            //                {
            //                    con.Open();
            //                    int r = cmd.ExecuteNonQuery();
            //                    if (r>0)
            //                    {
            //                        MessageBox.Show("修改成功！");
            //                        this.Close();
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("修改错误！");
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            this.Text = "两次密码输入不匹配！";
            //        }
            //    }
            //    else
            //    {
            //        this.Text = "原密码错误！";
            //    }
            #endregion

        }

        private bool UpdatePwd(string uName, string newPwd)
        {
            string constr = "Data Source =CHEN0; Initial Catalog = Itcast; Integrated Security = True";
            string sql = string.Format("update [user] set uPwd = N'{0}' where uUserName = N'{1}'", newPwd, uName);
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private bool checkOldPwd(string oldPwd, string OriPwd)
        {
            if (oldPwd == OriPwd)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
