using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private Label lblTotalDoctors;
        private Label lblTotalPatients;
        private Label lblTodayAppointments;
        private Label lblPendingAppts;

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
            this.Text = "Receptionist Dashboard";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.SteelBlue
            };

            Label titleLabel = new Label
            {
                Text = "Clinic Management System — Staff Panel",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 0, 0, 0)
            };
            headerPanel.Controls.Add(titleLabel);

            FlowLayoutPanel statsPanel = new FlowLayoutPanel
            {
                Size = new Size(760, 120),
                FlowDirection = FlowDirection.LeftToRight
            };

            lblTotalDoctors = CreateStatCard(statsPanel, "Total Doctors", "0", Color.FromArgb(52, 152, 219));
            lblTotalPatients = CreateStatCard(statsPanel, "Total Patients", "0", Color.FromArgb(46, 204, 113));
            lblTodayAppointments = CreateStatCard(statsPanel, "Today's Appts", "0", Color.FromArgb(155, 89, 182));
            lblPendingAppts = CreateStatCard(statsPanel, "Pending Appts", "0", Color.FromArgb(231, 76, 60));

            Panel navPanel = new Panel
            {
                Size = new Size(760, 180)
            };

            // Two large centered buttons
            Button btnDocs = CreateNavButton("Manage Doctors", 130, 10);
            btnDocs.Click += (s, e) => new DoctorsForm().ShowDialog();

            Button btnApps = CreateNavButton("Manage Appointments", 390, 10);
            btnApps.Click += (s, e) => new AppointmentsForm().ShowDialog();

            Button btnLogout = new Button
            {
                Text = "Logout",
                Size = new Size(120, 35),
                Location = new Point(320, 95),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnLogout.Click += (s, e) => {
                new RoleSelectForm().Show();
                this.Close();
            };

            navPanel.Controls.Add(btnDocs);
            navPanel.Controls.Add(btnApps);
            navPanel.Controls.Add(btnLogout);

            this.Controls.Add(navPanel);
            this.Controls.Add(statsPanel);
            this.Controls.Add(headerPanel);

            // Dynamic horizontal and vertical centering on window resizing
            this.SizeChanged += (s, e) => {
                int totalHeight = statsPanel.Height + navPanel.Height + 40; // 340px
                int startY = Math.Max(90, (this.ClientSize.Height - 70 - totalHeight) / 2 + 70);
                
                statsPanel.Location = new Point((this.ClientSize.Width - statsPanel.Width) / 2, startY);
                navPanel.Location = new Point((this.ClientSize.Width - navPanel.Width) / 2, startY + statsPanel.Height + 20);
            };
        }

        private Label CreateStatCard(Control parent, string title, string value, Color color)
        {
            Panel p = new Panel
            {
                Size = new Size(170, 100),
                BackColor = color,
                Margin = new Padding(10)
            };

            Label titleLbl = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label valueLbl = new Label
            {
                Text = value,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(10, 40),
                AutoSize = true
            };

            p.Controls.Add(titleLbl);
            p.Controls.Add(valueLbl);
            parent.Controls.Add(p);

            return valueLbl;
        }

        private Button CreateNavButton(string text, int x, int y)
        {
            return new Button
            {
                Text = text,
                Size = new Size(240, 70),
                Location = new Point(x, y),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            };
        }

        #endregion
    }
}
