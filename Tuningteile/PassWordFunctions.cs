using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Tuningteile
{
    public static class PassWordFunctions
    {
        //create hash
        public static string GetHasch(string Password, byte[] salt)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 100,
                    numBytesRequested: 256 /8
                    )
                );
        }

        //get salt from Base64 string
        public static byte[] GetByteArrayFomString(string input)
        {
            return Convert.FromBase64String(input);
        }

        //get string from byte array
        public static string GetStringfromByteArray(byte[] array)
        {
            return Convert.ToBase64String(array);
        }

        //generate salt
        public static byte[] GetSalt()
        {
            //generate 128 Bit alt using PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        //check if the hashes are the same
        public static bool VerifyHash(string dbHash, string UserHash)
        {
            if (dbHash.Equals(UserHash) == true)
                return true;
            else
                return false;
        }
    }
}
