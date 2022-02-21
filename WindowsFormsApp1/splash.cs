using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //chrono -= 1;
            count += 1;
            myProgress.Value = count;
            label2.Text =count+ "%";
            //TimeLbl.Text = "" + chrono;
            if (myProgress.Value == 100)
            {
                myProgress.Value = 0;
                timer1.Stop();
                //MessageBox.Show("Time Over");
                login log = new login();
                log.Show();
                this.Hide();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
