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

namespace 课程设计1.进货向
{
    public partial class goodsprint : Form
    {
        public goodsprint()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;

        private void FillDataGridView()
        {
            da = new SqlDataAdapter("select * from goods order by 商品编号", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds, "进货表");
            conn.Close();
            dataGridView1.DataSource = ds.Tables["进货表"];
            
        }

        private void goodsprint_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            toolStripComboBox1.Text = "业务员编号";
            da = new SqlDataAdapter("select * from goods", conn);
            FillDataGridView();
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (toolStripComboBox1.Text.Length != 0)
            {
                if (toolStripTextBox1.Text.Length == 0)
                {
                    this.FillDataGridView();
                }
                else
                {
                    string fieldName = toolStripComboBox1.Text;
                    string findValue = toolStripTextBox1.Text.Trim(); 
                    da = new SqlDataAdapter("select * from goods where " + fieldName + " ='" + findValue + "'", conn);
                    DataSet ds = new DataSet();
                    conn.Open();
                    int count = da.Fill(ds, "进货表");
                    conn.Close();
                    if (count != 0)
                    {
                        dataGridView1.DataSource = ds.Tables["进货表"];
                    }
                    else
                    {
                        MessageBox.Show("没有查询到符合条件的记录！");
                    }
                    da = new SqlDataAdapter("select 生产厂商,总金额 from goods where " + fieldName + " ='" + findValue + "'", conn);
                    DataSet dd = new DataSet();
                    conn.Open();
                    int count1 = da.Fill(dd, "进货表1");
                    conn.Close();
                    if (count1 != 0)
                    {
                        dataGridView2.DataSource = dd.Tables["进货表1"];
                    }
                    else
                    {
                        MessageBox.Show("没有查询到符合条件的记录！");
                    }
                    conn.Open();
                    com = new SqlCommand("select sum(总金额) as '总金额' from goods where " + fieldName + " = '" + findValue + "'", conn);
                    string text1 = com.ExecuteScalar().ToString();
                    conn.Close();
                    textBox1.Text = text1;
                }
            }
            else
            {
                MessageBox.Show("请选择查询条件");
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
