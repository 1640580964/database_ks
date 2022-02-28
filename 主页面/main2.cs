using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 课程设计1.员工向;
using 课程设计1.进货向;
using 课程设计1.厂商向;
using 课程设计1.销售向;
using 课程设计1.退货向;

namespace 课程设计1
{
    public partial class main2 : Form
    {
        public main2()
        {
            InitializeComponent();
        }

        private void main2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addgoods ag = new addgoods();
            ag.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goodsprint gp = new goodsprint();
            gp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addsell ads = new addsell();
            ads.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sellprint sp = new sellprint();
            sp.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addretreat ar = new addretreat();
            ar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            retreatprint rp = new retreatprint();
            rp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addemployee ade = new addemployee();
            ade.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            employeeprint ep = new employeeprint();
            ep.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addmanufacturer am = new addmanufacturer();
            am.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            manufacturerprint mp = new manufacturerprint();
            mp.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            employeesell es = new employeesell();
            es.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            login login1 = new login();
            this.Close();
            login1.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            goodstrails gt = new goodstrails();
            gt.Show();
        }
    }
}
