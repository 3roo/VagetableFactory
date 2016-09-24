using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegetableFactory
{
    public partial class FrmSetUp : Form
    {
        public FrmSetUp()
        {
            InitializeComponent();
            this.Timer_Clock.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Clock_Tick(object sender, EventArgs e)
        {
            string dt = DateTime.Now.ToString();
            this.lbldt2.Text = dt;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMain.backToMain.Show();
        }
    }
}
