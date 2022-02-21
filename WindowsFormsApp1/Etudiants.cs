using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Etudiants : Form
    {
        public Etudiants()
        {
            InitializeComponent();
            DisplayCandidates();
        }
        private void Rest()
        {
            CNameTb.Text = "";
            CAgeTb.Text = "";
            PhoneTb.Text = "";
            AdressseTb.Text = "";
            PasswordTb.Text = "";
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UJ3VNRC\SQLEXPRESS;Initial Catalog=GestionQuiz;Integrated Security=True");
        private void DisplayCandidates()
        {
            con.Open();
            string Query = "select * from CondidateTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CandidateDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(CNameTb.Text=="" || CAgeTb.Text=="" || PasswordTb.Text=="" || PhoneTb.Text=="" || AdressseTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    int score = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CondidateTbl (CName,CAge,CPass,CScore,CAdd,Cphone) values (@Cn,@Ca,@Cp,@Cs,@Cad,@Cph)", con);
                    cmd.Parameters.AddWithValue("@Cn",CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAgeTb.Text);
                    cmd.Parameters.AddWithValue("@Cp", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@Cs", score);
                    cmd.Parameters.AddWithValue("@Cad", AdressseTb.Text);
                    cmd.Parameters.AddWithValue("@Cph", PhoneTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Candidate save");
                    con.Close();
                    Rest();
                    DisplayCandidates();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void RestBtn_Click(object sender, EventArgs e)
        {
            Rest();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAgeTb.Text == "" || CAgeTb.Text == "Age" || PasswordTb.Text == "" || PhoneTb.Text == "" || AdressseTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    //int score = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update condidateTbl set CName=@Cn, Cage=@Ca, CPass=@Cp,CAdd=@Cad, Cphone=@Cph where Cid=@Ckey", con);
                    cmd.Parameters.AddWithValue("@Cn", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAgeTb.Text);
                    cmd.Parameters.AddWithValue("@Cp", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@Cad", AdressseTb.Text);
                    cmd.Parameters.AddWithValue("@Cph", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Ckey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Candidate updated");
                    con.Close();
                    Rest();
                    DisplayCandidates();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void CandidateDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;
            if (pos != -1)
            {
                CNameTb.Text = CandidateDGV.Rows[pos].Cells[1].Value.ToString();
                CAgeTb.Text = CandidateDGV.Rows[pos].Cells[2].Value.ToString();
                PasswordTb.Text = CandidateDGV.Rows[pos].Cells[3].Value.ToString();
                AdressseTb.Text = CandidateDGV.Rows[pos].Cells[5].Value.ToString();
                PhoneTb.Text = CandidateDGV.Rows[pos].Cells[6].Value.ToString();

                if (CNameTb.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(CandidateDGV.Rows[pos].Cells[0].Value.ToString());
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Questions obj = new Questions();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Matieres obj = new Matieres();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Etudiants obj = new Etudiants();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewResult obj = new ViewResult();
            obj.Show();
            this.Hide();
        }
    }
}
