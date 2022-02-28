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
    public partial class monthcheck : Form
    {
        public monthcheck()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlDataAdapter da;

        private void FillDataGridView()
        {
            da = new SqlDataAdapter("select * from sell order by 商品编号", conn);
            DataSet ds = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int count = da.Fill(ds, "销售表");
            conn.Close();
            dataGridView1.DataSource = ds.Tables["销售表"];
        }

        private void monthcheck_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=(local);integrated security=true;database=sells1");
            com = new SqlCommand("select 员工编号 from employee", conn);
            conn.Open();
            DataTable dt1 = new DataTable();
            da = new SqlDataAdapter(com);
            da.Fill(dt1);
            toolStripComboBox2.ComboBox.DataSource = dt1;
            toolStripComboBox2.ComboBox.DisplayMember = "员工编号";
            conn.Close();
            FillDataGridView();
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(toolStripComboBox2.Text.Length==0)
            {
                FillDataGridView();
            }
            else
            {
                if (toolStripTextBox2.Text.Length==0)
                {
                    if(toolStripComboBox1.Text.Length==0)
                    {
                        da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "'", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        int count = da.Fill(ds, "销售表");
                        conn.Close();
                        if (count != 0)
                        {
                            dataGridView1.DataSource = ds.Tables["销售表"];
                        }
                        else
                        {
                            MessageBox.Show("没有查询到符合条件的记录！");
                        }
                        da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "'", conn);
                        DataSet dd = new DataSet();
                        conn.Open();
                        int count1 = da.Fill(dd, "销售表1");
                        conn.Close();
                        if (count1 != 0)
                        {
                            dataGridView2.DataSource = dd.Tables["销售表1"];
                        }
                        else
                        {
                            MessageBox.Show("没有查询到符合条件的记录！");
                        }
                        conn.Open();
                        com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "'", conn);
                        string text1 = com.ExecuteScalar().ToString();
                        conn.Close();
                        textBox1.Text = text1;
                    }
                    else
                    {
                        if(toolStripComboBox1.Text=="第一季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='1' or 销售月='2' or 销售月='3')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='1' or 销售月='2' or 销售月='3')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='1' or 销售月='2' or 销售月='3')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else if (toolStripComboBox1.Text == "第二季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='4' or 销售月='5' or 销售月='6')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='4' or 销售月='5' or 销售月='6')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='4' or 销售月='5' or 销售月='6')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else if (toolStripComboBox1.Text == "第三季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='7' or 销售月='8' or 销售月='9')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='7' or 销售月='8' or 销售月='9')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='7' or 销售月='8' or 销售月='9')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else if (toolStripComboBox1.Text == "第四季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='10' or 销售月='11' or 销售月='12')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='10' or 销售月='11' or 销售月='12')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and (销售月='10' or 销售月='11' or 销售月='12')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售月='"+toolStripComboBox1.Text.Trim()+"' ", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售月='" + toolStripComboBox1.Text.Trim() + "' ", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售月='" + toolStripComboBox1.Text.Trim() + "' ", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                    }
                }
                else
                {
                    if (toolStripComboBox1.Text.Length == 0)
                    {
                        da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "'and 销售年='"+toolStripTextBox2.Text.Trim()+"'", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        int count = da.Fill(ds, "销售表");
                        conn.Close();
                        if (count != 0)
                        {
                            dataGridView1.DataSource = ds.Tables["销售表"];
                        }
                        else
                        {
                            MessageBox.Show("没有查询到符合条件的记录！");
                        }
                        da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "'and 销售年='" + toolStripTextBox2.Text.Trim() + "'", conn);
                        DataSet dd = new DataSet();
                        conn.Open();
                        int count1 = da.Fill(dd, "销售表1");
                        conn.Close();
                        if (count1 != 0)
                        {
                            dataGridView2.DataSource = dd.Tables["销售表1"];
                        }
                        else
                        {
                            MessageBox.Show("没有查询到符合条件的记录！");
                        }
                        conn.Open();
                        com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "'and 销售年='" + toolStripTextBox2.Text.Trim() + "'", conn);
                        string text1 = com.ExecuteScalar().ToString();
                        conn.Close();
                        textBox1.Text = text1;
                    }
                    else
                    {
                        if (toolStripComboBox1.Text == "第一季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='"+toolStripTextBox2.Text.Trim()+"'and (销售月='1' or 销售月='2' or 销售月='3')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='1' or 销售月='2' or 销售月='3')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='1' or 销售月='2' or 销售月='3')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else if (toolStripComboBox1.Text == "第二季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='"+toolStripTextBox2.Text.Trim()+"'and (销售月='4' or 销售月='5' or 销售月='6')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='4' or 销售月='5' or 销售月='6')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='4' or 销售月='5' or 销售月='6')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else if (toolStripComboBox1.Text == "第三季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" +toolStripTextBox2.Text.Trim()+"'and (销售月='7' or 销售月='8' or 销售月='9')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='7' or 销售月='8' or 销售月='9')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='7' or 销售月='8' or 销售月='9')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else if (toolStripComboBox1.Text == "第四季度")
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='"+toolStripTextBox2.Text.Trim()+"'and (销售月='10' or 销售月='11' or 销售月='12')", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='10' or 销售月='11' or 销售月='12')", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售年='" + toolStripTextBox2.Text.Trim() + "'and (销售月='10' or 销售月='11' or 销售月='12')", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                        else
                        {
                            da = new SqlDataAdapter("select * from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售月='" + toolStripComboBox1.Text.Trim() + "'and 销售年='"+toolStripTextBox2.Text.Trim()+"'", conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            int count = da.Fill(ds, "销售表");
                            conn.Close();
                            if (count != 0)
                            {
                                dataGridView1.DataSource = ds.Tables["销售表"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            da = new SqlDataAdapter("select 生产厂商,总金额 from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售月='" + toolStripComboBox1.Text.Trim() + "'and 销售年='" + toolStripTextBox2.Text.Trim() + "'", conn);
                            DataSet dd = new DataSet();
                            conn.Open();
                            int count1 = da.Fill(dd, "销售表1");
                            conn.Close();
                            if (count1 != 0)
                            {
                                dataGridView2.DataSource = dd.Tables["销售表1"];
                            }
                            else
                            {
                                MessageBox.Show("没有查询到符合条件的记录！");
                            }
                            conn.Open();
                            com = new SqlCommand("select sum(总金额) as '总金额' from sell where 业务员编号 ='" + toolStripComboBox2.Text.Trim() + "' and 销售月='" + toolStripComboBox1.Text.Trim() + "'and 销售年='" + toolStripTextBox2.Text.Trim() + "'", conn);
                            string text1 = com.ExecuteScalar().ToString();
                            conn.Close();
                            textBox1.Text = text1;
                        }
                    }
                }
            }
        }
    }
}
