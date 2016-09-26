using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01连接数据库增删改查
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 链接数据库
            //链接字符串
            //string constr = "Data source = CHEN0; Initial Catalog = School; Integrated Security = True";
            //创建链接对象
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    //打开链接
            //    con.Open();
            //    Console.WriteLine("打开资源！");
            //    //关闭链接
            //    //con.Close();
            //    //con.Dispose();
            //}
            //Console.WriteLine("关闭资源，释放资源！");
            //Console.ReadKey();
            #endregion

            #region 插入一条数据
            ////链接字符串
            //string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
            ////创建链接对象
            //using (SqlConnection con = new SqlConnection(constr))
            //{

            //    //编写SQL语句
            //    string sql = "INSERT INTO Student (StdClassID,StdName,StdAge,StdGender,StdIDCard,StdBirthday,StdPhone)	VALUES(2, '大乔', 208, '女', 12344378451234563, '1987-8-3', '13926522433')";
            //    //创建一个执行SQL语句的对象（命令对象） SqlCommand
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        //打开链接
            //        con.Open();
            //        Console.WriteLine("链接打开成功！");
            //        //开始执行SQL语句
            //        int r = cmd.ExecuteNonQuery();//insert/delete/update，返回值是一个int类型，表示所影响的行数,其他SQL语句返回-1。
            //        //cmd.ExecuteScalar();//返回单个结果使用
            //        //cmd.ExecuteReader();//返回多行多列结果使用
            //        Console.WriteLine("成功插入{0}行数据。", r);
            //    }
            //}
            //Console.ReadKey();
            #endregion

            #region 删除一条数据
            ////链接字符串
            //string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
            ////创建链接对象
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string sql = "delete from Student where StdID = 25";
            //    using (SqlCommand cmd = new SqlCommand(sql,con))
            //    {
            //        con.Open();
            //        int r = cmd.ExecuteNonQuery();
            //        Console.WriteLine("成功删除{0}行数据。", r);
            //    }
            //}
            //Console.ReadKey();
            #endregion

            #region 查询表中的记录条数
            ////链接字符串
            //string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
            ////创建链接对象
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string sql = "select count(*) from Student";
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        con.Open();
            //        /********************************************
            //        PS：当执行SQL语句时，如果是聚合函数，则ExecuteScalar不会返回Null值，
            //        由于聚合函数不会返回NULL值；如果不是使用聚合函数，
            //        则ExecuteScalar可能返回NULL值，此时需要判断返回值是否NULL。
            //        ********************************************/
            //        object r1 = cmd.ExecuteScalar();
            //        Console.WriteLine("表中共有记录" + r1.ToString() + "条。");

            //        //object r2 = (int)cmd.ExecuteScalar();
            //        object r2 = Convert.ToInt32(cmd.ExecuteScalar());
            //        Console.WriteLine("表中共有记录{0}条。", r2);
            //    }
            //}
            //Console.ReadKey();
            #endregion

            #region ExecuteReader读取多行数据
            string constr = "Data Source = CHEN0; Initial Catalog = School; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from Class";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //for (int i = 0; i < reader.FieldCount; i++)
                                //{
                                //    //Console.Write(reader[i] + "   |   ");
                                //    //Console.Write(reader.GetValues(i) + "   |   " );

                                //}
                                Console.Write(reader.GetInt32(0) + "   |   ");
                                Console.Write(reader.IsDBNull(1) ? null : reader.GetString(1) + "   |   ");
                                Console.Write(reader.IsDBNull(2) ? null : reader.GetString(2) + "   |   ");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("没有查到数据！");
                        }
                    } 
                }
            }
            Console.ReadKey();
            #endregion
        }
    }
}
