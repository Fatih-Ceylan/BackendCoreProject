namespace Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Sha256
{
    public interface ISha256Service
    {
        string PasswordEncrypt(string password);

        string GenerateUniqueCode();

        string HashPassword(string password);

        bool VerifyPassword(string enteredPassword, string storedHash);

    }
}
