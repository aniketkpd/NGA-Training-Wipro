using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Day6_StopWatchApp
{
    public partial class Form1 : Form
    {
        // High-precision timer object
        private Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
        }

        // This runs every time the timer "ticks" (every 10ms)
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDisplay.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            timer1.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            lblDisplay.Text = "00:00:00.00";
            lstLaps.Items.Clear();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                lstLaps.Items.Add(lblDisplay.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
