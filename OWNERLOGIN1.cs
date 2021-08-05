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
    public partial class OWNERLOGIN1 : Form
    {
        public OWNERLOGIN1()
        {
            InitializeComponent();
        }

        private void LOGIN1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ValidateUser";
                    SqlParameter param;

                    param = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100);
                    param.Value = textBox1.Text;

                    param = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100);
                    param.Value = textBox2.Text;

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    con.Close();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        mainform11 mn = new mainform11();
                        mn.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and password");
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            ForgetPassword fp = new ForgetPassword();
            fp.ShowDialog();
            this.Close();
        }
    }
    }
