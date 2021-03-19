using System;
using System.Linq;

namespace Encryption.Caesar
{
    public class Cipher
    {
        public static string Encrypt(string input, int shift)
        {
            var result = input.ToCharArray()
                .Select(c => ShiftCharachter(c, shift))
                .ToArray();

            return new string(result);
        }

        public static string Decrypt(string input, int shift)
        {
            return Encrypt(input, -1 * shift);
        }

        private static char ShiftCharachter(char c, int shift)
        {
            shift %= 26;

            if (!char.IsLetter(c))
                return c;

            var isUpper = char.IsUpper(c);          

            var result = (char)(char.ToLower(c) + shift);

            if(result > 'z')
            {
                result = (char)(result - 26); 
            }
            else if(result < 'a')
            {
                result = (char)(result + 26); 
            }

            return isUpper ? char.ToUpper(result) : result;
        }
    }
}
