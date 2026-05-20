namespace CareBridgeClinic.Forms
{
    partial class MainForm
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

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.FlowLayoutPanel statsPanel;
        
        private System.Windows.Forms.Panel pnlStatDoctors;
        private System.Windows.Forms.Label lblStatDoctorsTitle;
        private System.Windows.Forms.Label lblTotalDoctors;

        private System.Windows.Forms.Panel pnlStatPatients;
        private System.Windows.Forms.Label lblStatPatientsTitle;
        private System.Windows.Forms.Label lblTotalPatients;

        private System.Windows.Forms.Panel pnlStatToday;
        private System.Windows.Forms.Label lblStatTodayTitle;
        private System.Windows.Forms.Label lblTodayAppointments;

        private System.Windows.Forms.Panel pnlStatPending;
        private System.Windows.Forms.Label lblStatPendingTitle;
        private System.Windows.Forms.Label lblPendingAppts;

        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Button btnDocs;
        private System.Windows.Forms.Button btnApps;
        private System.Windows.Forms.Button btnLogout;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlStatDoctors = new System.Windows.Forms.Panel();
            this.lblStatDoctorsTitle = new System.Windows.Forms.Label();
            this.lblTotalDoctors = new System.Windows.Forms.Label();
            this.pnlStatPatients = new System.Windows.Forms.Panel();
            this.lblStatPatientsTitle = new System.Windows.Forms.Label();
            this.lblTotalPatients = new System.Windows.Forms.Label();
            this.pnlStatToday = new System.Windows.Forms.Panel();
            this.lblStatTodayTitle = new System.Windows.Forms.Label();
            this.lblTodayAppointments = new System.Windows.Forms.Label();
            this.pnlStatPending = new System.Windows.Forms.Panel();
            this.lblStatPendingTitle = new System.Windows.Forms.Label();
            this.lblPendingAppts = new System.Windows.Forms.Label();
            this.navPanel = new System.Windows.Forms.Panel();
            this.btnDocs = new System.Windows.Forms.Button();
            this.btnApps = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.statsPanel.SuspendLayout();
            this.pnlStatDoctors.SuspendLayout();
            this.pnlStatPatients.SuspendLayout();
            this.pnlStatToday.SuspendLayout();
            this.pnlStatPending.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Controls.Add(this.picLogo);
            this.header.Controls.Add(this.headerLabel);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1024, 70);
            this.header.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(30, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // headerLabel
            // 
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Padding = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.headerLabel.Size = new System.Drawing.Size(1024, 70);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "CareBridge Clinic — Staff Panel";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.pnlStatDoctors);
            this.statsPanel.Controls.Add(this.pnlStatPatients);
            this.statsPanel.Controls.Add(this.pnlStatToday);
            this.statsPanel.Controls.Add(this.pnlStatPending);
            this.statsPanel.Location = new System.Drawing.Point(50, 100);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(920, 120);
            this.statsPanel.TabIndex = 1;
            this.statsPanel.WrapContents = false;
            // 
            // pnlStatDoctors
            // 
            this.pnlStatDoctors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlStatDoctors.Controls.Add(this.lblStatDoctorsTitle);
            this.pnlStatDoctors.Controls.Add(this.lblTotalDoctors);
            this.pnlStatDoctors.Location = new System.Drawing.Point(10, 10);
            this.pnlStatDoctors.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStatDoctors.Name = "pnlStatDoctors";
            this.pnlStatDoctors.Size = new System.Drawing.Size(210, 100);
            this.pnlStatDoctors.TabIndex = 0;
            // 
            // lblStatDoctorsTitle
            // 
            this.lblStatDoctorsTitle.AutoSize = true;
            this.lblStatDoctorsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatDoctorsTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatDoctorsTitle.Location = new System.Drawing.Point(14, 12);
            this.lblStatDoctorsTitle.Name = "lblStatDoctorsTitle";
            this.lblStatDoctorsTitle.Size = new System.Drawing.Size(111, 21);
            this.lblStatDoctorsTitle.TabIndex = 0;
            this.lblStatDoctorsTitle.Text = "Total Doctors";
            // 
            // lblTotalDoctors
            // 
            this.lblTotalDoctors.AutoSize = true;
            this.lblTotalDoctors.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalDoctors.ForeColor = System.Drawing.Color.White;
            this.lblTotalDoctors.Location = new System.Drawing.Point(14, 42);
            this.lblTotalDoctors.Name = "lblTotalDoctors";
            this.lblTotalDoctors.Size = new System.Drawing.Size(43, 50);
            this.lblTotalDoctors.TabIndex = 1;
            this.lblTotalDoctors.Text = "0";
            // 
            // pnlStatPatients
            // 
            this.pnlStatPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlStatPatients.Controls.Add(this.lblStatPatientsTitle);
            this.pnlStatPatients.Controls.Add(this.lblTotalPatients);
            this.pnlStatPatients.Location = new System.Drawing.Point(240, 10);
            this.pnlStatPatients.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStatPatients.Name = "pnlStatPatients";
            this.pnlStatPatients.Size = new System.Drawing.Size(210, 100);
            this.pnlStatPatients.TabIndex = 1;
            // 
            // lblStatPatientsTitle
            // 
            this.lblStatPatientsTitle.AutoSize = true;
            this.lblStatPatientsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatPatientsTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatPatientsTitle.Location = new System.Drawing.Point(14, 12);
            this.lblStatPatientsTitle.Name = "lblStatPatientsTitle";
            this.lblStatPatientsTitle.Size = new System.Drawing.Size(114, 21);
            this.lblStatPatientsTitle.TabIndex = 0;
            this.lblStatPatientsTitle.Text = "Total Patients";
            // 
            // lblTotalPatients
            // 
            this.lblTotalPatients.AutoSize = true;
            this.lblTotalPatients.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalPatients.ForeColor = System.Drawing.Color.White;
            this.lblTotalPatients.Location = new System.Drawing.Point(14, 42);
            this.lblTotalPatients.Name = "lblTotalPatients";
            this.lblTotalPatients.Size = new System.Drawing.Size(43, 50);
            this.lblTotalPatients.TabIndex = 1;
            this.lblTotalPatients.Text = "0";
            // 
            // pnlStatToday
            // 
            this.pnlStatToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.pnlStatToday.Controls.Add(this.lblStatTodayTitle);
            this.pnlStatToday.Controls.Add(this.lblTodayAppointments);
            this.pnlStatToday.Location = new System.Drawing.Point(470, 10);
            this.pnlStatToday.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStatToday.Name = "pnlStatToday";
            this.pnlStatToday.Size = new System.Drawing.Size(210, 100);
            this.pnlStatToday.TabIndex = 2;
            // 
            // lblStatTodayTitle
            // 
            this.lblStatTodayTitle.AutoSize = true;
            this.lblStatTodayTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatTodayTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatTodayTitle.Location = new System.Drawing.Point(14, 12);
            this.lblStatTodayTitle.Name = "lblStatTodayTitle";
            this.lblStatTodayTitle.Size = new System.Drawing.Size(180, 21);
            this.lblStatTodayTitle.TabIndex = 0;
            this.lblStatTodayTitle.Text = "Today\'s Appointments";
            // 
            // lblTodayAppointments
            // 
            this.lblTodayAppointments.AutoSize = true;
            this.lblTodayAppointments.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTodayAppointments.ForeColor = System.Drawing.Color.White;
            this.lblTodayAppointments.Location = new System.Drawing.Point(14, 42);
            this.lblTodayAppointments.Name = "lblTodayAppointments";
            this.lblTodayAppointments.Size = new System.Drawing.Size(43, 50);
            this.lblTodayAppointments.TabIndex = 1;
            this.lblTodayAppointments.Text = "0";
            // 
            // pnlStatPending
            // 
            this.pnlStatPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlStatPending.Controls.Add(this.lblStatPendingTitle);
            this.pnlStatPending.Controls.Add(this.lblPendingAppts);
            this.pnlStatPending.Location = new System.Drawing.Point(700, 10);
            this.pnlStatPending.Margin = new System.Windows.Forms.Padding(10);
            this.pnlStatPending.Name = "pnlStatPending";
            this.pnlStatPending.Size = new System.Drawing.Size(210, 100);
            this.pnlStatPending.TabIndex = 3;
            // 
            // lblStatPendingTitle
            // 
            this.lblStatPendingTitle.AutoSize = true;
            this.lblStatPendingTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatPendingTitle.ForeColor = System.Drawing.Color.White;
            this.lblStatPendingTitle.Location = new System.Drawing.Point(14, 12);
            this.lblStatPendingTitle.Name = "lblStatPendingTitle";
            this.lblStatPendingTitle.Size = new System.Drawing.Size(74, 21);
            this.lblStatPendingTitle.TabIndex = 0;
            this.lblStatPendingTitle.Text = "Pending";
            // 
            // lblPendingAppts
            // 
            this.lblPendingAppts.AutoSize = true;
            this.lblPendingAppts.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPendingAppts.ForeColor = System.Drawing.Color.White;
            this.lblPendingAppts.Location = new System.Drawing.Point(14, 42);
            this.lblPendingAppts.Name = "lblPendingAppts";
            this.lblPendingAppts.Size = new System.Drawing.Size(43, 50);
            this.lblPendingAppts.TabIndex = 1;
            this.lblPendingAppts.Text = "0";
            // 
            // navPanel
            // 
            this.navPanel.Controls.Add(this.btnDocs);
            this.navPanel.Controls.Add(this.btnApps);
            this.navPanel.Controls.Add(this.btnLogout);
            this.navPanel.Location = new System.Drawing.Point(200, 300);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(620, 200);
            this.navPanel.TabIndex = 2;
            // 
            // btnDocs
            // 
            this.btnDocs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnDocs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDocs.FlatAppearance.BorderSize = 0;
            this.btnDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDocs.ForeColor = System.Drawing.Color.White;
            this.btnDocs.Location = new System.Drawing.Point(20, 20);
            this.btnDocs.Name = "btnDocs";
            this.btnDocs.Size = new System.Drawing.Size(280, 72);
            this.btnDocs.TabIndex = 0;
            this.btnDocs.Text = "🩺 Manage Doctors";
            this.btnDocs.UseVisualStyleBackColor = false;
            this.btnDocs.Click += new System.EventHandler(this.BtnDocs_Click);
            // 
            // btnApps
            // 
            this.btnApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnApps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApps.FlatAppearance.BorderSize = 0;
            this.btnApps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApps.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnApps.ForeColor = System.Drawing.Color.White;
            this.btnApps.Location = new System.Drawing.Point(320, 20);
            this.btnApps.Name = "btnApps";
            this.btnApps.Size = new System.Drawing.Size(280, 72);
            this.btnApps.TabIndex = 1;
            this.btnApps.Text = "📅 Manage Appointments";
            this.btnApps.UseVisualStyleBackColor = false;
            this.btnApps.Click += new System.EventHandler(this.BtnApps_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLogout.Location = new System.Drawing.Point(240, 130);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(140, 38);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.navPanel);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CareBridge Clinic — Staff Panel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.statsPanel.ResumeLayout(false);
            this.pnlStatDoctors.ResumeLayout(false);
            this.pnlStatDoctors.PerformLayout();
            this.pnlStatPatients.ResumeLayout(false);
            this.pnlStatPatients.PerformLayout();
            this.pnlStatToday.ResumeLayout(false);
            this.pnlStatToday.PerformLayout();
            this.pnlStatPending.ResumeLayout(false);
            this.pnlStatPending.PerformLayout();
            this.navPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.PictureBox picLogo;
    }
}
