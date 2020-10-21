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
    public partial class MainWindow : Form
    {
        List<Note> notes = new List<Note>();
        double currTime = 0;
        double PPS = 1000; // pixels per second in chart display, essentially spacing between notes

        ChartData chart;
        public MainWindow()
        {
            InitializeComponent();
            
            chart = Parser.ParseChart(
                @"D:\Games\New folder\Etterna\Songs\Miracle Streamz^\Paraclete (SnowPh)\paraclete.sm");
            double offset = chart.NoteData[0].MSFromStart;
            for (int i = 0; i < chart.NoteData.Count; i++)
                chart.NoteData[i].MSFromStart -= offset;

            this.Paint += this.DrawNotes;
        }

        private void DrawNotes(object sender, PaintEventArgs e)
        {
            int i = 0;
            
            while (chart.NoteData[i].MSFromStart < currTime + DisplayRectangle.Height / PPS)
            {
                if (chart.NoteData[i].MSFromStart > currTime - DisplayRectangle.Height / PPS)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (chart.NoteData[i].Note[j] == '1')
                        {
                            e.Graphics.FillRectangle(Brushes.Red, 200 + (50 * j),
                                (int)((chart.NoteData[i].MSFromStart - currTime) * PPS),
                                30, 15);
                        }
                    }
                }
                i++;
                if (i >= chart.NoteData.Count)
                    break;
            }
        } 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool changed = true;
            if (e.KeyCode == Keys.Up)
                currTime -= 0.15;
            else if (e.KeyCode == Keys.Down)
                currTime += 0.15;
            else if (e.KeyCode == Keys.Oemplus)
                PPS += 25;
            else if (e.KeyCode == Keys.OemMinus)
                PPS = PPS - 25 > 0 ? PPS - 25 : 0;
            else
                changed = false;
            if (changed)
                this.Invalidate();
        }
    }
}
