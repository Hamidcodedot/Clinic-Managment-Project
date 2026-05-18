using System;
using System.Windows.Forms;
using ClinicApp.Models;
using ClinicApp.Repositories;

namespace ClinicApp.Forms
{
    public partial class DoctorsForm : Form
    {
        private DoctorRepository repo = new DoctorRepository();
        private int selectedDoctorID = 0;

        public DoctorsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string query = "")
        {
            if (dgvDoctors == null) return;
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
