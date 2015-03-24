namespace MaiNeMai
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnMusicStart = new System.Windows.Forms.Button();
            this.btnMusicStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(12, 75);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "Init Game";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnMusicStart
            // 
            this.btnMusicStart.Location = new System.Drawing.Point(12, 146);
            this.btnMusicStart.Name = "btnMusicStart";
            this.btnMusicStart.Size = new System.Drawing.Size(75, 23);
            this.btnMusicStart.TabIndex = 2;
            this.btnMusicStart.Text = "Start Music";
            this.btnMusicStart.UseVisualStyleBackColor = true;
            this.btnMusicStart.Click += new System.EventHandler(this.btnMusicStart_Click);
            // 
            // btnMusicStop
            // 
            this.btnMusicStop.Location = new System.Drawing.Point(108, 146);
            this.btnMusicStop.Name = "btnMusicStop";
            this.btnMusicStop.Size = new System.Drawing.Size(75, 23);
            this.btnMusicStop.TabIndex = 3;
            this.btnMusicStop.Text = "Stop Music";
            this.btnMusicStop.UseVisualStyleBackColor = true;
            this.btnMusicStop.Click += new System.EventHandler(this.btnMusicStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnMusicStop);
            this.Controls.Add(this.btnMusicStart);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnMusicStart;
        private System.Windows.Forms.Button btnMusicStop;
    }
}

