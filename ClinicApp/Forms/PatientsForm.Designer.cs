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

            // Left Input Panel - Enabled AutoScroll for small screen responsiveness
            Panel inputPanel = new Panel { Dock = DockStyle.Left, Width = 300, Padding = new Padding(20), AutoScroll = true };
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

            // Right Grid Panel
            Panel gridPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            
            // Search Bar Panel - Clean docked container to prevent overlapping
            Panel pnlSearch = new Panel { Dock = DockStyle.Top, Height = 55 };
            Label lblSearch = new Label { Text = "Search:", Location = new Point(0, 5), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            txtSearch = new TextBox { Location = new Point(0, 25), Width = 400, Font = new Font("Segoe UI", 11F) };
            txtSearch.TextChanged += (s, e) => LoadData(txtSearch.Text);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);

            // Grid
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

            // Bottom Actions Panel
            Panel buttonPanel = new Panel { Dock = DockStyle.Bottom, Height = 60 };
            btnEdit = new Button { Text = "Edit Selected", Location = new Point(20, 10), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit.Click += BtnEdit_Click;
            
            btnDelete = new Button { Text = "Delete Selected", Location = new Point(140, 10), Size = new Size(110, 35), BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete.Click += BtnDelete_Click;

            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnDelete);

            // Add to Grid Panel in strict order
            gridPanel.Controls.Add(dgvPatients);
            gridPanel.Controls.Add(pnlSearch);
            gridPanel.Controls.Add(buttonPanel);

            // Prevent overlapping by ordering the dock Z-index
            pnlSearch.BringToFront();
            buttonPanel.BringToFront();

            this.Controls.Add(gridPanel);
            this.Controls.Add(inputPanel);
            inputPanel.BringToFront(); // Ensure Left Input Panel is never overlapped by Grid Panel
        }

        private TextBox CreateInput(Control parent, string label, int y)
        {
            parent.Controls.Add(new Label { Text = label, Location = new Point(20, y), AutoSize = true });
            TextBox tb = new TextBox { Location = new Point(20, y + 20), Width = 230 };
            parent.Controls.Add(tb);
            return tb;
        }

        #endregion
    }
}
