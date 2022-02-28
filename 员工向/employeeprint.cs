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

namespace 课程设计1.员工向
{
    public partial class employeeprint : Form
    {
        public employeeprint()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;

        private void ClearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void js()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select count(*) as "+"计数"+" from employee ", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds);
            conn.Close();
           
            textBox5.Text = ds.Tables[0].Rows[0]["计数"].ToString();
            textBox5.Enabled = false;
        }

        private void LockedTextBox()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void UnLockedTextBox()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void bt_check()
        {
            string fieldName = toolStripComboBox1.Text;
            string findValue = toolStripTextBox1.Text.Trim();
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select * from employee where " + fieldName + " ='" + findValue + "'", conn);
            DataSet ds = new DataSet();
            conn.Open();
            int count = da.Fill(ds, "员工表");
            conn.Close();
            if (count != 0)
            {
                dataGridView1.DataSource = ds.Tables["员工表"];
                if (count == 1)
                {
                    textBox2.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    textBox3.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    textBox4.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    textBox1.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    UnLockedTextBox();
                    textBox1.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("没有查询到符合条件的记录！");
            }
        }

        private void FillDataGridView()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select * from employee order by 员工编号", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds, "员工表");
            conn.Close();
            dataGridView1.DataSource = ds.Tables["员工表"];
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            if (toolStripComboBox1.Text.Length != 0)
            {
               
               
               if (toolStripTextBox1.Text.Length == 0)
               {
                   this.FillDataGridView();
               }
               else
               {
                   bt_check();
               }
            }
            else
            {
                MessageBox.Show("请选择查询条件");
            }
            js();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该员工信息吗？", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                com = new SqlCommand("delete from employee where 员工编号=" + Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim(), conn);
                //string dd = "delete from employee where 员工编号=" + Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                com.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("删除数据成功！");
                ClearText();
                js();
                bt_check();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            com = new SqlCommand("update employee set 员工姓名='" + textBox2.Text.Trim() + "',员工电话='" + textBox3.Text.Trim() + "',员工地址='" + textBox4.Text.Trim() + "' where 员工编号=" + Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim(), conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("修改数据成功！");
            js();
            bt_check();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addemployee ade = new addemployee();
            ade.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void employeeprint_Load_1(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            da = new SqlDataAdapter("select * from employee", conn);
            toolStripComboBox1.Text = "员工编号";
            js();
            LockedTextBox();
        }
    }
}
