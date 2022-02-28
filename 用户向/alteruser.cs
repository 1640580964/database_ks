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
    public partial class alteruser : Form
    {
        public alteruser()
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
            textBox4.Clear();
        }

        private void LockedTextBox()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void alteruser_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1;";
            da = new SqlDataAdapter("select * from userdb", conn);
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
                MessageBox.Show("旧密码不能为空！");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("新密码不能为空！");
                return;
            }
            if (textBox3.Text == textBox2.Text)
            {
                MessageBox.Show("新旧密码不能相同！");
                return;
            }
            if (textBox4.Text != textBox3.Text)
            {
                MessageBox.Show("确认密码需要与新密码一致！");
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
            if (count!=0)
            {
                com = new SqlCommand("update userdb set 用户名='" + textBox1.Text.Trim() + "',密码='" + textBox3.Text.Trim()+"' where 用户名='" + textBox1.Text.Trim() +"' and 密码='"+textBox2.Text.Trim()+"'", conn);
                da = new SqlDataAdapter("select * from userdb where 用户名='" + textBox1.Text.Trim() + "' and 密码='" + textBox2.Text.Trim() + "'", conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da.Fill(ds, "userdb");
                com.ExecuteNonQuery();
                conn.Close();
                if (ds.Tables["userdb"].Rows.Count > 0)
                {
                    MessageBox.Show("修改密码成功！");
                    button1.Enabled = false;
                    button2.Enabled = false;
                    LockedTextBox();
                }
                else
                {
                    MessageBox.Show("旧密码错误，请重新输入！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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
    }
}
