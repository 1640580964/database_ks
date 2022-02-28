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
    public partial class addmanufacturer : Form
    {
        public addmanufacturer()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;
        //SqlDataReader dr;
        //DataSet ds;

        private void bh()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select top 1 厂商编号 from manufacturer order by 厂商编号 desc", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds);
            conn.Close();
            string s1 = ds.Tables[0].Rows[0]["厂商编号"].ToString();
            int a;
            int.TryParse(s1, out a);
            a++;
            string s2 = "" + a;
            textBox1.Text = s2;
            textBox1.Enabled = false;
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

        private void ClearText()//清除控件内容
        {
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void addmanufacturer_Load(object sender, EventArgs e)
        {
            bh();
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            da = new SqlDataAdapter("select * from manufacturer", conn);
            js();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearText();
            js();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("厂商名称不能为空！");
                return;
            }
            da = new SqlDataAdapter("select * from manufacturer where 电话='" + textBox3.Text.Trim() + "'", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int count = da.Fill(ds, "厂商表");
            conn.Close();
            if (count != 0)
            {
                MessageBox.Show("该厂商已存在，请重新输入！");
                textBox2.Focus();
                return;
            }
            com = new SqlCommand("insert into manufacturer(厂商名称,法人代表,电话,厂商地址)values('" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','"+ textBox5.Text.Trim() +"')", conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加数据成功！");
            ClearText();
            bh();
            js();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
