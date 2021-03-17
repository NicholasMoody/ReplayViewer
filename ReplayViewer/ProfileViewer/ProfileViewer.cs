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
        List<Score> scores;
        public ProfileViewer()
        {
            InitializeComponent();
            XMLParser things = new XMLParser();
            scores = things.scores;

            foreach (Score s in scores) {
                lbScores.Items.Add(s.ToStringShort());
            }
        }

        private void lbScores_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (Score s in scores) {
                if (s.ToStringShort() == lbScores.SelectedItem.ToString()) {
                    txtTesting.Text = s.ToString();
                }
            } 
        }

        private void Search(object sender, EventArgs e) {
            // the real meme will be implementing LCS for search when it's not 3am :)

            lbScores.Items.Clear();
            txtTesting.Text = "";
            foreach (Score s in scores) {
                if (s.ChartName.ToLower().StartsWith(txtSearch.Text.ToLower()))
                    lbScores.Items.Add(s.ToStringShort());
            }
        }
    }
}
