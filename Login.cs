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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kwame\Desktop\Major\Pharmacy2\Pharmacy2.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static string User;
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter Username and/or Password");
            }
            else
            {
                Con.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from SellerTbl where SName = '" + UNameTb.Text + "' and SPass = '" + PassTb.Text + "' ", Con);
                SqlCommand cmd = new SqlCommand("select * from SellerTbl where SName='" + UNameTb.Text + "' and SPass='" + PassTb.Text + "'", Con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    if (UNameTb.Text == "Prince" && PassTb.Text == "Obeng")
                    {
                        User = UNameTb.Text;
                        Dashboard Obj = new Dashboard();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        User = UNameTb.Text;
                        Sellings Obj = new Sellings();
                        Obj.Show();
                        this.Hide();


                    }
                }

                else
                {
                    dr.Close();
                    MessageBox.Show("Wrong Username and/or Password");
                }
                Con.Close();


            }


        }
    }
}
