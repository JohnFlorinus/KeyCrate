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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo;
            this.ActiveControl = changepasswordBtn; // ta bort autofokuset från TextBox kontrollen för att visa placeholder.
        }

        private void crntpasswordTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void changepasswordBtn_Click(object sender, EventArgs e)
        {
            byte[] crntpasswordinput = Cryptos.GetMasterKey(crntpasswordTxt.Text, Cryptos.StoredSeed, 1000000);
            // om det nuvarande lösenordet textfield är korrekt
            if (Cryptos.DecryptCredentials(CrateHandler.ReadCrateHeader(false), crntpasswordinput, Cryptos.StoredSeed) == "correct password")
            {
                if (MessageBox.Show("Your new master password will be irrecoverable if you lose it.\nAre you sure that you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    // Läs igenom gamla krypterade CSV databasen
                    List<string> oldDB = CrateHandler.ReadCrateContents();
                    // Skapa randomiserad salt och IV - IV behöver vara 128 bits därav 16 bytes
                    byte[] seed = Cryptos.GetRandomSeed(16);
                    // skapa krypteringsnyckel med en miljon iterationer via PBKDF2 med SHA512 och seed som salt
                    byte[] masterKey = Cryptos.GetMasterKey(newpasswordTxt.Text, seed, 1000000);
                    // Skapa ny databas fil med de nya headers
                    CrateHandler.CreateCrate(Convert.ToBase64String(seed), Cryptos.EncryptCredentials("correct password", masterKey, seed));
                    // byt ut seed och masterkey i minnet till den nya
                    Cryptos.StoredSeed = seed;
                    Cryptos.StoredKey = masterKey;
                    // Skapa ny krypterad databas
                    foreach (string dbItem in oldDB)
                    {
                        string[] values = dbItem.Split(",");
                        CrateHandler.AddToCrate(values[0], values[1], values[2]);
                    }
                    MessageBox.Show("You have successfully changed your password!\n\nThe program will now close. You may login with your new password.", "New Password Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("You typed the wrong current password", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
