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
    public partial class Show_Patient : Form
    {
        public static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Show_Patient()
        {
            InitializeComponent();
          
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Patient order by Patient_ID", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;

            }
        }
        
        //   public string conString = "Data Source=DESKTOP-6KR7IHT\\SQLEXPRESS;Initial Catalog=DB_LAB;Integrated Security=True";
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patients obj = new Patients();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        
        }

        private void Show_Patient_Load(object sender, EventArgs e)
        {

        }
    }
}
