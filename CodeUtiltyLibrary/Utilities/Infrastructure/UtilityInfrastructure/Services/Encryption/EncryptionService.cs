using System.Security.Cryptography;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Aes256;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.Encryption
{
    public class aes256Service : IAes256Service
    {
        private readonly string Key = "ODm9CM1K5jmOCosk+jmMhdb43UGt9D+je1uy1WELT5Y="; // 256 bit Base64 Key
        private readonly string IV = "iiezgqluPKHQCmQ6xiVlqg=="; // 128 bit Base64 IV

        public string Encrypt(string plainText)
        {
            try
            {
                using (var aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(Key);
                    aesAlg.IV = Convert.FromBase64String(IV);
                    aesAlg.Padding = PaddingMode.PKCS7;

                    var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        var encrypted = msEncrypt.ToArray();

                        return Convert.ToBase64String(encrypted);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Encryption failed.", ex);
            }
        }

        public string Decrypt(string cipherText)
        {
            try
            {
                using (var aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(Key);
                    aesAlg.IV = Convert.FromBase64String(IV);
                    aesAlg.Padding = PaddingMode.PKCS7;

                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    using (var msDecrypt = new MemoryStream(cipherBytes))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Decryption failed.", ex);
            }
        }
    }
}
