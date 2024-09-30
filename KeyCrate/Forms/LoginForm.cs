using System.Diagnostics;
using System.Drawing;
using System.Text;
using KeyCrate.Classes;
using KeyCrate.Forms;

namespace KeyCrate
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        bool emptyDB = false;
        bool backupLoaded = false;
        string backupPath = string.Empty;
        managerForm manager = new managerForm();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo;
            // Sätt den automatiska crate path
            CrateHandler.CratePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\KeyCrate.txt";
            if (!File.Exists(CrateHandler.CratePath)) // Om användaren inte har skapat en databas än
            {
                loginBtn.Text = "Create Master Password";
                emptyDB = true;
            }
            this.ActiveControl = loginBtn; // ta bort autofokuset från TextBox kontrollen för att visa placeholder.
            manager.FormClosed += Manager_FormClosed; // När passwordmanager formen stängs så stängs den gömda inloggningsformen
        }

        private void showPasswordBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordBox.Checked)
            {
                passwordTxt.UseSystemPasswordChar = true;
            }
            else
            {
                passwordTxt.UseSystemPasswordChar = false;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (backupLoaded)
                {
                    CrateHandler.CratePath = backupPath;
                    byte[] seed = Convert.FromBase64String(CrateHandler.ReadCrateHeader(true));
                    byte[] masterKey = Cryptos.GetMasterKey(passwordTxt.Text, seed, 1000000);
                    // testa om angivna lösenordet är korrekt
                    if (Cryptos.DecryptCredentials(CrateHandler.ReadCrateHeader(false), masterKey, seed) == "correct password")
                    {
                        // behåll avkrypteringsnyckel och seed i minnet för password managern
                        Cryptos.StoredKey = masterKey;
                        Cryptos.StoredSeed = seed;
                        this.Hide();
                        manager.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong!", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (emptyDB) // Om användaren inte har skapat en databas än
                {
                    if (MessageBox.Show("Your master password will be irrecoverable if you lose it.\nAre you sure that you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        // Skapa randomiserad salt och IV - IV behöver vara 128 bits därav 16 bytes
                        byte[] seed = Cryptos.GetRandomSeed(16);
                        // skapa krypteringsnyckel med en miljon iterationer via PBKDF2 med SHA512 och seed som salt
                        byte[] masterKey = Cryptos.GetMasterKey(passwordTxt.Text, seed, 1000000);
                        // spara seed och en decryption key test
                        if (CrateHandler.CreateCrate(Convert.ToBase64String(seed), Cryptos.EncryptCredentials("correct password", masterKey, seed)))
                        {
                            // behåll avkrypteringsnyckel och seed i minnet för password managern
                            Cryptos.StoredKey = masterKey;
                            Cryptos.StoredSeed = seed;
                            // Göm inloggningsform och visa password manager
                            this.Hide();
                            manager.Show();
                        }
                    }
                }
                else
                {
                    byte[] seed = Convert.FromBase64String(CrateHandler.ReadCrateHeader(true));
                    byte[] masterKey = Cryptos.GetMasterKey(passwordTxt.Text, seed, 1000000);
                    // testa om angivna lösenordet är korrekt
                    if (Cryptos.DecryptCredentials(CrateHandler.ReadCrateHeader(false), masterKey, seed) == "correct password")
                    {
                        // behåll avkrypteringsnyckel och seed i minnet för password managern
                        Cryptos.StoredKey = masterKey;
                        Cryptos.StoredSeed = seed;
                        this.Hide();
                        manager.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong!", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to enter the password manager\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Manager_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void loadbackupBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "TXT Files (*.txt) | *.txt";
                fd.RestoreDirectory = true;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(fd.FileName))
                    {
                        backupPath = fd.FileName;
                        backupLoaded = true;
                        MessageBox.Show($"Backup File is loaded, enter the password for the file to display the credentials.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load backup file.\n\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
