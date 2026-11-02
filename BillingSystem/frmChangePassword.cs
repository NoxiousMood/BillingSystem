using System;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        private int loggedInUserId;

        public frmChangePassword(int userId)
        {
            InitializeComponent();
            this.loggedInUserId = userId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string retypePassword = txtRetypePassword.Text;

            // 1. Check for empty fields
            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(retypePassword))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Current Password Database Verification
            if (!VerifyCurrentPassword(loggedInUserId, currentPassword))
            {
                MessageBox.Show("Current password is incorrect.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Focus();
                return;
            }

            // 3. Password Match Check
            if (newPassword != retypePassword)
            {
                MessageBox.Show("New Password and Retype Password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetypePassword.Focus();
                return;
            }

            // 4. Password Complexity Verification
            if (!ValidatePasswordComplexity(newPassword, out string complexityErrorMessage))
            {
                MessageBox.Show(complexityErrorMessage, "Password Complexity Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // 5. Parameterized Update Execution
            if (UpdatePasswordInDatabase(loggedInUserId, newPassword))
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occurred while updating the password.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePasswordComplexity(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (password.Length < 8)
            {
                errorMessage = "New password must be at least 8 characters long.";
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                errorMessage = "New password must contain at least one uppercase letter (A-Z).";
                return false;
            }
            if (!password.Any(char.IsLower))
            {
                errorMessage = "New password must contain at least one lowercase letter (a-z).";
                return false;
            }
            if (!password.Any(char.IsDigit))
            {
                errorMessage = "New password must contain at least one numeric digit (0-9).";
                return false;
            }
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errorMessage = "New password must contain at least one special character (e.g., !@#$%^&*).";
                return false;
            }

            return true;
        }

        private bool VerifyCurrentPassword(int userId, string inputPassword)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Password FROM Users WHERE UserId = @UserId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string dbPassword = result.ToString();
                        return dbPassword == inputPassword;
                    }
                }
            }
            return false;
        }

        private bool UpdatePasswordInDatabase(int userId, string newPassword)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET Password = @NewPassword WHERE UserId = @UserId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e) { }
        private void txtNewPassword_TextChanged(object sender, EventArgs e) { }
        private void txtRetypePassword_TextChanged(object sender, EventArgs e) { }
        private void txtCurrentPassword_TextChanged(object sender, EventArgs e) { }
        private void frmChangePassword_Load(object sender, EventArgs e) { }
    }
}