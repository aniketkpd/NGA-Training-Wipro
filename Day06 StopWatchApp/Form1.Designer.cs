namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnReset = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lblDisplay = new Label();
            btnStop = new Button();
            btnLap = new Button();
            lstLaps = new ListBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Silver;
            btnStart.Location = new Point(54, 487);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(205, 105);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Silver;
            btnReset.Location = new Point(1099, 487);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(205, 105);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblDisplay
            // 
            lblDisplay.AutoSize = true;
            lblDisplay.BackColor = Color.Transparent;
            lblDisplay.Font = new Font("Segoe UI", 50F);
            lblDisplay.ForeColor = Color.SpringGreen;
            lblDisplay.Location = new Point(198, 150);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(353, 112);
            lblDisplay.TabIndex = 2;
            lblDisplay.Text = "00:00:00";
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Silver;
            btnStop.Location = new Point(383, 487);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(205, 105);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnLap
            // 
            btnLap.BackColor = Color.Silver;
            btnLap.Location = new Point(742, 487);
            btnLap.Name = "btnLap";
            btnLap.Size = new Size(205, 105);
            btnLap.TabIndex = 4;
            btnLap.Text = "Lap";
            btnLap.UseVisualStyleBackColor = false;
            btnLap.Click += btnLap_Click;
            // 
            // lstLaps
            // 
            lstLaps.BackColor = Color.Tan;
            lstLaps.Font = new Font("Segoe UI", 30F);
            lstLaps.FormattingEnabled = true;
            lstLaps.Location = new Point(785, 21);
            lstLaps.Name = "lstLaps";
            lstLaps.Size = new Size(519, 339);
            lstLaps.TabIndex = 5;
            lstLaps.SelectedIndexChanged += lstLaps_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1360, 641);
            Controls.Add(lstLaps);
            Controls.Add(btnLap);
            Controls.Add(btnStop);
            Controls.Add(lblDisplay);
            Controls.Add(btnReset);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnReset;
        private System.Windows.Forms.Timer timer1;
        private Label lblDisplay;
        private Button btnStop;
        private Button btnLap;
        private ListBox lstLaps;
    }
}
