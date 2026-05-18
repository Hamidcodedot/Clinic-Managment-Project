using System;
using System.Windows.Forms;
using ClinicApp.Models;
using ClinicApp.Repositories;

namespace ClinicApp.Forms
{
    public partial class PatientsForm : Form
    {
        private PatientRepository repo = new PatientRepository();
        private int selectedPatientID = 0;

        public PatientsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string query = "")
        {
            if (dgvPatients == null) return;
            try
            {
                dgvPatients.DataSource = string.IsNullOrEmpty(query) ? repo.GetAll() : repo.Search(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            txtPhone.Clear();
            txtAddress.Clear();
            selectedPatientID = 0;
            btnSave.Text = "Save";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Name and Phone are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Patient p = new Patient
                {
                    PatientID = selectedPatientID,
                    Name = txtName.Text,
                    Age = int.TryParse(txtAge.Text, out int a) ? a : 0,
                    Gender = cmbGender.SelectedItem?.ToString() ?? "",
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    Password = txtPhone.Text // Default password is their phone number
                };

                if (selectedPatientID == 0) repo.Add(p);
                else repo.Update(p);

                MessageBox.Show("Patient saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count > 0)
            {
                var row = dgvPatients.SelectedRows[0];
                selectedPatientID = (int)row.Cells["PatientID"].Value;
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                cmbGender.SelectedItem = row.Cells["Gender"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                btnSave.Text = "Update";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    repo.Delete((int)dgvPatients.SelectedRows[0].Cells["PatientID"].Value);
                    LoadData();
                }
            }
        }
    }
}
