using KeyCrate.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyCrate.Forms
{
    public partial class managerForm : Form
    {
        public managerForm()
        {
            InitializeComponent();
        }

        List<string> credentialsViewList = new List<string>();
        private void managerForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo;
            AddListToCredentialsView(CrateHandler.ReadCrateContents());
        }

        private void addcredentialsBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(siteTxt.Text) || String.IsNullOrEmpty(usernameTxt.Text) || String.IsNullOrEmpty(passwordTxt.Text))
            {
                MessageBox.Show($"You have to fill all three textboxes to add a new account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CrateHandler.AddToCrate(siteTxt.Text, usernameTxt.Text, passwordTxt.Text))
                {
                    AddListToCredentialsView(CrateHandler.ReadCrateContents());
                    MessageBox.Show($"Password for {usernameTxt.Text} on {siteTxt.Text} has been added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AddListToCredentialsView(List<string> input)
        {
            credentialsView.Items.Clear();
            credentialsViewList.Clear();
            foreach (string s in input)
            {
                string[] values = s.Split(",");
                credentialsView.Items.Add($"{values[0]} : {values[1]}");
                credentialsViewList.Add(s);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void deletecredentialsBtn_Click(object sender, EventArgs e)
        {
            if (credentialsView.SelectedIndex != -1)
            {
                CrateHandler.CreateCrate(Convert.ToBase64String(Cryptos.StoredSeed), Cryptos.EncryptCredentials("correct password", Cryptos.StoredKey, Cryptos.StoredSeed));
                for (int i = 0; i < credentialsViewList.Count; i++)
                {
                    if (i != credentialsView.SelectedIndex)
                    {
                        string[] values = credentialsViewList[i].Split(",");
                        CrateHandler.AddToCrate(values[0], values[1], values[2]);
                    }
                }
                AddListToCredentialsView(CrateHandler.ReadCrateContents());
                MessageBox.Show($"The account credentials have been deleted", "Deleted Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updatecredentialsBtn_Click(object sender, EventArgs e)
        {
            if (credentialsView.SelectedIndex != -1)
            {
                if (String.IsNullOrEmpty(siteTxt.Text) || String.IsNullOrEmpty(usernameTxt.Text) || String.IsNullOrEmpty(passwordTxt.Text))
                {
                    MessageBox.Show($"You have to fill all three textboxes to update the account details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CrateHandler.CreateCrate(Convert.ToBase64String(Cryptos.StoredSeed), Cryptos.EncryptCredentials("correct password", Cryptos.StoredKey, Cryptos.StoredSeed));
                    for (int i = 0; i < credentialsViewList.Count; i++)
                    {
                        if (i != credentialsView.SelectedIndex)
                        {
                            string[] values = credentialsViewList[i].Split(",");
                            CrateHandler.AddToCrate(values[0], values[1], values[2]);
                        }
                        else
                        {
                            // Om det är den valda entry, lägg till uppgifterna i textbox fälten istället. Uppdatering sker
                            CrateHandler.AddToCrate(siteTxt.Text, usernameTxt.Text, passwordTxt.Text);
                        }
                    }
                    AddListToCredentialsView(CrateHandler.ReadCrateContents());
                    MessageBox.Show($"The account credentials have been updated", "Updated Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void credentialsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (credentialsView.SelectedIndex != -1)
            {
                string[] values = credentialsViewList[credentialsView.SelectedIndex].Split(",");
                siteTxt.Text = values[0];
                usernameTxt.Text = values[1];
                passwordTxt.Text = values[2];
            }
        }

        private void changeMasterPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog();
        }
    }
}