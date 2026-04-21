//namespace Day6_StopWatchApp
//{
//    partial class Form1
//    {
//        /// <summary>
//        ///  Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        ///  Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        ///  Required method for Designer support - do not modify
//        ///  the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            button1 = new Button();
//            SuspendLayout();
//            // 
//            // button1
//            // 
//            button1.Location = new Point(637, 220);
//            button1.Name = "button1";
//            button1.Size = new Size(94, 29);
//            button1.TabIndex = 0;
//            button1.Text = "button1";
//            button1.UseVisualStyleBackColor = true;
//            // 
//            // Form1
//            // 
//            AutoScaleDimensions = new SizeF(8F, 20F);
//            AutoScaleMode = AutoScaleMode.Font;
//            ClientSize = new Size(1109, 674);
//            Controls.Add(button1);
//            Name = "Form1";
//            Text = "Form1";
//            Load += Form1_Load;
//            ResumeLayout(false);
//        }

//        #endregion

//        private Button button1;
//    }
//}










namespace Day6_StopWatchApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblDisplay = new Label();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            btnLap = new Button();
            lstLaps = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblDisplay
            // 
            lblDisplay.AutoSize = true;
            lblDisplay.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblDisplay.Location = new Point(67, 46);
            lblDisplay.Margin = new Padding(4, 0, 4, 0);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(261, 60);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "00:00:00.00";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(67, 154);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 46);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(180, 154);
            btnStop.Margin = new Padding(4, 5, 4, 5);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 46);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(180, 215);
            btnReset.Margin = new Padding(4, 5, 4, 5);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 46);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnLap
            // 
            btnLap.Location = new Point(67, 215);
            btnLap.Margin = new Padding(4, 5, 4, 5);
            btnLap.Name = "btnLap";
            btnLap.Size = new Size(100, 46);
            btnLap.TabIndex = 3;
            btnLap.Text = "Lap";
            btnLap.UseVisualStyleBackColor = true;
            btnLap.Click += btnLap_Click;
            // 
            // lstLaps
            // 
            lstLaps.FormattingEnabled = true;
            lstLaps.Location = new Point(67, 292);
            lstLaps.Margin = new Padding(4, 5, 4, 5);
            lstLaps.Name = "lstLaps";
            lstLaps.Size = new Size(212, 144);
            lstLaps.TabIndex = 5;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 504);
            Controls.Add(lstLaps);
            Controls.Add(btnReset);
            Controls.Add(btnLap);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblDisplay);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Stopwatch";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.ListBox lstLaps;
        private System.Windows.Forms.Timer timer1;
    }
}