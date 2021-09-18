using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_LAB
{
    public partial class Isolation_Ward : Form
    {
        public Isolation_Ward()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)//
        {
            this.Hide();
            Ward_Form obj = new Ward_Form();
            obj.ShowDialog();
        }

        private void Isolation_Ward_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//
        {
            this.Hide();
            Search_Ward obj = new Search_Ward();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)//
        {
            this.Hide();
            Update_Ward obj = new Update_Ward();
            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)//
        {
            this.Hide();
            Delete_Ward obj = new Delete_Ward();
            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)//
        {
            this.Hide();
            Show_Ward obj = new Show_Ward();
            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Wards obj = new Wards();
            obj.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FUNC_Isolation obj = new FUNC_Isolation();
            obj.ShowDialog();
        }
    }
}
