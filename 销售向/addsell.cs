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
    public partial class addsell : Form
    {
        public addsell()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;

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
            com = new SqlCommand("select 商品编号 from goods", conn);
            conn.Open();
            DataTable dt2 = new DataTable();
            da = new SqlDataAdapter(com);
            da.Fill(dt2);
            comboBox3.DisplayMember = "商品编号";
            comboBox3.DataSource = dt2;
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

        public double num11;

        private void compute_1()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            com = new SqlCommand("select 单价 from goods where 商品编号=" + comboBox3.Text, conn);
            conn.Open();
            DataSet dt = new DataSet();
            da = new SqlDataAdapter(com);
            da.Fill(dt, "销售表");
            string s1 = dt.Tables[0].Rows[0]["单价"].ToString();
            num11 = double.Parse(s1);
        }

        private void _fill()
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            com = new SqlCommand("select * from goods where 商品编号=" + comboBox3.Text, conn);
            conn.Open();
            DataSet dt = new DataSet();
            da = new SqlDataAdapter(com);
            da.Fill(dt,"销售表");
            textBox2.Text = dt.Tables[0].Rows[0]["商品名"].ToString();
            comboBox1.Text = dt.Tables[0].Rows[0]["生产厂商"].ToString();
            textBox4.Text = dt.Tables[0].Rows[0]["型号"].ToString();
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            textBox4.Enabled = false;
            conn.Close();
        }


        private void addgoods_Load(object sender, EventArgs e)
        {
            textBox11.Enabled = false;
            cbx();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定该商品已售出吗？", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    compute_1();
                    double num12 = double.Parse(textBox6.Text);
                    double num13 = num12 * num11;
                    com = new SqlCommand("update goods set 总金额 = 总金额-" + num13 + "where 商品编号=" + comboBox3.Text.Trim(), conn); ;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    com.ExecuteNonQuery();
                    conn.Close();
                    com = new SqlCommand("update goods set 数量 = 数量-" + textBox6.Text.Trim() + "where 商品编号=" + comboBox3.Text.Trim(), conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("删除数据成功！");
                    com = new SqlCommand("insert into sell(生产厂商,商品名,型号,单价,数量,总金额,销售年,销售月,销售日,业务员编号)values('" + comboBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox11.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + comboBox2.Text.Trim() + "')", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("修改数据成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

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
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fill();
        }
    }
}
