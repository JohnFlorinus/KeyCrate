using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security;

namespace KeyCrate.Classes
{
    public class Cryptos
    {
        // Store decryption key and seed after login for password manager
        public static byte[] StoredKey { get; set; }
        public static byte[] StoredSeed { get; set; }

        // AES-256 nyckelgeneration via pbkdf2 med sha512
        public static byte[] GetMasterKey(string password, byte[] salt, int iterations)
        {
            int keySize = 32; // 32 bytes = 256 bits
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, salt, iterations, HashAlgorithmName.SHA512))
            {
                return pbkdf2.GetBytes(keySize);
            }
        }

        // randomiserad salt och iv generation
        public static byte[] GetRandomSeed(int size)
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[size];
                rng.GetBytes(bytes);
                return bytes;
            }
        }

        // AES-256 kryptering
        public static string EncryptCredentials(string input, byte[] key, byte[] IV)
        {
            using (Aes aes = Aes.Create())
            {
                using (var encryptor = aes.CreateEncryptor(key, IV))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cs))
                            {
                                sw.Write(input);
                            }
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        // AES-256 dekryptering
        public static string DecryptCredentials(string input, byte[] key, byte[] IV)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    using (var decryptor = aes.CreateDecryptor(key, IV))
                    {
                        using (var ms = new MemoryStream(Convert.FromBase64String(input)))
                        {
                            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                            {
                                using (var sr = new StreamReader(cs))
                                {
                                    return sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return "unable to decrypt";
            }
        }
    }
}
