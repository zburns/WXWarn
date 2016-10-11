namespace WXWarn
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
            this.timerPoll = new System.Windows.Forms.Timer(this.components);
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.dataGridViewFeedTable = new System.Windows.Forms.DataGridView();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.Zone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxTextToSpeech = new System.Windows.Forms.CheckBox();
            this.labelDetailedNWSData = new System.Windows.Forms.Label();
            this.checkBoxPlayAlertSounds = new System.Windows.Forms.CheckBox();
            this.linkLabelCopyright = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeedTable)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPoll
            // 
            this.timerPoll.Interval = 1000;
            this.timerPoll.Tick += new System.EventHandler(this.timerPoll_Tick);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(12, 228);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(602, 218);
            this.textBoxStatus.TabIndex = 0;
            // 
            // dataGridViewFeedTable
            // 
            this.dataGridViewFeedTable.AllowUserToAddRows = false;
            this.dataGridViewFeedTable.AllowUserToDeleteRows = false;
            this.dataGridViewFeedTable.AllowUserToResizeColumns = false;
            this.dataGridViewFeedTable.AllowUserToResizeRows = false;
            this.dataGridViewFeedTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeedTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Zone,
            this.NextUpdate,
            this.Activity});
            this.dataGridViewFeedTable.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewFeedTable.Name = "dataGridViewFeedTable";
            this.dataGridViewFeedTable.ReadOnly = true;
            this.dataGridViewFeedTable.RowHeadersVisible = false;
            this.dataGridViewFeedTable.Size = new System.Drawing.Size(602, 150);
            this.dataGridViewFeedTable.TabIndex = 1;
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTime.Location = new System.Drawing.Point(130, 167);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(219, 23);
            this.labelCurrentTime.TabIndex = 2;
            this.labelCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTime
            // 
            this.labelTime.Location = new System.Drawing.Point(12, 167);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(112, 23);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "Current Date/Time:";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Zone
            // 
            this.Zone.HeaderText = "Zone ID";
            this.Zone.Name = "Zone";
            this.Zone.ReadOnly = true;
            this.Zone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NextUpdate
            // 
            this.NextUpdate.HeaderText = "Next Update";
            this.NextUpdate.Name = "NextUpdate";
            this.NextUpdate.ReadOnly = true;
            this.NextUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NextUpdate.Width = 200;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Watch/Warning Activity";
            this.Activity.Name = "Activity";
            this.Activity.ReadOnly = true;
            this.Activity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Activity.Width = 275;
            // 
            // checkBoxTextToSpeech
            // 
            this.checkBoxTextToSpeech.AutoSize = true;
            this.checkBoxTextToSpeech.Location = new System.Drawing.Point(515, 171);
            this.checkBoxTextToSpeech.Name = "checkBoxTextToSpeech";
            this.checkBoxTextToSpeech.Size = new System.Drawing.Size(99, 17);
            this.checkBoxTextToSpeech.TabIndex = 4;
            this.checkBoxTextToSpeech.Text = "Text to Speech";
            this.checkBoxTextToSpeech.UseVisualStyleBackColor = true;
            // 
            // labelDetailedNWSData
            // 
            this.labelDetailedNWSData.Location = new System.Drawing.Point(12, 207);
            this.labelDetailedNWSData.Name = "labelDetailedNWSData";
            this.labelDetailedNWSData.Size = new System.Drawing.Size(602, 18);
            this.labelDetailedNWSData.TabIndex = 5;
            this.labelDetailedNWSData.Text = "National Weather Service Data Connection and Watch/Warning Information";
            this.labelDetailedNWSData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxPlayAlertSounds
            // 
            this.checkBoxPlayAlertSounds.AutoSize = true;
            this.checkBoxPlayAlertSounds.Location = new System.Drawing.Point(386, 171);
            this.checkBoxPlayAlertSounds.Name = "checkBoxPlayAlertSounds";
            this.checkBoxPlayAlertSounds.Size = new System.Drawing.Size(109, 17);
            this.checkBoxPlayAlertSounds.TabIndex = 6;
            this.checkBoxPlayAlertSounds.Text = "Play Alert Sounds";
            this.checkBoxPlayAlertSounds.UseVisualStyleBackColor = true;
            // 
            // linkLabelCopyright
            // 
            this.linkLabelCopyright.Location = new System.Drawing.Point(12, 449);
            this.linkLabelCopyright.Name = "linkLabelCopyright";
            this.linkLabelCopyright.Size = new System.Drawing.Size(602, 22);
            this.linkLabelCopyright.TabIndex = 7;
            this.linkLabelCopyright.TabStop = true;
            this.linkLabelCopyright.Text = "Copyright 2011 Zachary Burns - weather@zackburns.com - All Rights Reserved.  Read" +
    " Important Legal Notice Here";
            this.linkLabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelCopyright.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabelCopyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCopyright_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 477);
            this.Controls.Add(this.linkLabelCopyright);
            this.Controls.Add(this.checkBoxPlayAlertSounds);
            this.Controls.Add(this.labelDetailedNWSData);
            this.Controls.Add(this.checkBoxTextToSpeech);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.dataGridViewFeedTable);
            this.Controls.Add(this.textBoxStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WXWarn";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeedTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerPoll;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.DataGridView dataGridViewFeedTable;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zone;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.CheckBox checkBoxTextToSpeech;
        private System.Windows.Forms.Label labelDetailedNWSData;
        private System.Windows.Forms.CheckBox checkBoxPlayAlertSounds;
        private System.Windows.Forms.LinkLabel linkLabelCopyright;
    }
}

