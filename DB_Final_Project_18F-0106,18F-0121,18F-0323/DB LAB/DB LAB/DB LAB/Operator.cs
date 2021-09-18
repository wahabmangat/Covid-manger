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
    public partial class Operator : Form
    {
        //  public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Operator()
        {
            InitializeComponent();
        }

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false,flag1=false;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtOID.Text.ToString() != String.Empty && txtONAME.Text.ToString() != String.Empty && txtCID.Text.ToString() != String.Empty && txtCON.Text.ToString() != String.Empty)
                {

                    string q = "\0";
                    ////
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
                    con.Close();
                    con.Open();
                    ccmd.CommandText = "Select * from operator where opID=" + txtOID.Text.ToString();
                    ccmd.Connection = con;
                    rd = ccmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[0].ToString() == txtOID.Text.ToString())
                        {
                            flag1 = true;
    
                            break;
                        }
                    }

                    if (flag && !flag1)
                    {
                        con.Close();
                        con.Open();
                        q = "insert into  operator values(" + txtOID.Text.ToString() + ",'" + txtONAME.Text.ToString() + "'," + txtCON.Text.ToString() + "," + txtCID.Text.ToString() + ");";
                      //  con.Open();
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Operator: " + txtONAME.Text.ToString() + " inserted Successfully!");
                    }
                    else {
                       if(!flag) MessageBox.Show("Referenced Call center: " + txtCID.Text.ToString() + " not found!!");
                        if (flag1) MessageBox.Show("Error! Primary key Operator ID duplication!");
                    }
                }
                else MessageBox.Show("Enter Missing Fields!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {

                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from operator order by opID", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtOID.Text.ToString() != String.Empty)
                {
                    string q = "Delete from operator where opID= " + txtOID.Text.ToString();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Operator:  " + txtOID.Text.ToString() + " deleted Successfully!");
                }
                else MessageBox.Show("Enter Operator ID!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (txtOID.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from operator where opID=" + txtOID.Text.ToString() + " order by opID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }

                else if (txtONAME.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from operator where opName='" + txtONAME.Text.ToString() + "' order by opID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else if (txtCON.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from operator where opContact=" + txtCON.Text.ToString() + " order by opID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else if (txtCID.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from operator where opCenter=" + txtCID.Text.ToString() + " order by opID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else MessageBox.Show("Enter Field Value!");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string q = "\0";
            bool flag = false;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (txtOID.Text.ToString() != String.Empty)
                {
                    if (txtONAME.Text.ToString() != String.Empty)
                        q = "update operator  set opName= '" + txtONAME.Text.ToString() + "' where opID = " + txtOID.Text.ToString();
                    if (txtCON.Text.ToString() != String.Empty)
                        q += " update operator set opContact= " + txtCON.Text.ToString() + " where opID = " + txtOID.Text.ToString();
                    if (txtCID.Text.ToString() != String.Empty)
                    {    ////
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
                        ////

                        if (flag)
                        {
                            q += " update operator set opCenter= " + txtCID.Text.ToString() + " where opID = " + txtOID.Text.ToString();
                        }
                        else MessageBox.Show("Referenced Call center: " + txtCID.Text.ToString() + " not found!!");
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Operator: " + txtONAME.Text.ToString() + " info updated Successfully!");
                }
                else MessageBox.Show("Enter Operator ID!");
            }
        }
    }
}
