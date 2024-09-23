namespace KeyCrate
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            passwordTxt = new TextBox();
            loginBtn = new Button();
            showPasswordBox = new CheckBox();
            SuspendLayout();
            // 
            // passwordTxt
            // 
            passwordTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTxt.Location = new Point(12, 12);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PlaceholderText = "Password";
            passwordTxt.Size = new Size(458, 38);
            passwordTxt.TabIndex = 1;
            passwordTxt.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            loginBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.Location = new Point(12, 56);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(486, 55);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Login With Password";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // showPasswordBox
            // 
            showPasswordBox.AutoSize = true;
            showPasswordBox.Checked = true;
            showPasswordBox.CheckState = CheckState.Checked;
            showPasswordBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPasswordBox.Location = new Point(480, 23);
            showPasswordBox.Name = "showPasswordBox";
            showPasswordBox.Size = new Size(18, 17);
            showPasswordBox.TabIndex = 4;
            showPasswordBox.UseVisualStyleBackColor = true;
            showPasswordBox.CheckedChanged += showPasswordBox_CheckedChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 116);
            Controls.Add(showPasswordBox);
            Controls.Add(loginBtn);
            Controls.Add(passwordTxt);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KeyCrate Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox passwordTxt;
        private Button loginBtn;
        private CheckBox showPasswordBox;
    }
}
