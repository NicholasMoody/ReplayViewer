using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ReplayViewer {
    class XMLParser {
        XmlDocument src = new XmlDocument();
        //public List<Chart> charts = new List<Chart>(); // stop working with charts because it just seems like more work without real benefit
        public List<Score> scores = new List<Score>();
        public XMLParser() {
            src.Load(@"D:\Games\New folder\Etterna\Save\LocalProfiles\00000000\Etterna.xml");
            XmlNodeList chartsXML = src.GetElementsByTagName("Chart");
            // for each chart
            foreach (XmlNode chartNode in chartsXML) {
                XmlDocument actualChartXML = new XmlDocument();
                actualChartXML.LoadXml(chartNode.OuterXml);
                XmlNodeList scoresAt = actualChartXML.GetElementsByTagName("ScoresAt");
                Chart c = new Chart(actualChartXML.FirstChild.Attributes["Song"].Value);

                foreach (XmlNode xmlScores in scoresAt) {
                    XmlNodeList actualXmlScores = xmlScores.ChildNodes;
                    foreach (XmlNode sc in actualXmlScores) {
                        XmlNodeList scoreInfoXML = sc.ChildNodes;
                        Score s = new Score();
                        s.ChartName = c.Name;
                        s.Key = sc.Attributes["Key"].Value;
                        s.Rate = double.Parse(xmlScores.Attributes["Rate"].Value);
                        foreach (XmlNode sAttr in scoreInfoXML) {
                            if (sAttr.Name == "SSRNormPercent") {
                                s.Wife = double.Parse(sAttr.InnerText);
                            }
                            else if (sAttr.Name == "EtternaValid") {
                                s.Valid = sAttr.InnerText == "1";
                            }
                            else if (sAttr.Name == "DateTime") {
                                s.Date = sAttr.InnerText.Split(' ')[0]; // extract only date, excluding time
                            }
                            else if (sAttr.Name == "SkillsetSSRs") {
                                XmlNodeList skillsetsXml = sAttr.ChildNodes;
                                foreach (XmlNode ssNode in skillsetsXml) {
                                    if (ssNode.Name == "Overall")
                                        s.Overall = double.Parse(ssNode.InnerText);
                                    else if (ssNode.Name == "Stream")
                                        s.Stream = double.Parse(ssNode.InnerText);
                                    else if (ssNode.Name == "Jumpstream")
                                        s.Jumpstream = double.Parse(ssNode.InnerText);
                                    else if (ssNode.Name == "Handstream")
                                        s.Handstream = double.Parse(ssNode.InnerText);
                                    else if (ssNode.Name == "Stamina")
                                        s.Stamina = double.Parse(ssNode.InnerText);
                                    else if (ssNode.Name == "JackSpeed")
                                        s.Jackspeed = double.Parse(ssNode.InnerText);
                                    else if (ssNode.Name == "Chordjack")
                                        s.Chordjack = double.Parse(ssNode.InnerText);
                                    else if (ssNode.Name == "Technical")
                                        s.Technical = double.Parse(ssNode.InnerText);
                                }
                            }
                            else if (sAttr.Name == "TapNoteScores") {
                                XmlNodeList tapNoteXml = sAttr.ChildNodes;
                                foreach (XmlNode tapNode in tapNoteXml) {
                                    if (tapNode.Name == "W1") 
                                        s.Marv = double.Parse(tapNode.InnerText);
                                    else if (tapNode.Name == "W2") 
                                        s.Perf = double.Parse(tapNode.InnerText);
                                    else if (tapNode.Name == "W3") 
                                        s.Great = double.Parse(tapNode.InnerText);
                                    else if (tapNode.Name == "W4")
                                        s.Good = double.Parse(tapNode.InnerText);
                                    else if (tapNode.Name == "W5") 
                                        s.Boo = double.Parse(tapNode.InnerText);
                                    else if (tapNode.Name == "Miss") 
                                        s.Miss = double.Parse(tapNode.InnerText);
                                }
                            }
                        }
                        scores.Add(s);
                        //c.Scores.Add(s);
                    }
                }
                //charts.Add(c); 
            }
        } 
    }
}
