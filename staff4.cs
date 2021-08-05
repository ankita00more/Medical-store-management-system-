using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ms2
{
    public partial class staff4 : UserControl
    {


        public staff4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtContactNo.Text == "" || txtPassword.Text == "" || txtUserName.Text == "")
            {
                MessageBox.Show("Please Fill The Missing Fields To Add Items");
            }
            else if (!Regex.IsMatch(txtContactNo.Text, @"^[0-9]{10}$"))
            {
                MessageBox.Show("Invalid Contact No.");
                txtContactNo.Focus();
                return;
            }
            //@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
            else if (!Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
            {
                MessageBox.Show("Invalid Email Format");
                txtEmail.Focus();
                return;
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
                            cmd.CommandText = "ADDSTAFF";

                            SqlParameter param;
                            param = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                            param.Value = txtName.Text;
                            param = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                            param.Value = txtEmail.Text;
                            param = cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100);
                            param.Value = txtAddress.Text;
                            param = cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
                            param.Value = txtContactNo.Text;
                            param = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                            param.Value = txtUserName.Text;
                            param = cmd.Parameters.Add("@PassWord", SqlDbType.VarChar, 50);
                            param.Value = txtPassword.Text;



                            con.Open();
                            string q = "insert into LOGIN2(UserName,PassWord)values('"+txtUserName.Text+"','"+txtPassword.Text+"')";
                            SqlCommand cmd1 = new SqlCommand(q, con);
                            cmd1.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    txtContactNo.Text = "";
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                    disp_data();
                    MessageBox.Show("Staff details added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add Staff");
                }
                return;
            
        }
    }
        public void disp_data()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GETSTAFF";

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    con.Close();
                    table1.DataSource = dt;

                }
            }
        }


        private void btnSearch(object sender, EventArgs e)
        {
            { //using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
              //{
              //    using (SqlCommand cmd = con.CreateCommand())
              //    {
              //        cmd.CommandType = CommandType.StoredProcedure;
              //        cmd.CommandText = "GetStaffByName";

                //        SqlParameter param;
                //        param = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
                //        param.Value = txtName.Text;

                //        DataTable dt = new DataTable();
                //        dt.Load(cmd.ExecuteReader());
                //        dataGridView1.DataSource = dt;
                //    }
                //}
                BindingSource bs = new BindingSource();
                bs.DataSource = table1.DataSource;
                bs.Filter = "Name like '%" + txtSearch.Text + "%'";
                table1.DataSource = bs;
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Fill The Name Field To Delete Staff Details");
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
                            cmd.CommandText = "DELETESTAFF";

                            SqlParameter param;
                            param = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
                            param.Value = txtName.Text;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    txtName.Text = "";
                    disp_data();
                    MessageBox.Show("Staff details deleted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete Staff");
                }
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtContactNo.Text == "")
            {
                MessageBox.Show("Please Fill The Missing Fields To Update Staff Details");
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
                            cmd.CommandText = "UPDATESTAFF";
                            SqlParameter param;
                            param = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                            param.Value = txtName.Text;
                            param = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                            param.Value = txtEmail.Text;
                            param = cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100);
                            param.Value = txtAddress.Text;
                            param = cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar,50);
                            param.Value = txtContactNo.Text;
                            param = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                            param.Value = txtUserName.Text;
                            param = cmd.Parameters.Add("@PassWord", SqlDbType.VarChar, 50);
                            param.Value = txtPassword.Text;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                    }

                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    txtContactNo.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    disp_data();
                    MessageBox.Show("Staff details updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update Staff");
                }
                return;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void staff4_Load(object sender, EventArgs e)
        {
            
            disp_data();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    



       
        

        

       
