using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ms2
{
    public partial class MainForm2 : Form
    {
        public MainForm2()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
          
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {
            customer21.Hide();
            supplier1.Hide();
            stock1.Hide();
            bill1.Hide();
            //customer21.Hide();
                         //supplier1.Hide();
                         //          stock1.Hide();
                         //        bill1.Hide();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        customer21.Show();
            supplier1.Hide();
            stock1.Hide();
            bill1.Hide();
            customer21.BringToFront();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           customer21.Hide();
            supplier1.Show();
            stock1.Hide();
            bill1.Hide();
            supplier1.BringToFront();

            }

        private void button4_Click(object sender, EventArgs e)
        {

        customer21.Hide();
            supplier1.Hide();
            stock1.Show();
            bill1.Hide();
            stock1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
                        customer21.Hide();
            supplier1.Hide();
            stock1.Hide();
            bill1.Show();
            bill1.BringToFront();
        }

        private void bill1_Load(object sender, EventArgs e)
        {

        }
    }
}
