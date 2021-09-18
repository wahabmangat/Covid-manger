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
    public partial class Update_Patient : Form
    {
        // public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Update_Patient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patients obj = new Patients();
            obj.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Patients obj = new Patients();
            obj.ShowDialog();
        }

        private void Update_Patient_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (txtPID.Text.ToString() != String.Empty)
            {
                string q = "\0";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    if (name.Text.ToString() != String.Empty)
                        q = "update patient set p_Name= '" + name.Text.ToString()+"' where Patient_ID = "+ txtPID.Text.ToString();
                    if(cnic.Text.ToString() != String.Empty)
                        q += " update patient set cnic= '" + cnic.Text.ToString() + "' where Patient_ID = " + txtPID.Text.ToString();
                    if (phone.Text.ToString() != String.Empty)
                        q += " update patient set phone= " + phone.Text.ToString() + " where Patient_ID = " + txtPID.Text.ToString();
                    if (address.Text.ToString() != String.Empty)
                        q += " update patient set P_address= '" + phone.Text.ToString() + "' where Patient_ID = " + txtPID.Text.ToString();
                    if(this.comboBox2.SelectedIndex==0)
                        q += " update patient set condition= 'Mild' where Patient_ID = " + txtPID.Text.ToString();
                    if (this.comboBox2.SelectedIndex == 1)
                        q += " update patient set condition= 'Critical' where Patient_ID = " + txtPID.Text.ToString();
                    if (this.comboBox2.SelectedIndex == 2)
                        q += " update patient set condition= 'Normal' where Patient_ID = " + txtPID.Text.ToString();
                    if(wid.Text.ToString()!=String.Empty)
                    {
                        SqlCommand cccmd = new SqlCommand();
                        cccmd.CommandText = "select * from patientAdmit where P_ID=" + txtPID.Text.ToString() + " and W_ID=" + wid.Text.ToString();
                        cccmd.Connection = con;
                        SqlDataReader rd = cccmd.ExecuteReader();
               
                        while (rd.Read())
                        {
                           
                            if (rd[1].ToString() ==wid.Text.ToString())
                            {
                                flag = true;
                                con.Close();
                                break;
                            }
                        }
                        if(!flag)
                        {
                            flag = false;

                            SqlCommand md = new SqlCommand();
                            md.CommandText = "select * from ward where w_ID=" + wid.Text.ToString();
                            if (comboBox1.SelectedIndex == 0)
                                md.CommandText += " and w_type='Isolation'";
                            else if (comboBox1.SelectedIndex == 1)
                                md.CommandText += " and w_type='Quarantine'";
                            md.Connection = con;
                            con.Close();
                            con.Open();
                            SqlDataReader rrd = md.ExecuteReader();
                            while (rrd.Read())
                            {
                                if (rrd[0].ToString() == wid.Text.ToString())
                                {
                                    flag = true;
                                    con.Close();
                                    break;
                                }
                            }
                            if (flag)
                            {
                                con.Open();
                                SqlCommand ccmd;
                                string s = "\0";
                                s = "update ward set NoOfPatients = NoOfPatients - 1, beds = beds + 1 where w_id = (select W_ID from patientAdmit where p_ID=" + txtPID.Text.ToString() + ")";
                                ccmd = new SqlCommand(s, con);
                                ccmd.ExecuteNonQuery();
                                s = "update PatientAdmit set dateDischarge= getdate() where p_ID= " + txtPID.Text.ToString();
                                ccmd = new SqlCommand(s, con);
                                ccmd.ExecuteNonQuery();
                                s = "insert into patientAdmit values(" + txtPID.Text.ToString() + "," + wid.Text.ToString() + ", getdate(),NULL);";
                                ccmd = new SqlCommand(s, con);
                                ccmd.ExecuteNonQuery();
                                s = "update ward set NoOfPatients = NoOfPatients + 1, beds = beds - 1 where w_id = " + wid.Text.ToString();
                                ccmd = new SqlCommand(s, con);
                                ccmd.ExecuteNonQuery();
                                
                            }
                            else MessageBox.Show("Referenced Ward: " + wid.Text.ToString() + " is not found!");
                            //MessageBox.Show("HELLO"+rd[1].ToString());
                        }
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                }
            }
            else MessageBox.Show("Enter Patient ID!");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
