using System;
using System.Windows.Forms;
using ClinicApp.Models;
using ClinicApp.Repositories;

namespace ClinicApp.Forms
{
    public partial class PatientPortalForm : Form
    {
        private PatientRepository patRepo = new PatientRepository();
        private AppointmentRepository appRepo = new AppointmentRepository();
        private Patient loggedInPatient = null;

        public PatientPortalForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            loggedInPatient = patRepo.Login(txtLoginPhone.Text, txtLoginPassword.Text);
            if (loggedInPatient != null) {
                lblRecordWelcome.Text = "Hello, " + loggedInPatient.Name;
                pnlHistoryAndProfile.Visible = true;
                dgvMyAppts.DataSource = appRepo.GetByPatientId(loggedInPatient.PatientID);
                
                // Hide ID column if exists
                if (dgvMyAppts.Columns.Count > 0)
                {
                    if (dgvMyAppts.Columns.Contains("PatientID")) dgvMyAppts.Columns["PatientID"].Visible = false;
                    if (dgvMyAppts.Columns.Contains("DoctorID")) dgvMyAppts.Columns["DoctorID"].Visible = false;
                }
            } else { MessageBox.Show("Invalid Login"); }
        }
    }
}
