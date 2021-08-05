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
using System.Text.RegularExpressions;

namespace ms2
{
    public partial class ForgetPassword : Form
    {
        string myInput;
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please Fill The Fields");
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
            {
                MessageBox.Show("Invalid Email Format");
                txtEmail.Focus();
                return;
            }


            {

                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "forgetpswd";
                        SqlParameter param;

                        param = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                        param.Value = txtEmail.Text;

                        param = cmd.Parameters.Add("@Question", SqlDbType.VarChar, 50);
                        param.Value = textBox1.Text;
                        DataTable dt = new DataTable();
                        con.Open();
                        dt.Load(cmd.ExecuteReader());
                        con.Close();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            NewPassword nm = new NewPassword();
                            nm.ShowDialog();
                            this.Close();
                        }


                        else
                        {
                            MessageBox.Show("Incorrect Answer");

                            return;
                            
                        }
                    }
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            {
                OWNERLOGIN1 hm = new OWNERLOGIN1();
                hm.ShowDialog();
                this.Close();

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
