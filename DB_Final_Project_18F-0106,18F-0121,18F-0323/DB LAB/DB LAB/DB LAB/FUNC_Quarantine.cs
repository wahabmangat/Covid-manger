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
    public partial class FUNC_Quarantine : Form
    {
        //public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public FUNC_Quarantine()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quarantine_Ward obj = new Quarantine_Ward();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select Loc as 'Location', count(*) as 'No of Wards' from ward where w_type='Quarantine' group by loc order by loc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
            else if (this.comboBox1.SelectedIndex == 1)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select wardSec as 'Ward Sector', count(*) as 'No of Wards' from ward where w_type='Quarantine' group by wardSec order by wardSec", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == 0)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from ward where w_type='Quarantine' order by w_id asc", con);
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
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from ward where w_type='Quarantine' order by beds asc", con);
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
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from ward where w_type='Quarantine' order by noOfPatients asc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == 0)
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from ward where w_type='Quarantine' order by w_id desc", con);
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
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from ward where w_type='Quarantine' order by beds desc", con);
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
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from ward where w_type='Quarantine' order by noOfPatients desc", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }
            }
        }
    }
}
