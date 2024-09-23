namespace KeyCrate.Forms
{
    partial class managerForm
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
            topviewMenu = new MenuStrip();
            changeMasterPasswordToolStripMenuItem = new ToolStripMenuItem();
            siteTxt = new TextBox();
            usernameTxt = new TextBox();
            passwordTxt = new TextBox();
            addcredentialsBtn = new Button();
            panel1 = new Panel();
            updatecredentialsBtn = new Button();
            deletecredentialsBtn = new Button();
            credentialsView = new ListBox();
            topviewMenu.SuspendLayout();
            SuspendLayout();
            // 
            // topviewMenu
            // 
            topviewMenu.ImageScalingSize = new Size(20, 20);
            topviewMenu.Items.AddRange(new ToolStripItem[] { changeMasterPasswordToolStripMenuItem });
            topviewMenu.Location = new Point(0, 0);
            topviewMenu.Name = "topviewMenu";
            topviewMenu.Size = new Size(700, 28);
            topviewMenu.TabIndex = 0;
            topviewMenu.Text = "menuStrip1";
            // 
            // changeMasterPasswordToolStripMenuItem
            // 
            changeMasterPasswordToolStripMenuItem.Name = "changeMasterPasswordToolStripMenuItem";
            changeMasterPasswordToolStripMenuItem.Size = new Size(187, 24);
            changeMasterPasswordToolStripMenuItem.Text = "Change Master Password";
            changeMasterPasswordToolStripMenuItem.Click += changeMasterPasswordToolStripMenuItem_Click;
            // 
            // siteTxt
            // 
            siteTxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            siteTxt.Location = new Point(12, 328);
            siteTxt.Name = "siteTxt";
            siteTxt.PlaceholderText = "Site";
            siteTxt.Size = new Size(333, 34);
            siteTxt.TabIndex = 2;
            // 
            // usernameTxt
            // 
            usernameTxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTxt.Location = new Point(12, 368);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.PlaceholderText = "Username";
            usernameTxt.Size = new Size(333, 34);
            usernameTxt.TabIndex = 4;
            // 
            // passwordTxt
            // 
            passwordTxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTxt.Location = new Point(12, 408);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PlaceholderText = "Password";
            passwordTxt.Size = new Size(333, 34);
            passwordTxt.TabIndex = 5;
            // 
            // addcredentialsBtn
            // 
            addcredentialsBtn.Location = new Point(0, 448);
            addcredentialsBtn.Name = "addcredentialsBtn";
            addcredentialsBtn.Size = new Size(345, 34);
            addcredentialsBtn.TabIndex = 6;
            addcredentialsBtn.Text = "Add New Account";
            addcredentialsBtn.UseVisualStyleBackColor = true;
            addcredentialsBtn.Click += addcredentialsBtn_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(351, 315);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 228);
            panel1.TabIndex = 7;
            // 
            // updatecredentialsBtn
            // 
            updatecredentialsBtn.Location = new Point(383, 355);
            updatecredentialsBtn.Name = "updatecredentialsBtn";
            updatecredentialsBtn.Size = new Size(282, 47);
            updatecredentialsBtn.TabIndex = 8;
            updatecredentialsBtn.Text = "Update Selected Account";
            updatecredentialsBtn.UseVisualStyleBackColor = true;
            updatecredentialsBtn.Click += updatecredentialsBtn_Click;
            // 
            // deletecredentialsBtn
            // 
            deletecredentialsBtn.Location = new Point(383, 408);
            deletecredentialsBtn.Name = "deletecredentialsBtn";
            deletecredentialsBtn.Size = new Size(282, 47);
            deletecredentialsBtn.TabIndex = 9;
            deletecredentialsBtn.Text = "Delete Selected Account";
            deletecredentialsBtn.UseVisualStyleBackColor = true;
            deletecredentialsBtn.Click += deletecredentialsBtn_Click;
            // 
            // credentialsView
            // 
            credentialsView.FormattingEnabled = true;
            credentialsView.Location = new Point(0, 31);
            credentialsView.Name = "credentialsView";
            credentialsView.Size = new Size(700, 284);
            credentialsView.TabIndex = 10;
            credentialsView.SelectedIndexChanged += credentialsView_SelectedIndexChanged;
            // 
            // managerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 494);
            Controls.Add(credentialsView);
            Controls.Add(deletecredentialsBtn);
            Controls.Add(updatecredentialsBtn);
            Controls.Add(panel1);
            Controls.Add(addcredentialsBtn);
            Controls.Add(passwordTxt);
            Controls.Add(usernameTxt);
            Controls.Add(siteTxt);
            Controls.Add(topviewMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = topviewMenu;
            MaximizeBox = false;
            Name = "managerForm";
            Text = "KeyCrate Password Manager";
            Load += managerForm_Load;
            topviewMenu.ResumeLayout(false);
            topviewMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip topviewMenu;
        private TextBox siteTxt;
        private TextBox usernameTxt;
        private TextBox passwordTxt;
        private Button addcredentialsBtn;
        private Panel panel1;
        private Button updatecredentialsBtn;
        private ToolStripMenuItem changeMasterPasswordToolStripMenuItem;
        private Button deletecredentialsBtn;
        private ListBox credentialsView;
    }
}