using System;
using Xunit;

namespace Encryption.Caesar.Test
{
    public class CipherTest
    {
        [Fact]
        public void EncryptTest()
        {
            string input = "Test String";

            var result = Cipher.Encrypt(input , 4);

            Assert.Equal("Xiwx Wxvmrk", result);
        }

        [Fact]
        public void DecryptTest()
        {
            string input = "Xiwx Wxvmrk";

            var result = Cipher.Decrypt(input, 4);

            Assert.Equal("Test String", result);
        }
    }
}
