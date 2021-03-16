using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplayViewer
{
    public partial class ProfileViewer : Form
    {
        public ProfileViewer()
        {
            InitializeComponent();
            XMLParser things = new XMLParser();
            List<Chart> charts = things.charts;
            PrintCharts(charts);
        }

        private void PrintCharts(List<Chart> charts) {
            string nl = Environment.NewLine;
            for (int i = 0; i < 25; i++) {
                Chart c = charts[i];
                txtTesting.Text += c.Name + ": " + nl;
                foreach (Score s in c.Scores) {
                    txtTesting.Text += "\tWife: " + s.Wife + ", Rate: " + s.Rate + nl;
                    txtTesting.Text += "\tMarvelous: " + s.Marv + nl;
                    txtTesting.Text += "\tPerfect: " + s.Perf + nl;
                    txtTesting.Text += "\tGreat: " + s.Great + nl;
                    txtTesting.Text += "\tGood: " + s.Good + nl;
                    txtTesting.Text += "\tBoo: " + s.Boo + nl;
                    txtTesting.Text += "\tMiss: " + s.Miss + nl;
                }
                txtTesting.Text += nl;
            }
        }
    }
}
