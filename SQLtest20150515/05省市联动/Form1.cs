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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1.省份加载到cb_province
            LoadProvince();
        }
        //加载省份
        private void LoadProvince()
        {
            //1查找省份数据
            string sql = "SELECT Name, Code FROM dbo.province_city_area where Code like '__0000'";
            List<Province_City> list = new List<Province_City>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Province_City PCity_module  = new Province_City();
                        //PCity_module.ID = reader.GetInt32(0);
                        //PCity_module.Code = reader.GetString(1);
                        PCity_module.Name = reader.GetString(0);
                        PCity_module.Code = reader.GetString(1);
                        cb_province.Items.Add(PCity_module);

                    }
                }
            }

        }

        private void cb_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_province.SelectedItem!=null)
            {
                
                Province_City PCity_module = cb_province.SelectedItem as Province_City;
                show_Pid.Text =  "代码：" + PCity_module.Code;
                string Code = PCity_module.Code;
                //根据code从数据库查询对应的数据
                List<Province_City> city = GetCitylist(Code);

                //方式一：向下拉菜单中增加数据
                //cb_city.Items.Clear();
                //foreach (Province_City item in city)
                //{
                //    cb_city.Items.Add(item);
                //}

                //方式二：通过数据绑定的方式向下拉菜单中添加项
                cb_city.DisplayMember = "Name";
                cb_city.ValueMember = "Code";
                cb_city.DataSource = city;
            }
        }

        private List<Province_City> GetCitylist(string code)
        {
            List<Province_City> list = new List<Province_City>();
            string sql = "select Code, Name from Province_City where PCode = @code";
            SqlParameter pm = new SqlParameter("@code", SqlDbType.Char, 6) { Value = code};
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql,pm))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    while (reader.Read())
                    {
                        Province_City PCity_module = new Province_City();
                        PCity_module.Code = reader.GetString(0);
                        PCity_module.Name = reader.GetString(1);
                        list.Add(PCity_module);
                    }
                    
                }
            }
            return list;
        }

        private void cb_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_Cid.Text = "代码：" + cb_city.SelectedValue.ToString();
            if (cb_city.SelectedItem != null)
            {
                Province_City PCity_module = cb_city.SelectedItem as Province_City;
                string code = PCity_module.Code;
                List<Province_City> area = GetAreaList(code);
                cb_area.DisplayMember = "Name";
                cb_area.ValueMember = "Code";
                cb_area.DataSource = area;
             
            }
        }

        private List<Province_City> GetAreaList(string code)
        {
            List<Province_City> list = new List<Province_City>();
            string sql = "select Code, Name from Province_City_area where PCode = @code";
            SqlParameter pm = new SqlParameter("@code", SqlDbType.Char, 6) { Value=code};
            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql,pm))
            {
                if (reader.HasRows)
                {
                    //reader.Read();
                    while (reader.Read())
                    {
                        Province_City PCity_module = new Province_City();
                        PCity_module.Code = reader.GetString(0);
                        PCity_module.Name = reader.GetString(1);
                        list.Add(PCity_module);
                    }
                }
            }
            return list;
        }

        private void cb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_area.Text =  "代码：" + cb_area.SelectedValue.ToString();

        }
    }
}
