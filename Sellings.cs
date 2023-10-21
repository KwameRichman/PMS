using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pharmacy2
{
    public partial class Sellings : Form
    {
        public Sellings()
        {
            InitializeComponent();
            ShowDGV();
            GetCustomerName();
            GetMedName();
            ResetPage();

            ShowBill();
            SNameTb.Text = Login.User;
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
            MedListCb.SelectedIndex = -1;
            MedQtyTb.Text = "";
            MedPriceTb.Text = "";
            OldCustCb.SelectedIndex = -1;
            CustIdTb.Text = "";
        }

        private void ResetPage()
        {
            MedListCb.SelectedIndex = -1;
            MedQtyTb.Text = "";
            MedPriceTb.Text = "";
            OldCustCb.SelectedIndex = -1;
        }

        private void UpdateQty()
        {
            try
            {
                float NewQty = Convert.ToSingle(stock) - Convert.ToSingle(MedQtyTb.Text);
                Con.Open();
                SqlCommand cmd = new SqlCommand("update MedicineTbl set MedQty=@MQ where MedNum=@Mkey ", Con);
                cmd.Parameters.AddWithValue("@MQ", NewQty);
                cmd.Parameters.AddWithValue("@Mkey", key);
                cmd.ExecuteNonQuery();
                Con.Close();
                ShowDGV();
                Reset();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
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
            OldCustCb.ValueMember = "CustName";
            OldCustCb.DataSource = dt;
            OldCustCb.SelectedIndex = 1;
            Con.Close();
        }

        private void GetCustomerId()
        {
            Con.Open();
            string Query = "select * from CustomerTbl where CustName = '" + OldCustCb.SelectedValue.ToString() + "' ";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustIdTb.Text = dr["CustNum"].ToString();
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
            MedListCb.ValueMember = "MedName";
            MedListCb.DataSource = dt;
            MedListCb.SelectedIndex = -1;
            Con.Close();
        }

        private void AddToBill()
        {
            if (OldCustCb.Text == "")
            {

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BillTbl (SName, CustNum, CustName, BDate, BAmount) values (@SN, @CN, @OCN, @BD, @BA)", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@CN", CustIdTb.Text);
                    cmd.Parameters.AddWithValue("@OCN", OldCustCb.Text);
                    cmd.Parameters.AddWithValue("@BD", DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("@BA", GrndTotal);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    ShowBill();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

                int nRowIndex = TransDGV.Rows.Count - 1;
                int nColumnIndex = 3;

                TransDGV.Rows[nRowIndex].Selected = true;
                TransDGV.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                RNoLbl.Text = TransDGV.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void ShowBill()
        {
            Con.Open();
            string querry = "Select * from BillTbl where SName = '" + SNameTb.Text + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            TransDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Sellings_Load(object sender, EventArgs e)
        {
            ShowBill();

            if (SNameTb.Text == "Prince")
            {

            }
            else
            {
                DashboardBtn.Enabled = false;
                SellersLbl.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
            }
        }

        int key = 0;
        float stock = 0;
        private void MedStockDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MedListCb.Text = MedStockDGV.SelectedRows[0].Cells[1].Value.ToString();
            stock = Convert.ToSingle(MedStockDGV.SelectedRows[0].Cells[3].Value.ToString());
            MedPriceTb.Text = MedStockDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (MedListCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MedStockDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        int n = 0; float GrndTotal = 0;
        private void AddBillBtn_Click(object sender, EventArgs e)
        {
            if (MedQtyTb.Text == "" || Convert.ToSingle(MedQtyTb.Text) > stock || MedPriceTb.Text == "")
            {
                MessageBox.Show("Enter Correct Quantity and/or Medicine");
                Reset();
            }
            else
            {

                n += 1;
                bool Found = false;
                if (BillListDGV.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in BillListDGV.Rows)
                    {
                        if (row.Cells[1].Value.ToString() == MedListCb.Text && row.Cells[3].Value.ToString() == MedPriceTb.Text)
                        {
                            row.Cells[2].Value = Convert.ToString(Convert.ToSingle(MedQtyTb.Text) + Convert.ToSingle(row.Cells[2].Value));
                            Found = true;
                        }
                    }
                    if (!Found)
                    {

                        BillListDGV.Rows.Add(n, MedListCb.Text, MedQtyTb.Text, MedPriceTb.Text);
                    }
                }
                else
                {
                    BillListDGV.Rows.Add(n, MedListCb.Text, MedQtyTb.Text, MedPriceTb.Text);
                }

                foreach (DataGridViewRow row in BillListDGV.Rows)
                {
                    row.Cells[4].Value = (Convert.ToSingle(row.Cells[3].Value)) * (Convert.ToSingle(row.Cells[2].Value));
                }

                TotalLbl.Text = "0";
                for (int i = 0; i < BillListDGV.Rows.Count; i++)
                {
                    TotalLbl.Text = Convert.ToString(Convert.ToSingle(TotalLbl.Text) + Convert.ToSingle(BillListDGV.Rows[i].Cells[4].Value.ToString()));

                    GrndTotal = Convert.ToSingle(TotalLbl.Text);
                    GrandTotalLbl.Text = "GH¢" + GrndTotal.ToString("0.00");
                }

                UpdateQty();
            }
            n++;
            //Creating a barcode
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            BarcodePb.Image = barcode.Draw(GrndTotal.ToString(), 50);
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (BillListDGV.Rows.Count < 0 || MedQtyTb.Text == "" || MedListCb.Text == "")
            {
                MessageBox.Show("Select Item");
            }
            else
            {
                float total = Convert.ToSingle(BillListDGV.CurrentRow.Cells[4].Value);
                GrndTotal = GrndTotal - Convert.ToSingle(total);
                GrandTotalLbl.Text = "GH¢" + GrndTotal.ToString("0.00");

                foreach (DataGridViewRow row in MedStockDGV.Rows)
                {
                    if (row.Cells[1].Value.ToString() == MedListCb.Text && row.Cells[4].Value.ToString() == MedPriceTb.Text)
                    {
                        row.Cells[3].Value = Convert.ToString(Convert.ToSingle(MedQtyTb.Text) + Convert.ToSingle(row.Cells[3].Value));
                        //Found = true;

                        try
                        {
                            Con.Open();
                            SqlCommand cmd = new SqlCommand("update MedicineTbl set MedName=@MN, MedQty=@MQ, MedPrice=@MP where MedNum=@Mkey ", Con);
                            cmd.Parameters.AddWithValue("@MN", MedListCb.Text);
                            cmd.Parameters.AddWithValue("@MQ", row.Cells[3].Value);
                            cmd.Parameters.AddWithValue("@MP", MedPriceTb.Text);
                            cmd.Parameters.AddWithValue("@Mkey", key);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Medicine Removed");
                            Con.Close();
                            ShowDGV();
                        }
                        catch (Exception Ex)
                        {

                            MessageBox.Show(Ex.Message);
                        }
                    }
                }


                int rowIndex = BillListDGV.CurrentCell.RowIndex;
                BillListDGV.Rows.RemoveAt(rowIndex);

                Reset();
                BillListDGV.Refresh();
                BillListDGV.Update();
            }

        }

        int MedId;
        int pos = 60;
        float MedPrice, MedTot, MedQty;
        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (BillListDGV.Rows.Count < 1)
            {
                MessageBox.Show("Add to Bill.");
            }
            else if (OldCustCb.Text == "" || CustIdTb.Text == "")
            {
                MessageBox.Show("Add Customer Name or ID.");
            }
            else
            {
                AddToBill();
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprm", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }

            }

            GrandTotalLbl.Text = "GH¢0.00";

        }

        private void MedQtyTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
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
        string MedName = "";
        int longpaper;
        private void ChangeLongPaper()
        {
            int rowcount;
            longpaper = 0;
            rowcount = BillListDGV.Rows.Count;
            longpaper = rowcount * 55;
            longpaper += 220;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f8 = new("Calibri", 8, FontStyle.Regular);
            Font f8b = new("Calibri", 8, FontStyle.Bold);
            Font f8i = new("Calibri", 8, FontStyle.Italic);
            Font f10 = new("Calibri", 10, FontStyle.Regular);
            Font f10b = new("Calibri", 10, FontStyle.Bold);
            Font f10i = new("Calibri", 10, FontStyle.Italic);
            Font f14 = new("Calibri", 14, FontStyle.Regular);

            int LeftMargin = printDocument1.DefaultPageSettings.Margins.Left;
            int CenterMargin = printDocument1.DefaultPageSettings.PaperSize.Width / 2;
            int RightMargin = printDocument1.DefaultPageSettings.PaperSize.Width;

            //FONT ALIGNMENT
            StringFormat Right = new StringFormat();
            StringFormat Center = new StringFormat();
            Right.Alignment = StringAlignment.Far;
            Center.Alignment = StringAlignment.Center;

            string line;
            line = "-----------------------------------------------------------------------------------------------";
            e.Graphics.DrawString("BETHEL", f14, Brushes.Black, CenterMargin, 5, Center);
            e.Graphics.DrawString("CHEMIST LIMITED", f14, Brushes.Black, CenterMargin, 20, Center);
            e.Graphics.DrawString("kotobabi Road, Accra, Ghana", f10, Brushes.Black, CenterMargin, 40, Center);
            e.Graphics.DrawString("Tel: +233244711751", f8, Brushes.Black, CenterMargin, 55, Center);

            e.Graphics.DrawString("" + DateTime.Now + "", f8, Brushes.Black, 0, 70);
            e.Graphics.DrawString("Receipt No.: " + RNoLbl.Text + " ", f8, Brushes.Black, 0, 80);
            e.Graphics.DrawString("PAID BY: " + OldCustCb.Text + " ", f8, Brushes.Black, 145, 70);
            e.Graphics.DrawString("Seller: " + SNameTb.Text + " ", f8, Brushes.Black, 145, 80);

            e.Graphics.DrawString(line, f8, Brushes.Black, 0, 90);

            e.Graphics.DrawString("Qty", f8b, Brushes.Black, 0, 100);
            e.Graphics.DrawString("Item", f8b, Brushes.Black, 30, 100);
            e.Graphics.DrawString("Price", f8b, Brushes.Black, 200, 100);
            e.Graphics.DrawString("Total", f8b, Brushes.Black, RightMargin, 100, Right);

            e.Graphics.DrawString(line, f8, Brushes.Black, 0, 110);

            int height = 0;
            BillListDGV.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in BillListDGV.Rows)
            {
                height += 15;
                //MedId = Convert.ToInt32(row.Cells["Column1"].Value);
                MedName = "" + row.Cells["Column2"].Value;
                MedPrice = Convert.ToSingle(row.Cells["Column4"].Value);
                MedQty = Convert.ToSingle(row.Cells["Column3"].Value);
                MedTot = Convert.ToSingle(row.Cells["Column5"].Value);
                //e.Graphics.DrawString("" + MedId, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(26, pos));
                e.Graphics.DrawString("" + MedName, f8, Brushes.Black, 30, 120 + height);
                e.Graphics.DrawString("" + MedPrice.ToString("0.00"), f8, Brushes.Black, 200, 120 + height);
                e.Graphics.DrawString("" + MedQty, f8, Brushes.Black, 7, 120 + height, Center);
                e.Graphics.DrawString("" + MedTot.ToString("0.00"), f8, Brushes.Black, RightMargin, 120 + height, Right);
            }

            int height2;
            height2 = 135 + height;
            e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2);
            e.Graphics.DrawString("Total: " + GrandTotalLbl.Text + "", f10b, Brushes.Black, RightMargin, 15 + height2, Right);

            Bitmap bmp = new Bitmap(BarcodePb.Width, BarcodePb.Height);
            BarcodePb.DrawToBitmap(bmp, new Rectangle(0, 0, BarcodePb.Width, BarcodePb.Height));
            e.Graphics.DrawImage(bmp, 70, 40 + height2);
            bmp.Dispose();

            e.Graphics.DrawString("~Thank you for buying from us~", f10i, Brushes.Black, CenterMargin, 70 + height2, Center);
            e.Graphics.DrawString("~HAVE A NICE DAY ;)~", f10i, Brushes.Black, CenterMargin, 90 + height2, Center);
            e.Graphics.DrawString("~BETHEL CHEMIST LIMITED~", f10i, Brushes.Black, CenterMargin, 110 + height2, Center);

            BillListDGV.Rows.Clear();
            BillListDGV.Refresh();
            GrndTotal = 0;
            TotalLbl.Text = "GH¢" + GrndTotal.ToString("0.00");
        }

        private void BillListDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MedListCb.Text = BillListDGV.SelectedRows[0].Cells[1].Value.ToString();
            MedQtyTb.Text = BillListDGV.SelectedRows[0].Cells[2].Value.ToString();
            MedPriceTb.Text = BillListDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (MedListCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(MedStockDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void MedListCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MedListCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void MedListCb_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MedStockDGV.Rows)
            {
                // Test if the MedName column of the current row equals
                // the value in the text box
                if ((string)row.Cells[1].Value == MedListCb.Text)
                {
                    // we have a match
                    row.Selected = true;
                    //MedPriceTb.Text = MedStockDGV.SelectedRows[0].Cells[4].Value.ToString();
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void OldCustCb_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void OldCustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustomerId();
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

        private void MedListCb_Leave(object sender, EventArgs e)
        {
        }

        private void MedListCb_TextUpdate(object sender, EventArgs e)
        {
            MedPriceTb.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (BillListDGV.Rows.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Complete Sale or Remove Items");
            }

        }

        private void BillListDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != this.BillListDGV.NewRowIndex)
            {
                if (BillListDGV.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    double val1 = double.Parse(e.Value.ToString());
                    e.Value = val1.ToString("N2");
                }
            }
            if (e.ColumnIndex == 4 && e.RowIndex != this.BillListDGV.NewRowIndex)
            {
                if (BillListDGV.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    double val1 = double.Parse(e.Value.ToString());
                    e.Value = val1.ToString("N2");
                }
            }
        }

        private void MedStockDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != this.MedStockDGV.NewRowIndex)
            {
                if (MedStockDGV.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    double val1 = double.Parse(e.Value.ToString());
                    e.Value = val1.ToString("N2");
                }
            }
        }

        private void BillListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            //PageSettings PageSetup = new PageSettings();
            //PageSetup.PaperSize = new PaperSize("Custom", 290, longpaper);
            //printDocument1.DefaultPageSettings = PageSetup;
        }

        private void RemoveBtn_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void TransDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != this.MedStockDGV.NewRowIndex)
            {
                if (TransDGV.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    double val1 = double.Parse(e.Value.ToString());
                    e.Value = val1.ToString("N2");
                }
            }
        }

        private void CustIdTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
