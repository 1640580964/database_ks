using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 课程设计1
{
    public partial class main1 : Form
    {
        public main1()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            adduser open= new adduser();
            open.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alteruser open = new alteruser();
            open.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login open = new login();
            open.Show();
        }
    }
}
