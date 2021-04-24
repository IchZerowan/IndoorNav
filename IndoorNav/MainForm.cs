using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace IndoorNav
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Process("1-1");
            Process("1-2");
            Process("1-3");
            Process("2-1");
            Process("2-6");
        }

        private void Process(string name) {
            var data = CSVParser.ReadCSV("data-" + name + ".csv");

            int invalidCount = 0;

            List<PointData> temp = new List<PointData>();
            foreach (PointData pd in data)
            {
                if (temp.Where(x => x.id == pd.id).Count() != 0)
                {
                    Log("Temp count: " + temp.Count);
                    if (temp.Count >= 3)
                    {
                        temp.Sort((pd1, pd2) => pd1.rssi.CompareTo(pd2.rssi));
                        temp.Reverse();
                        Point p = null;
                        int skip = 0;
                        while (p == null)
                        {
                            List<PointData> result = temp.Skip(skip++).Take(3).ToList();
                            if (result.Count < 3)
                            {
                                break;
                            }
                            p = Algorithm.Trilateration(temp[0], temp[1], temp[2]);
                        }

                        if (p != null)
                        {
                            Out("C" + RoomData.GetRoom(p) + " B" + RoomData.GetClosest(p));
                        }
                        else
                        {
                            Log("No intersections");
                            invalidCount++;
                        }
                    }
                    temp.Clear();
                }

                temp.Add(pd);
            }

            Log("Invalid count: " + invalidCount);

            SaveFile("out-" + name + ".txt");
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
            textBoxLog.AppendText(message + "\r\n");
        }

        private string result = "";
        private string previous = "";
        public void Out(string message)
        {
            Log(message);
            if(previous == message)
            {
                return;
            }
            previous = message;
            result += message + "\n";
        }

        public void SaveFile(string filename)
        {
            File.WriteAllText(filename, result);
            result = "";
        }
    }
}
