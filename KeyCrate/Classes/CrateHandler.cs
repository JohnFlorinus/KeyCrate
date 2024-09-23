using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyCrate.Classes
{
    public class CrateHandler
    {
        // Läs endast den första linjen av CSV databasen som innehåller det unika seed och lösenordtestet
        public static string ReadCrateHeader(bool getSeed)
        {
            using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\KeyCrate.txt")) 
            {
                if (getSeed) // få salt&IV
                {
                    return sr.ReadLine().Split(",").First();
                }
                else // få lösenordstestet
                {
                    return sr.ReadLine().Split(",").Last();
                }
            }
        }

        // Läs av de sparade kontouppgifterna från CSV databas och avkryptera dom
        public static List<string> ReadCrateContents()
        {
            List<string> encryptedCredentialsList = new List<string>();
            List<string> decryptedCredentialsList = new List<string>();
            bool pastHeader = false;
            using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\KeyCrate.txt"))
            {
                while (!sr.EndOfStream)
                {
                    // ignorera första linjen (seed och krypteringstest)
                    if (!pastHeader)
                    {
                        pastHeader = true;
                        sr.ReadLine();
                    }
                    else
                    {
                        encryptedCredentialsList.Add(sr.ReadLine());
                    }
                }
            }
            // avkryptera kontouppgifterna
            foreach (string encryptedEntry in encryptedCredentialsList)
            {
                string[] splitEncryptedEntry = encryptedEntry.Split(",");
                for (int i=0; i< splitEncryptedEntry.Length; i++)
                {
                    splitEncryptedEntry[i] = Cryptos.DecryptCredentials(splitEncryptedEntry[i], Cryptos.StoredKey, Cryptos.StoredSeed);
                }
                decryptedCredentialsList.Add(String.Join(",", splitEncryptedEntry));
            }
            return decryptedCredentialsList;
        }

        // Skapa ny CSV databas med seed och master password test
        public static bool CreateCrate(string crateseed, string masterTest)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\KeyCrate.txt", false))
                {
                    sw.WriteLine(crateseed + "," + masterTest);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"KeyCrate was unable to create a database file.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return false;
            }
        }

        // Kryptera angivna kontouppgifter och lägg till i CSV databas
        public static bool AddToCrate(string site, string username, string password)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\KeyCrate.txt", true))
                {
                    sw.WriteLine($"{Cryptos.EncryptCredentials(site, Cryptos.StoredKey, Cryptos.StoredSeed)}" +
                        $",{Cryptos.EncryptCredentials(username, Cryptos.StoredKey, Cryptos.StoredSeed)}" +
                        $",{Cryptos.EncryptCredentials(password, Cryptos.StoredKey, Cryptos.StoredSeed)}");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"KeyCrate was unable to add a new entry to the database file.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return false;
            }
        }
    }
}
