using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicApp.Models;
using ClinicApp.Repositories;
using System.Collections.Generic;

namespace ClinicApp.Forms
{
    public class AppointmentsForm : Form
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

        private void InitializeComponent()
        {
            this.Text = "Manage Appointments & Bookings";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // Left Panel (Form Entry Pane)
            Panel pnlForm = new Panel
            {
                Dock = DockStyle.Left,
                Width = 380,
                BackColor = Color.FromArgb(248, 249, 250),
                Padding = new Padding(15, 10, 15, 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label
            {
                Text = "Appointment Booking",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.SteelBlue,
                Location = new Point(15, 10),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblTitle);

            // Patient Details GroupBox
            GroupBox grpPatient = new GroupBox
            {
                Text = "Patient Information",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(10, 45),
                Size = new Size(358, 255),
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            // Set child controls within GroupBox to use Regular font
            Font regFont = new Font("Segoe UI", 9F, FontStyle.Regular);

            Label lblSelectPat = new Label { Text = "Select Existing Patient:", Location = new Point(10, 20), AutoSize = true, Font = regFont };
            cmbPatient = new ComboBox { Location = new Point(10, 38), Width = 338, DropDownStyle = ComboBoxStyle.DropDownList, Font = regFont };
            cmbPatient.SelectedIndexChanged += CmbPatient_SelectedIndexChanged;

            chkEditPatient = new CheckBox { Text = "Edit Patient Info", Location = new Point(10, 64), AutoSize = true, Font = regFont, Visible = false };
            chkEditPatient.CheckedChanged += ChkEditPatient_CheckedChanged;

            Label lblName = new Label { Text = "Name*:", Location = new Point(10, 88), AutoSize = true, Font = regFont };
            txtName = new TextBox { Location = new Point(10, 106), Width = 338, Font = regFont };

            Label lblPhone = new Label { Text = "Phone*:", Location = new Point(10, 136), AutoSize = true, Font = regFont };
            txtPhone = new TextBox { Location = new Point(10, 154), Width = 160, Font = regFont };

            Label lblAge = new Label { Text = "Age:", Location = new Point(180, 136), AutoSize = true, Font = regFont };
            txtAge = new TextBox { Location = new Point(180, 154), Width = 60, Font = regFont };

            Label lblGender = new Label { Text = "Gender:", Location = new Point(250, 136), AutoSize = true, Font = regFont };
            cmbGender = new ComboBox { Location = new Point(250, 154), Width = 98, DropDownStyle = ComboBoxStyle.DropDownList, Font = regFont };
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });

            Label lblAddress = new Label { Text = "Address:", Location = new Point(10, 184), AutoSize = true, Font = regFont };
            txtAddress = new TextBox { Location = new Point(10, 202), Width = 338, Font = regFont };

            grpPatient.Controls.Add(lblSelectPat);
            grpPatient.Controls.Add(cmbPatient);
            grpPatient.Controls.Add(chkEditPatient);
            grpPatient.Controls.Add(lblName);
            grpPatient.Controls.Add(txtName);
            grpPatient.Controls.Add(lblPhone);
            grpPatient.Controls.Add(txtPhone);
            grpPatient.Controls.Add(lblAge);
            grpPatient.Controls.Add(txtAge);
            grpPatient.Controls.Add(lblGender);
            grpPatient.Controls.Add(cmbGender);
            grpPatient.Controls.Add(lblAddress);
            grpPatient.Controls.Add(txtAddress);
            
            pnlForm.Controls.Add(grpPatient);

            // Appointment Details GroupBox
            GroupBox grpAppt = new GroupBox
            {
                Text = "Appointment Details",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(10, 305),
                Size = new Size(358, 310),
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            Label lblDoctor = new Label { Text = "Doctor*:", Location = new Point(10, 20), AutoSize = true, Font = regFont };
            cmbDoctor = new ComboBox { Location = new Point(10, 38), Width = 338, DropDownStyle = ComboBoxStyle.DropDownList, Font = regFont };
            cmbDoctor.SelectedIndexChanged += CmbDoctor_SelectedIndexChanged;

            lblDoctorInfo = new Label
            {
                Location = new Point(10, 64),
                Size = new Size(338, 42),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = Color.DimGray
            };

            Label lblDate = new Label { Text = "Date*:", Location = new Point(10, 110), AutoSize = true, Font = regFont };
            dtpDate = new DateTimePicker { Location = new Point(10, 128), Width = 160, Format = DateTimePickerFormat.Short, MinDate = DateTime.Today, Font = regFont };
            dtpDate.ValueChanged += DtpDate_ValueChanged;

            Label lblTimeSlot = new Label { Text = "Time Slot*:", Location = new Point(180, 110), AutoSize = true, Font = regFont };
            cmbTimeSlot = new ComboBox { Location = new Point(180, 128), Width = 168, DropDownStyle = ComboBoxStyle.DropDownList, Font = regFont };

            Label lblNotes = new Label { Text = "Notes:", Location = new Point(10, 158), AutoSize = true, Font = regFont };
            txtNotes = new TextBox { Location = new Point(10, 176), Width = 338, Height = 95, Multiline = true, Font = regFont, ScrollBars = ScrollBars.Vertical };

            grpAppt.Controls.Add(lblDoctor);
            grpAppt.Controls.Add(cmbDoctor);
            grpAppt.Controls.Add(lblDoctorInfo);
            grpAppt.Controls.Add(lblDate);
            grpAppt.Controls.Add(dtpDate);
            grpAppt.Controls.Add(lblTimeSlot);
            grpAppt.Controls.Add(cmbTimeSlot);
            grpAppt.Controls.Add(lblNotes);
            grpAppt.Controls.Add(txtNotes);

            pnlForm.Controls.Add(grpAppt);

            // Action Buttons
            btnBook = new Button
            {
                Text = "Book Appointment",
                Location = new Point(10, 625),
                Size = new Size(215, 38),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            btnBook.Click += BtnBook_Click;

            btnClear = new Button
            {
                Text = "Clear Form",
                Location = new Point(233, 625),
                Size = new Size(135, 38),
                BackColor = Color.FromArgb(230, 234, 237),
                ForeColor = Color.FromArgb(44, 62, 80),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            btnClear.Click += BtnClear_Click;

            pnlForm.Controls.Add(btnBook);
            pnlForm.Controls.Add(btnClear);

            // Right Panel (Appointments Grid & Actions)
            Panel pnlList = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            // Filter Bar Panel
            Panel pnlFilter = new Panel
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = Color.FromArgb(240, 242, 245),
                Padding = new Padding(10)
            };

            Label lblFilterTitle = new Label { Text = "Filter By:", Location = new Point(10, 18), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80) };
            pnlFilter.Controls.Add(lblFilterTitle);

            chkEnableDateFilter = new CheckBox { Text = "Date:", Location = new Point(85, 17), Width = 60 };
            pnlFilter.Controls.Add(chkEnableDateFilter);

            dtpFilterDate = new DateTimePicker { Location = new Point(145, 15), Width = 120, Format = DateTimePickerFormat.Short };
            pnlFilter.Controls.Add(dtpFilterDate);

            Label lblFilterStatus = new Label { Text = "Status:", Location = new Point(285, 18), AutoSize = true };
            pnlFilter.Controls.Add(lblFilterStatus);

            cmbFilterStatus = new ComboBox { Location = new Point(335, 15), Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFilterStatus.Items.AddRange(new string[] { "All", "Pending", "Confirmed", "Completed", "Cancelled" });
            cmbFilterStatus.SelectedIndex = 0;
            pnlFilter.Controls.Add(cmbFilterStatus);

            btnApplyFilter = new Button { Text = "Apply Filter", Location = new Point(475, 12), Size = new Size(100, 30), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnApplyFilter.Click += (s, e) => LoadData();
            pnlFilter.Controls.Add(btnApplyFilter);

            btnShowAll = new Button { Text = "Show All", Location = new Point(585, 12), Size = new Size(100, 30), BackColor = Color.Gray, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnShowAll.Click += (s, e) => { chkEnableDateFilter.Checked = false; cmbFilterStatus.SelectedIndex = 0; LoadData(); };
            pnlFilter.Controls.Add(btnShowAll);

            pnlList.Controls.Add(pnlFilter);

            // DataGridView Setup
            dgvApps = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,

                // Modern flat border aur horizontal borders
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(230, 235, 240), // Halka solid border line color

                // Heights to give rows breathing room
                RowTemplate = { Height = 40 }, // Row ki height 40px ki taake text squished na ho
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 45, // Headers ki height 45px

                // Windows ke default themes ko overrides karne ke liye
                EnableHeadersVisualStyles = false
            };

            // Headers Styling (Premium Header Look)
            dgvApps.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.SteelBlue, // Header select hone par same color rahe
                SelectionForeColor = Color.White
            };

            // Default Cell Styling (Clean & Readable)
            dgvApps.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 62, 80), // Modern dark slate color
                Font = new Font("Segoe UI", 9F),
                SelectionBackColor = Color.FromArgb(220, 235, 252), // Premium soft blue select background
                SelectionForeColor = Color.FromArgb(44, 62, 80), // Soft blue par readable dark text
                Padding = new Padding(10, 0, 10, 0) // Cells ke andar horizontal gap
            };

            // Alternating Row Style (Subtle Zebra Striping)
            dgvApps.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 252, 254), // Subtle row color tint
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(44, 62, 80)
            };

