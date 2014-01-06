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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                Program.numviruses.Clear();
                Program.viruses.Clear();
                Program.problem_6();
                int final = Program.numviruses[Program.numviruses.Count - 1];
                chart1.Series["Virus Growth"].ChartType = SeriesChartType.Line;
                chart1.ChartAreas["draw"].AxisX.Minimum = 0;
                chart1.ChartAreas["draw"].AxisX.Maximum = 150 + Program.timeAfter;
                chart1.ChartAreas["draw"].AxisX.Interval = (150 + Program.timeAfter) / 10;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisY.Minimum = 0;
                chart1.ChartAreas["draw"].AxisY.Maximum = 450;
                chart1.ChartAreas["draw"].AxisY.Interval = 50;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
                foreach (int i in Program.numviruses)
                {
                    chart1.Series[0].Points.Add(i);
                    chart1.Update();
                }
                Controls.Add(this.chart1);
                label1.Text = "Final virus count: " + final.ToString();
            }
            else
                MessageBox.Show("Invalid Input", "Error");
        }
        private bool check()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) /* && !String.IsNullOrEmpty(textBox2.Text)*/)
            {
                try 
                {
                    /*Program.timeAfter = Int32.Parse(textBox2.Text); */ 
                    Program.timeAfter = Int32.Parse(textBox1.Text);
                    return true; 
                }
                catch { return false; }
            }
            else
                return false;
        }
    }
}
