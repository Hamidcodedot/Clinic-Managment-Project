using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class RoleSelectForm
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
            this.Text = "Clinic Management System";
            this.Size = new Size(480, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Header Panel (UiTheme.CreateHeader replacement)
            var header = new Panel { Dock = DockStyle.Top, Height = 72, BackColor = Color.FromArgb(70, 130, 180) };
            header.Controls.Add(new Label
            {
                Text = "Clinic Management System",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            });

            var subtitle = new Label
            {
                Text = "Please select how you want to sign in",
                ForeColor = Color.FromArgb(127, 140, 141),
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(40, 100),
                Size = new Size(400, 24)
            };

            // btnStaff (UiTheme.CreateButton / StaffPrimary replacement)
            var btnStaff = new Button
            {
                Text = "Staff / Receptionist",
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(280, 52),
                Location = new Point(100, 150)
            };
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };

            // btnPatient (UiTheme.CreateButton / PatientPrimary replacement)
            var btnPatient = new Button
            {
                Text = "Patient Portal",
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(280, 52),
                Location = new Point(100, 220)
            };
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.Click += (s, e) => { new PatientPortalForm().Show(); this.Hide(); };

            var hint = new Label
            {
                Text = "Staff: manage doctors, patients & appointments  •  Patients: view history & change password",
                ForeColor = Color.FromArgb(127, 140, 141),
                Font = new Font("Segoe UI", 8.5F),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(30, 295),
                Size = new Size(420, 36)
            };

            this.Controls.Add(hint);
            this.Controls.Add(btnPatient);
            this.Controls.Add(btnStaff);
            this.Controls.Add(subtitle);
            this.Controls.Add(header);
        }
    }
}
