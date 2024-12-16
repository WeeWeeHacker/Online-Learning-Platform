using BCrypt.Net;
using Microsoft.CodeAnalysis.Scripting;

namespace CacheClass.Models
{
    public static class PasswordHelper
    {
        
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "Password cannot be null or empty.");
            }
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }
        
        

        // Verify if the provided password matches the stored hashed password
        public static bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            // Use the built-in BCrypt verification method
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}
