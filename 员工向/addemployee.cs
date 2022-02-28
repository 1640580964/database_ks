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
    public partial class addemployee : Form
    {
        public addemployee()
        {
            InitializeComponent();
        }
       
        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;
       
        private void js()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select count(*) as " + "计数" + " from employee ", conn);
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

        private void bh()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da= new SqlDataAdapter("select top 1 员工编号 from employee order by 员工编号 desc", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds); 
            conn.Close();
            string s1 = ds.Tables[0].Rows[0]["员工编号"].ToString();
            int a;
            int.TryParse(s1, out a);
            a++;
            string s2 = "" + a;
            textBox1.Text=s2;
            textBox1.Enabled=false;
        }

        private void ClearText()
        {
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addemployee_Load(object sender, EventArgs e)
        {
            bh();
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            da = new SqlDataAdapter("select * from employee", conn);
            js();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearText();
            js();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("员工名称不能为空！");
                return;
            }
            da = new SqlDataAdapter("select * from employee where 员工电话='" + textBox3.Text.Trim() + "'", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int count = da.Fill(ds, "员工表");
            conn.Close();
            if (count != 0)
            {
                 MessageBox.Show("该员工已存在，请重新输入！");
                 textBox2.Focus();
                 return;
            }
            com = new SqlCommand("insert into employee(员工姓名,员工电话,员工地址)values('" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text + "')", conn);
            if (conn.State == ConnectionState.Closed)
            {
                 conn.Open();
            }
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加数据成功！");
            ClearText();
            js();
            bh();
        }
    }
}
