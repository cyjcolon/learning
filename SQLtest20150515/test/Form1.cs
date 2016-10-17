using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ChangeColor += new Form2.ChangeFormColor(f_ChangeColor);
            string[] txtspath = Directory.GetFiles("E:\\资料\\book\\东野圭吾作品集", "*.txt");
            foreach (string item in txtspath)
            {
                string txtpath = item.ToString();
                string txttitle = Path.GetFileNameWithoutExtension(txtpath);
                string content = File.ReadAllText(txtpath,Encoding.Default);
                Encoding encode = txtGetEncoding.GetFileEncodeType(txtpath);


            }
            f.Show();
        }
        void f_ChangeColor(string text)
        {
            this.BackColor = Color.LightBlue;
            this.Text = text; 
        }
    }
}
