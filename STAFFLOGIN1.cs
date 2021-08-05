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

namespace ms2
{
    public partial class STAFFLOGIN1 : Form
    {
        public STAFFLOGIN1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Validate";
                    SqlParameter param;

                    param = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                    param.Value = textBox1.Text;

                    param = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                    param.Value = textBox2.Text;

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    con.Close();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        MainForm2 nm = new MainForm2();
                        nm.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and password");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.ShowDialog();
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                button2.PerformClick();
            }
        }

        private void STAFFLOGIN1_Load(object sender, EventArgs e)
        {

        }
    }
    }



        