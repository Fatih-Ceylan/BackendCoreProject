namespace Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Aes256
{
    public interface IAes256Service
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}
