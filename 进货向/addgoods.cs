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
    public partial class addgoods : Form
    {
        public addgoods()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;
        public int cnt1,cnt2;

        private void bh()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select top 1 商品编号 from goods order by 商品编号 desc", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds);
            int count = da.Fill(ds);
            conn.Close();
            if (count == 0)
            {
                textBox1.Text = "1";
                textBox1.Enabled = false;
            }
            else
            {
                string s1 = ds.Tables[0].Rows[0]["商品编号"].ToString();
                int a;
                int.TryParse(s1, out a);
                cnt1 = a;
                a++;
                string s2 = "" + a;
                textBox1.Text = s2;
                textBox1.Enabled = false;
            }
        }

        /*private void fill_sell()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            da = new SqlDataAdapter("select top 1 商品编号 from sell order by 商品编号 desc", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da.Fill(ds);
            int count = da.Fill(ds,"销售表");
            cnt2 = count;
            for(int i=cnt2;i<=cnt1;i++)
            {
                da = new SqlDataAdapter("select count(*) from sell where 商品编号="+i, conn);
                DataSet ds10 = new DataSet();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da.Fill(ds10);
                int count1 = da.Fill(ds10,"销售表1");
                conn.Close();
                da = new SqlDataAdapter("select count(*) from goods where 商品编号=" + i, conn);
                DataSet ds20 = new DataSet();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da.Fill(ds20);
                int count2 = da.Fill(ds20,"销售表2");
                conn.Close();
                da = new SqlDataAdapter("select * from sell where 商品编号=" + i, conn);
                DataSet ds1 = new DataSet();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da.Fill(ds1);
                conn.Close();
                da = new SqlDataAdapter("select * from goods where 商品编号=" + i, conn);
                DataSet ds2 = new DataSet();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da.Fill(ds2);
                conn.Close();
                textBox3.Text = count1.ToString();
                if (count1==0)
                {
                    if(count2!=0)
                    {
                        conn.Open();
                        com = new SqlCommand("insert into sell(生产厂商,商品名,型号,单价,数量,总金额)values('" + ds2.Tables[0].Rows[0]["生产厂商"] + "','" + ds2.Tables[0].Rows[0]["商品名"] + "','" + ds2.Tables[0].Rows[0]["型号"] + "','" + ds2.Tables[0].Rows[0]["单价"] + "','" + 0 + "','" + 0 + "')", conn);
                        conn.Close();
                    }
                    else
                    {
                        conn.Open();
                        com = new SqlCommand("insert into sell(生产厂商,商品名,型号,单价,数量,总金额)values('" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')", conn);
                        conn.Close();
                    }
                }
            }
        }*/

        private void cbx()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            com = new SqlCommand("select 厂商名称 from manufacturer ", conn);
            conn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(com);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "厂商名称";
            conn.Close();
            com = new SqlCommand("select 员工编号 from employee", conn);
            conn.Open();
            DataTable dt1 = new DataTable();
            da = new SqlDataAdapter(com);
            da.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "员工编号";
            conn.Close();
        }

        private void ClearText()
        {
            textBox4.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox11.Clear();
        }

        private void compute()
        {
            if(textBox5.Text!=""&&textBox6.Text!="")
            {
                double num1 = double.Parse(textBox5.Text);
                double num2 = double.Parse(textBox6.Text);
                double num3 = num1 * num2;
                textBox11.Text = num3.ToString();
            }
            else
            {
                textBox11.Clear();
            }
        }

        private void addgoods_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            da = new SqlDataAdapter("select * from goods", conn);
            textBox11.Enabled = false;
            cbx();
            bh();
            //fill_sell();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from goods where 商品编号='" + textBox1.Text.Trim() + "'", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int count = da.Fill(ds, "商品表");
                conn.Close();
            if (count != 0)
            {
                 MessageBox.Show("该商品编号已存在，请重新输入！");
                 textBox1.Focus();
                 return;
            }
            com = new SqlCommand("insert into goods(生产厂商,商品名,型号,单价,数量,总金额,进货年,进货月,进货日,业务员编号)values('" + comboBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox4.Text + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox11.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + comboBox2.Text.Trim() + "')", conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加数据成功！");
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            compute();
         }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            compute();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearText();
           // fill_sell();
        }
    }
}
