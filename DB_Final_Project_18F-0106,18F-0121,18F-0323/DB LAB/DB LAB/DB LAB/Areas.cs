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
    public partial class Areas : Form
    {
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public Areas()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Expose_to obj = new Expose_to();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from areaExposed  order by city", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (txtLOC.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from areaExposed where location like '%" + txtLOC.Text.ToString() + "%' order by location", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }

                else if (txtCITY.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from areaExposed where city like '%" + txtCITY.Text.ToString() + "%' order by City", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else if (txtREG.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from areaExposed where region like '%" + txtREG.Text.ToString() + "%' order by region", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else MessageBox.Show("Enter Field Value!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtLOC.Text.ToString() != String.Empty && txtCITY.Text.ToString() != String.Empty && txtREG.Text.ToString() != String.Empty)
                {

                    string q = "insert into areaExposed values('" + txtLOC.Text.ToString() + "','" + txtCITY.Text.ToString() + "','" + txtREG.Text.ToString() + "');";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Area inserted Successfully!");
                }
                else MessageBox.Show("Enter Missing Fields!!");
            }
        }

        private void Areas_Load(object sender, EventArgs e)
        {

        }
    }
}
