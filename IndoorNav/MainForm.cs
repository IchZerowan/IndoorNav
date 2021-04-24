using System;
using System.Windows.Forms;

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
            for(int i = 0; i < data.Count - 2; i++)
            {
                Point p = Algorithm.Trilateration(data[i], data[i + 1], data[i + 2]);
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
