using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SkinCareDAO.Utils
{
    public static class MyUtils
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("YourSecretKey32Characters1234567890"); // 32-byte key, change it to your own key
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("YourSecretIV16Characters1234567890"); // 16-byte IV, change it to your own IV

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                }
            }
        }