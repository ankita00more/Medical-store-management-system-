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
    public partial class bill : UserControl
    {
        int r;
        int rid;
        string fcode = "";
        public bill()
        {
            InitializeComponent();
        }

        private void bill_Load(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToLongTimeString();
            label15.Text = DateTime.Now.ToShortDateString();
            timer1.Start();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True");
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {

                disp();

            } }
            public void disp()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True");
            con.Open();
            string q = "select * from STOCK1";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            table1.DataSource = dt;

            string w = "select * from Bill";
            SqlCommand cmd1 = new SqlCommand(w, con);
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            table2.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtName2.Text == "" || txtContactNo.Text == "" || txtTotal.Text == "")
            {
                MessageBox.Show("Please fill all bill details");
            }
            else if (!Regex.IsMatch(txtContactNo.Text, @"^[0-9]{10}$"))
            {
                MessageBox.Show("Invalid Contact No.");
                txtContactNo.Focus();
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(Id as int)),0)+1 from Customer", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string q = "INSERT INTO Customer(Name,ContactNo)values('" + txtName2.Text + "','" + txtContactNo.Text + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.ClientRectangle.Width, panel1.ClientRectangle.Height);
            panel1.DrawToBitmap(bmp, panel1.ClientRectangle);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    private void cleartext()
        {           
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtSearch.Text = "";
       }
        private void cleartext1()
        {
            txtContactNo.Text = "";
            txtTotal.Text = "";
            txtName2.Text = "";
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True");
            con.Open();
            
            SqlDataAdapter da1 = new SqlDataAdapter("select MedicineName from STOCK1 where MedicineName='"+txtSearch.Text+"'",con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please enter Medicine name");
            }
            else if (dt1.Rows.Count >= 1)
            {
                    {
                    string q = "select * from STOCK1 where MedicineName like '%" + txtSearch.Text + "%'";
                    SqlCommand cmd = new SqlCommand(q,con);
                     cmd.ExecuteNonQuery();
                     DataTable dt = new DataTable();
                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                     da.Fill(dt);
                    table1.DataSource = dt;
                    rid = int.Parse(table1.Rows[r].Cells[0].Value.ToString());
                    fcode = rid.ToString();
                    txtName.Text = table1.Rows[r].Cells[1].Value.ToString();
                    txtPrice.Text = table1.Rows[r].Cells[7].Value.ToString();
                    txtType.Text = table1.Rows[r].Cells[4].Value.ToString();
                    txtQuantity.Text = "1";
                    txtQuantity.Focus();
                }
            }
            else
            {
                MessageBox.Show("Medicine does not exist");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True");
            con.Open();
            if ( txtName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "" || txtType.Text == "")
            {
                MessageBox.Show("Please select a medicine to add");
            }
            else 
            {
                double price, quantity, total;
                price = Convert.ToDouble(txtPrice.Text.Trim());
                quantity = Convert.ToDouble(txtQuantity.Text.Trim());
                total = price * quantity;
                txtTotal.Text = total.ToString();
                int qty = 0;
                string r = "select * from STOCK1 where MedicineName='" + txtName.Text + "'";
                SqlCommand cmd3 = new SqlCommand(r, con);
                cmd3.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                da.Fill(dt);
                table1.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    qty = Convert.ToInt32(dr["Quantity"].ToString());
                }
                if (qty > 0)
                {
                    string q = "insert into Bill(MedicineName,Quantity,Price,MedicineType)values('" + txtName.Text + "','" + txtQuantity.Text + "' ,'" + txtPrice.Text + "','" + txtType.Text + "')";
                    string w = "update Bill set TotalPrice=Price*Quantity";
                    string v = "update STOCK1 set Quantity=(Quantity -'" + txtQuantity.Text + "') where MedicineName='" + txtName.Text + "'";

                    SqlCommand cmd4 = new SqlCommand(q, con);
                    cmd4.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand(w, con);
                    cmd2.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand(v, con);
                    cmd1.ExecuteNonQuery();
                    
                    for (int i = 0; i <= table2.Rows.Count - 1; ++i)
                    {
                        int a = int.Parse(txtTotal.Text);
                        int b = Convert.ToInt32(table2.Rows[i].Cells[4].Value);
                        int c = a + b;
                        txtTotal.Text = c.ToString();
                    }
            
                    table2.Sort(table2.Columns[0], ListSortDirection.Ascending);
                    cleartext();
                    disp();
                }
                else                
                {
                    MessageBox.Show("Medicine not available");
                    string q = "delete from STOCK1 where Quantity=0 or Quantity<0";
                    SqlCommand cmd5 = new SqlCommand(q, con);
                    cmd5.ExecuteNonQuery();
                    cleartext();
                    disp();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-594UGPP\SQLEXPRESS;Initial Catalog=medsto2;Integrated Security=True");
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string w = "delete  from Bill";
                SqlCommand cmd1 = new SqlCommand(w, con);
                cmd1.ExecuteNonQuery();
                table2.Sort(table2.Columns[0], ListSortDirection.Ascending);
                cleartext1();
                disp();

            }
        }

        private void txtType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void table2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = table1.DataSource;
            bs.Filter = table1.Columns[1].HeaderText.ToString() + " LIKE '%" + txtSearch.Text + "%'";
            table1.DataSource = bs;
        }
    }
    }

    


