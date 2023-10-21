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

namespace Pharmacy2
{
    public partial class Manufacturer : Form
    {
        public Manufacturer()
        {
            InitializeComponent();
            ShowDGV();
            GetManufacturerName();
            Reset();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kwame\Desktop\Major\Pharmacy2\Pharmacy2.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowDGV()
        {
            Con.Open();
            string querry = "Select * from ManuTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            ManuListDGV.DataSource = ds.Tables[0];
            this.ManuListDGV.Sort(this.ManuListDGV.Columns["ManName"], ListSortDirection.Ascending);
            Con.Close();

        }

        private void Reset()
        {
            ManNameCb.SelectedIndex = -1;
            ManAddTb.Text = "";
            ManPhoneTb.Text = "";
            ManJDateCb.Value = DateTime.Today;
            key = 0;
        }

        private void GetManufacturerName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select ManName from ManuTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ManName", typeof(string));
            dt.Load(Rdr);
            ManNameCb.ValueMember = "ManName";
            ManNameCb.DataSource = dt;
            ManNameCb.SelectedIndex = -1;
            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ManNameCb.Text == "" || ManAddTb.Text == "" || ManPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (ManNameCb.Text == ManuListDGV.CurrentRow.Cells[1].Value.ToString())
            {
                MessageBox.Show("Manufacturer already Exists");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ManuTbl (ManName, ManAdd, ManPhone, ManDate) values (@MN, @MA, @MP, @MJD)", Con);
                    cmd.Parameters.AddWithValue("@MN", ManNameCb.Text);
                    cmd.Parameters.AddWithValue("@MA", ManAddTb.Text);
                    cmd.Parameters.AddWithValue("@MP", ManPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@MJD", ManJDateCb.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufacturer Added");
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int key = 0;
        private void ManuListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ManNameCb.Text = ManuListDGV.SelectedRows[0].Cells[1].Value.ToString();
            //ManAddTb.Text = ManuListDGV.SelectedRows[0].Cells[2].Value.ToString();
            //ManPhoneTb.Text = ManuListDGV.SelectedRows[0].Cells[3].Value.ToString();
            //ManJDateCb.Text = ManuListDGV.SelectedRows[0].Cells[4].Value.ToString();
            //if (ManNameCb.Text == "")
            //{
            //    key = 0;
            //}
            //else
            //{
            //    key = Convert.ToInt32(ManuListDGV.SelectedRows[0].Cells[0].Value.ToString());
            //}
        }

        private void ManuListDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ManNameCb.Text = ManuListDGV.SelectedRows[0].Cells[1].Value.ToString();
            ManAddTb.Text = ManuListDGV.SelectedRows[0].Cells[2].Value.ToString();
            ManPhoneTb.Text = ManuListDGV.SelectedRows[0].Cells[3].Value.ToString();
            ManJDateCb.Text = ManuListDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (ManNameCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ManuListDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Manufacturer to Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ManuTbl where ManId = @key", Con);
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufacturer Deleted");
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
            if (ManNameCb.Text == "" || ManAddTb.Text == "" || ManPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ManuTbl set ManName=@MN, ManAdd=@MA, ManPhone=@MP, ManDate=@MJD where ManId=@Mkey", Con);
                    cmd.Parameters.AddWithValue("@MN", ManNameCb.Text);
                    cmd.Parameters.AddWithValue("@MA", ManAddTb.Text);
                    cmd.Parameters.AddWithValue("@MP", ManPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@MJD", ManJDateCb.Value.Date);
                    cmd.Parameters.AddWithValue("@Mkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufacturer Updated");
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

        private void MedLbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicine f2 = new Medicine();
            f2.Show();
        }

        private void CustLbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer f2 = new Customer();
            f2.Show();
        }

        private void SLbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seller f2 = new Seller();
            f2.Show();
        }

        private void BLbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sellings f2 = new Sellings();
            f2.Show();
        }

        private void ManNameCb_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ManuListDGV.Rows)
            {
                // Test if the MedName column of the current row equals
                // the value in the text box
                if ((string)row.Cells[1].Value == ManNameCb.Text)
                {
                    // we have a match
                    row.Selected = true;
                    ManNameCb.Text = ManuListDGV.SelectedRows[0].Cells[1].Value.ToString();
                    ManAddTb.Text = ManuListDGV.SelectedRows[0].Cells[2].Value.ToString();
                    ManPhoneTb.Text = ManuListDGV.SelectedRows[0].Cells[3].Value.ToString();
                    ManJDateCb.Text = ManuListDGV.SelectedRows[0].Cells[4].Value.ToString();
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

        private void ManNameCb_TextChanged(object sender, EventArgs e)
        {
            ManAddTb.Text = "";
            ManPhoneTb.Text = "";
            ManJDateCb.Value = DateTime.Today;
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.Show();
        }
    }
}
