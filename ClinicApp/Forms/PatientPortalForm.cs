using System;
using System.Windows.Forms;
using ClinicApp.Database;
using ClinicApp.Models;

namespace ClinicApp.Forms
{
    public partial class PatientPortalForm : Form
    {
        private TextBox txtLoginPhone, txtLoginPassword, txtNewPass;
        private Label lblRecordWelcome;
        private DataGridView dgvMyAppts;
        private Panel pnlHistoryAndProfile;

        private readonly PatientRepository patRepo = new PatientRepository();
        private readonly AppointmentRepository appRepo = new AppointmentRepository();
        private Patient loggedInPatient;

        public PatientPortalForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // --- Authentication Logic ---
            // Calls the PatientRepository to verify the phone number and password against the database.
            loggedInPatient = patRepo.Login(txtLoginPhone.Text.Trim(), txtLoginPassword.Text);
            
            // If the credentials don't match any record, 'loggedInPatient' will be null.
            if (loggedInPatient == null)
            {
                MessageBox.Show("Invalid phone number or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Success UI Updates ---
            // Update the welcome label with the patient's name and show the data panel.
            lblRecordWelcome.Text = "Hello, " + loggedInPatient.Name;
            pnlHistoryAndProfile.Visible = true;
            
            // Load the patient's past and upcoming appointments into the grid.
            dgvMyAppts.DataSource = appRepo.GetByPatientId(loggedInPatient.PatientID);

            if (dgvMyAppts.Columns.Contains("AppointmentID")) dgvMyAppts.Columns["AppointmentID"].Visible = false;
            if (dgvMyAppts.Columns.Contains("DoctorName")) dgvMyAppts.Columns["DoctorName"].HeaderText = "Doctor";
            if (dgvMyAppts.Columns.Contains("AppointmentDate")) dgvMyAppts.Columns["AppointmentDate"].HeaderText = "Date";
            if (dgvMyAppts.Columns.Contains("AppointmentTime")) dgvMyAppts.Columns["AppointmentTime"].HeaderText = "Time";
            if (dgvMyAppts.Columns.Contains("Status")) dgvMyAppts.Columns["Status"].HeaderText = "Status";
            if (dgvMyAppts.Columns.Contains("Notes")) dgvMyAppts.Columns["Notes"].HeaderText = "Notes";
        }
    }
}
