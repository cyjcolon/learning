using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLHelper
{
    public static class SQLHelper
    {
        //定义一个连接字符串
        //readonly修饰变量，只能初始化以及构造函数中赋值，其他地方只能读取不能赋值
        private static readonly string constr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;


        //1.执行增（insert）删（delete）改（update）的方法，ExecuteNonQuery()
        public static int ExecuteNonQuery(string sql,CommandType cmdtype, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    cmd.CommandType = cmdtype;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //2.执行查询返回单个结果的方法，ExcuteScalar()
        public static object ExecuteScaler(string sql, CommandType cmdtype, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdtype;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();

                    return cmd.ExecuteScalar();
                }
            }
        }

        //3.执行查询返回多行多列结果的方法，ExcuteReader()
        public static SqlDataReader ExecuteReader(string sql, CommandType cmdtype, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(constr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdtype;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    //CloseConnection这个枚举参数表示使用完毕SqlDataReader后，
                    //关闭reader的同时，会将相关联的connection对象关闭
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch(Exception ex) 
                {
                    con.Close();
                    con.Dispose();
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            
        }

        //4.查询数据返回DataTable
        public static DataTable ExecuteDataTable(string sql, CommandType cmdtype, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql,constr))
            {
                adapter.SelectCommand.CommandType = cmdtype;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

    }
} 
