namespace WinFormsApp4
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            btnSave = new Button();
            txtH = new RichTextBox();
            txtM = new RichTextBox();
            txtS = new RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(150, 398);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(196, 85);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(420, 398);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(196, 85);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(723, 398);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(196, 85);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // txtH
            // 
            txtH.Font = new Font("Segoe UI", 50F);
            txtH.ForeColor = Color.DimGray;
            txtH.Location = new Point(150, 175);
            txtH.Name = "txtH";
            txtH.ReadOnly = true;
            txtH.Size = new Size(196, 120);
            txtH.TabIndex = 3;
            txtH.Text = "00";
            // 
            // txtM
            // 
            txtM.Font = new Font("Segoe UI", 50F);
            txtM.ForeColor = Color.DimGray;
            txtM.Location = new Point(420, 175);
            txtM.Name = "txtM";
            txtM.ReadOnly = true;
            txtM.Size = new Size(196, 120);
            txtM.TabIndex = 4;
            txtM.Text = "00";
            // 
            // txtS
            // 
            txtS.Font = new Font("Segoe UI", 50F);
            txtS.ForeColor = Color.DimGray;
            txtS.Location = new Point(723, 175);
            txtS.Name = "txtS";
            txtS.ReadOnly = true;
            txtS.Size = new Size(196, 120);
            txtS.TabIndex = 5;
            txtS.Text = "00";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 645);
            Controls.Add(txtS);
            Controls.Add(txtM);
            Controls.Add(txtH);
            Controls.Add(btnSave);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnSave; // Renamed from button3
        private RichTextBox txtH;
        private RichTextBox txtM;
        private RichTextBox txtS;
        private System.Windows.Forms.Timer timer1;
    }
}