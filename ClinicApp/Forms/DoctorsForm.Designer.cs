using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class DoctorsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private DataGridView dgvDoctors;
        private TextBox txtName, txtSpec, txtPhone, txtDays, txtSlots, txtRoom, txtFee, txtSearch;
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
            this.Text = "Manage Doctors";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // Left Input Panel - Enabled AutoScroll for small screen responsiveness
            Panel inputPanel = new Panel { Dock = DockStyle.Left, Width = 300, Padding = new Padding(20), AutoScroll = true };
            
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

            // Grid - Docked Fill
            dgvDoctors = new DataGridView
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

            // Z-Order layout configuration to prevent overlaps
            pnlSearch.BringToFront();
            buttonPanel.BringToFront();
            dgvDoctors.SendToBack(); // Pushes the grid to the background so search panel & action button panel are fully visible!

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
