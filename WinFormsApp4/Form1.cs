namespace WinFormsApp4
{

    public partial class Form1 : Form
    {
        int h, m, s; // Hours, Minutes, Seconds

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize variables
            h = m = s = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s++; // Increment seconds
            if (s >= 60)
            {
                s = 0;
                m++;
            }
            if (m >= 60)
            {
                m = 0;
                h++;
            }

            // Update your text boxes/labels (assuming they are named txtH, txtM, txtS)
            txtH.Text = h.ToString("00");
            txtM.Text = m.ToString("00");
            txtS.Text = s.ToString("00");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                btnStart.Text = "Start";
            }
            else
            {
                timer1.Start();
                btnStart.Text = "Stop";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string timeRecord = $"Saved Time: {h:00}:{m:00}:{s:00}";

            // This appends the time to a file named "log.txt" in your debug folder
            System.IO.File.AppendAllText("log.txt", timeRecord + Environment.NewLine);

            MessageBox.Show("Time Saved Successfully!");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // Pause the time
            h = m = s = 0; // Set variables back to zero

            // Update the display
            txtH.Text = "00";
            txtM.Text = "00";
            txtS.Text = "00";

            // Reset the Start button text so the user can start over
            btnStart.Text = "Start";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Construct the time string
            string currentTime = $"{txtH.Text}:{txtM.Text}:{txtS.Text}";

            try
            {
                // This saves a file named "StopwatchLog.txt" in your project's Debug folder
                System.IO.File.AppendAllText("StopwatchLog.txt", $"Logged at {DateTime.Now}: {currentTime}{Environment.NewLine}");
                MessageBox.Show("Time saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message);
            }
        }
    }
}
