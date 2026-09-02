namespace BillingSystem
{
    partial class CustomerListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnLogout = new Button();
            btnSearch = new Button();
            dgvCustomers = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            ContactNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Balance = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(34, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(161, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer List";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(191, 375);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(126, 28);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Customer";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(342, 375);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 28);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(459, 375);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 28);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(641, 34);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 28);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Address, ContactNumber, Email, Balance });
            dgvCustomers.Location = new Point(34, 74);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(713, 286);
            dgvCustomers.TabIndex = 5;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // CustomerID
            // 
            CustomerID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            CustomerID.Frozen = true;
            CustomerID.HeaderText = "ID";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.ReadOnly = true;
            CustomerID.Width = 125;
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            FullName.HeaderText = "Full Name";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            FullName.Width = 108;
            // 
            // Address
            // 
            Address.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Address.HeaderText = "Address";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.ReadOnly = true;
            Address.Width = 108;
            // 
            // ContactNumber
            // 
            ContactNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ContactNumber.HeaderText = "Contact No.";
            ContactNumber.MinimumWidth = 6;
            ContactNumber.Name = "ContactNumber";
            ContactNumber.ReadOnly = true;
            ContactNumber.Width = 107;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 108;
            // 
            // Balance
            // 
            Balance.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Balance.HeaderText = "Balance";
            Balance.MinimumWidth = 6;
            Balance.Name = "Balance";
            Balance.ReadOnly = true;
            Balance.Width = 108;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(510, 36);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 26);
            txtSearch.TabIndex = 6;
            // 
            // CustomerListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 430);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomers);
            Controls.Add(btnSearch);
            Controls.Add(btnLogout);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lblTitle);
            Name = "CustomerListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System - Customer List (Z.G)";
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnLogout;
        private Button btnSearch;
        private DataGridView dgvCustomers;
        private TextBox txtSearch;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ContactNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Balance;
    }
}