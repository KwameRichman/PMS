using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy2
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (MyProgressBar.Value < 100)
            {
                MyProgressBar.Value += 1;
                MyProgressBar.Style = ProgressBarStyle.Blocks;
                label2.Text = MyProgressBar.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Hide();
                Login f2 = new Login();
                f2.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
