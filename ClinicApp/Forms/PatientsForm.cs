using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicApp.Models;
using ClinicApp.Repositories;

namespace ClinicApp.Forms
{
    public class PatientsForm : Form
    {
        private DataGridView dgvPatients;
        private TextBox txtName, txtAge, txtPhone, txtAddress, txtSearch;
        private ComboBox cmbGender;
        private Button btnSave, btnEdit, btnDelete, btnClear;
        private PatientRepository repo = new PatientRepository();
        private int selectedPatientID = 0;

        public PatientsForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Manage Patients";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            Panel inputPanel = new Panel { Dock = DockStyle.Left, Width = 300, Padding = new Padding(20) };
            Label lblHeader = new Label { Text = "Patient Details", Font = new Font("Segoe UI", 14F, FontStyle.Bold), Dock = DockStyle.Top, Height = 40 };
            inputPanel.Controls.Add(lblHeader);

            txtName = CreateInput(inputPanel, "Name*", 60);
            txtAge = CreateInput(inputPanel, "Age", 120);
            
            inputPanel.Controls.Add(new Label { Text = "Gender", Location = new Point(20, 180), AutoSize = true });
            cmbGender = new ComboBox { Location = new Point(20, 200), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            inputPanel.Controls.Add(cmbGender);

            txtPhone = CreateInput(inputPanel, "Phone*", 240);
            txtAddress = CreateInput(inputPanel, "Address", 300);

            btnSave = new Button { Text = "Save", Location = new Point(20, 370), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSave.Click += BtnSave_Click;
            
            btnClear = new Button { Text = "Clear", Location = new Point(140, 370), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnClear.Click += (s, e) => ClearForm();

            inputPanel.Controls.Add(btnSave);
            inputPanel.Controls.Add(btnClear);

            Panel gridPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            txtSearch = new TextBox { Dock = DockStyle.Top, Font = new Font("Segoe UI", 11F) };
            txtSearch.TextChanged += (s, e) => LoadData(txtSearch.Text);
            gridPanel.Controls.Add(new Label { Text = "Search:", Dock = DockStyle.Top, Height = 25 });
            gridPanel.Controls.Add(txtSearch);

            dgvPatients = new DataGridView
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
                ColumnHeadersVisible = true, // Explicitly show column headers
                EnableHeadersVisualStyles = false
            };

            dgvPatients.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.SteelBlue,
                SelectionForeColor = Color.White
            };

            dgvPatients.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 62, 80),
                Font = new Font("Segoe UI", 9F),
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(44, 62, 80),
                Padding = new Padding(10, 0, 10, 0)
            };

            dgvPatients.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 252, 254),
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(44, 62, 80)
            };

            Panel buttonPanel = new Panel { Dock = DockStyle.Bottom, Height = 60 };
            btnEdit = new Button { Text = "Edit Selected", Location = new Point(20, 10), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit.Click += BtnEdit_Click;
            
            btnDelete = new Button { Text = "Delete Selected", Location = new Point(140, 10), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += BtnDelete_Click;

            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnDelete);
            
            // Add docked controls first, and then the Fill control last to prevent overlapping
            gridPanel.Controls.Add(buttonPanel);
            gridPanel.Controls.Add(dgvPatients);

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
                dgvPatients.DataSource = string.IsNullOrEmpty(query) ? repo.GetAll() : repo.Search(query);

                // Adjust Column Headers Height after binding to avoid WinForms layout calculation bugs
                dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvPatients.ColumnHeadersHeight = 45;

                // Explicitly style each auto-generated column header to guarantee it renders SteelBlue with white text
                foreach (DataGridViewColumn col in dgvPatients.Columns)
                {
                    col.HeaderCell.Style.BackColor = Color.SteelBlue;
                    col.HeaderCell.Style.ForeColor = Color.White;
                }

                if (dgvPatients.Columns.Count > 0)
                {
                    if (dgvPatients.Columns.Contains("PatientID")) dgvPatients.Columns["PatientID"].Visible = false;
                    if (dgvPatients.Columns.Contains("FullName")) dgvPatients.Columns["FullName"].HeaderText = "Full Name";
                    if (dgvPatients.Columns.Contains("Gender")) dgvPatients.Columns["Gender"].HeaderText = "Gender";
                    if (dgvPatients.Columns.Contains("Age")) dgvPatients.Columns["Age"].HeaderText = "Age";
                    if (dgvPatients.Columns.Contains("Phone")) dgvPatients.Columns["Phone"].HeaderText = "Phone";
                    if (dgvPatients.Columns.Contains("Address")) dgvPatients.Columns["Address"].HeaderText = "Address";
                    if (dgvPatients.Columns.Contains("Password")) dgvPatients.Columns["Password"].Visible = false;
                }
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
