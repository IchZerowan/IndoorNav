using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        public static void Log(object message)
        {
            Console.WriteLine(message);
            instance.textBoxLog.AppendText(message + "\n");
        }
    }
}
