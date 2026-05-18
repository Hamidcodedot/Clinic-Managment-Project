using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class PatientsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private DataGridView dgvPatients;
        private TextBox txtName, txtAge, txtPhone, txtAddress, txtSearch;
        private ComboBox cmbGender;
        private Button btnSave, btnEdit, btnDelete, btnClear;

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
            this.Text = "Manage Patients";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            Panel inputPanel = new Panel { Dock = DockStyle.Left, Width = 300, Padding = new Padding(20) };
            Label lblHeader = new Label { Text = "Patient Details", Font = new Font("Segoe UI", 14F, FontStyle.Bold), Dock = DockStyle.Top, Height = 40 };
            inputPanel.Controls.Add(lblHeader);

            // Name Input
            Label lblName = new Label { Text = "Name*", Location = new Point(20, 60), AutoSize = true };
            txtName = new TextBox { Location = new Point(20, 80), Width = 230 };
            inputPanel.Controls.Add(lblName);
            inputPanel.Controls.Add(txtName);

            // Age Input
            Label lblAge = new Label { Text = "Age", Location = new Point(20, 120), AutoSize = true };
            txtAge = new TextBox { Location = new Point(20, 140), Width = 230 };
            inputPanel.Controls.Add(lblAge);
            inputPanel.Controls.Add(txtAge);
            
            // Gender Input
            Label lblGender = new Label { Text = "Gender", Location = new Point(20, 180), AutoSize = true };
            inputPanel.Controls.Add(lblGender);

            cmbGender = new ComboBox { Location = new Point(20, 200), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            inputPanel.Controls.Add(cmbGender);

            // Phone Input
            Label lblPhone = new Label { Text = "Phone*", Location = new Point(20, 240), AutoSize = true };
            txtPhone = new TextBox { Location = new Point(20, 260), Width = 230 };
            inputPanel.Controls.Add(lblPhone);
            inputPanel.Controls.Add(txtPhone);

            // Address Input
            Label lblAddress = new Label { Text = "Address", Location = new Point(20, 300), AutoSize = true };
            txtAddress = new TextBox { Location = new Point(20, 320), Width = 230 };
            inputPanel.Controls.Add(lblAddress);
            inputPanel.Controls.Add(txtAddress);

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
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(235, 245, 251) }
            };
            gridPanel.Controls.Add(dgvPatients);

            Panel buttonPanel = new Panel { Dock = DockStyle.Bottom, Height = 60 };
            btnEdit = new Button { Text = "Edit Selected", Location = new Point(20, 10), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit.Click += BtnEdit_Click;
            
            btnDelete = new Button { Text = "Delete Selected", Location = new Point(140, 10), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += BtnDelete_Click;

            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnDelete);
            gridPanel.Controls.Add(buttonPanel);

            this.Controls.Add(gridPanel);
            this.Controls.Add(inputPanel);
        }

        #endregion
    }
}
