using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace IndoorNav
{
    public partial class MainForm : Form
    {
        private static MainForm instance;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            instance = this;
            var data = CSVParser.ReadCSV("data-1-1.csv");

            List<PointData> temp = new List<PointData>();
            foreach (PointData pd in data)
            {
                if (temp.Where(x => x.id == pd.id).Count() != 0)
                {
                    if(temp.Count >= 3)
                    {
                        temp.Sort((pd1, pd2) => pd1.rssi.CompareTo(pd2.rssi));
                        temp.Reverse();
                        temp = temp.Take(3).ToList();
                        Point p = Algorithm.Trilateration(temp[0], temp[1], temp[2]);
                        if(p != null)
                        {
                            Log("C" + RoomData.GetRoom(p) + " B" + RoomData.GetClosest(p));
                        } else
                        {
                            
                        }
                    }
                    temp.Clear();
                }

                temp.Add(pd);
            }

            for(int i = 0; i < data.Count - 2; i++)
            {
                Point p = Algorithm.Trilateration(data[i], data[i + 1], data[i + 2]);
                if(p == null)
                {
                    Log("invalid");
                    continue;
                }
                int room = RoomData.GetRoom(p);
                Log("C" + room);
            }
        }

        public static void Log(object message)
        {
            Console.WriteLine(message);
            instance.textBoxLog.AppendText(message + "\n");
        }
    }
}
