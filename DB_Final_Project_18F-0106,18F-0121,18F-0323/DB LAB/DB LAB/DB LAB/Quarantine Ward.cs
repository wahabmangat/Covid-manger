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
    public partial class Quarantine_Ward : Form
    {
        public Quarantine_Ward()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ward_Form2 obj = new Ward_Form2();
            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_Ward2 obj = new Search_Ward2();
            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show_Ward2 obj = new Show_Ward2();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_Ward2 obj = new Update_Ward2();
            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete_Ward2 obj = new Delete_Ward2();
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
            FUNC_Quarantine obj = new FUNC_Quarantine();
            obj.ShowDialog();
        }
    }
}