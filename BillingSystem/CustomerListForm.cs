using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
<<<<<<< HEAD
using ClosedXML.Excel;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;




=======
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc

namespace BillingSystem
{
    public partial class CustomerListForm : Form
    {
        // Stores the CustomerID of the currently selected row.
        // 0 means no customer is currently selected.
        private int selectedCustomerId = 0;

        public CustomerListForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

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
                            dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
                            dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
                            dgvCustomers.Columns["ContactNumber"].HeaderText = "Contact No.";
                            dgvCustomers.Columns["Balance"].HeaderText = "Balance (₱)";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
            LoadCustomers(); // Refreshes the list when returning from adding a customer
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
            // If no row is selected (e.g., grid is empty), do nothing
            if (dgvCustomers.CurrentRow == null) return;

            // Read the CustomerID value from the selected row
            var idCell = dgvCustomers.CurrentRow.Cells["CustomerID"].Value;
            if (idCell != null && int.TryParse(idCell.ToString(), out int id))
            {
                selectedCustomerId = id;
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex is -1 when the header row is double-clicked — ignore it
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

            // Open AddCustomerForm in EDIT mode, passing the selected CustomerID
            AddCustomerForm editForm = new AddCustomerForm(selectedCustomerId);

            // Refresh the grid automatically once the edit form closes
            editForm.FormClosed += (s, args) => LoadCustomers();
            editForm.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void DeleteCustomer()
        {
            // 1. Ensure a customer is actually selected
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Prompt for user confirmation to prevent accidental deletion
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

                        // Parameterized DELETE statement - safe from SQL injection
                        string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID;";

                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Customer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Reset selection and refresh the grid
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

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Connected to the designer button event — now calls DeleteCustomer()
            DeleteCustomer();
        }
<<<<<<< HEAD

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            frmAnalytics analyticsForm = new frmAnalytics();
            analyticsForm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Make sure there is something to export
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.",
                    "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Let the user choose where to save the file
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

                        // Write column headers in row 1
                        for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dgvCustomers.Columns[col].HeaderText;
                            worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                        }

                        // Write each data row starting from row 2
                        for (int row = 0; row < dgvCustomers.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                            {
                                var cellValue = dgvCustomers.Rows[row].Cells[col].Value;
                                worksheet.Cell(row + 2, col + 1).Value = cellValue?.ToString() ?? "";
                            }
                        }

                        // Auto-adjust column widths to fit the content
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveDialog.FileName);
                    }

                    MessageBox.Show("Customer list exported successfully to Excel.",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to Excel:\n{ex.Message}",
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            // Make sure there is something to export
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.",
                    "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        // Create a new page set to Landscape orientation
                        PdfPage page = document.AddPage();
                        page.Orientation = PdfSharp.PageOrientation.Landscape;

                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        {
                            XFont titleFont = new XFont("Arial", 16, XFontStyleEx.Bold);
                            XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                            XFont cellFont = new XFont("Arial", 9, XFontStyleEx.Regular);

                            // Title
                            gfx.DrawString("Customer List Report", titleFont, XBrushes.Black,
                                new XRect(0, 20, page.Width.Point, 30), XStringFormats.TopCenter);

                            int columnCount = dgvCustomers.Columns.Count;
                            double margin = 30;
                            double tableWidth = page.Width.Point - (margin * 2);
                            double colWidth = tableWidth / columnCount;
                            double rowHeight = 22;
                            double y = 60;

                            // Draw column headers
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

                            // Draw each data row
                            foreach (DataGridViewRow row in dgvCustomers.Rows)
                            {
                                x = margin;
                                y += rowHeight;

                                // Start a new page if we run out of vertical space
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

                        gfx.Dispose();   // finish drawing before saving
                        document.Save(saveDialog.FileName);
                    }

                    MessageBox.Show("Customer list exported successfully to PDF.",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to PDF:\n{ex.Message}",
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


=======
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
    }
}