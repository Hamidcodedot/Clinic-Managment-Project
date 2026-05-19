using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class LoginForm
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
            this.Text = "Staff Login";
            this.Size = new Size(420, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Header Panel
            var header = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = Color.FromArgb(70, 130, 180) };
            header.Controls.Add(new Label
            {
                Text = "Staff Login",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            });

            var lblUser = new Label { Text = "Username", Location = new Point(50, 80), AutoSize = true, ForeColor = Color.FromArgb(127, 140, 141) };
            txtUsername = new TextBox { Location = new Point(50, 98), Width = 300, Font = new Font("Segoe UI", 10F) };

            var lblPass = new Label { Text = "Password", Location = new Point(50, 135), AutoSize = true, ForeColor = Color.FromArgb(127, 140, 141) };
            txtPassword = new TextBox { Location = new Point(50, 153), Width = 300, PasswordChar = '●', Font = new Font("Segoe UI", 10F) };

            // PrimaryButton: Login
            var btnLogin = new Button
            {
                Text = "Login",
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(145, 40),
                Location = new Point(50, 200)
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;

            // SecondaryButton: Back
            var btnBack = new Button
            {
                Text = "Back",
                BackColor = Color.FromArgb(230, 234, 237),
                ForeColor = Color.FromArgb(44, 62, 80),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = new Size(145, 40),
                Location = new Point(205, 200)
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => { new RoleSelectForm().Show(); this.Close(); };

            // Hint label removed per user request

            this.AcceptButton = btnLogin;
            this.Controls.Add(btnBack);
            this.Controls.Add(btnLogin);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblUser);
            this.Controls.Add(header);
        }
    }
}
