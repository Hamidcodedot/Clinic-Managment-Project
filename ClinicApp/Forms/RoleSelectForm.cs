using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    public class RoleSelectForm : Form
    {
        public RoleSelectForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Clinic Management System - Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.SteelBlue
            };

            Label titleLabel = new Label
            {
                Text = "Clinic Management System",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            headerPanel.Controls.Add(titleLabel);

            Button btnStaff = new Button
            {
                Text = "Staff / Receptionist",
                Size = new Size(200, 50),
                Location = new Point(100, 100),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnStaff.Click += (s, e) => {
                new LoginForm().Show();
                this.Hide();
            };

            Button btnPatient = new Button
            {
                Text = "Patient Portal",
                Size = new Size(200, 50),
                Location = new Point(100, 170),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnPatient.Click += (s, e) => {
                new PatientPortalForm().Show();
                this.Hide();
            };

            this.Controls.Add(btnPatient);
            this.Controls.Add(btnStaff);
            this.Controls.Add(headerPanel);
        }
    }
}
