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
    public partial class NewPassword : Form
    {
        public NewPassword()
        {
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" )
            {
                MessageBox.Show("Please Fill The Missing Details");
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
                    {
                        using (SqlCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "UPDATEPASSwor";
                            SqlParameter param;

                            param = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                            param.Value = textBox2.Text;
                            param = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 500);
                            param.Value = textBox1.Text;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update details");
                }
                return;
            }
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            OWNERLOGIN1 hm = new OWNERLOGIN1();
            hm.ShowDialog();
            this.Close();

        }
    }
                }
        