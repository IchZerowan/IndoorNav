using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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
            Process("1-4");
            Process("1-5");
            Process("1-6");
            Process("2-2");
            Process("2-3");
            Process("2-4");
            Process("2-5");
            //Process("1-2");
            //Process("1-3");
            //Process("2-1");
            //Process("2-6");
        }

        private void Process(string name)
        {
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
                        DateTime time = temp[temp.Count - 1].timestamp;
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

                        if (p != null && RoomData.IsInBounds(p))
                        {
                            Out(p, time);
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
        private List<PointTime> points = new List<PointTime>();
        public void Out(Point p, DateTime time)
        {
            if(points.Count > 0)
            {
                var last = points.Last();
                if ((time - last.Time).TotalSeconds < 5)
                {
                    Log("Less then 5s, skip");
                    last.Point = p;
                    last.Time = time;
                }
                else
                {
                    string message = "C" + RoomData.GetRoom(last.Point) + " B" + RoomData.GetClosest(last.Point);
                    if(message != previous) {
                        Log(message);
                        Log(p.X + ";" + p.Y);
                        result += message + "\n";
                        points.Add(new PointTime(p, time));
                    }
                    previous = message;
                }
            } else
            {
                points.Add(new PointTime(p, time));
            }
            
        }

        public void SaveFile(string filename)
        {
            File.WriteAllText(filename, result);
            List<Point> toDraw = new List<Point>();
            toDraw.AddRange(points.Select(pointTime => pointTime.Point));
            //Task.Run(()=> DrawAnim(toDraw));

            points.Clear();
            result = "";
        }

        public async Task<bool> DrawAnim(List<Point> c_lp)
        {
            List<Point> draw_lp = new List<Point>();

            for (int i = 0; i < c_lp.Count; i++)
            {
                draw_lp.Add(c_lp[i]);
                pictureBoxGraphics.Image = DrawPointsOnImage.Draw(draw_lp, pictureBoxGraphics.Image);
                pictureBoxGraphics.Refresh();
                Thread.Sleep(1000);
            }
            return true;
        }
    }
}
