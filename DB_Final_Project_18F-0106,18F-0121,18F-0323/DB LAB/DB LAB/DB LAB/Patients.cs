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
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
        }
        //  public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.ShowDialog();
        }

        private void Patients_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Form obj = new Patient_Form();
            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_Patient obj = new Search_Patient();
            obj.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_Patient obj = new Update_Patient();
            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Discharge_Patient obj = new Discharge_Patient();
            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show_Patient obj = new Show_Patient();
            obj.ShowDialog();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FUNC_Patient obj = new FUNC_Patient();
            obj.ShowDialog();
        }
    }
}