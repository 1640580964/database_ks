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

namespace 课程设计1.退货向
{
    public partial class retreatprint : Form
    {
        public retreatprint()
        {
            InitializeComponent();
        }
   
        SqlConnection conn;
        SqlDataAdapter da;

        private void FillDataGridView()
        {
            da = new SqlDataAdapter("select * from retreat order by 退货编号", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds, "退货表");
            conn.Close();
            dataGridView1.DataSource = ds.Tables["退货表"];
           
        }

        private void retreatprint_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            da = new SqlDataAdapter("select * from retreat", conn);
            FillDataGridView();
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
                  
                    da = new SqlDataAdapter("select * from retreat where " + fieldName + " ='" + findValue + "'", conn);
                    DataSet ds = new DataSet();
                    conn.Open();
                    int count = da.Fill(ds, "退货表");
                    conn.Close();
                    if (count != 0)
                    {
                        dataGridView1.DataSource = ds.Tables["退货表"];
                    }
                    else
                    {
                        MessageBox.Show("没有查询到符合条件的记录！");
                    }
                }
            }
            else
            {

                MessageBox.Show("请选择查询条件");
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
