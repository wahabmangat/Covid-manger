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
    public partial class Discharge_Patient : Form
    {
        // public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Discharge_Patient()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patients obj = new Patients();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (dlt.Text.ToString() != String.Empty)
                {
                    string q = "Delete from Patient where patient_ID= " + dlt.Text.ToString();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    q = "update patientAdmit set dateDischarge= getdate() where p_ID=" + dlt.Text.ToString() + " and dateDischarge is null";
                    cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    q = "update ward set NoOfPatients = NoOfPatients - 1, beds = beds + 1 where w_id = (select W_ID from patientAdmit where p_ID=" + dlt.Text.ToString() + "and dateDischarge is null)";
                    cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient " + dlt.Text.ToString() + " discharged Successfully!");
                }
                else MessageBox.Show("Enter Patient ID!");
            }
        }

        private void Discharge_Patient_Load(object sender, EventArgs e)
        {

        }
    }
}