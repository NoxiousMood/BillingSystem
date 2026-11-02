namespace BillingSystem
{
    partial class frmAuditLogs
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
            lblFrom = new Label();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            btnClose = new Button();
            dgvAuditLogs = new DataGridView();
            btnSearch = new Button();
            btnAuditLog = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("SF Pro Display", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(198, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Audit Log Report";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("SF Pro Display", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFrom.Location = new Point(30, 93);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(47, 18);
            lblFrom.TabIndex = 1;
            lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI Variable Text Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTo.Location = new Point(421, 91);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(29, 20);
            lblTo.TabIndex = 2;
            lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(456, 86);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(238, 27);
            dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(92, 86);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(241, 27);
            dtpFrom.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(760, 462);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvAuditLogs
            // 
            dgvAuditLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLogs.Location = new Point(30, 141);
            dgvAuditLogs.Name = "dgvAuditLogs";
            dgvAuditLogs.RowHeadersWidth = 51;
            dgvAuditLogs.Size = new Size(805, 294);
            dgvAuditLogs.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(736, 87);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(99, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAuditLog
            // 
            btnAuditLog.BackColor = SystemColors.GradientActiveCaption;
            btnAuditLog.FlatStyle = FlatStyle.Flat;
            btnAuditLog.Font = new Font("SF Pro Display", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAuditLog.ForeColor = SystemColors.ActiveCaptionText;
            btnAuditLog.Location = new Point(604, 460);
            btnAuditLog.Name = "btnAuditLog";
            btnAuditLog.Size = new Size(94, 29);
            btnAuditLog.TabIndex = 8;
            btnAuditLog.Text = "Audit Logs";
            btnAuditLog.UseVisualStyleBackColor = false;
            btnAuditLog.Click += btnAuditLog_Click;
            // 
            // frmAuditLogs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 503);
            Controls.Add(btnAuditLog);
            Controls.Add(btnSearch);
            Controls.Add(dgvAuditLogs);
            Controls.Add(btnClose);
            Controls.Add(dtpFrom);
            Controls.Add(dtpTo);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(lblTitle);
            Name = "frmAuditLogs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Audit Log Report";
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Button btnClose;
        private DataGridView dgvAuditLogs;
        private Button btnSearch;
        private Button btnAuditLog;
    }
}