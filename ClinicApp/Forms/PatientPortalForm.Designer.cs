using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class PatientPortalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private Panel pnlHeader;
        private Panel pnlRecords;
        private Panel pnlHistoryAndProfile;
        
        // Login & Profile Controls
        private TextBox txtLoginPhone;
        private TextBox txtLoginPassword;
        private TextBox txtNewPass;
        private Label lblRecordWelcome;
        private DataGridView dgvMyAppts;

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

        private void InitializeComponent()
        {
            this.Text = "Patient Portal";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // 1. Header
            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.SeaGreen };
            pnlHeader.Controls.Add(new Label { Text = "Patient Portal", ForeColor = Color.White, Font = new Font("Segoe UI", 16F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill });

            // 2. Main Content Area
            Panel contentMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            SetupRecordsSection(contentMain);

            // 3. Footer
            Button btnBack = new Button { Text = "Back to Home", Dock = DockStyle.Bottom, Height = 40, BackColor = Color.FromArgb(230, 230, 230), FlatStyle = FlatStyle.Flat };
            btnBack.Click += (s, e) => { new RoleSelectForm().Show(); this.Close(); };

            // Add to Form
            this.Controls.Add(contentMain);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(btnBack);
        }

        private void SetupRecordsSection(Panel parent)
        {
            pnlRecords = new Panel { Dock = DockStyle.Fill, Visible = true };
            parent.Controls.Add(pnlRecords);

            pnlRecords.Controls.Add(new Label { Text = "View My History & Profile (Login Required)", Location = new Point(0, 0), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.SteelBlue });

            Panel pnlLog = new Panel { Location = new Point(0, 40), Size = new Size(780, 80), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.FromArgb(245, 245, 245) };
            pnlLog.Controls.Add(new Label { Text = "Phone:", Location = new Point(10, 10) });
            txtLoginPhone = new TextBox { Location = new Point(10, 30), Width = 150 };
            pnlLog.Controls.Add(txtLoginPhone);
            pnlLog.Controls.Add(new Label { Text = "Password:", Location = new Point(170, 10) });
            txtLoginPassword = new TextBox { Location = new Point(170, 30), Width = 150, PasswordChar = '*' };
            pnlLog.Controls.Add(txtLoginPassword);
            Button btnLogin = new Button { Text = "Login", Location = new Point(330, 28), Size = new Size(100, 32), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnLogin.Click += BtnLogin_Click;
            pnlLog.Controls.Add(btnLogin);
            lblRecordWelcome = new Label { Text = "", Location = new Point(450, 32), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            pnlLog.Controls.Add(lblRecordWelcome);
            pnlRecords.Controls.Add(pnlLog);

            pnlHistoryAndProfile = new Panel { Location = new Point(0, 130), Size = new Size(780, 450), Visible = false };
            pnlHistoryAndProfile.Controls.Add(new Label { Text = "Your Appointment History:", Location = new Point(0, 10), Font = new Font("Segoe UI", 10F, FontStyle.Bold) });
            dgvMyAppts = new DataGridView { Location = new Point(0, 35), Size = new Size(780, 220), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White, RowHeadersVisible = false, AllowUserToAddRows = false };
            pnlHistoryAndProfile.Controls.Add(dgvMyAppts);

            Panel pnlCP = new Panel { Location = new Point(0, 270), Size = new Size(780, 80), BorderStyle = BorderStyle.FixedSingle };
            pnlCP.Controls.Add(new Label { Text = "Change Password:", Location = new Point(10, 10), Font = new Font("Segoe UI", 9F, FontStyle.Bold) });
            txtNewPass = new TextBox { Location = new Point(10, 35), Width = 200, PasswordChar = '*' };
            pnlCP.Controls.Add(txtNewPass);
            Button btnUpdatePass = new Button { Text = "Update Password", Location = new Point(220, 33), Size = new Size(150, 30), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnUpdatePass.Click += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtNewPass.Text)) return;
                loggedInPatient.Password = txtNewPass.Text;
                patRepo.Update(loggedInPatient);
                MessageBox.Show("Password updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPass.Clear();
            };
            pnlCP.Controls.Add(btnUpdatePass);
            pnlHistoryAndProfile.Controls.Add(pnlCP);
            pnlRecords.Controls.Add(pnlHistoryAndProfile);
        }

        #endregion
    }
}
