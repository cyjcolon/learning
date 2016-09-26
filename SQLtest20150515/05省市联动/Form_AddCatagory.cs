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

namespace _05省市联动
{
    public partial class Form_AddCatagory : Form
    {
        private int ParentId;
        private Action _method;
        public Form_AddCatagory()
        {
            InitializeComponent();
        }
        
        public Form_AddCatagory(int p, Action method)
            :this()
        {
            this.ParentId = p;
            this._method = method;
            //资料管理器 DataManage = new 资料管理器();//创建资料管理器窗体实例
            ////将资料管理器窗体中的委托事件 与本窗体的InsertToDB函数形成委托关系，以调用InsertToDB函数
            //DataManage.ACF_DBIns += new 资料管理器.AddCategoryForm_DBInsert(InsertToDB);
        }

        //void InsertToDB()
        //{
        //    MessageBox.Show("asdf");
        //}
        //void InsertToDB(string Database, int PId, params string[] Column)
        //{
        //    Insert(Database, PId, Column);

        //    MessageBox.Show("asdf");
        //}

        //private void Insert(string Database, int PId, params string[] Column)
        //{

        //    if (Database == "Category")
        //    {
        //        string sql = "insert into Category values(@tName,@tParentId,@tNote)";
        //        SqlParameter[] pms = new SqlParameter[]
        //        {
        //            new SqlParameter("@tName",SqlDbType.NVarChar,100){ Value = Column[0] },
        //            new SqlParameter("@tParentId",SqlDbType.Int) { Value = PId },
        //            new SqlParameter("@tNote",SqlDbType.NVarChar,1000) { Value = Column[1] }
        //        };
        //        SQLHelper.ExecuteNonQuery(sql, pms);
        //    }
        //    else if (Database == "Contentinfo")
        //    {
        //        string sql = "insert into Contentinfo values(@dName,@dTId,@dContent)";
        //        SqlParameter[] pms = new SqlParameter[]
        //        {
        //            new SqlParameter("@dName",SqlDbType.NVarChar,100){ Value = Column[0] },
        //            new SqlParameter("@dTId",SqlDbType.Int) { Value = PId },
        //            new SqlParameter("@dContent",SqlDbType.NVarChar,1000) { Value = Column[1] }
        //        };
        //        SQLHelper.ExecuteNonQuery(sql, pms);
        //    }
        //    else
        //    {
        //        MessageBox.Show("无此数据库");
        //    }

        //}
        public delegate void AddCategoryForm_DBInsert(string Database, int PId, params string[] Column);//创建委托
        //public delegate void AddCategoryForm_DBInsert();//创建委托
        public event AddCategoryForm_DBInsert ACF_DBIns;//创建委托事件与Form_AddCatagory窗体相关联，以调用里面的InsertToDB函数
        public void button1_Click(object sender, EventArgs e)
        {
            Category Category = new Category();
            Category.tName =txtName.Text.Trim();
            Category.tNote = txtContent.Text.Trim();
            int PId = this.ParentId;
            string sql = "insert into Category values(@tName,@tParentId,@tNote)";
            SqlParameter[] pms = new SqlParameter[]
            {
                    new SqlParameter("@tName",SqlDbType.NVarChar,100){ Value = Category.tName },
                    new SqlParameter("@tParentId",SqlDbType.Int) { Value = PId },
                    new SqlParameter("@tNote",SqlDbType.NVarChar,1000) { Value = Category.tNote }
            };
            SQLHelper.ExecuteNonQuery(sql, pms); if (this._method != null)
            {
                this._method();//刷新父窗口的TreeView
            }
            this.Close();//关闭窗口
        }
    }
}
