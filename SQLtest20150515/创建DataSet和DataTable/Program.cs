using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06创建DataSet和DataTable
{
    class Program
    {
        static void Main(string[] args)
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

            //Console.WriteLine("OK");
            //Console.ReadKey();

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                Console.WriteLine("表名：{0}",ds.Tables[i].TableName);
                for (int r = 0; r < ds.Tables[i].Rows.Count; r++)
                {
                    DataRow currentRow = ds.Tables[i].Rows[r];
                    for (int c = 0; c < ds.Tables[i].Columns.Count; c++)
                    {
                        Console.Write(currentRow[c] + "\t|\t");

                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();


        }
    }
}
