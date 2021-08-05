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

namespace ms2
{
    public partial class Supplier : UserControl
    {


        public Supplier()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "getSupbyname";

                    SqlParameter param;
                    param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                    param.Value = txtName.Text;

                    //        DataTable dt = new DataTable();
                    //        dt.Load(cmd.ExecuteReader());
                    //        dataGridView1.DataSource = dt;
                    //    }
                    //}

                    BindingSource bs = new BindingSource();
                    bs.DataSource = table1.DataSource;
                    bs.Filter = "MedicineName like '%" + txtSearch.Text + "%'";
                    table1.DataSource = bs;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtOrderDate.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "" || txtTotalPrice.Text == "" || txtType.Text == "")
            {
                MessageBox.Show("Please Fill The Missing Fields To Add Supplier Details");
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
                        cmd.CommandText = "AdSup";

                        SqlParameter param;
                        param = cmd.Parameters.Add("@OrderDate", SqlDbType.VarChar, 50);
                        param.Value = txtOrderDate.Text;
                        param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                        param.Value = txtName.Text;
                        param = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                        param.Value = txtQuantity.Text;
                        param = cmd.Parameters.Add("@Costprice", SqlDbType.Float);
                        param.Value = txtPrice.Text;
                        param = cmd.Parameters.Add("@TotalCost", SqlDbType.Float);
                        param.Value = txtTotalPrice.Text;
                        param = cmd.Parameters.Add("@MedicineType", SqlDbType.VarChar, 50);
                        param.Value = txtType.Text;
                            con.Open();
                            string q = "insert into STOCK1(MedicineName,Quantity,MedicineType)values('" + txtName.Text + "','" + txtQuantity.Text + "' ,'" + txtType.Text + "')";
                          SqlCommand cmd1 = new SqlCommand(q, con);
                           cmd1.ExecuteNonQuery();
                           
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                txtPrice.Text = "";
                txtType.Text = "";
                txtQuantity.Text = "";
                txtTotalPrice.Text = "";
                txtName.Text = "";
                txtOrderDate.Text = "";
                disp();
                MessageBox.Show("Supplier details added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add Supplier");
                }
                return;
            }

        }
        public void disp()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GETSup";

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    con.Close();
                    table1.DataSource = dt;


                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtOrderDate.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "" || txtTotalPrice.Text == "" || txtType.Text == "")
            {
                MessageBox.Show("Please Fill The Missing Fields To Update Supplier Details");
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
                            cmd.CommandText = "upSup";
                            SqlParameter param;

                            param = cmd.Parameters.Add("@OrderDate", SqlDbType.VarChar, 50);
                            param.Value = txtOrderDate.Text;
                            param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                            param.Value = txtName.Text;
                            param = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                            param.Value = txtQuantity.Text;
                            param = cmd.Parameters.Add("@Costprice", SqlDbType.Float);
                            param.Value = txtPrice.Text;
                            param = cmd.Parameters.Add("@TotalCost", SqlDbType.Float);
                            param.Value = txtTotalPrice.Text;
                            param = cmd.Parameters.Add("@MedicineType", SqlDbType.VarChar, 50);
                            param.Value = txtType.Text;


                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    txtPrice.Text = "";
                    txtType.Text = "";
                    txtQuantity.Text = "";
                    txtTotalPrice.Text = "";
                    txtName.Text = "";
                    txtOrderDate.Text = "";
                    disp();
                    MessageBox.Show("Supplier details updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update Supplier details");
                }
                return;
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Fill The Item Name Field To Delete Supplier Details");
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
                            cmd.CommandText = "delSup";
                            SqlParameter param;
                            param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                            param.Value = txtName.Text;


                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    txtName.Text = "";
                    disp();
                    MessageBox.Show("Supplier details deleted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete Supplier details");
                }
                return;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtOrderDate.Text = dateTimePicker1.Text;
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            disp();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTotalPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disp();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
 
        
            
        

       



            
        
   

   
            

        

       

           

        

       

