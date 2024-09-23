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
        managerForm manager = new managerForm();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo;
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\KeyCrate.txt")) // Om användaren inte har skapat en databas än
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
            if (emptyDB) // Om användaren inte har skapat en databas än
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
                // test if the master password the user inputted gives correct decryption
                if (Cryptos.DecryptCredentials(CrateHandler.ReadCrateHeader(false), masterKey, seed)=="correct password")
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

        private void Manager_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
