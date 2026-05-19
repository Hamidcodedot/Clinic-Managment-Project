using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
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

        private void InitializeComponent()
        {
            // Apply Form Defaults
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);
            this.Text = "Receptionist Dashboard";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Header Panel
            var header = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(70, 130, 180) };
            var headerLabel = new Label
            {
                Text = "Clinic Management System — Staff Panel",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(24, 0, 0, 0),
                Dock = DockStyle.Fill
            };
            header.Controls.Add(headerLabel);

            statsPanel = new FlowLayoutPanel
            {
                Size = new Size(920, 120),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };
            lblTotalDoctors = CreateStatCard(statsPanel, "Total Doctors", "0", Color.FromArgb(52, 152, 219));
            lblTotalPatients = CreateStatCard(statsPanel, "Total Patients", "0", Color.FromArgb(46, 204, 113));
            lblTodayAppointments = CreateStatCard(statsPanel, "Today's Appointments", "0", Color.FromArgb(155, 89, 182));
            lblPendingAppts = CreateStatCard(statsPanel, "Pending", "0", Color.FromArgb(231, 76, 60));

            navPanel = new Panel { Size = new Size(920, 200) };

            var btnDocs = NavTile("Manage Doctors", 0);
            btnDocs.Click += (s, e) => { using (var f = new DoctorsForm()) f.ShowDialog(); RefreshStats(); };

            var btnPats = NavTile("Manage Patients", 1);
            btnPats.Click += (s, e) => { using (var f = new PatientsForm()) f.ShowDialog(); RefreshStats(); };

            var btnApps = NavTile("Manage Appointments", 2);
            btnApps.Click += (s, e) => { using (var f = new AppointmentsForm()) f.ShowDialog(); RefreshStats(); };

            // SecondaryButton: Logout
            var btnLogout = new Button
            {
                Text = "Logout",
                BackColor = Color.FromArgb(230, 234, 237),
                ForeColor = Color.FromArgb(44, 62, 80),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(140, 38),
                Location = new Point(390, 130)
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => { new RoleSelectForm().Show(); this.Close(); };

            navPanel.Controls.Add(btnDocs);
            navPanel.Controls.Add(btnPats);
            navPanel.Controls.Add(btnApps);
            navPanel.Controls.Add(btnLogout);

            this.Controls.Add(navPanel);
            this.Controls.Add(statsPanel);
            this.Controls.Add(header);

            this.SizeChanged += (s, e) => CenterContent();
        }

        private Button NavTile(string text, int index)
        {
            // UiTheme.CreateButton representation
            var btn = new Button
            {
                Text = text,
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(280, 72),
                Location = new Point(index * 300 + 20, 20)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private Label CreateStatCard(Control parent, string title, string value, Color color)
        {
            var p = new Panel { Size = new Size(210, 100), BackColor = color, Margin = new Padding(10) };
            p.Controls.Add(new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(14, 12),
                AutoSize = true
            });
            var valueLbl = new Label
            {
                Text = value,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                Location = new Point(14, 42),
                AutoSize = true
            };
            p.Controls.Add(valueLbl);
            parent.Controls.Add(p);
            return valueLbl;
        }
    }
}
