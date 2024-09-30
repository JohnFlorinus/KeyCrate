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
            loadbackupBtn = new Button();
            SuspendLayout();
            // 
            // passwordTxt
            // 
            passwordTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTxt.Location = new Point(12, 40);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PlaceholderText = "Password";
            passwordTxt.Size = new Size(486, 38);
            passwordTxt.TabIndex = 1;
            passwordTxt.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            loginBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.Location = new Point(12, 84);
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
            showPasswordBox.Location = new Point(12, 7);
            showPasswordBox.Name = "showPasswordBox";
            showPasswordBox.Size = new Size(198, 29);
            showPasswordBox.TabIndex = 4;
            showPasswordBox.Text = "Hide Password Input";
            showPasswordBox.UseVisualStyleBackColor = true;
            showPasswordBox.CheckedChanged += showPasswordBox_CheckedChanged;
            // 
            // loadbackupBtn
            // 
            loadbackupBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadbackupBtn.Location = new Point(216, 5);
            loadbackupBtn.Name = "loadbackupBtn";
            loadbackupBtn.Size = new Size(282, 32);
            loadbackupBtn.TabIndex = 5;
            loadbackupBtn.Text = "Load Backup";
            loadbackupBtn.UseVisualStyleBackColor = true;
            loadbackupBtn.Click += loadbackupBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 140);
            Controls.Add(loadbackupBtn);
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
        private Button loadbackupBtn;
    }
}
