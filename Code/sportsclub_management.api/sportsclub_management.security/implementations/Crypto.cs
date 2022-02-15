using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace sportsclub_management.security.implementations
{
    public class Crypto : ICrypto
    {
        private const string PASSWORD_SECRET_KEY = "B12C00BC210B41AFB59A3E602F202";
        private const string PASSWORD_IV_KEY = "48FBC9198ED647E38CFD1D8CFE731";

        private const string SECRET_KEY = "977CC00194F343C5BE215E561D73A";
        private const string IV_KEY = "D1898755D1514ADEB3A3F1F6CE5A3";

        public string Encrypt(string TextToEncrypt) => Encrypt(TextToEncrypt, SECRET_KEY, IV_KEY);

        public string Decrypt(string TextToDecrypt) => Decrypt(TextToDecrypt, SECRET_KEY, IV_KEY);

        public string EncryptPassword(string TextToEncrypt)
        {
            if (string.IsNullOrEmpty(TextToEncrypt)) return TextToEncrypt;

            return Encrypt(TextToEncrypt, PASSWORD_SECRET_KEY, PASSWORD_IV_KEY);
        }

        public string DecryptPassword(string TextToDecrypt)
        {
            if (string.IsNullOrEmpty(TextToDecrypt)) return TextToDecrypt;

            return Decrypt(TextToDecrypt, PASSWORD_SECRET_KEY, PASSWORD_IV_KEY);
        }

        #region Decrypt given string
        private static string Decrypt(string cipherText, string key, string iv_key)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using Aes encryptor = Aes.Create();

                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key + iv_key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }

                return cipherText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return cipherText;

        }
        #endregion

        #region Encrypt given string
        private static string Encrypt(string clearText, string key, string iv_key)
        {
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using Aes encryptor = Aes.Create();

                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key + iv_key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }

                return clearText;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return clearText;
        }

        #endregion

        public void Dispose()
        {
            // TODO: Is you have any other variables which you need to force dispose you can write here

            GC.SuppressFinalize(this);
        }
    }
}
