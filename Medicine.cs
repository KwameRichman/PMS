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
    public partial class Medicine : Form
    {
        public Medicine()
        {
            InitializeComponent();
            ShowDGV();
            GetManufacturerId();
            GetMedName();
            Reset();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kwame\Desktop\Major\Pharmacy2\Pharmacy2.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowDGV()
        {
            Con.Open();
            string querry = "Select * from MedicineTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            MedStockDGV.DataSource = ds.Tables[0];
            this.MedStockDGV.Sort(this.MedStockDGV.Columns["MedName"], ListSortDirection.Ascending);
            Con.Close();

        }

        private void Reset()
        {
            MedNameCb.SelectedIndex = -1;
            MedQtyTb.Text = "";
            MedPriceTb.Text = "";
            ManuCb.SelectedIndex = -1;
            MedTypeCb.SelectedIndex = -1;
            ManNameTb.Text = "";
            key = 0;
        }

        private void GetManufacturerId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select ManName from ManuTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ManName", typeof(string));
            dt.Load(Rdr);
            ManuCb.ValueMember = "ManName";
            ManuCb.DataSource = dt;
            ManuCb.SelectedIndex = -1;
            Con.Close();
        }

        private void GetManufacturerName()
        {
            Con.Open();
            string Query = "select * from ManuTbl where ManName = '" + ManuCb.SelectedValue.ToString() + "' ";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ManNameTb.Text = dr["ManId"].ToString();
            }
            Con.Close();
        }

        private void GetMedName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MedName from MedicineTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MedName", typeof(string));
            dt.Load(Rdr);
            MedNameCb.ValueMember = "MedName";
            MedNameCb.DataSource = dt;
            MedNameCb.SelectedIndex = -1;
            Con.Close();
        }

        private void CheckDuplicates()
        {
            for (int Med = 0; Med < MedStockDGV.Rows.Count; Med++)
            {
                if (MedNameCb.Text == MedStockDGV.Rows[Med].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Medicine is already Available");
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (MedNameCb.Text == "" || MedQtyTb.Text == "" || MedPriceTb.Text == "" || MedTypeCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else if (MedNameCb.Text == MedStockDGV.CurrentRow.Cells[1].Value.ToString())
            {
                MessageBox.Show("Medicine is already Available");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into MedicineTbl (MedName, MedType, MedQty, MedPrice, MedManId, MedMan) values (@MN, @MT, @MQ, @MP, @MMI, @MM)", Con);
                    cmd.Parameters.AddWithValue("@MN", MedNameCb.Text);
                    cmd.Parameters.AddWithValue("@MT", MedTypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ", MedQtyTb.Text);
                    cmd.Parameters.AddWithValue("@MP", MedPriceTb.Text);
                    cmd.Parameters.AddWithValue("@MM", ManuCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MMI", ManNameTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine Added");
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

        private void ManuCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetManufacturerName();
        }

        int key = 0;
        private void MedStockDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MedNameCb.Text = MedStockDGV.SelectedRows[0].Cells[1].Value.ToString();
            MedTypeCb.SelectedItem = MedStockDGV.SelectedRows[0].Cells[2].Value.ToString();
            MedQtyTb.Text = MedStockDGV.SelectedRows[0].Cells[3].Value.ToString();
            MedPriceTb.Text = MedStockDGV.SelectedRows[0].Cells[4].Value.ToString();
            ManNameTb.Text = MedStockDGV.SelectedRows[0].Cells[5].Value.ToString();
            ManuCb.SelectedValue = MedStockDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (MedNameCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MedStockDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manufacturer f2 = new Manufacturer();
            f2.Show();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Medicine to Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from MedicineTbl where MedNum = @key", Con);
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine Deleted");
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
            if (MedNameCb.Text == "" || MedQtyTb.Text == "" || MedPriceTb.Text == "" || MedTypeCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update MedicineTbl set MedName=@MN, MedType=@MT, MedQty=@MQ, MedPrice=@MP, MedManId=@MMI, MedMan=@MM where MedNum=@Mkey ", Con);
                    cmd.Parameters.AddWithValue("@MN", MedNameCb.Text);
                    cmd.Parameters.AddWithValue("@MT", MedTypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ", MedQtyTb.Text);
                    cmd.Parameters.AddWithValue("@MP", MedPriceTb.Text);
                    cmd.Parameters.AddWithValue("@MM", ManuCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MMI", ManNameTb.Text);
                    cmd.Parameters.AddWithValue("@Mkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine Updated");
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

        private void MedQtyTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void MedQtyTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void MedPriceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void MedPriceTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void MedNameCb_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MedStockDGV.Rows)
            {
                // Test if the MedName column of the current row equals
                // the value in the text box
                if ((string)row.Cells[1].Value == MedNameCb.Text)
                {
                    // we have a match
                    row.Selected = true;
                    MedNameCb.Text = MedStockDGV.SelectedRows[0].Cells[1].Value.ToString();
                    MedTypeCb.SelectedItem = MedStockDGV.SelectedRows[0].Cells[2].Value.ToString();
                    MedQtyTb.Text = MedStockDGV.SelectedRows[0].Cells[3].Value.ToString();
                    MedPriceTb.Text = MedStockDGV.SelectedRows[0].Cells[4].Value.ToString();
                    ManNameTb.Text = MedStockDGV.SelectedRows[0].Cells[5].Value.ToString();
                    ManuCb.SelectedValue = MedStockDGV.SelectedRows[0].Cells[6].Value.ToString();
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

        private void MedNameCb_TextChanged(object sender, EventArgs e)
        {
            MedQtyTb.Text = "";
            MedPriceTb.Text = "";
            ManuCb.SelectedIndex = -1;
            MedTypeCb.SelectedIndex = -1;
            ManNameTb.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.Show();
        }

        private void MedStockDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != this.MedStockDGV.NewRowIndex)
            {
                if (MedStockDGV.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    double val1 = double.Parse(e.Value.ToString());
                    e.Value = val1.ToString("N2");
                }
            }
        }

        private void ManuCb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (MedNameCb.Text == "")
            {
                foreach (DataGridViewRow row in MedStockDGV.Rows)
                {
                    // Test if the MedName column of the current row equals
                    // the value in the text box
                    if ((string)row.Cells[6].Value == ManuCb.Text)
                    {
                        // we have a match
                        row.Selected = true;
                    }
                    else
                    {
                        row.Selected = false;
                    }
                }
            }
            
        }
    }
}
