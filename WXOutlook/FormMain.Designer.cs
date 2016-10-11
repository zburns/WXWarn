namespace WXOutlook
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.textBoxHazzardReport = new System.Windows.Forms.TextBox();
            this.labelMorning = new System.Windows.Forms.Label();
            this.labelAfternoon = new System.Windows.Forms.Label();
            this.labelEvening = new System.Windows.Forms.Label();
            this.checkBoxSendAlertToEmail = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayAlertIfHazzard = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTime.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(506, 23);
            this.labelCurrentTime.TabIndex = 0;
            this.labelCurrentTime.Text = "Current Time";
            this.labelCurrentTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerClock
            // 
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // textBoxHazzardReport
            // 
            this.textBoxHazzardReport.Location = new System.Drawing.Point(16, 76);
            this.textBoxHazzardReport.Multiline = true;
            this.textBoxHazzardReport.Name = "textBoxHazzardReport";
            this.textBoxHazzardReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHazzardReport.Size = new System.Drawing.Size(502, 228);
            this.textBoxHazzardReport.TabIndex = 1;
            // 
            // labelMorning
            // 
            this.labelMorning.BackColor = System.Drawing.Color.Yellow;
            this.labelMorning.Location = new System.Drawing.Point(13, 42);
            this.labelMorning.Name = "labelMorning";
            this.labelMorning.Size = new System.Drawing.Size(142, 23);
            this.labelMorning.TabIndex = 2;
            this.labelMorning.Text = "Morning (00:00 - 12:00)";
            this.labelMorning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAfternoon
            // 
            this.labelAfternoon.BackColor = System.Drawing.Color.Yellow;
            this.labelAfternoon.Location = new System.Drawing.Point(194, 41);
            this.labelAfternoon.Name = "labelAfternoon";
            this.labelAfternoon.Size = new System.Drawing.Size(142, 23);
            this.labelAfternoon.TabIndex = 3;
            this.labelAfternoon.Text = "Afternoon (13:00 - 17:00)";
            this.labelAfternoon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEvening
            // 
            this.labelEvening.BackColor = System.Drawing.Color.Yellow;
            this.labelEvening.Location = new System.Drawing.Point(376, 41);
            this.labelEvening.Name = "labelEvening";
            this.labelEvening.Size = new System.Drawing.Size(142, 23);
            this.labelEvening.TabIndex = 4;
            this.labelEvening.Text = "Evening (18:00 - 23:00)";
            this.labelEvening.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxSendAlertToEmail
            // 
            this.checkBoxSendAlertToEmail.AutoSize = true;
            this.checkBoxSendAlertToEmail.Location = new System.Drawing.Point(16, 310);
            this.checkBoxSendAlertToEmail.Name = "checkBoxSendAlertToEmail";
            this.checkBoxSendAlertToEmail.Size = new System.Drawing.Size(115, 17);
            this.checkBoxSendAlertToEmail.TabIndex = 5;
            this.checkBoxSendAlertToEmail.Text = "Send Alert to Email";
            this.checkBoxSendAlertToEmail.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlayAlertIfHazzard
            // 
            this.checkBoxPlayAlertIfHazzard.AutoSize = true;
            this.checkBoxPlayAlertIfHazzard.Location = new System.Drawing.Point(187, 310);
            this.checkBoxPlayAlertIfHazzard.Name = "checkBoxPlayAlertIfHazzard";
            this.checkBoxPlayAlertIfHazzard.Size = new System.Drawing.Size(115, 17);
            this.checkBoxPlayAlertIfHazzard.TabIndex = 6;
            this.checkBoxPlayAlertIfHazzard.Text = "Play Alert if Hazard";
            this.checkBoxPlayAlertIfHazzard.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(346, 310);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Play Alert if Skywarn Activation";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 333);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBoxPlayAlertIfHazzard);
            this.Controls.Add(this.checkBoxSendAlertToEmail);
            this.Controls.Add(this.labelEvening);
            this.Controls.Add(this.labelAfternoon);
            this.Controls.Add(this.labelMorning);
            this.Controls.Add(this.textBoxHazzardReport);
            this.Controls.Add(this.labelCurrentTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hazardous Weather Outlook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.TextBox textBoxHazzardReport;
        private System.Windows.Forms.Label labelMorning;
        private System.Windows.Forms.Label labelAfternoon;
        private System.Windows.Forms.Label labelEvening;
        private System.Windows.Forms.CheckBox checkBoxSendAlertToEmail;
        private System.Windows.Forms.CheckBox checkBoxPlayAlertIfHazzard;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

