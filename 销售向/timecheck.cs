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
    public partial class timecheck : Form
    {
        public timecheck()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlDataAdapter da1,da2,da3;

        private void FillDataGridView()//填充表格数据
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select * from goods order by 商品编号", conn);//
            DataSet ds1 = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da1.Fill(ds1, "进货表");
            conn.Close();
            dataGridView1.DataSource = ds1.Tables["进货表"];
            SqlDataAdapter da2 = new SqlDataAdapter("select * from sell order by 商品编号", conn);//
            DataSet ds2 = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da2.Fill(ds2, "销售表");
            conn.Close();
            dataGridView2.DataSource = ds2.Tables["销售表"];
            SqlDataAdapter da3 = new SqlDataAdapter("select * from retreat order by 退货编号", conn);//
            DataSet ds3 = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da3.Fill(ds3, "退货表");
            conn.Close();
            dataGridView3.DataSource = ds3.Tables["退货表"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag1 = 0, flag2 = 0, flag3 = 0;
            if (toolStripTextBox1.Text.Length == 0 && toolStripTextBox2.Text.Length == 0 && toolStripTextBox3.Text.Length == 0 )
            {
                FillDataGridView();
            }
            else if(toolStripTextBox1.Text.Length!=0 && toolStripTextBox2.Text.Length == 0 && toolStripTextBox3.Text.Length == 0 )
            {
                string findValue = toolStripTextBox1.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 进货年='" + findValue +"'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 销售年='" + findValue + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 退货年='" + findValue + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if(flag1==1&&flag2==1&&flag3==1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }
            else if (toolStripTextBox1.Text.Length == 0 && toolStripTextBox2.Text.Length != 0 && toolStripTextBox3.Text.Length == 0)
            {
                string findValue = toolStripTextBox2.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 进货月='" + findValue + "'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 销售月='" + findValue + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 退货月='" + findValue + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if (flag1 == 1 && flag2 == 1 && flag3 == 1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }
            else if (toolStripTextBox1.Text.Length == 0 && toolStripTextBox2.Text.Length == 0 && toolStripTextBox3.Text.Length != 0)
            {
                string findValue = toolStripTextBox3.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 进货日='" + findValue + "'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 销售日='" + findValue + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 退货日='" + findValue + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if (flag1 == 1 && flag2 == 1 && flag3 == 1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }
            else if (toolStripTextBox1.Text.Length != 0 && toolStripTextBox2.Text.Length != 0 && toolStripTextBox3.Text.Length == 0)
            {
                string findValue1 = toolStripTextBox1.Text.Trim();
                string findValue2 = toolStripTextBox2.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 进货年='" + findValue1 + "' and 进货月='"+findValue2+"'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 销售年='" + findValue1 + "' and 销售月='" + findValue2 + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 退货年='" + findValue1 + "' and 退货月='" + findValue2 + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if (flag1 == 1 && flag2 == 1 && flag3 == 1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }
            else if (toolStripTextBox1.Text.Length != 0 && toolStripTextBox2.Text.Length == 0 && toolStripTextBox3.Text.Length != 0)
            {
                string findValue1 = toolStripTextBox1.Text.Trim();
                string findValue3 = toolStripTextBox3.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 进货年='" + findValue1 + "' and 进货日='" + findValue3 + "'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 销售年='" + findValue1 + "' and 销售日='" + findValue3 + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 退货年='" + findValue1 + "' and 退货日='" + findValue3 + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if (flag1 == 1 && flag2 == 1 && flag3 == 1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }
            else if (toolStripTextBox1.Text.Length == 0 && toolStripTextBox2.Text.Length != 0 && toolStripTextBox3.Text.Length != 0)
            {
                string findValue3 = toolStripTextBox3.Text.Trim();
                string findValue2 = toolStripTextBox2.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 进货日='" + findValue3 + "' and 进货月='" + findValue2 + "'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 销售日='" + findValue3 + "' and 销售月='" + findValue2 + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 退货日='" + findValue3 + "' and 退货月='" + findValue2 + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if (flag1 == 1 && flag2 == 1 && flag3 == 1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }
            else if (toolStripTextBox1.Text.Length != 0 && toolStripTextBox2.Text.Length != 0 && toolStripTextBox3.Text.Length != 0)
            {
                string findValue1 = toolStripTextBox1.Text.Trim();
                string findValue2 = toolStripTextBox2.Text.Trim();
                string findValue3 = toolStripTextBox3.Text.Trim();
                da1 = new SqlDataAdapter("select * from goods where 进货年='" + findValue1 + "' and 进货月='" + findValue2 + "' and 进货日='"+findValue3+"'", conn);
                DataSet ds1 = new DataSet();
                conn.Open();
                int count1 = da1.Fill(ds1, "进货表");
                conn.Close();
                if (count1 != 0)
                {
                    dataGridView1.DataSource = ds1.Tables["进货表"];
                }
                else
                {
                    flag1 = 1;
                }

                da2 = new SqlDataAdapter("select * from sell where 销售年='" + findValue1 + "' and 销售月='" + findValue2 + "'and 销售日='" + findValue3 + "'", conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                int count2 = da2.Fill(ds2, "销售表");
                conn.Close();
                if (count2 != 0)
                {
                    dataGridView2.DataSource = ds2.Tables["销售表"];
                }
                else
                {
                    flag2 = 1;
                }

                da3 = new SqlDataAdapter("select * from retreat where 退货年='" + findValue1 + "' and 退货月='" + findValue2 + "'and 退货日='" + findValue3 + "'", conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                int count3 = da3.Fill(ds3, "退货表");
                conn.Close();
                if (count3 != 0)
                {
                    dataGridView3.DataSource = ds3.Tables["退货表"];
                }
                else
                {
                    flag3 = 1;
                }
                if (flag1 == 1 && flag2 == 1 && flag3 == 1)
                {
                    MessageBox.Show("未查询到结果");
                }
            }
        }

        private void goodstrails_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=(local);integrated security=true;database=sells1";
            da1 = new SqlDataAdapter("select * from goods", conn);
            da2 = new SqlDataAdapter("select * from sell", conn);
            da2 = new SqlDataAdapter("select * from retreat", conn);
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
        }

    }
}
