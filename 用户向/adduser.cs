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

namespace 课程设计1
{
    public partial class adduser : Form
    {
        public adduser()
        {
            InitializeComponent();
        }
        public static string userName;
        public static string userRight;

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;
        //SqlDataReader dr;
        //DataSet ds;

        private void ClearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void LockedTextBox()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void js()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select count(*) as " + "计数" + " from userdb ", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds);
            conn.Close();
            textBox4.Text = ds.Tables[0].Rows[0]["计数"].ToString();
            textBox4.Enabled = false;
        }

        private void adduser_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1;";
            da = new SqlDataAdapter("select * from userdb", conn);
            js();
        } 

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            da = new SqlDataAdapter("select * from userdb where 用户名='" + textBox1.Text.Trim() + "'", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int count = da.Fill(ds, "用户表");
            conn.Close();
            if (count != 0)
            {
                 MessageBox.Show("该用户已存在，请重新输入！");
                 textBox1.Focus();
                  return;
            }
            if (textBox2.Text.Trim() != textBox3.Text.Trim())
            {
                 MessageBox.Show("两次密码输入不相同，请重新输入！");
                 textBox1.Focus();
                 return;
            }  
            com = new SqlCommand("insert into userdb(用户名,密码)values('"+textBox1.Text.Trim()+"','"+textBox2.Text.Trim()+"')", conn);
            if (conn.State == ConnectionState.Closed)
            {
                 conn.Open();
            }
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加用户成功！");
            button1.Enabled = false;
            button2.Enabled = false;  
            LockedTextBox();
            js();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearText();
            js();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
