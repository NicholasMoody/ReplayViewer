using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReplayViewer
{
    public class MeasureBPMPair
    {
        public int measure;
        public double BPM;

        public MeasureBPMPair(int m, double bpm)
        {
            measure = m;
            BPM = bpm;
        }
    }
}
