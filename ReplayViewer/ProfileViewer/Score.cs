using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplayViewer {
    class Score {
        public string ChartName;
        public double Wife;
        public double Rate;
        public double Marv;
        public double Perf;
        public double Great;
        public double Good;
        public double Boo;
        public double Miss;
        public bool Valid;
        public string Key;
        public string Date;
        public double Overall;
        public double Jumpstream;
        public double Stream;
        public double Handstream;
        public double Stamina;
        public double Jackspeed;
        public double Chordjack;
        public double Technical;

        public string ToStringShort() {
            string r = Rate == 1 ? "1.0" : Rate.ToString(); // print 1.0 instead of 1 for rate
            string s = ChartName + " " + r + " " + Math.Round(Wife * 100, 2) + "% " + $"({Overall}) " + Date;
            return s;
        }
        
        public override string ToString() {
            string nl = Environment.NewLine;
            double totalNotes = Marv + Perf + Great + Good + Boo + Miss;
            string s = ToStringShort() + nl + $"Date: {Date}" + nl + nl;
            s += $"\tMarvelous: {Marv} ({Math.Round((Marv / totalNotes) * 100, 2)}%)" + nl;
            s += $"\tPerfect: {Perf} ({Math.Round((Perf / totalNotes) * 100, 2)}%)" + nl;
            s += $"\tGreat: {Great} ({Math.Round((Great / totalNotes) * 100, 2)}%)" + nl;
            s += $"\tGood: {Good} ({Math.Round((Good / totalNotes) * 100, 2)}%)" + nl;
            s += $"\tBoo: {Boo} ({Math.Round((Boo / totalNotes) * 100, 2)}%)" + nl;
            s += $"\tMiss: {Miss} ({Math.Round((Miss / totalNotes) * 100, 2)}%)" + nl + nl;
            s += "\tOverall: " + Overall + nl;
            s += "\tStream: " + Stream + nl;
            s += "\tHandstream: " + Handstream + nl;
            s += "\tJumpstream: " + Jumpstream + nl;
            s += "\tStamina: " + Stamina + nl;
            s += "\tJackSpeed: " + Jackspeed + nl;
            s += "\tChordjack: " + Chordjack + nl;
            s += "\tTechnical: " + Technical + nl;
            return s;
        }
        
        public string GetSSRString() {
            string nl = Environment.NewLine;
            string ssr = "Overall: " + Overall + nl;
            ssr += "Stream: " + Stream + nl;
            ssr += "Handstream: " + Handstream + nl;
            ssr += "Jumpstream: " + Jumpstream + nl;
            ssr += "Stamina: " + Stamina + nl;
            ssr += "JackSpeed: " + Jackspeed + nl;
            ssr += "Chordjack: " + Chordjack + nl;
            ssr += "Technical: " + Technical + nl;
            return ssr;
        }
    }
}
