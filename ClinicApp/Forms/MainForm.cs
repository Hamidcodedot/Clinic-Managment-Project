using System;
using System.Windows.Forms;
using ClinicApp.Repositories;

namespace ClinicApp.Forms
{
    public partial class MainForm : Form
    {
        private DoctorRepository docRepo = new DoctorRepository();
        private PatientRepository patRepo = new PatientRepository();
        private AppointmentRepository appRepo = new AppointmentRepository();

        public MainForm()
        {
            InitializeComponent();
            this.Activated += (s, e) => RefreshStats();
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
