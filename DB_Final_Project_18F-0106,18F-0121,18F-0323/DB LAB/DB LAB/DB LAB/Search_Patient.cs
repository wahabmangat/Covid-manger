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
    public partial class Search_Patient : Form
    {
        //  public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Search_Patient()
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
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (srch.Text.ToString() != string.Empty)//no value input
                {
                    if (this.comboBox1.SelectedIndex == 0)//name
                    {
                        SqlDataAdapter sqlDa = new SqlDataAdapter("select * from patient where P_Name = '" + srch.Text.ToString()+"'", con);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                   else if (this.comboBox1.SelectedIndex == 1)//ID
                    {
                        SqlDataAdapter sqlDa = new SqlDataAdapter("select * from patient where patient_ID = " + srch.Text.ToString(), con);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }

                    else if (this.comboBox1.SelectedIndex == 2)//Age
                    {
                        SqlDataAdapter sqlDa = new SqlDataAdapter("select * from patient where Age = " + srch.Text.ToString(), con);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                    else if (this.comboBox1.SelectedIndex == 3)//Condition 
                    {
                        SqlDataAdapter sqlDa = new SqlDataAdapter("select * from patient where condition = '" + srch.Text.ToString()+"'", con);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                    else if (this.comboBox1.SelectedIndex == 4)//Location 
                    {
                        SqlDataAdapter sqlDa = new SqlDataAdapter("select * from patient where P_Address = '" + srch.Text.ToString()+"'", con);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        dataGridView1.DataSource = dtbl;
                    }
                }
                else MessageBox.Show("Enter value!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void srch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
