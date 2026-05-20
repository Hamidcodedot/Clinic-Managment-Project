using System;
using System.Drawing;
using System.Windows.Forms;
using CareBridgeClinic.Database;

namespace CareBridgeClinic.Forms
{
    public partial class MainForm : Form
    {
        private readonly DoctorRepository docRepo;
        private readonly PatientRepository patRepo;
        private readonly AppointmentRepository appRepo;

        public MainForm()
        {
            InitializeComponent();
            docRepo = new DoctorRepository();
            patRepo = new PatientRepository();
            appRepo = new AppointmentRepository();
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "Assets", "logo.png");
                if (System.IO.File.Exists(logoPath)) picLogo.Image = Image.FromFile(logoPath);
            }
            catch { }
            Activated += MainForm_Activated;
            Shown += MainForm_Shown;
        }


        private void MainForm_Activated(object sender, EventArgs e) => RefreshStats();
        private void MainForm_Shown(object sender, EventArgs e) => CenterContent();

        private void BtnDocs_Click(object sender, EventArgs e)
        {
            using (var f = new DoctorsForm()) f.ShowDialog();
            RefreshStats();
        }

        private void BtnApps_Click(object sender, EventArgs e)
        {
            using (var f = new AppointmentsForm()) f.ShowDialog();
            RefreshStats();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            new RoleSelectForm().Show();
            this.Close();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void CenterContent()
        {
            int y = Math.Max(100, (ClientSize.Height - 70 - statsPanel.Height - navPanel.Height - 40) / 2 + 70);
            statsPanel.Location = new Point((ClientSize.Width - statsPanel.Width) / 2, y);
            navPanel.Location = new Point((ClientSize.Width - navPanel.Width) / 2, y + statsPanel.Height + 24);
        }

        private void RefreshStats()
        {
            try
            {
                // Queries the database to count the total number of doctors and patients
                lblTotalDoctors.Text = docRepo.GetAll().Count.ToString();
                lblTotalPatients.Text = patRepo.GetAll().Count.ToString();
                
                // Queries the database for appointments that are scheduled for today, and those that are pending
                lblTodayAppointments.Text = appRepo.GetTodayAppointmentCount().ToString();
                lblPendingAppts.Text = appRepo.GetPendingAppointmentsCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing stats: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
