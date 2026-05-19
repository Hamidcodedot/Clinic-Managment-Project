using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicApp.Models;
using ClinicApp.Database;
using System.Collections.Generic;

namespace ClinicApp.Forms
{
    public partial class AppointmentsForm : Form
    {
        // UI Controls
        private DataGridView dgvApps;
        
        // Patient Information Group Box Controls
        private ComboBox cmbPatient;
        private CheckBox chkEditPatient;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAge;
        private ComboBox cmbGender;
        private TextBox txtAddress;

        // Appointment Information Group Box Controls
        private ComboBox cmbDoctor;
        private Label lblDoctorInfo;
        private DateTimePicker dtpDate;
        private ComboBox cmbTimeSlot;
        private TextBox txtNotes;

        // Action Buttons
        private Button btnBook;
        private Button btnClear;

        // Filters Controls
        private CheckBox chkEnableDateFilter;
        private DateTimePicker dtpFilterDate;
        private ComboBox cmbFilterStatus;
        private Button btnApplyFilter;
        private Button btnShowAll;

        // Right Pane Actions
        private ComboBox cmbGridStatus;
        private Button btnUpdateStatus;
        private Button btnDelete;
        private Button btnRefresh;

        // Repositories
        private AppointmentRepository appRepo = new AppointmentRepository();
        private PatientRepository patRepo = new PatientRepository();
        private DoctorRepository docRepo = new DoctorRepository();

        public AppointmentsForm()
        {
            InitializeComponent();
            LoadLookups();
            LoadData();
        }

        private void LoadLookups()
        {
            try
            {
                cmbPatient.SelectedIndexChanged -= CmbPatient_SelectedIndexChanged;
                cmbPatient.Items.Clear();
                cmbPatient.Items.Add("-- [New Patient] --");
                
                var patients = patRepo.GetAll();
                foreach (var p in patients)
                {
                    cmbPatient.Items.Add(p);
                }
                cmbPatient.SelectedIndex = 0;
                cmbPatient.SelectedIndexChanged += CmbPatient_SelectedIndexChanged;

                cmbDoctor.SelectedIndexChanged -= CmbDoctor_SelectedIndexChanged;
                cmbDoctor.DataSource = docRepo.GetAll();
                cmbDoctor.SelectedIndexChanged += CmbDoctor_SelectedIndexChanged;
                if (cmbDoctor.Items.Count > 0) CmbDoctor_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lookups: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                string dateStr = chkEnableDateFilter.Checked ? dtpFilterDate.Value.ToString("yyyy-MM-dd") : null;
                string status = cmbFilterStatus.SelectedItem.ToString();
                dgvApps.DataSource = appRepo.GetAll(dateStr, status);
                
                // Set column headers
                if (dgvApps.Columns.Count > 0)
                {
                    if (dgvApps.Columns.Contains("PatientID")) dgvApps.Columns["PatientID"].Visible = false;
                    if (dgvApps.Columns.Contains("DoctorID")) dgvApps.Columns["DoctorID"].Visible = false;
                    if (dgvApps.Columns.Contains("PatientName")) dgvApps.Columns["PatientName"].HeaderText = "Patient Name";
                    if (dgvApps.Columns.Contains("DoctorName")) dgvApps.Columns["DoctorName"].HeaderText = "Doctor Name";
                    if (dgvApps.Columns.Contains("AppointmentDate")) dgvApps.Columns["AppointmentDate"].HeaderText = "Date";
                    if (dgvApps.Columns.Contains("AppointmentTime")) dgvApps.Columns["AppointmentTime"].HeaderText = "Time Slot";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedIndex == 0) // -- [New Patient] --
            {
                chkEditPatient.Visible = false;
                chkEditPatient.Checked = false;
                
                txtName.Text = "";
                txtPhone.Text = "";
                txtAge.Text = "";
                cmbGender.SelectedIndex = -1;
                txtAddress.Text = "";

                txtName.ReadOnly = false;
                txtPhone.ReadOnly = false;
                txtAge.ReadOnly = false;
                cmbGender.Enabled = true;
                txtAddress.ReadOnly = false;
            }
            else if (cmbPatient.SelectedItem is Patient pat)
            {
                chkEditPatient.Visible = true;
                chkEditPatient.Checked = false;

                txtName.Text = pat.Name;
                txtPhone.Text = pat.Phone;
                txtAge.Text = pat.Age.ToString();
                cmbGender.SelectedItem = pat.Gender;
                txtAddress.Text = pat.Address;

                txtName.ReadOnly = true;
                txtPhone.ReadOnly = true;
                txtAge.ReadOnly = true;
                cmbGender.Enabled = false;
                txtAddress.ReadOnly = true;
            }
        }

        private void ChkEditPatient_CheckedChanged(object sender, EventArgs e)
        {
            bool isEditable = chkEditPatient.Checked || cmbPatient.SelectedIndex == 0;
            txtName.ReadOnly = !isEditable;
            txtPhone.ReadOnly = !isEditable;
            txtAge.ReadOnly = !isEditable;
            cmbGender.Enabled = isEditable;
            txtAddress.ReadOnly = !isEditable;
        }

        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedItem is Doctor doc)
            {
                // Auto-adjust date to nearest available day if the current one is invalid
                DateTime current = dtpDate.Value;
                string currentDay = current.DayOfWeek.ToString().Substring(0, 3);
                if (!string.IsNullOrWhiteSpace(doc.AvailableDays) && doc.AvailableDays.IndexOf(currentDay, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    dtpDate.Value = GetNearestAvailableDate(doc, current);
                }
            }
            UpdateDoctorInfoAndSlots();
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateDoctorInfoAndSlots();
        }

