using System;
using System.Drawing;
using System.Windows.Forms;

namespace CareBridgeClinic.Forms
{
    public partial class RoleSelectForm : Form
    {
        public RoleSelectForm()
        {
            InitializeComponent();
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "Assets", "logo.png");
                if (System.IO.File.Exists(logoPath))
                {
                    picLogo.Image = Image.FromFile(logoPath);
                }
            }
            catch { }
        }


        private void BtnStaff_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void BtnPatient_Click(object sender, EventArgs e)
        {
            new PatientPortalForm().Show();
            this.Hide();
        }
    }
}
