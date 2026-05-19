using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicApp.Database;

namespace ClinicApp.Forms
{
    public partial class MainForm : Form
    {
        private Label lblTotalDoctors, lblTotalPatients, lblTodayAppointments, lblPendingAppts;
        private FlowLayoutPanel statsPanel;
        private Panel navPanel;

        private readonly DoctorRepository docRepo = new DoctorRepository();
        private readonly PatientRepository patRepo = new PatientRepository();
        private readonly AppointmentRepository appRepo = new AppointmentRepository();

        public MainForm()
        {
            InitializeComponent();
            Activated += (s, e) => RefreshStats();
            Shown += (s, e) => CenterContent();
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
                lblTotalDoctors.Text = docRepo.GetAll().Count.ToString();
                lblTotalPatients.Text = patRepo.GetAll().Count.ToString();
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
