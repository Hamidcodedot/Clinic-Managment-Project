namespace CareBridgeClinic.Forms
{
    partial class PatientPortalForm
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
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLoginPhone;
        private System.Windows.Forms.TextBox txtLoginPhone;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblRecordWelcome;
        private System.Windows.Forms.Panel pnlHistoryAndProfile;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.DataGridView dgvMyAppts;
        private System.Windows.Forms.Panel pnlCP;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnUpdatePass;
        private System.Windows.Forms.Button btnBack;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            
            this.header = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.lblLoginPhone = new System.Windows.Forms.Label();
            this.txtLoginPhone = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblRecordWelcome = new System.Windows.Forms.Label();
            this.pnlHistoryAndProfile = new System.Windows.Forms.Panel();
            this.lblHistory = new System.Windows.Forms.Label();
            this.dgvMyAppts = new System.Windows.Forms.DataGridView();
            this.pnlCP = new System.Windows.Forms.Panel();
            this.lblCP = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.btnUpdatePass = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.content.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlHistoryAndProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyAppts)).BeginInit();
            this.pnlCP.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Controls.Add(this.picLogo);
            this.header.Controls.Add(this.lblHeader);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(800, 70);
            this.header.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(20, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(40, 40);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(800, 70);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "CareBridge Clinic — Patient Portal";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // content
            // 
            this.content.Controls.Add(this.pnlHistoryAndProfile);
            this.content.Controls.Add(this.pnlLog);
            this.content.Controls.Add(this.lblSubtitle);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 64);
            this.content.Name = "content";
            this.content.Padding = new System.Windows.Forms.Padding(32, 24, 32, 16);
            this.content.Size = new System.Drawing.Size(800, 346);
            this.content.TabIndex = 1;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSubtitle.Location = new System.Drawing.Point(32, 24);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(736, 28);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "Sign in to view your appointments and update your password";
            // 
            // pnlLog
            // 
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlLog.Controls.Add(this.lblRecordWelcome);
            this.pnlLog.Controls.Add(this.btnLogin);
            this.pnlLog.Controls.Add(this.txtLoginPassword);
            this.pnlLog.Controls.Add(this.lblLoginPassword);
            this.pnlLog.Controls.Add(this.txtLoginPhone);
            this.pnlLog.Controls.Add(this.lblLoginPhone);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLog.Location = new System.Drawing.Point(32, 52);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Padding = new System.Windows.Forms.Padding(16);
            this.pnlLog.Size = new System.Drawing.Size(736, 88);
            this.pnlLog.TabIndex = 1;
            // 
            // lblLoginPhone
            // 
            this.lblLoginPhone.AutoSize = true;
            this.lblLoginPhone.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLoginPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblLoginPhone.Location = new System.Drawing.Point(16, 8);
            this.lblLoginPhone.Name = "lblLoginPhone";
            this.lblLoginPhone.Size = new System.Drawing.Size(41, 15);
            this.lblLoginPhone.TabIndex = 0;
            this.lblLoginPhone.Text = "Phone";
            // 
            // txtLoginPhone
            // 
            this.txtLoginPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLoginPhone.Location = new System.Drawing.Point(16, 26);
            this.txtLoginPhone.Name = "txtLoginPhone";
            this.txtLoginPhone.Size = new System.Drawing.Size(180, 25);
            this.txtLoginPhone.TabIndex = 1;
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLoginPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblLoginPassword.Location = new System.Drawing.Point(210, 8);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(57, 15);
            this.lblLoginPassword.TabIndex = 2;
            this.lblLoginPassword.Text = "Password";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLoginPassword.Location = new System.Drawing.Point(210, 26);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '●';
            this.txtLoginPassword.Size = new System.Drawing.Size(180, 25);
            this.txtLoginPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(410, 24);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 34);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lblRecordWelcome
            // 
            this.lblRecordWelcome.AutoSize = true;
            this.lblRecordWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblRecordWelcome.Location = new System.Drawing.Point(530, 30);
            this.lblRecordWelcome.Name = "lblRecordWelcome";
            this.lblRecordWelcome.Size = new System.Drawing.Size(0, 19);
            this.lblRecordWelcome.TabIndex = 5;
            // 
            // pnlHistoryAndProfile
            // 
            this.pnlHistoryAndProfile.Controls.Add(this.pnlCP);
            this.pnlHistoryAndProfile.Controls.Add(this.dgvMyAppts);
            this.pnlHistoryAndProfile.Controls.Add(this.lblHistory);
            this.pnlHistoryAndProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistoryAndProfile.Location = new System.Drawing.Point(32, 140);
            this.pnlHistoryAndProfile.Name = "pnlHistoryAndProfile";
            this.pnlHistoryAndProfile.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlHistoryAndProfile.Size = new System.Drawing.Size(736, 206);
            this.pnlHistoryAndProfile.TabIndex = 2;
            this.pnlHistoryAndProfile.Visible = false;
            // 
            // lblHistory
            // 
            this.lblHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblHistory.Location = new System.Drawing.Point(0, 16);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(736, 28);
            this.lblHistory.TabIndex = 0;
            this.lblHistory.Text = "Your appointment history";
            // 
            // dgvMyAppts
            // 
            this.dgvMyAppts.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvMyAppts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMyAppts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyAppts.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyAppts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyAppts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMyAppts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMyAppts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMyAppts.ColumnHeadersHeight = 38;
            this.dgvMyAppts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMyAppts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMyAppts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMyAppts.EnableHeadersVisualStyles = false;
            this.dgvMyAppts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvMyAppts.Location = new System.Drawing.Point(0, 44);
            this.dgvMyAppts.Name = "dgvMyAppts";
            this.dgvMyAppts.ReadOnly = true;
            this.dgvMyAppts.RowHeadersVisible = false;
            this.dgvMyAppts.RowTemplate.Height = 40;
            this.dgvMyAppts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyAppts.Size = new System.Drawing.Size(736, 280);
            this.dgvMyAppts.TabIndex = 1;
            // 
            // pnlCP
            // 
            this.pnlCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCP.Controls.Add(this.btnUpdatePass);
            this.pnlCP.Controls.Add(this.txtNewPass);
            this.pnlCP.Controls.Add(this.lblCP);
            this.pnlCP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCP.Location = new System.Drawing.Point(0, 324);
            this.pnlCP.Name = "pnlCP";
            this.pnlCP.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlCP.Size = new System.Drawing.Size(736, 100);
            this.pnlCP.TabIndex = 2;
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblCP.Location = new System.Drawing.Point(16, 12);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(104, 15);
            this.lblCP.TabIndex = 0;
            this.lblCP.Text = "Change password";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPass.Location = new System.Drawing.Point(16, 38);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '●';
            this.txtNewPass.Size = new System.Drawing.Size(220, 25);
            this.txtNewPass.TabIndex = 1;
            // 
            // btnUpdatePass
            // 
            this.btnUpdatePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnUpdatePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdatePass.FlatAppearance.BorderSize = 0;
            this.btnUpdatePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePass.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePass.Location = new System.Drawing.Point(250, 36);
            this.btnUpdatePass.Name = "btnUpdatePass";
            this.btnUpdatePass.Size = new System.Drawing.Size(150, 34);
            this.btnUpdatePass.TabIndex = 2;
            this.btnUpdatePass.Text = "Update Password";
            this.btnUpdatePass.UseVisualStyleBackColor = false;
            this.btnUpdatePass.Click += new System.EventHandler(this.BtnUpdatePass_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnBack.Location = new System.Drawing.Point(0, 410);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(800, 40);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back to Home";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // PatientPortalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.content);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PatientPortalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Portal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.header.ResumeLayout(false);
            this.content.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.pnlHistoryAndProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyAppts)).EndInit();
            this.pnlCP.ResumeLayout(false);
            this.pnlCP.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        
        private System.Windows.Forms.PictureBox picLogo;
    }
}
