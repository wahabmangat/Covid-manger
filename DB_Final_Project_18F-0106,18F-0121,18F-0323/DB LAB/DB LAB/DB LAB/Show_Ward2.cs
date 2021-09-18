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
    public partial class Show_Ward2 : Form
    {
        public Show_Ward2()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from ward where w_type='Quarantine' order by W_ID", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quarantine_Ward obj = new Quarantine_Ward();
            obj.ShowDialog();
        }
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";

        private void Show_Ward_Load(object sender, EventArgs e)
        {
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Show_Ward2_Load(object sender, EventArgs e)
        {

        }
    }
}
