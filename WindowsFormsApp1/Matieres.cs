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
    public partial class Matieres : Form
    {
        public Matieres()
        {
            InitializeComponent();
            DisplaySubject();
        }
        //int key = 0;
        private int key;
        private void Rest()
        {
            SNameTb.Text = "";
            key = 0;
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UJ3VNRC\SQLEXPRESS;Initial Catalog=GestionQuiz;Integrated Security=True");


        private void DisplaySubject()
        {
            con.Open();
            string Query = "select * from SubjectTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MatiereDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SubjectTbl (SName) values (@Sn)", con);
                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject saved");
                    con.Close();
                    Rest();
                    DisplaySubject();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Rest();
        }

        private void MatiereDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SNameTb.Text = MatiereDGV.SelectedRows[0].Cells[1].Value.ToString();
            if (SNameTb.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(MatiereDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update SubjectTblset SName=@Sn where Sid=@SKey", con);
                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@Ckey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject updated");
                    con.Close();
                    Rest();
                    DisplaySubject();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Etudiants obj = new Etudiants();
            obj.Show();
            this.Hide();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewResult obj = new ViewResult();
            obj.Show();
            this.Hide();
        }
    }
}
