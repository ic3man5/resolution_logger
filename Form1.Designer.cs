using System.Windows.Forms;

namespace resolution_logger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        private long start_ms = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
        protected override void WndProc(ref Message m)
        {
            const int WM_DISPLAYCHANGE = 0x007E;
            switch (m.Msg)
            {
                case WM_DISPLAYCHANGE:
                    long now = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                    double elapsed = (now - start_ms) / 1000.0;
                    string screenWidth = SystemInformation.PrimaryMonitorSize.Width.ToString();
                    string screenHeight = SystemInformation.PrimaryMonitorSize.Height.ToString();
                    textBox1.Text += ("[" + elapsed.ToString() + "] Resolution Change: " + screenWidth + "x" + screenHeight + "\r\n");
                    start_ms = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
                    break;
            }
            base.WndProc(ref m);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(483, 237);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 261);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Resolution Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
    }
}

