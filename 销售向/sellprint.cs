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
    public partial class sellprint : Form
    {
        public sellprint()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;

        private void FillDataGridView()
        {
            da = new SqlDataAdapter("select * from sell order by 商品编号", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds, "销售表");
            conn.Close();
            dataGridView1.DataSource = ds.Tables["销售表"];
            
        }

        private void sellprint_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            toolStripComboBox1.Text = "业务员编号";
            da = new SqlDataAdapter("select * from sell", conn);
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
                    da = new SqlDataAdapter("select * from sell where " + fieldName + " ='" + findValue + "'", conn);
                    DataSet ds = new DataSet();
                    conn.Open();
                    int count = da.Fill(ds, "销售表");
                    conn.Close();
                    if (count != 0)
                    {
                        dataGridView1.DataSource = ds.Tables["销售表"];
                    }
                    else
                    {
                        MessageBox.Show("没有查询到符合条件的记录！");
                    }
                    da = new SqlDataAdapter("select 生产厂商,总金额 from sell where " + fieldName + " ='" + findValue + "'", conn);
                    DataSet dd = new DataSet();
                    conn.Open();
                    int count1 = da.Fill(dd, "销售表1");
                    conn.Close();
                    if (count1 != 0)
                    {
                        dataGridView2.DataSource = dd.Tables["销售表1"];
                    }
                    else
                    {
                        MessageBox.Show("没有查询到符合条件的记录！");
                    }                        
                    conn.Open();
                    com = new SqlCommand("select sum(总金额) as '总金额' from sell where " + fieldName + " = '" + findValue + "'", conn);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
