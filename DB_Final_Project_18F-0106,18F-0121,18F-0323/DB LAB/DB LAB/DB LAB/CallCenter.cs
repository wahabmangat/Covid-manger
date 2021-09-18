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
    public partial class CallCenter : Form
    {
        public CallCenter()
        {
            InitializeComponent();
        }
      //  public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Information obj = new Information();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void CallCenter_Load(object sender, EventArgs e)
        {

        }
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtCID.Text.ToString() != String.Empty && txtLOC.Text.ToString() != String.Empty && txtENO.Text.ToString() != String.Empty)
                {
                    SqlCommand ccmd = new SqlCommand();
                    ccmd.CommandText = "select * from callcenter where centID=" + txtCID.Text.ToString();
                    ccmd.Connection = con;
                    SqlDataReader rd = ccmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[0].ToString() == txtCID.Text.ToString())
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        con.Close();
                        con.Open();
                        string q = "insert into callcenter values(" + txtCID.Text.ToString() + "," + txtENO.Text.ToString() + ",'" + txtLOC.Text.ToString() + "');";
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Call Center:  " + txtCID.Text.ToString() + " inserted Successfully!");
                    }
                    else MessageBox.Show("Error Primary Key Center ID duplication!!");
                }
                else MessageBox.Show("Enter Missing Fields!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (txtCID.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from callCenter where centID=" + txtCID.Text.ToString() + " order by centID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }

                else if (txtENO.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from callCenter where emergNUm=" + txtENO.Text.ToString() + " order by centID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else if (txtLOC.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from callCenter where centLOC='" + txtLOC.Text.ToString() + "' order by centID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else MessageBox.Show("Enter Field Value!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtCID.Text.ToString() != String.Empty)
                {
                    string q = "Delete from callCenter where centID= " + txtCID.Text.ToString();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Call Center:  " + txtCID.Text.ToString() + " deleted Successfully!");
                }
                else MessageBox.Show("Enter Call center ID!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from callCenter  order by centID", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string q = "\0";
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtCID.Text.ToString() != String.Empty)
                {
                  
                    if (txtENO.Text.ToString() != String.Empty)
                    q += "update callCenter set emergNum="+ txtENO.Text.ToString()+"where centID= " + txtCID.Text.ToString();
                    if (txtLOC.Text.ToString() != String.Empty)
                        q += "update callCenter set centLOC='" + txtENO.Text.ToString() + "' where centID= " + txtCID.Text.ToString();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Call Center:  " + txtCID.Text.ToString() + " info updated Successfully!");
                }
                else MessageBox.Show("Enter Call center ID!!");
            }
        }
    }
}
