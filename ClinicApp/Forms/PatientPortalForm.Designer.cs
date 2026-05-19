using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
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

        private void InitializeComponent()
        {
            // Apply Form Defaults
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);
            this.Text = "Patient Portal";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Header Panel (UiTheme.PatientPrimary = Color.FromArgb(39, 174, 96))
            var header = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Color.FromArgb(39, 174, 96) };
            header.Controls.Add(new Label
            {
                Text = "Patient Portal",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            });

            var content = new Panel { Dock = DockStyle.Fill, Padding = new Padding(32, 24, 32, 16) };

            content.Controls.Add(new Label
            {
                Text = "Sign in to view your appointments and update your password",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(127, 140, 141),
                Dock = DockStyle.Top,
                Height = 28
            });

            // Login Panel (UiTheme.Surface = Color.FromArgb(248, 249, 250))
            var pnlLog = new Panel
            {
                Dock = DockStyle.Top,
                Height = 88,
                BackColor = Color.FromArgb(248, 249, 250),
                Padding = new Padding(16)
            };
            pnlLog.Controls.Add(new Label { Text = "Phone", Location = new Point(16, 8), AutoSize = true, ForeColor = Color.FromArgb(127, 140, 141), Font = new Font("Segoe UI", 8.5F) });
            txtLoginPhone = new TextBox { Location = new Point(16, 26), Width = 180, Font = new Font("Segoe UI", 10F) };
            pnlLog.Controls.Add(txtLoginPhone);
            pnlLog.Controls.Add(new Label { Text = "Password", Location = new Point(210, 8), AutoSize = true, ForeColor = Color.FromArgb(127, 140, 141), Font = new Font("Segoe UI", 8.5F) });
            txtLoginPassword = new TextBox { Location = new Point(210, 26), Width = 180, PasswordChar = '●', Font = new Font("Segoe UI", 10F) };
            pnlLog.Controls.Add(txtLoginPassword);

            // btnLogin (UiTheme.CreateButton representation)
            var btnLogin = new Button
            {
                Text = "Login",
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(100, 34)
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Location = new Point(410, 24);
            btnLogin.Click += BtnLogin_Click;
            pnlLog.Controls.Add(btnLogin);

            lblRecordWelcome = new Label
            {
                Location = new Point(530, 30),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96)
            };
            pnlLog.Controls.Add(lblRecordWelcome);

            pnlHistoryAndProfile = new Panel { Dock = DockStyle.Fill, Visible = false, Padding = new Padding(0, 16, 0, 0) };

            pnlHistoryAndProfile.Controls.Add(new Label
            {
                Text = "Your appointment history",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Dock = DockStyle.Top,
                Height = 28
            });

            dgvMyAppts = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 280,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            StyleDataGrid(dgvMyAppts, Color.FromArgb(39, 174, 96));
            pnlHistoryAndProfile.Controls.Add(dgvMyAppts);

            var pnlCP = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                Padding = new Padding(0, 20, 0, 0),
                BackColor = Color.FromArgb(248, 249, 250)
            };
            pnlCP.Controls.Add(new Label
            {
                Text = "Change password",
                Location = new Point(16, 12),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true
            });
            txtNewPass = new TextBox { Location = new Point(16, 38), Width = 220, PasswordChar = '●', Font = new Font("Segoe UI", 10F) };
            pnlCP.Controls.Add(txtNewPass);

            // btnUpdatePass
            var btnUpdatePass = new Button
            {
                Text = "Update Password",
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(150, 34)
            };
            btnUpdatePass.FlatAppearance.BorderSize = 0;
            btnUpdatePass.Location = new Point(250, 36);
            btnUpdatePass.Click += (s, e) =>
            {
                if (loggedInPatient == null || string.IsNullOrWhiteSpace(txtNewPass.Text)) return;
                loggedInPatient.Password = txtNewPass.Text.Trim();
                patRepo.Update(loggedInPatient);
                MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPass.Clear();
            };
            pnlCP.Controls.Add(btnUpdatePass);
            pnlHistoryAndProfile.Controls.Add(pnlCP);

            content.Controls.Add(pnlHistoryAndProfile);
            content.Controls.Add(pnlLog);

            // btnBack (SecondaryButton representation)
            var btnBack = new Button
            {
                Text = "Back to Home",
                BackColor = Color.FromArgb(230, 234, 237),
                ForeColor = Color.FromArgb(44, 62, 80),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(160, 40)
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Dock = DockStyle.Bottom;
            btnBack.Click += (s, e) => { new RoleSelectForm().Show(); this.Close(); };

            this.Controls.Add(content);
            this.Controls.Add(btnBack);
            this.Controls.Add(header);
        }

        private void StyleDataGrid(DataGridView grid, Color headerColor)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 235, 240);
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.RowTemplate.Height = 40;
            grid.ColumnHeadersHeight = 38;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = headerColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 62, 80),
                Font = new Font("Segoe UI", 9F),
                SelectionBackColor = Color.FromArgb(220, 245, 230),
                SelectionForeColor = Color.FromArgb(44, 62, 80),
                Padding = new Padding(10, 0, 10, 0)
            };
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 252, 254),
                SelectionBackColor = Color.FromArgb(220, 245, 230),
                SelectionForeColor = Color.FromArgb(44, 62, 80)
            };
        }
    }
}
