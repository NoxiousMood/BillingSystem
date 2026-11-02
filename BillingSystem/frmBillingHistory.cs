using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;

namespace BillingSystem
{
    public partial class frmBillingHistory : Form
    {
        private int customerId;

        public frmBillingHistory(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void frmBillingHistory_Load(object sender, EventArgs e)
        {
            // 1. Fetch Customer Name
            string customerName = GetCustomerFullName(customerId);
            lblCustomerName.Text = "Billing History - " + customerName;

            // 2. Load Records
            LoadBillingRecords(customerId);
        }

        private string GetCustomerFullName(int id)
        {
            string fullName = "Unknown Customer";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Query matched to Customers table primary key CustomerID
                    string query = "SELECT FullName FROM customers WHERE CustomerID = @CustomerId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            fullName = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting customer name: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return fullName;
        }

        private void LoadBillingRecords(int id)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Query matched to billing table column names (CustomerID, BillingID)
                    string query = @"SELECT 
                                        BillingMonth AS 'Billing Month',
                                        PreviousReading AS 'Previous Reading',
                                        PresentReading AS 'Present Reading',
                                        Consumption,
                                        RatePerCubic AS 'Rate Per Cubic',
                                        TotalAmount AS 'Total Amount',
                                        Status 
                                     FROM billing 
                                     WHERE CustomerID = @CustomerId 
                                     ORDER BY BillingID DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading billing records: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Bind Data to DataGridView
            dgvBillingHistory.AutoGenerateColumns = true;
            dgvBillingHistory.DataSource = dt;

            // Show Popup 2 if customer has no billing records
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No billing records were found for this customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBillingHistory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblCustomerName_Click(object sender, EventArgs e) { }
    }
}