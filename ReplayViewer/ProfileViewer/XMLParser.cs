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
        public List<Chart> charts = new List<Chart>();
        public XMLParser() {
            src.Load(@"D:\Games\New folder\Etterna\Save\LocalProfiles\00000000\Etterna.xml");
            XmlNodeList chartsXML = src.GetElementsByTagName("Chart");
            // for each chart
            foreach (XmlNode chartNode in chartsXML) {
                XmlDocument bad = new XmlDocument();
                bad.LoadXml(chartNode.OuterXml);
                XmlNodeList scoresAt = bad.GetElementsByTagName("ScoresAt");
                Chart c = new Chart(bad.FirstChild.Attributes["Song"].Value);

                foreach (XmlNode xmlScores in scoresAt) {
                    XmlNodeList actualXmlScores = xmlScores.ChildNodes;
                    foreach (XmlNode sc in actualXmlScores) {
                        XmlNodeList scoreInfoXML = sc.ChildNodes;
                        Score s = new Score();
                        s.Rate = xmlScores.Attributes["Rate"].Value;
                        foreach (XmlNode sAttr in scoreInfoXML) {
                            if (sAttr.Name == "WifeScore") {
                                s.Wife = sAttr.InnerText;
                            }
                            else if (sAttr.Name == "TapNoteScores") {
                                XmlNodeList tapNoteXml = sAttr.ChildNodes;
                                foreach (XmlNode tapNode in tapNoteXml) {
                                    if (tapNode.Name == "W1") {
                                        s.Marv = tapNode.InnerText;
                                    }
                                    else if (tapNode.Name == "W2") {
                                        s.Perf = tapNode.InnerText;
                                    }
                                    else if (tapNode.Name == "W3") {
                                        s.Great = tapNode.InnerText;
                                    }
                                    else if (tapNode.Name == "W4") {
                                        s.Good = tapNode.InnerText;
                                    }
                                    else if (tapNode.Name == "W5") {
                                        s.Boo = tapNode.InnerText;
                                    }
                                    else if (tapNode.Name == "Miss") {
                                        s.Miss = tapNode.InnerText;
                                    }
                                }
                            }
                        }
                        c.Scores.Add(s);
                    }
                }
                charts.Add(c);
            }
        } 
    }
}
