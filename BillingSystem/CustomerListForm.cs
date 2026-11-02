using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;
using ClosedXML.Excel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace BillingSystem
{
    public partial class CustomerListForm : Form
    {
        // Stores the CustomerID of the currently selected row (0 = none)
        private int selectedCustomerId = 0;

        // Permission flag for editing via double-click
        private bool _canEdit = true;

        public CustomerListForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadCustomers();
            ApplyPermissions();
            InitStatusStrip();
        }

        #region Theme & DataGridView Formatting (Step 9.3)

        private void ApplyTheme()
        {
            // Apply main form background color
            this.BackColor = AppTheme.BackgroundColor;

            // DataGridView Headers, Rows, and Grid Background Styling
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.BackgroundColor = AppTheme.BackgroundColor;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PrimaryColor;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = AppTheme.GridRowAlt;

            // Apply AppTheme Color Constants across all buttons
            if (btnAdd != null)
            {
                btnAdd.BackColor = AppTheme.SuccessColor;
                btnAdd.ForeColor = Color.White;
                btnAdd.FlatStyle = FlatStyle.Flat;
                btnAdd.FlatAppearance.BorderSize = 0;
            }
            if (btnDelete != null)
            {
                btnDelete.BackColor = AppTheme.DangerColor;
                btnDelete.ForeColor = Color.White;
                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.FlatAppearance.BorderSize = 0;
            }
            if (btnLogout != null)
            {
                btnLogout.BackColor = AppTheme.SecondaryColor;
                btnLogout.ForeColor = Color.White;
                btnLogout.FlatStyle = FlatStyle.Flat;
                btnLogout.FlatAppearance.BorderSize = 0;
            }
            if (btnSearch != null)
            {
                btnSearch.BackColor = AppTheme.PrimaryColor;
                btnSearch.ForeColor = Color.White;
                btnSearch.FlatStyle = FlatStyle.Flat;
                btnSearch.FlatAppearance.BorderSize = 0;
            }
            if (btnAnalytics != null)
            {
                btnAnalytics.BackColor = AppTheme.PrimaryColor;
                btnAnalytics.ForeColor = Color.White;
                btnAnalytics.FlatStyle = FlatStyle.Flat;
                btnAnalytics.FlatAppearance.BorderSize = 0;
            }
            if (btnExportExcel != null)
            {
                btnExportExcel.BackColor = AppTheme.SecondaryColor;
                btnExportExcel.ForeColor = Color.White;
                btnExportExcel.FlatStyle = FlatStyle.Flat;
                btnExportExcel.FlatAppearance.BorderSize = 0;
            }
            if (btnExportPdf != null)
            {
                btnExportPdf.BackColor = AppTheme.SecondaryColor;
                btnExportPdf.ForeColor = Color.White;
                btnExportPdf.FlatStyle = FlatStyle.Flat;
                btnExportPdf.FlatAppearance.BorderSize = 0;
            }
            if (btnAuditLog != null)
            {
                btnAuditLog.BackColor = AppTheme.SecondaryColor;
                btnAuditLog.ForeColor = Color.White;
                btnAuditLog.FlatStyle = FlatStyle.Flat;
                btnAuditLog.FlatAppearance.BorderSize = 0;
            }
            if (btnManagePermissions != null)
            {
                btnManagePermissions.BackColor = AppTheme.SecondaryColor;
                btnManagePermissions.ForeColor = Color.White;
                btnManagePermissions.FlatStyle = FlatStyle.Flat;
                btnManagePermissions.FlatAppearance.BorderSize = 0;
            }
        }

        /// <summary>
        /// Step 9.3: Colors rows based on customer Status.
        /// Inactive customers receive a light-red row background.
        /// Active customers receive a light-green background on their Status cell.
        /// </summary>
        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCustomers.Rows.Count) return;

            if (!dgvCustomers.Columns.Contains("Status")) return;

            var row = dgvCustomers.Rows[e.RowIndex];
            var statusVal = row.Cells["Status"]?.Value?.ToString();

            if (string.Equals(statusVal, "Inactive", StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor = AppTheme.InactiveRowColor;
            }
            else if (string.Equals(statusVal, "Active", StringComparison.OrdinalIgnoreCase))
            {
                if (dgvCustomers.Columns[e.ColumnIndex].Name == "Status")
                {
                    e.CellStyle.BackColor = AppTheme.ActiveRowColor;
                }
            }
        }

        #endregion

        #region StatusStrip, Live Clock & RBAC Permissions

        private void InitStatusStrip()
        {
            if (lblStatusUser != null)
            {
                lblStatusUser.Text = $"User: {AppSession.CurrentFullName} | Role: {AppSession.CurrentRole}";
            }
            UpdateClock();
        }

        private void UpdateClock()
        {
            if (lblStatusTime != null)
            {
                lblStatusTime.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy hh:mm:ss tt");
            }
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void ApplyPermissions()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT PermissionName, IsAllowed 
                                   FROM UserPermissions 
                                   WHERE Role = @Role;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", AppSession.CurrentRole);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string permName = reader.GetString("PermissionName");
                                bool isAllowed = reader.GetBoolean("IsAllowed");

                                switch (permName)
                                {
                                    case "AddCustomer":
                                        if (btnAdd != null) btnAdd.Enabled = isAllowed;
                                        break;
                                    case "EditCustomer":
                                        _canEdit = isAllowed;
                                        break;
                                    case "DeleteCustomer":
                                        if (btnDelete != null) btnDelete.Enabled = isAllowed;
                                        break;
                                    case "Analytics":
                                        if (btnAnalytics != null) btnAnalytics.Enabled = isAllowed;
                                        break;
                                    case "ExportExcel":
                                        if (btnExportExcel != null) btnExportExcel.Enabled = isAllowed;
                                        break;
                                    case "ExportPdf":
                                        if (btnExportPdf != null) btnExportPdf.Enabled = isAllowed;
                                        break;
                                    case "AuditLogs":
                                        if (btnAuditLog != null) btnAuditLog.Enabled = isAllowed;
                                        break;
                                    case "ManagePermissions":
                                        if (btnManagePermissions != null) btnManagePermissions.Enabled = isAllowed;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading permissions:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Data Queries & Grid Setup

        private void LoadCustomers()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT CustomerID, 
                                          FullName, 
                                          Address, 
                                          ContactNumber, 
                                          Email, 
                                          Balance, 
                                          Status 
                                   FROM Customers 
                                   ORDER BY FullName ASC;";

                    using (var adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCustomers.DataSource = dt;

                        if (dgvCustomers.Columns.Count > 0)
                        {
                            if (dgvCustomers.Columns.Contains("CustomerID")) dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
                            if (dgvCustomers.Columns.Contains("FullName")) dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
                            if (dgvCustomers.Columns.Contains("ContactNumber")) dgvCustomers.Columns["ContactNumber"].HeaderText = "Contact No.";
                            if (dgvCustomers.Columns.Contains("Balance")) dgvCustomers.Columns["Balance"].HeaderText = "Balance (₱)";
                            if (dgvCustomers.Columns.Contains("Status")) dgvCustomers.Columns["Status"].HeaderText = "Status";
                        }

                        lblTitle.Text = $"Customer List ({dt.Rows.Count} record(s))";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Step 9.3: Binds the Status DataPropertyName to show each customer's status column.
        /// </summary>
        private void ConfigureDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;

            if (dgvCustomers.Columns.Contains("CustomerID")) dgvCustomers.Columns["CustomerID"].DataPropertyName = "CustomerID";
            if (dgvCustomers.Columns.Contains("FullName")) dgvCustomers.Columns["FullName"].DataPropertyName = "FullName";
            if (dgvCustomers.Columns.Contains("Address")) dgvCustomers.Columns["Address"].DataPropertyName = "Address";
            if (dgvCustomers.Columns.Contains("ContactNumber")) dgvCustomers.Columns["ContactNumber"].DataPropertyName = "ContactNumber";
            if (dgvCustomers.Columns.Contains("Email")) dgvCustomers.Columns["Email"].DataPropertyName = "Email";
            if (dgvCustomers.Columns.Contains("Balance")) dgvCustomers.Columns["Balance"].DataPropertyName = "Balance";
            if (dgvCustomers.Columns.Contains("Status")) dgvCustomers.Columns["Status"].DataPropertyName = "Status";
        }

        private void SearchCustomers(string keyword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT CustomerID, 
                                          FullName, 
                                          Address, 
                                          ContactNumber, 
                                          Email, 
                                          Balance, 
                                          Status 
                                   FROM Customers 
                                   WHERE FullName LIKE @keyword 
                                      OR Address LIKE @keyword 
                                      OR ContactNumber LIKE @keyword 
                                   ORDER BY FullName ASC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvCustomers.DataSource = dt;
                            lblTitle.Text = $"Customer List ({dt.Rows.Count} result(s))";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers:\n{ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers & Actions

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
            LoadCustomers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadCustomers();
            }
            else
            {
                SearchCustomers(keyword);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;

            var idCell = dgvCustomers.CurrentRow.Cells["CustomerID"].Value;
            if (idCell != null && int.TryParse(idCell.ToString(), out int id))
            {
                selectedCustomerId = id;
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_canEdit) return;

            if (e.RowIndex < 0) return;
            OpenEditForm();
        }

        private void OpenEditForm()
        {
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddCustomerForm editForm = new AddCustomerForm(selectedCustomerId);
            editForm.FormClosed += (s, args) => LoadCustomers();
            editForm.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void DeleteCustomer()
        {
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this customer record? This action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID;";

                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                AuditLogger.Log("DELETE_CUSTOMER", $"Customer ID {selectedCustomerId} deleted by {AppSession.CurrentUsername}.");

                                MessageBox.Show("Customer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                selectedCustomerId = 0;
                                LoadCustomers();
                            }
                            else
                            {
                                MessageBox.Show("Delete failed. The record may no longer exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AuditLogger.Log("LOGOUT", $"{AppSession.CurrentUsername} logged out.");

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            AuditLogger.Log("VIEW_ANALYTICS", $"{AppSession.CurrentUsername} opened the Analytics Dashboard.");

            frmAnalytics analyticsForm = new frmAnalytics();
            analyticsForm.ShowDialog(this);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveDialog.FileName = "CustomerList.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Customers");

                        for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dgvCustomers.Columns[col].HeaderText;
                            worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                        }

                        for (int row = 0; row < dgvCustomers.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                            {
                                var cellValue = dgvCustomers.Rows[row].Cells[col].Value;
                                worksheet.Cell(row + 2, col + 1).Value = cellValue?.ToString() ?? "";
                            }
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(saveDialog.FileName);
                    }

                    AuditLogger.Log("EXPORT_EXCEL", $"{AppSession.CurrentUsername} exported customer list to Excel.");

                    MessageBox.Show("Customer list exported successfully to Excel.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to Excel:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF Document (*.pdf)|*.pdf";
                saveDialog.FileName = "CustomerList.pdf";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (PdfDocument document = new PdfDocument())
                    {
                        PdfPage page = document.AddPage();
                        page.Orientation = PdfSharp.PageOrientation.Landscape;

                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        {
                            XFont titleFont = new XFont("Arial", 16, XFontStyleEx.Bold);
                            XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                            XFont cellFont = new XFont("Arial", 9, XFontStyleEx.Regular);

                            gfx.DrawString("Customer List Report", titleFont, XBrushes.Black,
                                new XRect(0, 20, page.Width.Point, 30), XStringFormats.TopCenter);

                            int columnCount = dgvCustomers.Columns.Count;
                            double margin = 30;
                            double tableWidth = page.Width.Point - (margin * 2);
                            double colWidth = tableWidth / columnCount;
                            double rowHeight = 22;
                            double y = 60;

                            double x = margin;
                            for (int col = 0; col < columnCount; col++)
                            {
                                gfx.DrawString(dgvCustomers.Columns[col].HeaderText, headerFont,
                                    XBrushes.Black, new XRect(x, y, colWidth, rowHeight),
                                    XStringFormats.CenterLeft);
                                x += colWidth;
                            }

                            y += rowHeight;
                            gfx.DrawLine(XPens.Black, margin, y, page.Width.Point - margin, y);

                            foreach (DataGridViewRow row in dgvCustomers.Rows)
                            {
                                x = margin;
                                y += rowHeight;

                                if (y > page.Height.Point - margin)
                                {
                                    page = document.AddPage();
                                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                                    gfx.Dispose();
                                    gfx = XGraphics.FromPdfPage(page);
                                    y = 40;
                                }

                                for (int col = 0; col < columnCount; col++)
                                {
                                    string text = row.Cells[col].Value?.ToString() ?? "";
                                    gfx.DrawString(text, cellFont, XBrushes.Black,
                                        new XRect(x, y, colWidth, rowHeight),
                                        XStringFormats.CenterLeft);
                                    x += colWidth;
                                }
                            }
                        }

                        gfx.Dispose();
                        document.Save(saveDialog.FileName);
                    }

                    AuditLogger.Log("EXPORT_PDF", $"{AppSession.CurrentUsername} exported customer list to PDF.");

                    MessageBox.Show("Customer list exported successfully to PDF.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to PDF:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnManagePermissions_Click(object sender, EventArgs e)
        {
            frmManagePermissions permForm = new frmManagePermissions();
            permForm.ShowDialog(this);

            ApplyPermissions();
        }

        private void btnAuditLog_Click(object sender, EventArgs e)
        {
            frmAuditLogs auditForm = new frmAuditLogs();
            auditForm.ShowDialog(this);
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        #endregion

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePasswordForm = new frmChangePassword(1); // Replace 1 with an existing User ID in your database
            changePasswordForm.ShowDialog();
        }

        private void btnViewBilling_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView (dgvCustomers)
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                // Popup 1: No Customer Selected Requirement
                MessageBox.Show("Please select a customer from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution without opening frmBillingHistory
            }

            // Retrieve the CustomerId column value from the selected row
            // Ensure "CustomerId" matches the exact column name in your DataGridView/DataTable
            int selectedCustomerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerId"].Value);

            // Open frmBillingHistory passing the selected CustomerId
            frmBillingHistory billingHistoryForm = new frmBillingHistory(selectedCustomerId);
            billingHistoryForm.ShowDialog();
        }
    }
}