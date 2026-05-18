using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicApp.Models;
using ClinicApp.Repositories;
using System.Collections.Generic;

namespace ClinicApp.Forms
{
    public class DoctorsForm : Form
    {
        private DataGridView dgvDoctors;
        private TextBox txtName, txtSpec, txtPhone, txtDays, txtSlots, txtRoom, txtFee, txtSearch;
        private Button btnSave, btnEdit, btnDelete, btnClear;
        private DoctorRepository repo = new DoctorRepository();
        private int selectedDoctorID = 0;

        public DoctorsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Manage Doctors";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // Left Input Panel
            Panel inputPanel = new Panel { Dock = DockStyle.Left, Width = 300, Padding = new Padding(20) };
            
            // Absolutely positioned header to avoid collisions
            Label lblHeader = new Label { Text = "Doctor Details", Font = new Font("Segoe UI", 14F, FontStyle.Bold), Location = new Point(20, 15), Size = new Size(230, 30) };
            inputPanel.Controls.Add(lblHeader);

            // Spaced Inputs
            txtName = CreateInput(inputPanel, "Name*", 55);
            txtSpec = CreateInput(inputPanel, "Specialization*", 115);
            txtPhone = CreateInput(inputPanel, "Phone", 175);
            txtDays = CreateInput(inputPanel, "Available Days (e.g. Mon, Wed, Fri)", 235);
            txtSlots = CreateInput(inputPanel, "Available Slots (comma separated)", 295);
            txtRoom = CreateInput(inputPanel, "Room Number", 355);
            txtFee = CreateInput(inputPanel, "Fee (Rs.)", 415);

            btnSave = new Button { Text = "Save", Location = new Point(20, 485), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            btnSave.Click += BtnSave_Click;
            
            btnClear = new Button { Text = "Clear", Location = new Point(140, 485), Size = new Size(110, 35), BackColor = Color.FromArgb(230, 234, 237), ForeColor = Color.FromArgb(44, 62, 80), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            btnClear.Click += (s, e) => ClearForm();

            inputPanel.Controls.Add(btnSave);
            inputPanel.Controls.Add(btnClear);

            // Right Grid Panel
            Panel gridPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            
            // Search Bar Panel
            Panel pnlSearch = new Panel { Dock = DockStyle.Top, Height = 55 };
            Label lblSearch = new Label { Text = "Search:", Location = new Point(0, 5), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            txtSearch = new TextBox { Location = new Point(0, 25), Width = 400, Font = new Font("Segoe UI", 11F) };
            txtSearch.TextChanged += (s, e) => LoadData(txtSearch.Text);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);

            // Grid
            dgvDoctors = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(230, 235, 240),
                RowTemplate = { Height = 40 },
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 45,
                EnableHeadersVisualStyles = false
            };

            dgvDoctors.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.SteelBlue,
                SelectionForeColor = Color.White
            };

            dgvDoctors.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 62, 80),
                Font = new Font("Segoe UI", 9F),
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(44, 62, 80),
                Padding = new Padding(10, 0, 10, 0)
            };

            dgvDoctors.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 252, 254),
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(44, 62, 80)
            };

            // Bottom Actions Panel
            Panel buttonPanel = new Panel { Dock = DockStyle.Bottom, Height = 60 };
            btnEdit = new Button { Text = "Edit Selected", Location = new Point(20, 15), Size = new Size(130, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            btnEdit.Click += BtnEdit_Click;
            
            btnDelete = new Button { Text = "Delete Selected", Location = new Point(160, 15), Size = new Size(130, 35), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            btnDelete.Click += BtnDelete_Click;

            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnDelete);

            // Add to Grid Panel in strict order
            gridPanel.Controls.Add(dgvDoctors);
            gridPanel.Controls.Add(pnlSearch);
            gridPanel.Controls.Add(buttonPanel);

            // Send DockStyle.Fill control to back so it properly fills space between top & bottom docked panels
            dgvDoctors.SendToBack();

            this.Controls.Add(gridPanel);
            this.Controls.Add(inputPanel);
        }

        private TextBox CreateInput(Control parent, string label, int y)
        {
            parent.Controls.Add(new Label { Text = label, Location = new Point(20, y), AutoSize = true });
            TextBox tb = new TextBox { Location = new Point(20, y + 20), Width = 230 };
            parent.Controls.Add(tb);
            return tb;
        }

        private void LoadData(string query = "")
        {
            try
            {
                dgvDoctors.DataSource = string.IsNullOrEmpty(query) ? repo.GetAll() : repo.Search(query);
                
                // Adjust headers
                if (dgvDoctors.Columns.Count > 0)
                {
                    if (dgvDoctors.Columns.Contains("AvailableDays")) dgvDoctors.Columns["AvailableDays"].HeaderText = "Available Days";
                    if (dgvDoctors.Columns.Contains("AvailableSlots")) dgvDoctors.Columns["AvailableSlots"].HeaderText = "Available Slots";
                    if (dgvDoctors.Columns.Contains("RoomNumber")) dgvDoctors.Columns["RoomNumber"].HeaderText = "Room Number";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtSpec.Clear();
            txtPhone.Clear();
            txtDays.Clear();
            txtSlots.Clear();
            txtRoom.Clear();
            txtFee.Clear();
            selectedDoctorID = 0;
            btnSave.Text = "Save";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSpec.Text))
            {
                MessageBox.Show("Name and Specialization are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Doctor doc = new Doctor
                {
                    DoctorID = selectedDoctorID,
                    Name = txtName.Text.Trim(),
                    Specialization = txtSpec.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    AvailableDays = txtDays.Text.Trim(),
                    AvailableSlots = txtSlots.Text.Trim(),
                    RoomNumber = txtRoom.Text.Trim(),
                    Fee = double.TryParse(txtFee.Text, out double f) ? f : 0
                };

                if (selectedDoctorID == 0) repo.Add(doc);
                else repo.Update(doc);

                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDoctors.SelectedRows.Count > 0)
            {
                var row = dgvDoctors.SelectedRows[0];
                selectedDoctorID = (int)row.Cells["DoctorID"].Value;
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSpec.Text = row.Cells["Specialization"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"]?.Value?.ToString() ?? "";
                txtDays.Text = row.Cells["AvailableDays"]?.Value?.ToString() ?? "";
                txtSlots.Text = row.Cells["AvailableSlots"]?.Value?.ToString() ?? "";
                txtRoom.Text = row.Cells["RoomNumber"]?.Value?.ToString() ?? "";
                txtFee.Text = row.Cells["Fee"].Value.ToString();
                btnSave.Text = "Update";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDoctors.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this doctor?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        repo.Delete((int)dgvDoctors.SelectedRows[0].Cells["DoctorID"].Value);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
