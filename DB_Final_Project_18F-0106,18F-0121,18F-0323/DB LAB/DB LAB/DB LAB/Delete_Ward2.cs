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
    public partial class Delete_Ward2 : Form
    {
        // public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Delete_Ward2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quarantine_Ward obj = new Quarantine_Ward();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open) ;
            {
                if (dlt.Text.ToString() != String.Empty)
                {
                    string q = "Delete from ward where w_ID= " + dlt.Text.ToString() + "and w_ID <> 21 and w_type='Quarantine'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();

                    SqlCommand ccmd = new SqlCommand();
                    MessageBox.Show("Quarantine Ward " + dlt.Text.ToString() + " removed Successfully!");
                    con.Close();
                    con.Open();
                    ccmd.CommandText = "select * from PatientADmit where W_ID=" + dlt.Text.ToString();
                    ccmd.Connection = con;
                    SqlDataReader rd = ccmd.ExecuteReader();
                    SqlCommand md = new SqlCommand();
                    Stack<string> stk = new Stack<string>();
                    while (rd.Read())
                    {

                        if (rd[1].ToString() == dlt.Text.ToString())
                        {
                            stk.Push(rd[0].ToString());

                        }
                    }
                    con.Close();
                    con.Open();
                    foreach (var itm in stk)
                    {
                        q = "insert into PatientAdmit values (" + itm + ",21,getdate(),NULL); update ward set NoOfPatients = NoOfPatients + 1, beds = beds - 1 where w_id = 21";
                        cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    con.Open();
                    q = "update PatientADmit set dateDischarge=getdate() where w_ID=" + dlt.Text.ToString();
                    cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else MessageBox.Show("Enter Ward ID!");
            }
        }
    }
}
