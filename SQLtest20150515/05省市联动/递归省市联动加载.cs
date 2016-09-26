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
    public partial class 递归省市联动加载 : Form
    {
        public 递归省市联动加载()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProvinceToTree("__0000",this.treeView1.Nodes,"Code");
        }
        //把指定Code下的节点加载到Nodes集合中
        private void LoadProvinceToTree(string v, TreeNodeCollection nodes,string code)
        {
            //根据PCode查询所有省份作为父ID
            List<Province_City> list = GetProvinceByCode(v,code);

            //把省份加到TreeView中，遍历list集合，把数据加到TreeNodeCollection中
            foreach (Province_City item in list)
            {
                TreeNode node = nodes.Add(item.Name);
                node.Tag = item.Code;
                
                //递归
                LoadProvinceToTree(item.Code,node.Nodes,"PCode");
            }
        }

        private List<Province_City> GetProvinceByCode(string v,string code)
        {
            List<Province_City> list = new List<Province_City>();
            string sql = "SELECT Code,Name,PCode  FROM dbo.province_city_area where " + code + " like @v";
            SqlParameter pm = new SqlParameter("@v", SqlDbType.Char, 6) { Value=v };
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql,pm))
            {
                if (reader.HasRows)
                {
                    if (code == "PCode")
                    {
                        reader.Read();
                    }
                    while (reader.Read())
                    {
                        Province_City model = new Province_City();
                        model.Code = reader.GetString(0);
                        model.Name = reader.GetString(1);
                        model.PCode = reader.GetString(2);
                        list.Add(model);
                    }
                }
            }
            return list;
        }


    }
}
