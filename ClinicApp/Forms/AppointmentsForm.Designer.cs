using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class AppointmentsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Text = "Manage Appointments & Bookings";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // Left Panel (Form Entry Pane) - Enabled AutoScroll for small screen responsiveness
            Panel pnlForm = new Panel
            {
                Dock = DockStyle.Left,
                Width = 380,
                BackColor = Color.FromArgb(248, 249, 250),
                Padding = new Padding(15, 10, 15, 10),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
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

            // DataGridView Setup - Docked Fill
            dgvApps = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                BorderStyle = BorderStyle.Fixed3D,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(245, 249, 253) }
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

            // Z-Order layout configuration to prevent overlaps
            pnlFilter.BringToFront();
            pnlActions.BringToFront();
            dgvApps.SendToBack(); // Pushes the grid to the background so filter bar & action panel are fully visible!

            // Add Panels to Form
            this.Controls.Add(pnlList);
            this.Controls.Add(pnlForm);
            pnlForm.BringToFront(); // Ensure Left Panel is never overlapped by Fill Panel
        }

        #endregion
    }
}
