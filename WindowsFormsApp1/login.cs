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

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            GetSubjects();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UJ3VNRC\SQLEXPRESS;Initial Catalog=GestionQuiz;Integrated Security=True");
        public static string CandName = "", SubName="";
        private void GetSubjects()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select SName from SubjectTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(string));
            dt.Load(rdr);
            SubjectCB.ValueMember = "SName";
            SubjectCB.DataSource = dt;
            con.Close();
        }

        private void nom_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginAd_Click(object sender, EventArgs e)
        {
            LoginAdmin obj = new LoginAdmin();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SubjectCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nom.Text== "" || password.Text == "")
            {
                MessageBox.Show("Vérifier les champs");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CondidateTbl where cpass='"+password.Text+"' and CName='"+nom.Text+"' ",con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    CandName = nom.Text;
                    SubName = SubjectCB.SelectedValue.ToString();
                    Examens obj = new Examens();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Erreur nom ou mot de passe");
                }
                con.Close();
            }
        }
    }
}