            dgvApps.CellFormatting += DgvApps_CellFormatting;
            dgvApps.SelectionChanged += DgvApps_SelectionChanged;


            // Action Panel at the Bottom (with dedicated Status Update Dropdown)
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 55,
                Padding = new Padding(0, 10, 0, 0)
            };

            Label lblGridStatus = new Label 
            { 
                Text = "Change Status to:", 
                Location = new Point(0, 18), 
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80)
            };
            pnlActions.Controls.Add(lblGridStatus);

            cmbGridStatus = new ComboBox 
            { 
                Location = new Point(115, 15), 
                Width = 120, 
                DropDownStyle = ComboBoxStyle.DropDownList 
            };
            cmbGridStatus.Items.AddRange(new string[] { "Pending", "Confirmed", "Completed", "Cancelled" });
            cmbGridStatus.SelectedIndex = 0;
            pnlActions.Controls.Add(cmbGridStatus);

            btnUpdateStatus = new Button 
            { 
                Text = "Update Status", 
                Location = new Point(245, 10), 
                Size = new Size(110, 35), 
                BackColor = Color.SteelBlue, 
                ForeColor = Color.White, 
                FlatStyle = FlatStyle.Flat, 
                Font = new Font("Segoe UI", 9F, FontStyle.Bold) 
            };
            btnUpdateStatus.Click += BtnUpdateStatus_Click;

            btnDelete = new Button { Text = "Delete", Location = new Point(365, 10), Size = new Size(110, 35), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            btnDelete.Click += BtnDelete_Click;

            btnRefresh = new Button { Text = "Refresh", Location = new Point(485, 10), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            btnRefresh.Click += (s, e) => LoadData();

            pnlActions.Controls.Add(btnUpdateStatus);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnRefresh);

            pnlList.Controls.Add(dgvApps);
            pnlList.Controls.Add(pnlActions);

            // Send DockStyle.Fill control to back so it properly fills space between top & bottom docked panels
            dgvApps.SendToBack();

            // Add Panels to Form
            this.Controls.Add(pnlList);
            this.Controls.Add(pnlForm);
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
            // 1. Validate Doctor and Time Slot
            if (cmbDoctor.SelectedItem == null)
            {
                MessageBox.Show("Please select a Doctor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTimeSlot.SelectedItem == null || cmbTimeSlot.SelectedItem.ToString() == "No slots available")
            {
                MessageBox.Show("Please select a valid Time Slot.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1.5 Validate Doctor Availability Day
            Doctor doc = (Doctor)cmbDoctor.SelectedItem;
            DateTime date = dtpDate.Value;
            string dayOfWeek = date.DayOfWeek.ToString().Substring(0, 3);
            if (!string.IsNullOrWhiteSpace(doc.AvailableDays) && doc.AvailableDays.IndexOf(dayOfWeek, StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show($"Doctor is not scheduled to work on {date.DayOfWeek}. Please select one of their scheduled days: {doc.AvailableDays}", "Scheduling Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate Patient Details
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Patient Name and Phone are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int patientId = 0;
                
                if (cmbPatient.SelectedIndex == 0) // New Patient
                {
                    // Create and save new patient first
                    Patient newPat = new Patient
                    {
                        Name = txtName.Text.Trim(),
                        Age = int.TryParse(txtAge.Text, out int age) ? age : 0,
                        Gender = cmbGender.SelectedItem?.ToString() ?? "",
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Password = txtPhone.Text.Trim() // Default password is their phone number
                    };

                    // Check if patient with this phone already exists to avoid duplication
                    Patient existing = patRepo.GetByPhone(newPat.Phone);
                    if (existing != null)
                    {
                        DialogResult res = MessageBox.Show(
                            $"A patient with Phone '{newPat.Phone}' already exists ({existing.Name}). Do you want to book the appointment for this existing patient?",
                            "Patient Exists",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (res == DialogResult.Yes)
                        {
                            patientId = existing.PatientID;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        patientId = patRepo.Add(newPat);
                    }
                }
                else if (cmbPatient.SelectedItem is Patient pat)
                {
                    patientId = pat.PatientID;

                    // If "Edit Patient Info" is enabled and checked, update the patient details
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

                if (patientId <= 0)
                {
                    MessageBox.Show("Could not resolve Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Book Appointment (New bookings are always hardcoded to 'Pending')
                Appointment app = new Appointment
                {
                    PatientID = patientId,
                    DoctorID = doc.DoctorID,
                    AppointmentDate = date.ToString("yyyy-MM-dd"),
                    AppointmentTime = cmbTimeSlot.SelectedItem.ToString(),
                    Status = "Pending",
                    Notes = txtNotes.Text.Trim(),
                    BookedBy = "Staff"
                };

                appRepo.Add(app);
                
                // 4. Reload lists and clear selection
                LoadLookups(); // This will reload patients including the new one
                LoadData();
                
                // Clear notes and reset form
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
