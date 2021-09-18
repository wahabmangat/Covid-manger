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
    public partial class Patient_Form : Form
    {
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Patient_Form()
        {
            InitializeComponent();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Patients obj = new Patients();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       // public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)//insertion 
        {
            bool flag = false,flag1=false;
            string q="\0";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
               
                 //FK constraint
                if (PID.Text.ToString() != String.Empty && P_Name.Text.ToString() != String.Empty && DOB.Text.ToString() != String.Empty && CNIC.Text.ToString() != String.Empty && Phone.Text.ToString() != String.Empty && Address.Text.ToString() != String.Empty && W_ID.Text.ToString() != String.Empty)
                {
                    SqlCommand ccmd = new SqlCommand();
                    ccmd.CommandText = "select * from ward where w_ID=" + W_ID.Text.ToString();
                    if (comboBox1.SelectedIndex == 0)
                        ccmd.CommandText += " and w_type='Isolation'";
                    else if (comboBox1.SelectedIndex == 1)
                        ccmd.CommandText += " and w_type='Quarantine'";
                    ccmd.Connection = con;
                    SqlDataReader rd = ccmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[0].ToString() == W_ID.Text.ToString())
                        {
                            flag = true;
                           
                            break;
                        }
                    }
                    //
                    con.Close();
                    con.Open();   //PK constraint 
                    ccmd.CommandText = "Select * from patient where patient_ID=" + PID.Text.ToString();
                    ccmd.Connection = con;
                    rd = ccmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[0].ToString() == PID.Text.ToString())
                        {
                            flag1 = true;
                            
                            break;
                        }
                    }
                    if (flag && !flag1)
                    {
                        con.Close();
                        con.Open();
                        if (comboBox3.SelectedIndex == 0)
                            q = "insert into patient values(" + PID.Text.ToString() + ",'" + P_Name.Text.ToString() + "','" + DOB.Text.ToString() + "','" + CNIC.Text.ToString() + "'," + Phone.Text.ToString() + ",'" + Address.Text.ToString() + "','Mild',NULL);\n";
                        else if (comboBox3.SelectedIndex == 1)
                            q = "insert into patient values(" + PID.Text.ToString() + ",'" + P_Name.Text.ToString() + "','" + DOB.Text.ToString() + "','" + CNIC.Text.ToString() + "'," + Phone.Text.ToString() + ",'" + Address.Text.ToString() + "','Critical',NULL);\n";
                        else if (comboBox3.SelectedIndex == 2)
                            q = "insert into patient values(" + PID.Text.ToString() + ",'" + P_Name.Text.ToString() + "','" + DOB.Text.ToString() + "','" + CNIC.Text.ToString() + "'," + Phone.Text.ToString() + ",'" + Address.Text.ToString() + "','Normal',NULL);\n";

                        if (checkBox1.CheckState == CheckState.Checked)

                        {
                            q += "insert into P_Symptoms(P_ID,S_ID) values(" + PID.Text.ToString() + ",1);\n";
                        }
                        if (checkBox2.CheckState == CheckState.Checked)
                        {
                            q += "insert into P_Symptoms(P_ID,S_ID) values(" + PID.Text.ToString() + ",2);\n";
                        }
                        if (checkBox3.CheckState == CheckState.Checked)
                        {
                            q += "insert into P_Symptoms(P_ID,S_ID) values(" + PID.Text.ToString() + ",3);\n";
                        }
                        if (checkBox4.CheckState == CheckState.Checked)
                        {
                            q += "insert into P_Symptoms(P_ID,S_ID) values(" + PID.Text.ToString() + ",4);\n";
                        }
                        if (checkBox5.CheckState == CheckState.Checked)
                        {
                            q += "insert into P_Symptoms(P_ID,S_ID) values(" + PID.Text.ToString() + ",5);\n";
                        }
                        if (checkBox6.CheckState == CheckState.Checked)
                        {
                            q += "insert into P_Symptoms(P_ID,S_ID) values(" + PID.Text.ToString() + ",6);\n";
                        }
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        q = "update patient set age=  ( SELECT  YEAR(getDATE()) - YEAR(p_DOB) AS age from patient where patient_ID = " + PID.Text.ToString() + ") where patient_ID = " + PID.Text.ToString();
                        cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        q = "update ward set Beds=Beds-1 where w_ID = " + W_ID.Text.ToString();
                        cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        q = "update ward set noOfpatients=noOfpatients+1 where w_ID = " + W_ID.Text.ToString();
                        cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        q = "insert into patientAdmit values (" + PID.Text.ToString() + "," + W_ID.Text.ToString() + ",GETDATE(),NULL)";
                        cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        this.Hide();
                        Expose_to obj = new Expose_to();
                        obj.ShowDialog();
                    }
                    else
                    {

                       if(!flag) MessageBox.Show("Referenced Ward: " + W_ID.Text.ToString() + " is not found!");
                        if (flag1) MessageBox.Show("Error! Primary key Patient ID duplication!");
                    }
                }
                else MessageBox.Show("Enter Missing Fields!!");
                
    
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Patient_Form_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
