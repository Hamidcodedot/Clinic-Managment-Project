using System;
using System.Windows.Forms;
using ClinicApp.Database;
using ClinicApp.Models;

namespace ClinicApp.Forms
{
    public partial class PatientsForm : Form
    {
        private DataGridView dgvPatients;
        private TextBox txtName, txtAge, txtPhone, txtAddress, txtSearch;
        private ComboBox cmbGender;
        private Button btnSave;
        private readonly PatientRepository repo = new PatientRepository();
        private int selectedPatientID;
        private string savedPassword;

        public PatientsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string query = "")
        {
            try
            {
                query = query?.Trim();
                dgvPatients.DataSource = string.IsNullOrEmpty(query) ? repo.GetAll() : repo.Search(query);
                if (dgvPatients.Columns.Contains("PatientID")) dgvPatients.Columns["PatientID"].Visible = false;
                if (dgvPatients.Columns.Contains("Password")) dgvPatients.Columns["Password"].Visible = false;
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
            savedPassword = null;
            btnSave.Text = "Save";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Name and Phone are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var p = new Patient
                {
                    PatientID = selectedPatientID,
                    Name = txtName.Text.Trim(),
                    Age = int.TryParse(txtAge.Text, out int a) ? a : 0,
                    Gender = cmbGender.SelectedItem?.ToString() ?? "",
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Password = selectedPatientID == 0 ? txtPhone.Text.Trim() : (savedPassword ?? txtPhone.Text.Trim())
                };

                if (selectedPatientID == 0) repo.Add(p);
                else repo.Update(p);

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
            if (dgvPatients.SelectedRows.Count == 0) return;
            var row = dgvPatients.SelectedRows[0];
            selectedPatientID = (int)row.Cells["PatientID"].Value;
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            cmbGender.SelectedItem = row.Cells["Gender"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
            var existing = repo.GetByPhone(txtPhone.Text.Trim());
            savedPassword = existing?.Password;
            btnSave.Text = "Update";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Delete this patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            repo.Delete((int)dgvPatients.SelectedRows[0].Cells["PatientID"].Value);
            LoadData();
        }
    }
}
