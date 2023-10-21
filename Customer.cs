using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy2
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            ShowDGV();
            GetCustomerName();
            Reset();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kwame\Desktop\Major\Pharmacy2\Pharmacy2.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowDGV()
        {
            Con.Open();
            string querry = "Select * from CustomerTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            CustListDGV.DataSource = ds.Tables[0];
            this.CustListDGV.Sort(this.CustListDGV.Columns["CustName"], ListSortDirection.Ascending);
            Con.Close();
        }

        private void Reset()
        {
            CustNameCb.SelectedIndex = -1;
            CustAddTb.Text = "";
            CustPhoneTb.Text = "";
            CustGenCb.SelectedIndex = -1;
            CustDOBCb.Value = DateTime.Today;
            key = 0;
        }

        private void GetCustomerName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustName from CustomerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustName", typeof(string));
            dt.Load(Rdr);
            CustNameCb.ValueMember = "CustName";
            CustNameCb.DataSource = dt;
            CustNameCb.SelectedIndex = -1;
            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustNameCb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "" || CustGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else if (CustNameCb.Text == CustListDGV.CurrentRow.Cells[1].Value.ToString())
            {
                MessageBox.Show("Customer already Exists");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl (CustName, CustAdd, CustPhone, CustDOB, CustGen) values (@CN, @CA, @CP, @CDOB, @CG)", Con);
                    cmd.Parameters.AddWithValue("@CN", CustNameCb.Text);
                    cmd.Parameters.AddWithValue("@CA", CustAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CustPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CDOB", CustDOBCb.Value.Date);
                    cmd.Parameters.AddWithValue("@CG", CustGenCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added");
                    Con.Close();
                    ShowDGV();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Customer to Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CustNum = @key", Con);
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted");
                    Con.Close();
                    ShowDGV();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CustNameCb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "" || CustGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update CustomerTbl set CustName=@CN, CustAdd=@CA, CustPhone=@CP, CustDOB=@CDOB, CustGen=@CG where CustNum=@Ckey", Con);
                    cmd.Parameters.AddWithValue("@CN", CustNameCb.Text);
                    cmd.Parameters.AddWithValue("@CA", CustAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CustPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CDOB", CustDOBCb.Value.Date);
                    cmd.Parameters.AddWithValue("@CG", CustGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Ckey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated");
                    Con.Close();
                    ShowDGV();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void CustListDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CustNameCb.Text = CustListDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustDOBCb.Text = CustListDGV.SelectedRows[0].Cells[5].Value.ToString();
            CustAddTb.Text = CustListDGV.SelectedRows[0].Cells[2].Value.ToString();
            CustPhoneTb.Text = CustListDGV.SelectedRows[0].Cells[3].Value.ToString();
            CustGenCb.Text = CustListDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (CustNameCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustListDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicine f2 = new Medicine();
            f2.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manufacturer f2 = new Manufacturer();
            f2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seller f2 = new Seller();
            f2.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sellings f2 = new Sellings();
            f2.Show();
        }

        private void CustNameCb_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in CustListDGV.Rows)
            {
                // Test if the MedName column of the current row equals
                // the value in the text box
                if ((string)row.Cells[1].Value == CustNameCb.Text)
                {
                    // we have a match
                    row.Selected = true;
                    CustNameCb.Text = CustListDGV.SelectedRows[0].Cells[1].Value.ToString();
                    CustDOBCb.Text = CustListDGV.SelectedRows[0].Cells[5].Value.ToString();
                    CustAddTb.Text = CustListDGV.SelectedRows[0].Cells[2].Value.ToString();
                    CustPhoneTb.Text = CustListDGV.SelectedRows[0].Cells[3].Value.ToString();
                    CustGenCb.Text = CustListDGV.SelectedRows[0].Cells[4].Value.ToString();
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustNameCb_TextChanged(object sender, EventArgs e)
        {
            CustAddTb.Text = "";
            CustPhoneTb.Text = "";
            CustGenCb.SelectedIndex = -1;
            CustDOBCb.Value = DateTime.Today;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.Show();
        }
    }
}
