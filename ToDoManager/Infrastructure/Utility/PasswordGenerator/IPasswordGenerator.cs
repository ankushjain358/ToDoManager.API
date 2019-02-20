using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace ToDoManager.Infrastructure
{
    public interface IPasswordGenerator
    {
        string GenerateHashedPassword(string password);

        bool Verify(string savedPasswordHash, string password);
    }
}
