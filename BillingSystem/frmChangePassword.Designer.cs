namespace BillingSystem
{
    partial class frmChangePassword
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
            btnSave = new Button();
            lblChangePassword = new Label();
            btnCancel = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtRetypePassword = new TextBox();
            txtNewPassword = new TextBox();
            txtCurrentPassword = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(68, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Password";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblChangePassword
            // 
            lblChangePassword.AutoSize = true;
            lblChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChangePassword.Location = new Point(101, 21);
            lblChangePassword.Name = "lblChangePassword";
            lblChangePassword.Size = new Size(177, 28);
            lblChangePassword.TabIndex = 1;
            lblChangePassword.Text = "Change Password";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(210, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 82);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 3;
            label2.Text = "Current Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 120);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 4;
            label3.Text = "New Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 163);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 5;
            label4.Text = "Retype Password:";
            label4.Click += label4_Click;
            // 
            // txtRetypePassword
            // 
            txtRetypePassword.Location = new Point(172, 163);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.Size = new Size(162, 27);
            txtRetypePassword.TabIndex = 6;
            txtRetypePassword.TextChanged += txtRetypePassword_TextChanged;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(172, 120);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(162, 27);
            txtNewPassword.TabIndex = 7;
            txtNewPassword.TextChanged += txtNewPassword_TextChanged;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(174, 82);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(160, 27);
            txtCurrentPassword.TabIndex = 8;
            txtCurrentPassword.TextChanged += txtCurrentPassword_TextChanged;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 303);
            Controls.Add(txtCurrentPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtRetypePassword);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(lblChangePassword);
            Controls.Add(btnSave);
            Name = "frmChangePassword";
            Text = "frmChangePassword";
            Load += frmChangePassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnSave;
        private Label lblChangePassword;
        private Button btnCancel;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtRetypePassword;
        private TextBox txtNewPassword;
        private TextBox txtCurrentPassword;
        #endregion
    }

}