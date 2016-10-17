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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        #region  登陆操作     
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            //string LoginID = txtLogin.Text.Trim();
            //string Password = txtPassword.Text;
            string constr = "Data Source = CHEN0; Initial Catalog = Itcast; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                #region 登陆(无法验证用户名是否存在或是否密码错误) 
                //string sql = string.Format("select count(*) from [user] where uUserName = N'{0}' and uPwd = N'{1}'", LoginID, Password) ;
                //using (SqlCommand cmd = new SqlCommand(sql,con))
                //{
                //    try
                //    {
                //        con.Open();
                //        int result = Convert.ToInt32(cmd.ExecuteScalar());
                //        if (result > 0)
                //        {
                //            this.Text = "登陆成功！";
                //            this.BackColor = Color.Green;
                //        }
                //        else
                //        {
                //            this.Text = "登陆失败！";
                //            this.BackColor = Color.Red;
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        con.Close();
                //        con.Dispose();
                //        MessageBox.Show("操作错误" + ex.Message);
                //        throw;
                //    }
                //}      
                #endregion

                #region 登陆并验证用户名是否存在或是否密码错误 

                #region 无法防止sql注入漏洞攻击
                //string sql = string.Format("select uUserName, uPwd from [user] where uUserName = N'{0}'", LoginID);
                //using (SqlCommand cmd = new SqlCommand(sql, con))
                //{
                //    try
                //    {
                //        con.Open();
                //        using (SqlDataReader reader = cmd.ExecuteReader())
                //        {
                //            if (reader.HasRows)
                //            {
                //                if (reader.Read())
                //                {
                //                    if (Password == reader.GetString(1))
                //                    {
                //                        this.Text = "登陆成功！";
                //                        this.BackColor = Color.Green;
                //                        ButtonEditPwd.Enabled = true;
                //                        user.uName = reader.GetString(0);
                //                        user.uPassword = reader.GetString(1);
                //                    }
                //                    else
                //                    {
                //                        this.Text = "密码错误！";
                //                        this.BackColor = Color.Red;
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                this.Text = "用户不存在！";
                //                this.BackColor = Color.Red;
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        con.Close();
                //        con.Dispose();
                //        MessageBox.Show("操作错误" + ex.Message);
                //        throw;
                //    }
                //}
                #endregion

                #region 带参数的SQL语句防止注入攻击
                //string sql = "select count(*) from [user] where uUserName = @LoginID";
                string sql = "select count(*) from [user] where uUserName = @LoginID and uPwd = @Password";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    #region 添加参数的三个方法
                    /*（1）*/
                    //SqlParameter LID = new SqlParameter("@LoginID", SqlDbType.NVarChar, 20)
                    //{
                    //    Value = txtLogin.Text.Trim()
                    //};
                    //SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 10)
                    //{
                    //    Value = txtPassword.Text
                    //};
                    //cmd.Parameters.Add(LID);
                    //cmd.Parameters.Add(Pwd);
                    /*（2）*/
                    SqlParameter[] pms = new SqlParameter[]
                    {
                        new SqlParameter("@LoginID", SqlDbType.NVarChar, 20)
                        {
                            Value = txtLogin.Text.Trim()
                        },
                        new SqlParameter("@Password", SqlDbType.VarChar, 10)
                        {
                            Value = txtPassword.Text
                        },
                    };
                    cmd.Parameters.AddRange(pms);
                    /*（3）*/
                    //cmd.Parameters.AddWithValue("@LoginID", txtLogin.Text.Trim());
                    //cmd.Parameters.AddWithValue("@Password",txtPassword.Text);
                    #endregion


                    con.Open();
                    int r = (int)cmd.ExecuteScalar();
                    if (r>0)
                    {
                        this.Text = "登陆成功";
                        ButtonEditPwd.Enabled = true;
                    }
                    else
                    {
                        this.Text = "登陆失败";
                    }
                }
                #endregion

                #endregion
            }

        }
        #endregion

        #region 注册操作
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            string LoginID = txtLogin.Text.Trim();
            string Password = txtPassword.Text;
            string constr = "Data Source = CHEN0; Initial Catalog = Itcast; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sqlchk = string.Format("select count(uUserName) from [user] where uUserName = N'{0}'", LoginID);
                string sqlreg = string.Format("INSERT into [user] values(N'{0}',N'{1}')", LoginID, Password);
                using (SqlCommand cmdchk = new SqlCommand(sqlchk, con))
                {
                    try
                    {
                        con.Open();
                        int result = Convert.ToInt32(cmdchk.ExecuteScalar());
                        if (result > 0)
                        {
                            this.Text = "用户已存在！";
                        }
                        else
                        {
                            /**********************************************
                            //不能关闭整个连接然后再打开。只能通过关闭上一条sqlcommon，
                            //在创建下一条只能通过关闭上一条sqlcommon，
                            //或者直接创建
                            //cmdchk.Dispose();
                            //con.Close();
                            //con.Dispose();
                            ****************************************************/
                            using (SqlCommand cmdreg = new SqlCommand(sqlreg, con))
                            {
                                //con.Open();
                                int r = cmdreg.ExecuteNonQuery();
                                if (r > 0)
                                {
                                    this.Text = "注册成功！";
                                }
                                else
                                {
                                    this.Text = "注册失败！";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        con.Dispose();
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
        }
        #endregion

        #region 修改密码
        private void ButtonEditPwd_Click(object sender, EventArgs e)
        {
            EditPwd ep = new EditPwd();
            ep.Show();
        }

        #endregion


    }
}
