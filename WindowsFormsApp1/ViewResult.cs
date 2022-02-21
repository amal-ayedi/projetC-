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
    public partial class ViewResult : Form
    {
        public ViewResult()
        {
            InitializeComponent();
            GetSubjects();
            GetCondidate();
            DisplayResults();
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
        private void GetCondidate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CName from CondidateTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CName", typeof(string));
            dt.Load(rdr);
            Cbox.ValueMember = "CName";
            Cbox.DataSource = dt;
            con.Close();
        }
        private void DisplayResults()
        {
            con.Open();
            string Query = "select * from ResultTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ResultDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void FilterBySub()
        {
            con.Open();
            string Query = "select * from ResultTbl where RSubject='"+SubjectCB.SelectedValue.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ResultDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void FilterByCandidate()
        {
            con.Open();
            string Query = "select * from ResultTbl where RCandidate='" + Cbox.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ResultDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MatiereDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SubjectCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SubjectCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterBySub();
        }

        private void Cbox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterByCandidate();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
