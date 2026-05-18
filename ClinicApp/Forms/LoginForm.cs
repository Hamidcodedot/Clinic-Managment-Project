using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicApp.Repositories;
using ClinicApp.Models;

namespace ClinicApp.Forms
{
    public class LoginForm : Form
    {
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnBack;
        private UserRepository repo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Staff Login";
            this.Size = new Size(350, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.SteelBlue };
            header.Controls.Add(new Label { Text = "Staff Login", ForeColor = Color.White, Font = new Font("Segoe UI", 12F, FontStyle.Bold), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter });
            
            this.Controls.Add(new Label { Text = "Username:", Location = new Point(50, 70), AutoSize = true });
            txtUsername = new TextBox { Location = new Point(50, 90), Width = 230 };
            
            this.Controls.Add(new Label { Text = "Password:", Location = new Point(50, 120), AutoSize = true });
            txtPassword = new TextBox { Location = new Point(50, 140), Width = 230, PasswordChar = '*' };

            btnLogin = new Button { Text = "Login", Location = new Point(50, 175), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnLogin.Click += BtnLogin_Click;

            btnBack = new Button { Text = "Back", Location = new Point(170, 175), Size = new Size(110, 35), BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat };
            btnBack.Click += (s, e) => { new RoleSelectForm().Show(); this.Close(); };

            this.Controls.Add(txtUsername);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnBack);
            this.Controls.Add(header);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var user = repo.Login(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
