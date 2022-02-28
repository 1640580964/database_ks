using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 课程设计1.销售向
{
    public partial class goodstrails : Form
    {
        public goodstrails()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlDataAdapter da1,da2,da3;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            timecheck tc = new timecheck();
            tc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag1 = 0, flag2 = 0, flag3 = 0;
            if (toolStripTextBox1.Text.Length == 0)
            {
              MessageBox.Show("请输入查询商品");
            }
            else
            {
                string findValue = toolStripTextBox1.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 商品名='" + findValue +"'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 商品名='" + findValue + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 商品名='" + findValue + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if(flag1==1&&flag2==1&&flag3==1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }

        }

        private void goodstrails_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            da1 = new SqlDataAdapter("select * from goods", conn);
            da2 = new SqlDataAdapter("select * from sell", conn);
            da2 = new SqlDataAdapter("select * from retreat", conn);
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
        }

    }
}
