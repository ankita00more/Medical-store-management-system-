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
    public partial class mainform11 : Form
    {
        public mainform11()
        {
            InitializeComponent();
        }

        private void mainform11_Load(object sender, EventArgs e)
        {
            staff43.Hide();
            customer22.Hide();
            supplier2.Hide();
            stock2.Hide();
            bill2.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            staff41.Show();
            customer21.Hide();
            supplier1.Hide();
            stock1.Hide();
            bill1.Hide();
            staff41.BringToFront();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            staff41.Hide();
            customer21.Show();
            supplier1.Hide();
            stock1.Hide();
            bill1.Hide();
            customer21.BringToFront();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            staff41.Hide();
            customer21.Hide();
            supplier1.Hide();
            stock1.Show();
            bill1.Hide();
            stock1.BringToFront();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            staff41.Hide();
            customer21.Hide();
            supplier1.Show();
            stock1.Hide();
            bill1.Hide();
            supplier1.BringToFront();
        }

        private void bILLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            staff41.Hide();
            customer21.Hide();
            supplier1.Hide();
            stock1.Hide();
            bill1.Show();
            bill1.BringToFront();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            Home hm = new Home();
            hm.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staff43.Show();
            customer22.Hide();
            supplier2.Hide();
            stock2.Hide();
            bill2.Hide();
            staff43.BringToFront();
        }

        private void staff43_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            staff43.Hide();
            customer22.Show();
            supplier2.Hide();
            stock2.Hide();
            bill2.Hide();
            customer22.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staff43.Hide();
            customer22.Hide();
            supplier2.Show();
            stock2.Hide();
            bill2.Hide();
            supplier2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            staff43.Hide();
            customer22.Hide();
            supplier2.Hide();
            stock2.Show();
            bill2.Hide();
            stock2.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            staff43.Hide();
            customer22.Hide();
            supplier2.Hide();
            stock2.Hide();
            bill2.Show();
            bill2.BringToFront();
        }
    }
}
