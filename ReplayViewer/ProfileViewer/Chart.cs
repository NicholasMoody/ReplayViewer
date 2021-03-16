using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayViewer {
    class Chart {
        public string Name;
        public List<Score> Scores = new List<Score>();
        public Chart(string n) {
            Name = n;
        }
    }
}
