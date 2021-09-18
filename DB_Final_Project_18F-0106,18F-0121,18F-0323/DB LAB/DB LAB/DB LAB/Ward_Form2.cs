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
    public partial class Ward_Form2 : Form
    {
        public Ward_Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quarantine_Ward obj = new Quarantine_Ward();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void Ward_Form2_Load(object sender, EventArgs e)
        {

        }
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool flag = false;

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (txtWID.Text.ToString() != String.Empty && txtBED.Text.ToString() != String.Empty && txtPAT.Text.ToString() != String.Empty && txtLOC.Text.ToString() != String.Empty && txtNAME.Text.ToString() != String.Empty)
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
                    if (!flag)
                    {
                        con.Close();
                        con.Open();
                        string q = "\0";
                        if (comboBox1.SelectedIndex == 0)
                            q = "insert into Ward values(" + txtWID.Text.ToString() + "," + txtBED.Text.ToString() + ",0,'" + txtLOC.Text.ToString() + "','Public','" + txtNAME.Text.ToString() + "','Quarantine');";
                        else if (comboBox1.SelectedIndex == 1)
                            q = "insert into Ward values(" + txtWID.Text.ToString() + "," + txtBED.Text.ToString() + ",0,'" + txtLOC.Text.ToString() + "','Private','" + txtNAME.Text.ToString() + "','Quarantine');";
                        SqlCommand cmd = new SqlCommand(q, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ward Inserted Successfully");
                    }
                    else MessageBox.Show("Error! Primary key Ward ID duplication!");
                }
                else MessageBox.Show("Enter Missing Fields!!");
            }
        }
    }
}
