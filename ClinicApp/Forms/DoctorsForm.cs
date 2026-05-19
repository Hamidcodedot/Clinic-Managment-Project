using System;
using System.Windows.Forms;
using ClinicApp.Database;
using ClinicApp.Models;

namespace ClinicApp.Forms
{
    public partial class DoctorsForm : Form
    {
        private DataGridView dgvDoctors;
        private TextBox txtName, txtSpec, txtPhone, txtDays, txtSlots, txtRoom, txtFee, txtSearch;
        private Button btnSave, btnEdit, btnDelete;
        private readonly DoctorRepository repo = new DoctorRepository();
        private int selectedDoctorID;

        public DoctorsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string query = "")
        {
            try
            {
                // Fetch all doctors from the database or search by name/specialization
                query = query?.Trim();
                dgvDoctors.DataSource = string.IsNullOrEmpty(query) ? repo.GetAll() : repo.Search(query);
                
                // Format the DataGridView columns for better user presentation
                // Hide the primary key ID column as the user doesn't need to see it
                if (dgvDoctors.Columns.Contains("DoctorID")) dgvDoctors.Columns["DoctorID"].Visible = false;
                if (dgvDoctors.Columns.Contains("AvailableDays")) dgvDoctors.Columns["AvailableDays"].HeaderText = "Available Days";
                if (dgvDoctors.Columns.Contains("AvailableSlots")) dgvDoctors.Columns["AvailableSlots"].HeaderText = "Time Slots";
                if (dgvDoctors.Columns.Contains("RoomNumber")) dgvDoctors.Columns["RoomNumber"].HeaderText = "Room";
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
            // --- Basic Validation ---
            // Ensure essential fields are not empty before saving
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSpec.Text))
            {
                MessageBox.Show("Name and Specialization are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create a Doctor object from the UI input fields
                var doc = new Doctor
                {
                    DoctorID = selectedDoctorID,
                    Name = txtName.Text.Trim(),
                    Specialization = txtSpec.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    AvailableDays = txtDays.Text.Trim(),
                    AvailableSlots = txtSlots.Text.Trim(),
                    RoomNumber = txtRoom.Text.Trim(),
                    // Parse the fee safely. If the user enters invalid text, it defaults to 0 instead of crashing.
                    Fee = double.TryParse(txtFee.Text, out double f) ? f : 0
                };

                // --- Decide whether to Add or Update ---
                // If selectedDoctorID is 0, it means we are creating a new record. 
                // Otherwise, we are updating an existing record.
                if (selectedDoctorID == 0) repo.Add(doc);
                else repo.Update(doc);

                // Reset UI and reload the grid to show the latest changes
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
            if (dgvDoctors.SelectedRows.Count == 0) return;
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDoctors.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Delete this doctor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
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
