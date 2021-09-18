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
    public partial class Map_Form : Form
    {
        public Map_Form()
        {
            InitializeComponent();
        }

        private void Map_Form_Load(object sender, EventArgs e)
        {
            LiveCharts.WinForms.GeoMap geoMap = new LiveCharts.WinForms.GeoMap();
            Dictionary<string, double> keyValues = new Dictionary<string, double>();
            keyValues["CN"] = 81285;
            keyValues["US"] = 75066;
            keyValues["IT"] = 74384;
            keyValues["ES"] = 56196;
            keyValues["IR"] = 29046;
            keyValues["FR"] = 25233;
            keyValues["UK"] = 9849;
            keyValues["CA"] = 3579;
            keyValues["PK"] = 1179;
            keyValues["IN"] = 719;

            geoMap.HeatMap = keyValues;
            geoMap.Source = $"{Application.StartupPath}\\world.xml";
            this.Controls.Add(geoMap);
            geoMap.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Information f1 = new Information();
            f1.ShowDialog();
        }
    }
}
