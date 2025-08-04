
using System.Security.Cryptography;
using System.Text;

public class PasswordHelper
{
    public static void CreatePaswordHash(string Password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));

        }
    }

    public static bool VerifyPassword(string Password, byte[] storedHash, byte[] StoredSalt)
    {
        using (var hmac = new HMACSHA512(StoredSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
            return computedHash.SequenceEqual(storedHash);

        }
    }
}