using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Chatroom.UseCases.Methods
{
    public class PasswordHashCompare
    {
        public static bool VerifyPassword(string fetchedHashedPassword, string inputPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                

                if (hashedPassword == null) return false;

                return fetchedHashedPassword == hashedPassword;
            }
        }

    }
}
