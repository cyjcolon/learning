using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05省市联动
{

    public partial class 资料管理器 : Form
    {
        public 资料管理器()
        {
            InitializeComponent();
        }

        private void 资料管理器_Load(object sender, EventArgs e)
        {
            UpdateTreeView();//更新TreeView

        }
        //更新TreeView
        private void UpdateTreeView()
        {
            this.treeView1.Nodes.Clear();//清空列表树
            LoadDataToTree(-1, this.treeView1.Nodes);//根据父PID读取数据节点进树
        }
        //根据父PID读取数据节点进树
        private void LoadDataToTree(int tParentId, TreeNodeCollection nodes)
        {
            List<Category> list = GetDataByParentID(tParentId);//根据父PID获取数据
            foreach (Category item in list)
            {
                TreeNode node = nodes.Add(item.tName);//添加节点
                node.Tag = item.tId;//获取节点ID
                LoadDataToTree(item.tId, node.Nodes); //递归加载节点数据
            }
        }
        //根据父PID获取数据
        private List<Category> GetDataByParentID(int PID)
        {
            List<Category> list = new List<Category>();
            string sql = "select tId,tName from Category where tParentId = @PID";
            SqlParameter pm = new SqlParameter("@PID", SqlDbType.Int) { Value = PID };
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql,pm))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Category model = new Category();
                        model.tId = reader.GetInt32(0);
                        model.tName = reader.GetString(1);
                        //model.tParentId = reader.GetInt32(2);
                        //model.tNote = reader.GetString(3);
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        //节点鼠标双击事件
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.textBox1.Text = GetContentToText((int)e.Node.Tag, "tNote", "Category","tId");//在textbox显示treeview节点内容
            LoadInfoToList((int)e.Node.Tag);//获取节点信息列表到listbox
        }
        //
        private void LoadInfoToList(int tag)
        {
            listBox1.Items.Clear();
            string sql = "select dId,dName,dContent from ContentInfo where dTId = @tag";
            SqlParameter pm = new SqlParameter("@tag", SqlDbType.Int) { Value = tag };
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql,pm))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contentinfo model = new contentinfo();
                        model.dId = reader.GetInt32(0);
                        model.dName = reader.GetString(1);
                        //model.dContent = reader.GetString(2);
                        this.listBox1.Items.Add(model);

                    }

                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                //获取选中文章ID
                int dId = (this.listBox1.SelectedItem as contentinfo).dId;
                //根据ID,列名以及数据库在textbox显示listbox相应节点的文章内容
                this.textBox1.Text = GetContentToText(dId, "dContent", "Contentinfo","dId");
            }

        }
        //在textbox显示节点内容
        private string GetContentToText(int dId,string ColumnName,string DataSource,string ID)
        {
            string sql = "select " + ColumnName + " from " + DataSource + " where " + ID + " = @dId";
            SqlParameter pm = new SqlParameter("@dId", SqlDbType.Int) { Value = dId };
            object Content = SQLHelper.ExecuteScaler(sql, pm);
            return Content == null ? string.Empty : Content.ToString();
        }

        private void 增加类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 增加父类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form_AddCatagory Form_AddCatagory = new Form_AddCatagory(-1,UpdateTreeView);
            Form_AddCatagory.Show();
        }

        private void 增加子类别ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                int tId = (int)treeView1.SelectedNode.Tag;
                Form_AddCatagory Form_AddCatagory = new Form_AddCatagory(tId, UpdateTreeView);
                Form_AddCatagory.Show();
            }

        }
        //public delegate void AddCategoryForm_DBInsert(string Database, int PId, params string[] Column);//创建委托
        ////public delegate void AddCategoryForm_DBInsert();//创建委托
        //public event AddCategoryForm_DBInsert ACF_DBIns;//创建委托事件与Form_AddCatagory窗体相关联，以调用里面的InsertToDB函数

        private void 导入文章ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode != null)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                Form_AddCatagory DataManage = new Form_AddCatagory();//创建资料管理器窗体实例
                //将资料管理器窗体中的委托事件 与本窗体的InsertToDB函数形成委托关系，以调用InsertToDB函数
                DataManage.ACF_DBIns += new Form_AddCatagory.AddCategoryForm_DBInsert(InsertToDB);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    int PId = (int)this.treeView1.SelectedNode.Tag;
                    string path = folderBrowserDialog1.SelectedPath;
                    string pathName = path.Split('\\').Last();
                    //InsertToDB("Category", PId, pathName, pathName);
                    //MessageBox.Show(path.Split('\\').Last());
                    string[] txtspath = Directory.GetFiles(path, "*.txt");
                    foreach (string item in txtspath)
                    {
                        string txtpath = item.ToString();
                        string txttitle = Path.GetFileNameWithoutExtension(txtpath);
                        string content = File.ReadAllText(txtpath,Encoding.Default);
                        InsertToDB("Contentinfo", PId, txttitle, content);
                    }
                }
                UpdateTreeView();
            }
            else
              {
                MessageBox.Show("没有选择类别");
            }

        }
        void InsertToDB(string Database, int PId, params string[] Column)
        {
            Insert(Database, PId, Column);

            MessageBox.Show("asdf");
        }
        private void Insert(string Database, int PId, params string[] Column)
        {

            if (Database == "Category")
            {
                string sql = "insert into Category values(@tName,@tParentId,@tNote)";
                SqlParameter[] pms = new SqlParameter[]
                {
                    new SqlParameter("@tName",SqlDbType.NVarChar,100){ Value = Column[0] },
                    new SqlParameter("@tParentId",SqlDbType.Int) { Value = PId },
                    new SqlParameter("@tNote",SqlDbType.NVarChar,1000) { Value = Column[1] }
                };
                SQLHelper.ExecuteNonQuery(sql, pms);
            }
            else if (Database == "Contentinfo")
            {
                string sql = "insert into Contentinfo(dTId, dName, dContent) values(@dTId, @dName, @dContent)";
                SqlParameter[] pms = new SqlParameter[]
                {
                    new SqlParameter("@dName",SqlDbType.NVarChar,100){ Value = Column[0] },
                    new SqlParameter("@dTId",SqlDbType.Int) { Value = PId },
                    new SqlParameter("@dContent",SqlDbType.NVarChar,-1) { Value = Column[1] }
                };
                SQLHelper.ExecuteNonQuery(sql, pms);
            }
            else
            {
                MessageBox.Show("无此数据库");
            }

        }
    }
}
