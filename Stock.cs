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
    public partial class Stock : UserControl
    {

        public Stock()
        {
            InitializeComponent();
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (txtMedicineName.Text == "" || textBox3.Text == "" || txtMediPrice.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please Fill The Missing Fields To Add Items");
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
                            cmd.CommandText = "ADStk";

                            SqlParameter param;

                            param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                            param.Value = txtMedicineName.Text;
                            param = cmd.Parameters.Add("@MedicineDesc", SqlDbType.VarChar, 200);
                            param.Value = textBox3.Text;
                            param = cmd.Parameters.Add("@MedicineType", SqlDbType.VarChar, 50);
                            param.Value = txtType.Text;
                            param = cmd.Parameters.Add("@SellPrice", SqlDbType.Float);
                            param.Value = txtMediPrice.Text;
                            param = cmd.Parameters.Add("@ExpiryDate", SqlDbType.VarChar, 50);
                            param.Value = textBox5.Text;
                            param = cmd.Parameters.Add("@ProductionDate", SqlDbType.VarChar, 50);
                            param.Value = textBox4.Text;
                            param = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                            param.Value = txtQuantity.Text;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                    }

                    txtMedicineName.Text = "";
                    txtMediPrice.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    txtType.Text = "";
                    txtQuantity.Text = "";
                    disp_data();
                    MessageBox.Show("Stock details Added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add Stock");
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
                    cmd.CommandText = "getstk";

                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    con.Close();
                    table1.DataSource = dt;
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker2.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker1.Text;
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == "" || textBox3.Text == "" || txtMediPrice.Text == "" || textBox4.Text == "" || textBox5.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please Fill The Missing Details To Update Stock Details");
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
                            cmd.CommandText = "upstk";
                            SqlParameter param;

                            param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                            param.Value = txtMedicineName.Text;
                            param = cmd.Parameters.Add("@MedicineDesc", SqlDbType.VarChar, 200);
                            param.Value = textBox3.Text;
                            param = cmd.Parameters.Add("@MedicineType", SqlDbType.VarChar, 50);
                            param.Value = txtType.Text;
                            param = cmd.Parameters.Add("@SellPrice", SqlDbType.Float);
                            param.Value = txtMediPrice.Text;
                            param = cmd.Parameters.Add("@ExpiryDate", SqlDbType.VarChar, 50);
                            param.Value = textBox5.Text;
                            param = cmd.Parameters.Add("@ProductionDate", SqlDbType.VarChar, 50);
                            param.Value = textBox4.Text;
                            param = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
                            param.Value = txtQuantity.Text;

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    txtMedicineName.Text = "";
                    txtMediPrice.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    txtType.Text = "";
                    txtQuantity.Text ="";
                    disp_data();
                    MessageBox.Show("Stock details updated successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update stock details");
                }
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == "")
            {
                MessageBox.Show("Please Fill The Item Name Field To Delete Stock Details");
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
                            cmd.CommandText = "delstk";

                            SqlParameter param;
                            param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                            param.Value = txtMedicineName.Text;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    txtMedicineName.Text = "";
                    disp_data();
                    MessageBox.Show("Stock details deleted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete Stock details");
                }
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True"))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "getstkbyname";

                    SqlParameter param;
                    param = cmd.Parameters.Add("@MedicineName", SqlDbType.VarChar, 50);
                    param.Value = txtMedicineName.Text;

                    //        DataTable dt = new DataTable();
                    //        dt.Load(cmd.ExecuteReader());
                    //        dataGridView1.DataSource = dt;
                    //    }
                    //}

                    BindingSource bs = new BindingSource();
                    bs.DataSource = table1.DataSource;
                    bs.Filter = "MedicineName like '%" + txtSearchMedicine.Text + "%'";
                    table1.DataSource = bs;
                }
            }

        }

        private void txtMedicineName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearchMedicine_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtMediPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    
    
    
