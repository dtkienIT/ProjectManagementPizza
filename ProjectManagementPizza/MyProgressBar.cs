using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementPizza
{
    public partial class MyProgressBar : Form
    {
        public MyProgressBar()
        {
            InitializeComponent();
        }

        private void MyProgressBar_Load(object sender, EventArgs e)
        {
            myProgBar.Value = 0;
            myProgBar.Maximum = 100;
            myProgBar.Step = 50;
            timer1.Interval = 100;

            timer1.Start();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void myProgBar_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            myProgBar.PerformStep();
            if (myProgBar.Value >= myProgBar.Maximum)
            {
                timer1.Stop();


                this.Hide();
                MenuQuanLi ap = new MenuQuanLi();
                ap.ShowDialog();
                this.Close();
            }
   
        }
    }
}
