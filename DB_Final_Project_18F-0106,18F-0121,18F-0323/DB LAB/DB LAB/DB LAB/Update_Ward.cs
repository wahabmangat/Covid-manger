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
    public partial class Update_Ward : Form
    {
        //  public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Update_Ward()
        {
            InitializeComponent();
        }

        private void Update_Ward_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Isolation_Ward obj = new Isolation_Ward();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtWID.Text.ToString() != String.Empty)
            {
                string q = "\0";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    if (txtNAME.Text.ToString() != String.Empty)
                        q = "update ward set w_ID= '" + txtNAME.Text.ToString() + "' where w_ID = " + txtWID.Text.ToString();
                    if (txtBed.Text.ToString() != String.Empty)
                        q = "update ward set beds= '" + txtBed.Text.ToString() + "' where w_ID = " + txtWID.Text.ToString();
                    if (txtPAT.Text.ToString() != String.Empty)
                        q = "update ward set noOfPatients= '" + txtPAT.Text.ToString() + "' where w_ID = " + txtWID.Text.ToString();
                    if (txtLOC.Text.ToString() != String.Empty)
                        q = "update ward set loc= '" + txtLOC.Text.ToString() + "' where w_ID = " + txtWID.Text.ToString();

                    if (this.comboBox1.SelectedIndex == 0)
                        q = "update ward set wardSec= 'Public' where w_ID = " + txtWID.Text.ToString();
                    if (this.comboBox1.SelectedIndex == 1)
                        q = "update ward set wardSec= 'Private' where w_ID = " + txtWID.Text.ToString();
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully!");
                }
            }
            else MessageBox.Show("Enter Ward ID!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
