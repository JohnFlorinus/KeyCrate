namespace KeyCrate.Forms
{
    partial class ChangePasswordForm
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
            crntpasswordTxt = new TextBox();
            newpasswordTxt = new TextBox();
            changepasswordBtn = new Button();
            SuspendLayout();
            // 
            // crntpasswordTxt
            // 
            crntpasswordTxt.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            crntpasswordTxt.Location = new Point(12, 12);
            crntpasswordTxt.Name = "crntpasswordTxt";
            crntpasswordTxt.PlaceholderText = "Current Password";
            crntpasswordTxt.Size = new Size(466, 43);
            crntpasswordTxt.TabIndex = 0;
            crntpasswordTxt.TextChanged += crntpasswordTxt_TextChanged;
            // 
            // newpasswordTxt
            // 
            newpasswordTxt.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newpasswordTxt.Location = new Point(12, 61);
            newpasswordTxt.Name = "newpasswordTxt";
            newpasswordTxt.PlaceholderText = "New Password";
            newpasswordTxt.Size = new Size(466, 43);
            newpasswordTxt.TabIndex = 1;
            // 
            // changepasswordBtn
            // 
            changepasswordBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            changepasswordBtn.Location = new Point(12, 110);
            changepasswordBtn.Name = "changepasswordBtn";
            changepasswordBtn.Size = new Size(466, 60);
            changepasswordBtn.TabIndex = 2;
            changepasswordBtn.Text = "Change Password";
            changepasswordBtn.UseVisualStyleBackColor = true;
            changepasswordBtn.Click += changepasswordBtn_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 177);
            Controls.Add(changepasswordBtn);
            Controls.Add(newpasswordTxt);
            Controls.Add(crntpasswordTxt);
            Name = "ChangePasswordForm";
            Text = "Change KeyCrate Password";
            Load += ChangePasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox crntpasswordTxt;
        private TextBox newpasswordTxt;
        private Button changepasswordBtn;
    }
}