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
<<<<<<< HEAD
            btnAnalytics = new Button();
            btnExportExcel = new Button();
            btnExportPdf = new Button();
=======
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(34, 32);
            lblTitle.Name = "lblTitle";

            lblTitle.Size = new Size(161, 31);

            lblTitle.Size = new Size(173, 27);
             77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer List";
            // 
            // btnAdd
            // 

            btnAdd.Location = new Point(178, 380);

            btnAdd.Location = new Point(191, 395);
 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(126, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Customer";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
<<<<<<< HEAD
            btnDelete.Location = new Point(333, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 29);
=======
            btnDelete.Location = new Point(342, 395);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnLogout
            // 
<<<<<<< HEAD
            btnLogout.Location = new Point(483, 380);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(131, 29);
=======
            btnLogout.Location = new Point(459, 395);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(641, 36);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Address, ContactNumber, Email, Balance });
            dgvCustomers.Location = new Point(34, 78);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
<<<<<<< HEAD
            dgvCustomers.Size = new Size(713, 285);
=======
            dgvCustomers.Size = new Size(713, 301);
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
            dgvCustomers.TabIndex = 5;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
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
            txtSearch.Location = new Point(510, 38);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 6;
            // 
<<<<<<< HEAD
            // btnAnalytics
            // 
            btnAnalytics.Location = new Point(178, 412);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Size = new Size(126, 29);
            btnAnalytics.TabIndex = 7;
            btnAnalytics.Text = "Analytics";
            btnAnalytics.UseVisualStyleBackColor = true;
            btnAnalytics.Click += btnAnalytics_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(333, 415);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(130, 29);
            btnExportExcel.TabIndex = 8;
            btnExportExcel.Text = "Export to Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(483, 415);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(131, 29);
            btnExportPdf.TabIndex = 9;
            btnExportPdf.Text = "Export to PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
=======
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
            // CustomerListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
<<<<<<< HEAD
            Controls.Add(btnExportPdf);
            Controls.Add(btnExportExcel);
            Controls.Add(btnAnalytics);
=======
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
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
<<<<<<< HEAD
            Load += CustomerListForm_Load;
            KeyPress += txtSearch_KeyPress;
=======
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
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
<<<<<<< HEAD
        private Button btnAnalytics;
        private Button btnExportExcel;
        private Button btnExportPdf;
=======
>>>>>>> 77bf3cce4d16e11c2fd12bd6dfb06e4377f168bc
    }
}