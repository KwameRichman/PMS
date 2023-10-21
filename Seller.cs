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
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
            ShowDGV();
            GetSellerName();
            Reset();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kwame\Desktop\Major\Pharmacy2\Pharmacy2.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowDGV()
        {
            Con.Open();
            string querry = "Select * from SellerTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            SListDGV.DataSource = ds.Tables[0];
            //this.SListDGV.Sort(this.SListDGV.Columns["SName"], ListSortDirection.Ascending);
            Con.Close();

        }

        private void Reset()
        {
            SNameCb.SelectedIndex = -1;
            SAddTb.Text = "";
            SPhoneTb.Text = "";
            SGenCb.SelectedIndex = -1;
            SPassTb.Text = "";
            SDOBCb.Value = DateTime.Today;
            key = 0;
        }

        private void GetSellerName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select SName from SellerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(string));
            dt.Load(Rdr);
            SNameCb.ValueMember = "SName";
            SNameCb.DataSource = dt;
            SNameCb.SelectedIndex = -1;
            Con.Close();
        }

        int key = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SNameCb.Text == "" || SAddTb.Text == "" || SPhoneTb.Text == "" || SGenCb.SelectedIndex == -1 || SPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (SNameCb.Text == SListDGV.CurrentRow.Cells[1].Value.ToString())
            {
                MessageBox.Show("Seller already Exists");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SellerTbl (SName, SAdd, SPhone, SDOB, SGen, SPass) values (@SN, @SA, @SP, @SDOB, @SG, @SPA)", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameCb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SPA", SPassTb.Text);
                    cmd.Parameters.AddWithValue("@SDOB", SDOBCb.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", SGenCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Added");
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
            if (SNameCb.Text == "" || SAddTb.Text == "" || SPhoneTb.Text == "" || SGenCb.SelectedIndex == -1 || SPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update SellerTbl set SName=@SN, SAdd=@SA, SPhone=@SP, SDOB=@SDOB, SGen=@SG, SPass=@SPA where SNum=@Skey", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameCb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SPA", SPassTb.Text);
                    cmd.Parameters.AddWithValue("@SDOB", SDOBCb.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", SGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Skey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Updated");
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

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Seller to Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from SellerTbl where SNum = @key", Con);
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted");
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

        private void SListDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SNameCb.Text = SListDGV.SelectedRows[0].Cells[1].Value.ToString();
            SDOBCb.Text = SListDGV.SelectedRows[0].Cells[2].Value.ToString();
            SAddTb.Text = SListDGV.SelectedRows[0].Cells[4].Value.ToString();
            SPhoneTb.Text = SListDGV.SelectedRows[0].Cells[3].Value.ToString();
            SGenCb.Text = SListDGV.SelectedRows[0].Cells[5].Value.ToString();
            SPassTb.Text = SListDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (SNameCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(SListDGV.SelectedRows[0].Cells[0].Value.ToString());
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

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer f2 = new Customer();
            f2.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sellings f2 = new Sellings();
            f2.Show();
        }

        private void SNameCb_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in SListDGV.Rows)
            {
                // Test if the MedName column of the current row equals
                // the value in the text box
                if ((string)row.Cells[1].Value == SNameCb.Text)
                {
                    // we have a match
                    row.Selected = true;
                    SNameCb.Text = SListDGV.SelectedRows[0].Cells[1].Value.ToString();
                    SDOBCb.Text = SListDGV.SelectedRows[0].Cells[2].Value.ToString();
                    SAddTb.Text = SListDGV.SelectedRows[0].Cells[4].Value.ToString();
                    SPhoneTb.Text = SListDGV.SelectedRows[0].Cells[3].Value.ToString();
                    SGenCb.Text = SListDGV.SelectedRows[0].Cells[5].Value.ToString();
                    SPassTb.Text = SListDGV.SelectedRows[0].Cells[6].Value.ToString();
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

        private void SNameCb_TextChanged(object sender, EventArgs e)
        {
            SAddTb.Text = "";
            SPhoneTb.Text = "";
            SGenCb.SelectedIndex = -1;
            SPassTb.Text = "";
            SDOBCb.Value = DateTime.Today;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.Show();
        }
    }
}
