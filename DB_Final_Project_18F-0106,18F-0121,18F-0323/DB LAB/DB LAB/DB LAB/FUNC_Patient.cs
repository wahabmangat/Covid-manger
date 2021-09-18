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
using System.Configuration;

namespace DB_LAB
{
    public partial class FUNC_Patient : Form
    {
        public FUNC_Patient()
        {
            InitializeComponent();
        }
        // public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patients obj = new Patients();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 1)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select Age, count(*) as 'No of Patients' from patient group by age order by age", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
           else if (this.comboBox1.SelectedIndex == 0)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select P_Address as 'Location', count(*) as 'No of Patients' from patient group by P_address order by P_address", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
            else if (this.comboBox1.SelectedIndex == 2)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select condition as 'Condition', count(*) as 'No of Patients' from patient group by condition order by condition", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e) //asc
        {
            if (this.comboBox2.SelectedIndex == 0)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select *  from patient  order by age asc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
            else if (this.comboBox2.SelectedIndex == 1)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select *  from patient  order by patient_ID asc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }

            else if (this.comboBox2.SelectedIndex == 2)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select *  from patient  order by p_name asc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//desc
        {
            if (this.comboBox2.SelectedIndex == 0)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select *  from patient  order by age desc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
            else if (this.comboBox2.SelectedIndex == 1)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select *  from patient  order by patient_ID desc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }

            else if (this.comboBox2.SelectedIndex == 2)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select *  from patient  order by p_name desc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
            }
        }

        private void FUNC_Patient_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("select pd.p_ID as 'Patient ID',pd.w_ID as 'Ward ID',pd.dateAdmit,pd.dateDischarge from  patientAdmit pd  order by pd.p_ID; ", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}
