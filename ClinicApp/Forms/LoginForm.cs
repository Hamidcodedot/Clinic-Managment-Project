using System;
using System.Windows.Forms;
using ClinicApp.Database;
using ClinicApp.Models;

namespace ClinicApp.Forms
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername, txtPassword;
        private readonly UserRepository repo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var user = repo.Login(txtUsername.Text.Trim(), txtPassword.Text);
            if (user != null)
            {
                new MainForm().Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
