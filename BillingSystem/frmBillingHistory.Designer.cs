namespace BillingSystem
{
    partial class frmBillingHistory
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
            btnClose = new Button();
            lblCustomerName = new Label();
            dgvBillingHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(873, 362);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(37, 37);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(204, 23);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Billing History - Loading...";
            lblCustomerName.Click += lblCustomerName_Click;
            // 
            // dgvBillingHistory
            // 
            dgvBillingHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillingHistory.Location = new Point(37, 77);
            dgvBillingHistory.Name = "dgvBillingHistory";
            dgvBillingHistory.RowHeadersWidth = 51;
            dgvBillingHistory.Size = new Size(930, 270);
            dgvBillingHistory.TabIndex = 2;
            dgvBillingHistory.CellContentClick += dgvBillingHistory_CellContentClick;
            // 
            // frmBillingHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 417);
            Controls.Add(dgvBillingHistory);
            Controls.Add(lblCustomerName);
            Controls.Add(btnClose);
            Name = "frmBillingHistory";
            Text = "frmBillingHistory";
            Load += frmBillingHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBillingHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Label lblCustomerName;
        private DataGridView dgvBillingHistory;
    }
}