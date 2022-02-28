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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public static string userName;
        public static string userRight;

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;
        DataSet ds;

        private void ClearText()
        {
            textBox2.Clear();
        }

        private void cbx()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            com = new SqlCommand("select 用户名 from userdb ", conn);
            conn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(com);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "用户名";
            conn.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearText();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select * from userdb where 用户名='" + comboBox1.Text.Trim() + "' and 密码='" + textBox2.Text.Trim() + "'", conn);
            ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds, "userdb");
            conn.Close();
            if (ds.Tables["userdb"].Rows.Count > 0)
            {
                userName = comboBox1.Text;
                main2 frmmain = new main2();
                this.Close();
                frmmain.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Text = "";
                comboBox1.Focus();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void login_Load_1(object sender, EventArgs e)
        {
            cbx();
        }
    }
}
