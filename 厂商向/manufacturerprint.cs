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

namespace 课程设计1.厂商向
{
    public partial class manufacturerprint : Form
    {
        public manufacturerprint()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;

        private void ClearText()//清除控件内容
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void js()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select count(*) as " + "计数" + " from manufacturer ", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds);
            conn.Close();

            textBox6.Text = ds.Tables[0].Rows[0]["计数"].ToString();
            textBox6.Enabled = false;
        }

        private void LockedTextBox()
        {
            textBox5.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Enabled = false;
        }

        private void UnLockedTextBox()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void FillDataGridView()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select * from manufacturer order by 厂商编号", conn);
            DataSet ds = new DataSet();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int count = da.Fill(ds, "厂商表");
            conn.Close();
            dataGridView1.DataSource = ds.Tables["厂商表"];
        }

        private void bt_check()
        {
            string fieldName = toolStripComboBox1.Text;
            string findValue = toolStripTextBox1.Text.Trim();
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select * from manufacturer where " + fieldName + " ='" + findValue + "'", conn);
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
                    textBox5.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    UnLockedTextBox();
                    textBox1.Enabled = false;
                }
            }
            if (count == 0)
            {
                MessageBox.Show("没有查询到符合条件的记录！");
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void manufacturerprint_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            da = new SqlDataAdapter("select * from manufacturer", conn);
            toolStripComboBox1.Text = "厂商编号";
            js();
            LockedTextBox();
            FillDataGridView();
            dataGridView1.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addmanufacturer am = new addmanufacturer();
            am.Show();
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
                com = new SqlCommand("delete from manufacturer where 厂商编号=" + Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim(), conn);
                //string dd = "delete from manufacturer where 厂商编号=" + Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
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

        private void button3_Click(object sender, EventArgs e)
        {
            com = new SqlCommand("update manufacturer set 厂商名称='" + textBox2.Text.Trim() + "',法人代表='" + textBox3.Text.Trim() + "',电话='" + textBox4.Text.Trim() + "',厂商地址='"+ textBox5.Text.Trim() +"' where 厂商编号=" + Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim(), conn);
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
    }
}
