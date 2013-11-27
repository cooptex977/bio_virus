using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace bio_virus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(640, 600);
        }
        private void VirusSim_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.problem_2();
            chart1.Palette = ChartColorPalette.SeaGreen;
            chart1.Size = new System.Drawing.Size(640, 480);
            chart1.Location = new System.Drawing.Point(10, 10);
            chart1.ChartAreas.Add("draw");
            chart1.ChartAreas["draw"].AxisX.Minimum = 1;
            chart1.ChartAreas["draw"].AxisX.Maximum = 10;
            chart1.ChartAreas["draw"].AxisX.Interval = 1;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["draw"].AxisY.Minimum = 0;
            chart1.ChartAreas["draw"].AxisY.Maximum = 1000;
            chart1.ChartAreas["draw"].AxisY.Interval = 100;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
            // Set title.
            chart1.Titles.Add("Virus Simulation");
            // Add series.
            chart1.Series.Add("Virus Growth");
            chart1.Series["Virus Growth"].ChartType = SeriesChartType.Line;
            // Add point.
            chart1.Series["Virus Growth"].Color = Color.LightGreen;
            chart1.Series["Virus Growth"].BorderWidth = 3;
            foreach (int i in Program.numviruses)
            {
                chart1.Series["Virus Growth"].Points.Add(i);
            }
            Controls.Add(this.chart1); 

        }
    }
}
