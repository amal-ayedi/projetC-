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
    public partial class Examens : Form
    {
        public Examens()
        {
            InitializeComponent();
            // multirandom();
            matiereLbl.Text = login.SubName;
            Cname.Text = login.CandName;
            Qn = CountQuestion();
            FetchQuestions();
            //saveHighest();
        }
        int Qn;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UJ3VNRC\SQLEXPRESS;Initial Catalog=GestionQuiz;Integrated Security=True");
        string a1, a2, a3, a4, a5, a6, a7, a8, a9, a10;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //timer1.Start();
        }

        private void Examens_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        string[] Ua = new string[10];
        private void Q1O1_CheckedChanged(object sender, EventArgs e)
        {
            //Ua[0] = Q1O1.Text;
            //MessageBox.Show("Selected Answer is " + Ua[0]);
        }



        private void Q1O2_CheckedChanged(object sender, EventArgs e)
        {
            //Ua[0] = Q1O2.Text;
        }

        int chrono = 350;
        int count = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            chrono -= 1;
            count += 1;
            TimerBar.Value = chrono;
            TimeLbl.Text = "" + chrono;
            if(TimerBar.Value == 350)
            {
                TimerBar.Value = 0;
                timer1.Stop();
                MessageBox.Show("Time Over");
                login log = new login();
                log.Show();
                this.Hide();
            }
        }
        
        private int CountQuestion()
        {
            int Qnum;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from QuestionTbl where QS = '" + matiereLbl.Text+"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Qnum = Convert.ToInt32(dt.Rows[0][0]);
            con.Close();
            //MessageBox.Show("" + Qnum);
            return Qnum;
        }

        /*private void saveHighest()
        {
            con.Open();
            SqlDataAdapter sda2 = new SqlDataAdapter("select Max(RScore) from ResultTbl where RCandidate = '"+ Cname.Text + "'",con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int BestScore = Convert.ToInt32(dt2.Rows[0][0].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand("Update condidateTbl set CScore=@Cs where CName=@Cn", con);
                cmd.Parameters.AddWithValue("@Cn", Cname.Text);
                cmd.Parameters.AddWithValue("@Cs", BestScore);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Candidate updated");
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            con.Close();
        } */

      /*  private int GenerateRand()
        //generer des valeurs aléatoires 
        {
            Random rd = new Random();
            int x = rd.Next(1, 4);
            int y = rd.Next(1, 4);
            int z = rd.Next(1, 4);
            //MessageBox.Show("" + x + "and" + y + "and" + z);
            return x;
        }
        */
        int[] keys = new int[10];
        private void multirandom() 
        //(generates 10 random numbers) get random questions whenever we start the application
        {
            HashSet<int> numbers = new HashSet<int>();
            var rnd = new Random();
            while (numbers.Count<10)
            {
                numbers.Add(rnd.Next(1, Qn));
            }
            for(int i = 0; i<10; i++)
            {
                keys[i] = numbers.ElementAt(i);
            }
        }
        private void FetchQuestions()
        {
            try
            {
                //int Qnum = GenerateRand();
                multirandom();
                con.Open();
                //displaying random question from the data base
                string Query = "select * from QuestionTbl where Qid="+keys[0]+"";
                SqlCommand cmd = new SqlCommand(Query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    Q1.Text = dr["QDesc"].ToString();
                    Q1O1.Text = dr["QO1"].ToString();
                    Q1O2.Text = dr["QO2"].ToString();
                    Q1O3.Text = dr["QO3"].ToString();
                    Q1O4.Text = dr["QO4"].ToString();
                    a1 = dr["QA"].ToString();
                }
                string Query1 = "select * from QuestionTbl where Qid=" + keys[1] + "";
                cmd = new SqlCommand(Query1, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q2.Text = dr["QDesc"].ToString();
                    Q2O1.Text = dr["QO1"].ToString();
                    Q2O2.Text = dr["QO2"].ToString();
                    Q2O3.Text = dr["QO3"].ToString();
                    Q2O4.Text = dr["QO4"].ToString();
                    a2 = dr["QA"].ToString();
                }
                
                string Query2 = "select * from QuestionTbl where Qid=" + keys[2] + "";
                cmd = new SqlCommand(Query2, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q3.Text = dr["QDesc"].ToString();
                    Q3O1.Text = dr["QO1"].ToString();
                    Q3O2.Text = dr["QO2"].ToString();
                    Q3O3.Text = dr["QO3"].ToString();
                    Q3O4.Text = dr["QO4"].ToString();
                    a3 = dr["QA"].ToString();
                }
                string Query3 = "select * from QuestionTbl where Qid=" + keys[3] + "";
                cmd = new SqlCommand(Query3, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q4.Text = dr["QDesc"].ToString();
                    Q4O1.Text = dr["QO1"].ToString();
                    Q4O2.Text = dr["QO2"].ToString();
                    Q4O3.Text = dr["QO3"].ToString();
                    Q4O4.Text = dr["QO4"].ToString();
                    a4 = dr["QA"].ToString();
                }
                string Query4 = "select * from QuestionTbl where Qid=" + keys[4] + "";
                cmd = new SqlCommand(Query4, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q5.Text = dr["QDesc"].ToString();
                    Q5O1.Text = dr["QO1"].ToString();
                    Q5O2.Text = dr["QO2"].ToString();
                    Q5O3.Text = dr["QO3"].ToString();
                    Q5O4.Text = dr["QO4"].ToString();
                    a5 = dr["QA"].ToString();
                }
                string Query5 = "select * from QuestionTbl where Qid=" + keys[5] + "";
                cmd = new SqlCommand(Query5, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q6.Text = dr["QDesc"].ToString();
                    Q6O1.Text = dr["QO1"].ToString();
                    Q6O2.Text = dr["QO2"].ToString();
                    Q6O3.Text = dr["QO3"].ToString();
                    Q6O4.Text = dr["QO4"].ToString();
                    a6 = dr["QA"].ToString();
                }
                string Query6 = "select * from QuestionTbl where Qid=" + keys[6] + "";
                cmd = new SqlCommand(Query6, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q7.Text = dr["QDesc"].ToString();
                    Q7O1.Text = dr["QO1"].ToString();
                    Q7O2.Text = dr["QO2"].ToString();
                    Q7O3.Text = dr["QO3"].ToString();
                    Q7O4.Text = dr["QO4"].ToString();
                    a7 = dr["QA"].ToString();
                }
                string Query7 = "select * from QuestionTbl where Qid=" + keys[7] + "";
                cmd = new SqlCommand(Query7, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q8.Text = dr["QDesc"].ToString();
                    Q8O1.Text = dr["QO1"].ToString();
                    Q8O2.Text = dr["QO2"].ToString();
                    Q8O3.Text = dr["QO3"].ToString();
                    Q8O4.Text = dr["QO4"].ToString();
                    a8 = dr["QA"].ToString();
                }
                string Query8 = "select * from QuestionTbl where Qid=" + keys[8] + "";
                cmd = new SqlCommand(Query8, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q9.Text = dr["QDesc"].ToString();
                    Q9O1.Text = dr["QO1"].ToString();
                    Q9O2.Text = dr["QO2"].ToString();
                    Q9O3.Text = dr["QO3"].ToString();
                    Q9O4.Text = dr["QO4"].ToString();
                    a9 = dr["QA"].ToString();
                }
                string Query9 = "select * from QuestionTbl where Qid=" + keys[9] + "";
                cmd = new SqlCommand(Query9, con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Q10.Text = dr["QDesc"].ToString();
                    Q10O1.Text = dr["QO1"].ToString();
                    Q10O2.Text = dr["QO2"].ToString();
                    Q10O3.Text = dr["QO3"].ToString();
                    Q10O4.Text = dr["QO4"].ToString();
                    a10 = dr["QA"].ToString();
                }
                con.Close();
            }
            catch
            {

            }

        }
        private void label4_Click(object sender, EventArgs e)
        {
            Etudiants obj = new Etudiants();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Matieres obj = new Matieres();
            obj.Show();
            this.Hide();
        }
        int score = 0;
        private void checkQ1()
        {
            if (Q1O1.Checked)
            {
                Ua[0] = "";
                Ua[0] = Q1O1.Text;
            }
            else if (Q1O2.Checked)
            {
                Ua[0] = "";
                Ua[0] = Q1O2.Text;
            }
            else if (Q1O3.Checked)
            {
                Ua[0] = "";
                Ua[0] = Q1O3.Text;
            }
            else if (Q1O4.Checked)
            {
                Ua[0] = "";
                Ua[0] = Q1O4.Text;
            }
            if(Ua[0] == a1)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }
        private void checkQ2()
        {
            if (Q2O1.Checked)
            {
                Ua[1] = "";
                Ua[1] = Q2O1.Text;
            }
            else if (Q2O2.Checked)
            {
                Ua[1] = "";
                Ua[1] = Q2O2.Text;
            }
            else if (Q2O3.Checked)
            {
                Ua[1] = "";
                Ua[1] = Q2O3.Text;
            }
            else if (Q2O4.Checked)
            {
                Ua[1] = "";
                Ua[1] = Q2O4.Text;
            }
            if (Ua[1] == a2)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void checkQ3()
        {
            if (Q3O1.Checked)
            {
                Ua[2] = "";
                Ua[2] = Q3O1.Text;
            }
            else if (Q3O2.Checked)
            {
                Ua[2] = "";
                Ua[2] = Q3O2.Text;
            }
            else if (Q3O3.Checked)
            {
                Ua[2] = "";
                Ua[2] = Q3O3.Text;
            }
            else if (Q3O4.Checked)
            {
                Ua[2] = "";
                Ua[2] = Q3O4.Text;
            }
            if (Ua[2] == a3)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TimerBar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkQ4()
        {
            if (Q4O1.Checked)
            {
                Ua[3] = "";
                Ua[3] = Q4O1.Text;
            }
            else if (Q4O2.Checked)
            {
                Ua[3] = "";
                Ua[3] = Q4O2.Text;
            }
            else if (Q4O3.Checked)
            {
                Ua[3] = "";
                Ua[3] = Q4O3.Text;
            }
            else if (Q4O4.Checked)
            {
                Ua[3] = "";
                Ua[3] = Q4O4.Text;
            }
            if (Ua[3] == a4)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void checkQ5()
        {
            if (Q5O1.Checked)
            {
                Ua[4] = "";
                Ua[4] = Q5O1.Text;
            }
            else if (Q5O2.Checked)
            {
                Ua[4] = "";
                Ua[4] = Q5O2.Text;
            }
            else if (Q5O3.Checked)
            {
                Ua[4] = "";
                Ua[4] = Q5O3.Text;
            }
            else if (Q5O4.Checked)
            {
                Ua[4] = "";
                Ua[4] = Q5O4.Text;
            }
            if (Ua[4] == a4)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void checkQ6()
        {
            if (Q6O1.Checked)
            {
                Ua[5] = "";
                Ua[5] = Q6O1.Text;
            }
            else if (Q6O2.Checked)
            {
                Ua[5] = "";
                Ua[5] = Q6O2.Text;
            }
            else if (Q6O3.Checked)
            {
                Ua[5] = "";
                Ua[5] = Q6O3.Text;
            }
            else if (Q6O4.Checked)
            {
                Ua[5] = "";
                Ua[5] = Q6O4.Text;
            }
            if (Ua[5] == a6)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void checkQ7()
        {
            if (Q7O1.Checked)
            {
                Ua[6] = "";
                Ua[6] = Q7O1.Text;
            }
            else if (Q7O2.Checked)
            {
                Ua[6] = "";
                Ua[6] = Q7O2.Text;
            }
            else if (Q7O3.Checked)
            {
                Ua[6] = "";
                Ua[6] = Q7O3.Text;
            }
            else if (Q7O4.Checked)
            {
                Ua[6] = "";
                Ua[6] = Q4O4.Text;
            }
            if (Ua[6] == a7
)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void checkQ8()
        {
            if (Q8O1.Checked)
            {
                Ua[7] = "";
                Ua[7] = Q8O1.Text;
            }
            else if (Q8O2.Checked)
            {
                Ua[7] = "";
                Ua[7] = Q8O2.Text;
            }
            else if (Q8O3.Checked)
            {
                Ua[7] = "";
                Ua[7] = Q8O3.Text;
            }
            else if (Q8O4.Checked)
            {
                Ua[7] = "";
                Ua[7] = Q8O4.Text;
            }
            if (Ua[7] == a8)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void checkQ9()
        {
            if (Q9O1.Checked)
            {
                Ua[8] = "";
                Ua[8] = Q9O1.Text;
            }
            else if (Q9O2.Checked)
            {
                Ua[8] = "";
                Ua[8] = Q9O2.Text;
            }
            else if (Q9O3.Checked)
            {
                Ua[8] = "";
                Ua[8] = Q9O3.Text;
            }
            else if (Q9O4.Checked)
            {
                Ua[8] = "";
                Ua[8] = Q9O4.Text;
            }
            if (Ua[8] == a9
)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void checkQ10()
        {
            if (Q10O1.Checked)
            {
                Ua[9] = "";
                Ua[9] = Q10O1.Text;
            }
            else if (Q10O2.Checked)
            {
                Ua[9] = "";
                Ua[9] = Q10O2.Text;
            }
            else if (Q10O3.Checked)
            {
                Ua[9] = "";
                Ua[9] = Q10O3.Text;
            }
            else if (Q10O4.Checked)
            {
                Ua[9] = "";
                Ua[9] = Q10O4.Text;
            }
            if (Ua[9] == a10)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        private void InsertResult()
        {
            try
            {
                //int score = 0;
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ResultTbl (RSubject,RCandidate,RDate,RTime,RScore) values (@RS,@RC,@RD,@RT,@RSC)", con);
                cmd.Parameters.AddWithValue("@RS", matiereLbl.Text);
                cmd.Parameters.AddWithValue("@RC", Cname.Text);
                cmd.Parameters.AddWithValue("@RD", dateP.Value.Date);
                cmd.Parameters.AddWithValue("@RT", Qtime.Text);
                cmd.Parameters.AddWithValue("@RSC", score);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Resultat Saved");
                con.Close();
                //Rest();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            score = 0;
            checkQ1();
            checkQ2();
            checkQ3();
            checkQ4();
            checkQ5();
            checkQ6();
            checkQ7();
            checkQ8();
            checkQ9();
            checkQ10();
            MessageBox.Show(""+score);
            InsertResult();
            //saveHighest();
            login log = new login();
            log.Show();
            this.Hide();
        }
    }
}
