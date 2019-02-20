using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace ToDoManager.Infrastructure
{
    public class PBKDF2PasswordGenerator : IPasswordGenerator
    {
        public string GenerateHashedPassword(string password)
        {
            string savedPasswordHash = string.Empty;

            if (!string.IsNullOrWhiteSpace(password))
            {
                // Create the salt value with a cryptographic PRNG:
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                // Create the Rfc2898DeriveBytes and get the hash value:
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                // Combine the salt and password bytes for later use:
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                // Turn the combined salt+hash into a string for storage
                savedPasswordHash = Convert.ToBase64String(hashBytes);
            }
            return savedPasswordHash;
        }

        public bool Verify(string savedPasswordHash, string password)
        {
            
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
//Code reference: https://stackoverflow.com/a/10402129/1273882
