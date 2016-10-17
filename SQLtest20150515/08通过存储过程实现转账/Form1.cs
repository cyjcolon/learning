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

namespace _08通过存储过程实现转账
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTran_Click(object sender, EventArgs e)
        {
            Transfer();
        }

        private void Transfer()
        {
            //@from CHAR(4),
            //@to CHAR(4),
            //@balance money,
            //@resultNumber bit OUTPUT--转账是否成功（1表示成功，2表示失败，3表示余额不足）            
            string from = labelFrom.Text.ToString();
            string to = labelTo.Text.ToString();
            double money = double.Parse(labelMoney.Text.Trim());
            int resultNumber;
            string sql = "usp_transfer";

            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@from",SqlDbType.Char,4) { Value = from },
            new SqlParameter("@to",SqlDbType.Char,4) { Value = to },
            new SqlParameter("@balance",SqlDbType.Money) { Value = money },
            new SqlParameter("@resultNumber",SqlDbType.Bit) { Direction=ParameterDirection.Output }
            };
            SQLHelper.SQLHelper.ExecuteNonQuery(sql, CommandType.StoredProcedure, pms);
            resultNumber = Convert.ToInt32(pms[3]);
            if (resultNumber == 1)
            {
                label_OK.Text = "转账成功";
            }
            else if (resultNumber == 2)
            {
                label_OK.Text = "转账失败";
            }
            else if (resultNumber == 3)
            {
                label_OK.Text = "余额不足";
            }


        }
    }
}
