using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ReplayViewer
{
    public static class Parser
    {
        public static ChartData ParseChart(string path)
        {
            ChartData chart = new ChartData();
            string[] fileData = File.ReadAllLines(path);
            List<MeasureBPMPair> BPMs = new List<MeasureBPMPair>();
            bool notesStarted = false;
            double time = 0;
            int currMeasure = 0;
            double currBPM;
            for (int i = 0; i < fileData.Length; i++)
            {
                if (notesStarted)
                {
                    currBPM = BPMs[0].BPM;
                    int quant = 0;
                    int j = i;
                    // determine quantization
                    while (fileData[j] != "," && fileData[j] != ";")
                    {
                        quant++;
                        j++;
                    }
                    double nps = (currBPM * ((double)quant / 4.0)) / 60;
                    double gap = 1.0 / nps;
                    // now add relevant notes with their timings
                    for (j = i; j < i + quant; j++)
                    {
                        string note = fileData[j];
                        time += gap;
                        note.Replace('2', '1');
                        if (note.Contains("1"))
                        {
                            for (int n = 0; n < 4; n++)
                            {
                                if (note[n] == '1')
                                {
                                    string isolatedNote = "000";
                                    isolatedNote = isolatedNote.Insert(n, "1");
                                    chart.NoteData.Add(new NoteInfo(isolatedNote, time));
                                }
                            }
                        }
                    }

                    while (fileData[i] != "," && fileData[i] != ";")
                        i++;

                    currMeasure++;
                    // update bpm if necessary
                    if (BPMs.Count > 1 && BPMs[1].measure >= currMeasure)
                    {
                        currBPM = BPMs[1].BPM;
                        BPMs.RemoveAt(0);
                    }
                    continue;
                }

                if (fileData[i].Contains("#BPMS:"))
                {
                    string bpmData = fileData[i];
                    while (!fileData[i].Contains(";")) 
                    {
                        i++;
                        bpmData += fileData[i];
                    }
                    BPMs = ParseBPMs(bpmData);
                }

                if (fileData[i].Contains("#NOTES:"))
                {
                    while (fileData[i].Length != 4 || fileData[i].Contains(" ")) 
                        i++;
                    i--;
                    notesStarted = true;
                }
            }
            return chart;
        }

        private static List<MeasureBPMPair> ParseBPMs(string data)
        {
            List<MeasureBPMPair> BPMs = new List<MeasureBPMPair>();
            string[] changes = data.Split(',');
            if (changes[changes.Length - 1].Contains(";"))
            {
                changes[changes.Length - 1] = changes[changes.Length - 1].Replace(";", "");
            }
            foreach (string s in changes)
            {
                string line = s;
                if (s.Contains("#BPMS:"))
                    line = s.Remove(0, 6);
                string[] d = line.Split('=');
                if (d.Length != 2)
                    break;
                int measure = (int)double.Parse(d[0]);
                double bpm; 
                double.TryParse(d[1], out bpm);
                MeasureBPMPair pair = new MeasureBPMPair(measure, bpm);
                BPMs.Add(pair);
            }
            return BPMs;
        }
    }
}
