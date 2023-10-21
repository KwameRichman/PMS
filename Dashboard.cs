using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pharmacy2
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountMeds();
            CountSellers();
            CountCustomers();
            //SumAmount();
            AutofillBillTbl();
            GetSellerName();
            GetBestSeller();
            GetBestCustomer();
            ShowDGV();
            ShortageLbl.Text = "(" + MedStockDGV.Rows.Count.ToString() + ")";
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kwame\Desktop\Major\Pharmacy2\Pharmacy2.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowDGV()
        {
            Con.Open();
            string querry = "Select * from MedicineTbl where MedQty < 20";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            MedStockDGV.DataSource = ds.Tables[0];
            this.MedStockDGV.Sort(this.MedStockDGV.Columns["MedName"], ListSortDirection.Ascending);
            Con.Close();
        }

        private void AutofillBillTbl()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into BillTbl (SName, CustNum, CustName, BDate, BAmount) values (@SN, @CN, @OCN, @BD, @BA)", Con);
                cmd.Parameters.AddWithValue("@SN", "Mr. Nobody");
                cmd.Parameters.AddWithValue("@CN", 2);
                cmd.Parameters.AddWithValue("@OCN", "Mr. Nobody");
                cmd.Parameters.AddWithValue("@BD", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("@BA", 100);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        private void CountMeds()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select count (*) from MedicineTbl", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            MedNumLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountSellers()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select count (*) from SellerTbl", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            SellerLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountCustomers()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select count (*) from CustomerTbl", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CustLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
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
            SellerNameCb.ValueMember = "SName";
            SellerNameCb.DataSource = dt;
            Con.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SumAmount()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Sum (BAmount) from BillTbl", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //SalesAmountLbl.Text = "GH₵" + dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void SumAmountBySeller()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Sum (BAmount) from BillTbl where SName = '" + SellerNameCb.SelectedValue.ToString() + "' ", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            SellerSalesLbl.Text = "GH₵"+dt.Rows[0][0].ToString()+".00";
            Con.Close();
        }

        private void GetBestSeller()
        {
            try
            {
                Con.Open();
                string querry1 = ("Select Max(BAmount) from BillTbl");
                DataTable dt1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(querry1, Con);
                adapter1.Fill(dt1);
                string querry2 = ("Select SName from BillTbl where BAmount = '" + dt1.Rows[0][0].ToString() + "' ");
                SqlDataAdapter adapter = new SqlDataAdapter(querry2, Con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BestSellerLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetBestCustomer()
        {
            try
            {
                Con.Open();
                string querry1 = ("Select Max(BAmount) from BillTbl");
                DataTable dt1 = new DataTable();
                SqlDataAdapter adapter1 = new SqlDataAdapter(querry1, Con);
                adapter1.Fill(dt1);
                string querry2 = ("Select CustName from BillTbl where BAmount = '" + dt1.Rows[0][0].ToString() + "' ");
                SqlDataAdapter adapter = new SqlDataAdapter(querry2, Con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BestCustLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "Delete from BillTbl ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
            MessageBox.Show("All transactions Cleared.");
            SellerNameCb.SelectedIndex = -1;
        }

        private void SellerNameCb_SelectedValueChanged(object sender, EventArgs e)
        {
            //SumAmountBySeller();
        }

        private void SellerNameCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SumAmountBySeller();
        }
    }
}
