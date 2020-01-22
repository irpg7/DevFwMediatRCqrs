using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (HMACSHA256 hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA256(passwordSalt))
            {
                var computedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedPassword.Length; i++)
                {
                    if (passwordHash[i] != computedPassword[i])
                        return false;
                }
            }
            return true;
        }
    }
}
