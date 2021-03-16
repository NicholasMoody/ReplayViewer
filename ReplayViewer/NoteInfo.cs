using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayViewer
{
    /// <summary>
    /// Contains information about a single note. 
    /// </summary>
    public class NoteInfo
    {
        public string Note { get; }
        public double MSFromStart { get; set; }
        
        public NoteInfo (string note, double ms)
        {
            Note = note;
            MSFromStart = ms;
        }
    }
}


