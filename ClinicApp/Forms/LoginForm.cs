using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicApp.Database;
using ClinicApp.Models;

namespace ClinicApp.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository repo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
            try
            {
                string assetsPath = System.IO.Path.Combine(Application.StartupPath, "Assets");
                string logoPath = System.IO.Path.Combine(assetsPath, "logo.png");
                string splashPath = System.IO.Path.Combine(assetsPath, "splash.png");
                
                if (System.IO.File.Exists(logoPath)) picLogo.Image = Image.FromFile(logoPath);
                if (System.IO.File.Exists(splashPath)) picSplash.Image = Image.FromFile(splashPath);
            }
            catch { }
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            new RoleSelectForm().Show();
            this.Close();
        }
    }
}
