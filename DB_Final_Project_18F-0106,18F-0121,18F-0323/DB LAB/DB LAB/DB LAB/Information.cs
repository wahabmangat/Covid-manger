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
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            CallCenter obj = new CallCenter();
            obj.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paramadics obj = new Paramadics();
            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Areas obj = new Areas();
            obj.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Operator obj = new Operator();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            People obj = new People();
            obj.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Map_Form obj = new Map_Form();
            obj.ShowDialog();
        }
    }
}
