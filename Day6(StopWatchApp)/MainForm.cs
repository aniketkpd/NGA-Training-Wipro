using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace StopwatchWinForms
{
    public class MainForm : Form
    {
        private Label lblTime;
        private Button btnStartStop;
        private Button btnReset;
        private Button btnLap;
        private Button btnSave;
        private ListBox lstLaps;
        private Timer uiTimer;
        private Stopwatch stopwatch;

        public MainForm()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            uiTimer = new Timer();
            uiTimer.Interval = 1000; // update every second
            uiTimer.Tick += UiTimer_Tick;
            UpdateTimeLabel(TimeSpan.Zero);
        }

        private void UiTimer_Tick(object? sender, EventArgs e)
        {
            UpdateTimeLabel(stopwatch.Elapsed);
        }

        private void InitializeComponent()
        {
            this.Text = "Stopwatch";
            this.ClientSize = new System.Drawing.Size(420, 360);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTime = new Label();
            lblTime.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblTime.AutoSize = false;
            lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTime.Size = new System.Drawing.Size(380, 60);
            lblTime.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(lblTime);

            btnStartStop = new Button();
            btnStartStop.Text = "Start";
            btnStartStop.Size = new System.Drawing.Size(80, 36);
            btnStartStop.Location = new System.Drawing.Point(20, 100);
            btnStartStop.Click += BtnStartStop_Click;
            this.Controls.Add(btnStartStop);

            btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Size = new System.Drawing.Size(80, 36);
            btnReset.Location = new System.Drawing.Point(110, 100);
            btnReset.Click += BtnReset_Click;
            this.Controls.Add(btnReset);

            btnLap = new Button();
            btnLap.Text = "Lap";
            btnLap.Size = new System.Drawing.Size(80, 36);
            btnLap.Location = new System.Drawing.Point(200, 100);
            btnLap.Click += BtnLap_Click;
            this.Controls.Add(btnLap);

            btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Size = new System.Drawing.Size(80, 36);
            btnSave.Location = new System.Drawing.Point(290, 100);
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            lstLaps = new ListBox();
            lstLaps.Location = new System.Drawing.Point(20, 150);
            lstLaps.Size = new System.Drawing.Size(360, 180);
            this.Controls.Add(lstLaps);
        }

        private void BtnStartStop_Click(object? sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                uiTimer.Start();
                btnStartStop.Text = "Stop";
            }
            else
            {
                stopwatch.Stop();
                uiTimer.Stop();
                btnStartStop.Text = "Start";
            }
            UpdateTimeLabel(stopwatch.Elapsed);
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            stopwatch.Reset();
            uiTimer.Stop();
            btnStartStop.Text = "Start";
            UpdateTimeLabel(TimeSpan.Zero);
            lstLaps.Items.Clear();
        }

        private void BtnLap_Click(object? sender, EventArgs e)
        {
            var elapsed = stopwatch.Elapsed;
            lstLaps.Items.Insert(0, FormatTime(elapsed));
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (lstLaps.Items.Count == 0)
            {
                MessageBox.Show("No lap times to save.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog();
            sfd.Title = "Save Lap Times";
            sfd.Filter = "Text Files|*.txt|All Files|*.*";
            sfd.FileName = "laps.txt";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var sw = new StreamWriter(sfd.FileName);
                foreach (var item in lstLaps.Items)
                {
                    sw.WriteLine(item.ToString());
                }
                MessageBox.Show("Lap times saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTimeLabel(TimeSpan t)
        {
            lblTime.Text = FormatTime(t);
        }

        private static string FormatTime(TimeSpan t)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
        }
    }
}
