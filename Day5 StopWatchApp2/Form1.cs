namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //It will track how many seconds are passed
        int secondsElapsed = 0;

        //It will track lap number
        int lapCount = 0;





        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsElapsed++;
            TimeSpan time = TimeSpan.FromSeconds(secondsElapsed);
            lblDisplay.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            secondsElapsed = 0;
            lapCount = 0;
            lblDisplay.Text = "00:00:00";
            lstLaps.Items.Clear(); // Empty the ListBox
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }


        private void lstLaps_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) // Only allow laps if the clock is running
            {
                lapCount++;
                string currentTime = lblDisplay.Text;
                lstLaps.Items.Add($"Lap {lapCount}: {currentTime}");
            }
        }
    }
}
