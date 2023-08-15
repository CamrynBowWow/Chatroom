using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Chatroom.UseCases.Methods
{
    public class PasswordHashCreate
    {
        // SHA-256 is considered a strong cryptographic hash function
        using (SHA256 sha256 = SHA256.Create())
        {
            // The Encoding.UTF8.GetBytes() method takes a string and converts it into a byte array
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            // The ComputeHash() method takes a byte array as input and returns the hash value as a byte array. 
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            // BitConverter.ToString() method is used to convert each byte in the array into a two - character hexadecimal string,
            // and the resulting strings are concatenated with a hyphen(-) separator.
            string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hashedPassword;
        }
    }
}
