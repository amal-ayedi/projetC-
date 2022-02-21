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
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
            GetSubjects();
            DisplayQuestions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {
            Questions obj = new Questions();
            obj.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UJ3VNRC\SQLEXPRESS;Initial Catalog=GestionQuiz;Integrated Security=True");
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
        private void Rest()
        {
            QuestTb.Text = "";
            Op1Tb.Text = "";
            Op2Tb.Text = "";
            Op3Tb.Text = "";
            Op4Tb.Text = "";
            AnswerTb.Text = "";
            SubjectCB.SelectedIndex = 0;
        }
        private void DisplayQuestions()
        {
            con.Open();
            string Query = "select * from QuestionTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            QuestionsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (QuestTb.Text == "" || Op1Tb.Text == "" || Op2Tb.Text == "" || Op3Tb.Text == "" || Op4Tb.Text == "" || AnswerTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    //int score = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into QuestionTbl (QDesc,QO1,QO2,QO3,QO4,QA,QS) values (@Qd,@Q1,@Q2,@Q3,@Q4,@QA,@QS)", con);
                    cmd.Parameters.AddWithValue("@Qd", QuestTb.Text);
                    cmd.Parameters.AddWithValue("@Q1", Op1Tb.Text);
                    cmd.Parameters.AddWithValue("@Q2", Op2Tb.Text);
                    cmd.Parameters.AddWithValue("@Q3", Op3Tb.Text);
                    cmd.Parameters.AddWithValue("@Q4", Op4Tb.Text);
                    cmd.Parameters.AddWithValue("@QA", AnswerTb.Text);
                    cmd.Parameters.AddWithValue("@QS", SubjectCB.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Question Added");
                    con.Close();
                    Rest();
                    DisplayQuestions();
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
        int key = 0;
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (QuestTb.Text == "" || Op1Tb.Text == "" || Op2Tb.Text == "" || Op3Tb.Text == "" || Op4Tb.Text == "" || AnswerTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update QuestionTbl set QDesc=@Qd, QO1=@Q1, QO2=@Q2,QO3=@Q3, QO4=@Q4,QA=@QA,QS=@QS where Qid=@Qkey", con);
                    cmd.Parameters.AddWithValue("@Qd", QuestTb.Text);
                    cmd.Parameters.AddWithValue("@Q1", Op1Tb.Text);
                    cmd.Parameters.AddWithValue("@Q2", Op2Tb.Text);
                    cmd.Parameters.AddWithValue("@Q3", Op3Tb.Text);
                    cmd.Parameters.AddWithValue("@Q4", Op4Tb.Text);
                    cmd.Parameters.AddWithValue("@QA", AnswerTb.Text);
                    cmd.Parameters.AddWithValue("@QS", SubjectCB.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@QKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Question Updated");
                    con.Close();
                    Rest();
                    DisplayQuestions();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void QuestionsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex;
            if (pos != -1)
            {
                QuestTb.Text = QuestionsDGV.Rows[pos].Cells[1].Value.ToString();
                Op1Tb.Text = QuestionsDGV.Rows[pos].Cells[2].Value.ToString();
                Op2Tb.Text = QuestionsDGV.Rows[pos].Cells[3].Value.ToString();
                Op3Tb.Text = QuestionsDGV.Rows[pos].Cells[4].Value.ToString();
                Op4Tb.Text = QuestionsDGV.Rows[pos].Cells[5].Value.ToString();
                AnswerTb.Text = QuestionsDGV.Rows[pos].Cells[6].Value.ToString();
                SubjectCB.SelectedValue = QuestionsDGV.Rows[pos].Cells[7].Value.ToString();
                if (QuestTb.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(QuestionsDGV.Rows[pos].Cells[0].Value.ToString());
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewResult obj = new ViewResult();
            obj.Show();
            this.Hide();
        }
    }
}