        private DateTime GetNearestAvailableDate(Doctor doc, DateTime fromDate)
        {
            if (string.IsNullOrWhiteSpace(doc.AvailableDays)) return fromDate;

            // Check up to 7 days ahead
            for (int i = 0; i < 7; i++)
            {
                DateTime testDate = fromDate.AddDays(i);
                string dayOfWeek = testDate.DayOfWeek.ToString().Substring(0, 3); // "Mon", "Tue", etc.
                if (doc.AvailableDays.IndexOf(dayOfWeek, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return testDate;
                }
            }
            return fromDate;
        }

        private void UpdateDoctorInfoAndSlots()
        {
            if (cmbDoctor.SelectedItem is Doctor doc)
            {
                // Check if doctor is available on the selected day
                DateTime date = dtpDate.Value;
                string dayOfWeek = date.DayOfWeek.ToString().Substring(0, 3); // "Mon", "Tue", etc.
                
                bool isAvailable = true;
                if (!string.IsNullOrWhiteSpace(doc.AvailableDays))
                {
                    isAvailable = doc.AvailableDays.IndexOf(dayOfWeek, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                string availStatus = isAvailable ? "Available" : "NOT AVAILABLE (Warning)";
                Color infoColor = isAvailable ? Color.DimGray : Color.Red;
                string room = string.IsNullOrWhiteSpace(doc.RoomNumber) ? "N/A" : doc.RoomNumber;

                lblDoctorInfo.Text = $"Specialization: {doc.Specialization}  |  Room: {room}\nFee: Rs. {doc.Fee}\nDays: {doc.AvailableDays} ({availStatus})";
                lblDoctorInfo.ForeColor = infoColor;

                // Load time slots and filter out already booked ones
                string dateStr = date.ToString("yyyy-MM-dd");
                List<string> bookedSlots = appRepo.GetBookedSlots(doc.DoctorID, dateStr);

                cmbTimeSlot.Items.Clear();
                
                IEnumerable<string> slotsToUse;
                if (!string.IsNullOrWhiteSpace(doc.AvailableSlots))
                {
                    var customSlots = new List<string>();
                    string[] parts = doc.AvailableSlots.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var p in parts)
                    {
                        customSlots.Add(p.Trim());
                    }
                    slotsToUse = customSlots;
                }
                else
                {
                    slotsToUse = new string[] {
                        "09:00 AM", "09:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM",
                        "12:00 PM", "12:30 PM", "01:00 PM", "01:30 PM", "02:00 PM", "02:30 PM",
                        "03:00 PM", "03:30 PM", "04:00 PM", "04:30 PM", "05:00 PM", "05:30 PM",
                        "06:00 PM", "06:30 PM", "07:00 PM", "07:30 PM", "08:00 PM", "08:30 PM",
                        "09:00 PM"
                    };
                }

                foreach (var slot in slotsToUse)
                {
                    if (!bookedSlots.Contains(slot))
                    {
                        cmbTimeSlot.Items.Add(slot);
                    }
                }

                if (cmbTimeSlot.Items.Count > 0)
                {
                    cmbTimeSlot.SelectedIndex = 0;
                }
                else
                {
                    cmbTimeSlot.Items.Add("No slots available");
                    cmbTimeSlot.SelectedIndex = 0;
                }
            }
            else
            {
                lblDoctorInfo.Text = "";
                cmbTimeSlot.Items.Clear();
            }
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            // --- STEP 1: Basic Validation ---
            // Ensure that the user has selected a valid Doctor from the dropdown.
            if (cmbDoctor.SelectedItem == null)
            {
                MessageBox.Show("Please select a Doctor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a valid time slot is selected (not empty or "No slots available").
            if (cmbTimeSlot.SelectedItem == null || cmbTimeSlot.SelectedItem.ToString() == "No slots available")
            {
                MessageBox.Show("Please select a valid Time Slot.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- STEP 2: Doctor Schedule Validation ---
            // Extract the first 3 letters of the selected day (e.g., "Mon", "Tue") to compare against the doctor's schedule.
            Doctor doc = (Doctor)cmbDoctor.SelectedItem;
            DateTime date = dtpDate.Value;
            string dayOfWeek = date.DayOfWeek.ToString().Substring(0, 3);

            // If the doctor has specific days, check if the selected day matches.
            // StringComparison.OrdinalIgnoreCase makes it case-insensitive.
            if (!string.IsNullOrWhiteSpace(doc.AvailableDays) && doc.AvailableDays.IndexOf(dayOfWeek, StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show($"Doctor is not scheduled to work on {date.DayOfWeek}. Please select one of their scheduled days: {doc.AvailableDays}", "Scheduling Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- STEP 3: Patient Data Validation & Saving ---
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Patient Name and Phone are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int patientId = 0;
                
                // If the user selected the first item "-- [New Patient] --"
                if (cmbPatient.SelectedIndex == 0)
                {
                    // Map the UI text boxes to the Patient model
                    Patient newPat = new Patient
                    {
                        Name = txtName.Text.Trim(),
                        Age = int.TryParse(txtAge.Text, out int age) ? age : 0,
                        Gender = cmbGender.SelectedItem?.ToString() ?? "",
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Password = txtPhone.Text.Trim() // We default the patient's portal password to their phone number
                    };

                    // Duplicate Check: Search the database by phone number
                    Patient existing = patRepo.GetByPhone(newPat.Phone);
                    if (existing != null)
                    {
                        // If patient exists, prompt the user to use the existing profile instead of creating a duplicate
                        DialogResult res = MessageBox.Show(
                            $"A patient with Phone '{newPat.Phone}' already exists ({existing.Name}). Do you want to book the appointment for this existing patient?",
                            "Patient Exists",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (res == DialogResult.Yes)
                        {
                            patientId = existing.PatientID; // Use existing ID
                        }
                        else
                        {
                            return; // Stop booking if user clicks 'No'
                        }
                    }
                    else
                    {
                        // Save the new patient to DB and get the auto-generated ID
                        patientId = patRepo.Add(newPat);
                    }
                }
                // If the user selected an existing patient from the dropdown list
                else if (cmbPatient.SelectedItem is Patient pat)
                {
                    patientId = pat.PatientID;

                    // If the receptionist checked the "Edit Info" box, save any changes made to the textboxes
                    if (chkEditPatient.Checked)
                    {
                        pat.Name = txtName.Text.Trim();
                        pat.Age = int.TryParse(txtAge.Text, out int age) ? age : 0;
                        pat.Gender = cmbGender.SelectedItem?.ToString() ?? "";
                        pat.Phone = txtPhone.Text.Trim();
                        pat.Address = txtAddress.Text.Trim();

                        patRepo.Update(pat);
                    }
                }

                // Failsafe: if something went wrong and ID wasn't retrieved
                if (patientId <= 0)
                {
                    MessageBox.Show("Could not resolve Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- STEP 4: Create the Appointment Record ---
                // Construct the Appointment model with the gathered IDs
                Appointment app = new Appointment
                {
                    PatientID = patientId,
                    DoctorID = doc.DoctorID,
                    AppointmentDate = date.ToString("yyyy-MM-dd"), // Standardized date format for SQLite
                    AppointmentTime = cmbTimeSlot.SelectedItem.ToString(),
                    Status = "Pending", // Default status for new appointments
                    Notes = txtNotes.Text.Trim(),
                    BookedBy = "Staff" // Audit trail to know who booked it
                };

                // Insert into the database
                appRepo.Add(app);
                
                // --- STEP 5: Refresh UI ---
                // Reload dropdowns (so the new patient appears) and refresh the DataGridView
                LoadLookups(); 
                LoadData();
                
                // Clean up the form fields for the next entry
                txtNotes.Clear();
                chkEditPatient.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            BtnClear_Form();
        }

        private void BtnClear_Form()
        {
            cmbPatient.SelectedIndex = 0;
            CmbPatient_SelectedIndexChanged(null, null);
            txtNotes.Clear();
            if (cmbDoctor.Items.Count > 0) cmbDoctor.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            UpdateDoctorInfoAndSlots();
        }

        private void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count > 0)
            {
                int id = (int)dgvApps.SelectedRows[0].Cells["AppointmentID"].Value;
                string newStatus = cmbGridStatus.SelectedItem.ToString();
                appRepo.UpdateStatus(id, newStatus);
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select an appointment from the grid to update status.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    appRepo.Delete((int)dgvApps.SelectedRows[0].Cells["AppointmentID"].Value);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment from the grid to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvApps_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count > 0)
            {
                var row = dgvApps.SelectedRows[0];
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (cmbGridStatus.Items.Contains(status))
                    {
                        cmbGridStatus.SelectedItem = status;
                    }
                }
            }
        }

        private void DgvApps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvApps.Columns.Count > e.ColumnIndex && dgvApps.Columns[e.ColumnIndex].Name == "BookedBy" && e.Value != null)
            {
                if (e.Value.ToString() == "Patient")
                {
                    dgvApps.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }
    }
}
