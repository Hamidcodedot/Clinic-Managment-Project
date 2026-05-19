using System.Drawing;
using System.Windows.Forms;

namespace ClinicApp.Forms
{
    partial class DoctorsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Apply Form Defaults
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);
            this.Text = "Manage Doctors";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;

            var inputPanel = CreateInputSidebar("Doctor Details");

            txtName = AddLabeledField(inputPanel, "Name *", 55);
            txtSpec = AddLabeledField(inputPanel, "Specialization *", 115);
            txtPhone = AddLabeledField(inputPanel, "Phone", 175);
            txtDays = AddLabeledField(inputPanel, "Available Days (Mon, Wed, Fri)", 235);
            txtSlots = AddLabeledField(inputPanel, "Time Slots (comma separated)", 295);
            txtRoom = AddLabeledField(inputPanel, "Room Number", 355);
            txtFee = AddLabeledField(inputPanel, "Fee (Rs.)", 415);

            btnSave = CreateButton("Save", Color.FromArgb(70, 130, 180), Color.White, new Size(110, 36));
            btnSave.Location = new Point(20, 485);
            btnSave.Click += BtnSave_Click;

            var btnClear = CreateButton("Clear", Color.FromArgb(230, 234, 237), Color.FromArgb(44, 62, 80), new Size(110, 36));
            btnClear.Location = new Point(140, 485);
            btnClear.Click += (s, e) => ClearForm();
            inputPanel.Controls.Add(btnSave);
            inputPanel.Controls.Add(btnClear);

            var gridPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            var pnlSearch = new Panel { Dock = DockStyle.Top, Height = 52 };
            pnlSearch.Controls.Add(new Label { Text = "Search doctors", Location = new Point(0, 4), AutoSize = true, ForeColor = Color.FromArgb(127, 140, 141), Font = new Font("Segoe UI", 8.5F) });
            txtSearch = new TextBox { Location = new Point(0, 22), Width = 420, Font = new Font("Segoe UI", 10F) };
            txtSearch.TextChanged += (s, e) => LoadData(txtSearch.Text);
            pnlSearch.Controls.Add(txtSearch);

            dgvDoctors = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            StyleDataGrid(dgvDoctors);

            var buttonPanel = new Panel { Dock = DockStyle.Bottom, Height = 58 };
            btnEdit = CreateButton("Edit Selected", Color.FromArgb(70, 130, 180), Color.White, new Size(130, 36));
            btnEdit.Location = new Point(0, 12);
            btnEdit.Click += BtnEdit_Click;
            btnDelete = CreateButton("Delete Selected", Color.FromArgb(231, 76, 60), Color.White, new Size(130, 36));
            btnDelete.Location = new Point(140, 12);
            btnDelete.Click += BtnDelete_Click;
            buttonPanel.Controls.Add(btnEdit);
            buttonPanel.Controls.Add(btnDelete);

            var divider = AddGridDivider();
            gridPanel.Controls.Add(pnlSearch);
            gridPanel.Controls.Add(divider);
            gridPanel.Controls.Add(buttonPanel);
            gridPanel.Controls.Add(dgvDoctors);
            FixGridDockOrder(gridPanel, pnlSearch, divider, buttonPanel);

            Controls.Add(inputPanel);
            Controls.Add(gridPanel);
            gridPanel.BringToFront();
        }

        private Panel CreateInputSidebar(string title)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 300,
                BackColor = Color.FromArgb(248, 249, 250),
                Padding = new Padding(20),
                AutoScroll = true
            };
            panel.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(20, 15),
                AutoSize = true
            });
            return panel;
        }

        private TextBox AddLabeledField(Control parent, string label, int y, int fieldWidth = 230)
        {
            parent.Controls.Add(new Label
            {
                Text = label,
                Location = new Point(20, y),
                AutoSize = true,
                ForeColor = Color.FromArgb(127, 140, 141),
                Font = new Font("Segoe UI", 8.5F)
            });
            var box = new TextBox
            {
                Location = new Point(20, y + 18),
                Width = fieldWidth,
                Font = new Font("Segoe UI", 9.5F)
            };
            parent.Controls.Add(box);
            return box;
        }

        private Button CreateButton(string text, Color backColor, Color foreColor, Size size)
        {
            var btn = new Button
            {
                Text = text,
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Size = size
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private Panel AddGridDivider()
        {
            var wrapper = new Panel { Dock = DockStyle.Top, Height = 12, BackColor = Color.White };
            wrapper.Controls.Add(new Panel
            {
                Dock = DockStyle.Top,
                Height = 2,
                BackColor = Color.FromArgb(218, 224, 233)
            });
            return wrapper;
        }

        private void FixGridDockOrder(Control gridPanel, params Control[] topAndBottom)
        {
            foreach (var c in topAndBottom)
                c.SendToBack();
            foreach (Control c in gridPanel.Controls)
            {
                if (c is DataGridView dgv)
                    dgv.BringToFront();
            }
        }

        private void StyleDataGrid(DataGridView grid)
        {
            Color header = Color.FromArgb(70, 130, 180);
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 235, 240);
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.RowTemplate.Height = 40;
            grid.ColumnHeadersHeight = 38;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = header,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 62, 80),
                Font = new Font("Segoe UI", 9F),
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(44, 62, 80),
                Padding = new Padding(10, 0, 10, 0)
            };
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 252, 254),
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(44, 62, 80)
            };
        }
    }
}
