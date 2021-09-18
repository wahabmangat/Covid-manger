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
    public partial class Paramadics : Form
    {
        // public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Paramadics()
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false,flag1=false;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtPID.Text.ToString() != String.Empty && txtNAME.Text.ToString() != String.Empty && txtWID.Text.ToString() != String.Empty)
                {
                    string q="\0";
                    SqlCommand ccmd = new SqlCommand();
                    ccmd.CommandText = "select * from ward where w_ID=" + txtWID.Text.ToString();
                    ccmd.Connection = con;
                    SqlDataReader rd = ccmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[0].ToString() == txtWID.Text.ToString())
                        {
                            flag = true;
                             break;
                        }
                    }
                    con.Close();
                    con.Open();
                    ccmd.CommandText = "Select * from paramadics where parID=" + txtPID.Text.ToString();
                    ccmd.Connection = con;
                    rd = ccmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[0].ToString() == txtPID.Text.ToString())
                        {
                            flag1 = true;

                            break;
                        }
                    }


                    if (flag && !flag1)
                    {
                        con.Close();
                        con.Open();
                        if (comboBox1.SelectedIndex == 0)
                        { q = "insert into paramadics values(" + txtPID.Text.ToString() + ",'" + txtNAME.Text.ToString() + "','Doctor'," + txtWID.Text.ToString() + ");"; }
                        else if (comboBox1.SelectedIndex == 1)
                        { q = "insert into paramadics values(" + txtPID.Text.ToString() + ",'" + txtNAME.Text.ToString() + "','Nurse'," + txtWID.Text.ToString() + ");"; }

                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Paramedic " + txtNAME.Text.ToString() + " inserted Successfully!");
                    }
                    else
                    {
                     if(!flag)   MessageBox.Show("Referenced Ward: " + txtWID.Text.ToString() + " not found!!");
                        if (flag1) MessageBox.Show("Error! Primary key Paramedic ID duplication!");
                    }
                }
                else MessageBox.Show("Enter Missing Fields!!");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtPID.Text.ToString() != String.Empty)
                {
                    string q = "Delete from paramadics where parID= " + txtPID.Text.ToString();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paramedic:  " + txtPID.Text.ToString() + " deleted Successfully!");
                }
                else MessageBox.Show("Enter Paramedic ID!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (txtPID.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from paramadics where parID=" + txtPID.Text.ToString() + " order by parID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }

                else if (txtNAME.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from paramadics where ParName='" + txtNAME.Text.ToString() + "' order by parID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else if (txtWID.Text.ToString() != String.Empty)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from paramadics where w_ID=" + txtWID.Text.ToString() + " order by parID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else if(comboBox1.SelectedIndex==0)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from paramadics where jobStatus='Doctor'  order by parID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from paramadics where jobStatus='Nurse'  order by parID", con);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;
                }
                else MessageBox.Show("Enter Field Value!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {

                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from paramadics order by parID", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string q = "\0";
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (txtPID.Text.ToString() != String.Empty)
                {
                    if(txtNAME.Text.ToString()!=String.Empty)
                     q += "Update Paramadics set parName= '"+ txtNAME.Text.ToString()+"' where parID= " + txtPID.Text.ToString();
                    if (comboBox1.SelectedIndex==0)
                        q += "Update Paramadics set jobStatus= 'Doctor' where parID= " + txtPID.Text.ToString();
                    if (comboBox1.SelectedIndex == 1)
                        q += "Update Paramadics set jobStatus= 'Nurse' where parID= " + txtPID.Text.ToString();
                    if(txtWID.Text.ToString()!=String.Empty)
                    {
                        SqlCommand ccmd = new SqlCommand();
                        ccmd.CommandText = "select * from ward where w_ID=" + txtWID.Text.ToString();
                        ccmd.Connection = con;
                        SqlDataReader rd = ccmd.ExecuteReader();
                        while (rd.Read())
                        {
                            if (rd[0].ToString() == txtWID.Text.ToString())
                            {
                                flag = true;
                                 break;
                            }
                        }
                        if(flag)
                            q += "Update Paramadics set w_ID="+ txtWID.Text.ToString()+" where parID= " + txtPID.Text.ToString();
                         else MessageBox.Show("Referenced Ward: " + txtWID.Text.ToString() + " is not found!");
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paramedic:  " + txtPID.Text.ToString() + " info updated Successfully!");
                }
                else MessageBox.Show("Enter Paramedic ID!!");
            }
        }
    }
}