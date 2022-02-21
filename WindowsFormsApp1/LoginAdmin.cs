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
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(password.Text == "")
            {
                MessageBox.Show("Entrez Votre Mot De Passe");
            }
            else if(password.Text == "password")
            {
                Questions obj = new Questions();
                obj.Show();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Verifiez Votre Mot De Passe");
                password.Text = "";
            }
        }
    }
}
