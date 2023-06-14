using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rene.Utils.Core.UnitTest.Security
{
    using Core.Security;
    using FluentAssertions;
    using Xunit;

    public class CipherTest
    {
        
        private const string KEY_16 = "RENE23C8PSDEB450";
        private const string KEY_24 = "RENE23C8PSDEB450PSDEB450";
        private const string KEY_32 = "RENE23C8PSDEB450RENE23C8PSDEB450";

        private const string TEST_STRING = "Se me Enfría la Comida, Leche!";

        public CipherTest()
        {

        }

        [Theory]
        [InlineData(KEY_16)]
        [InlineData(KEY_24)]
        [InlineData(KEY_32)]
        public void Cipher_Encrypt_Decrypt_String_Works_As_Should(string key)
        {
            var cipher = new Cipher(key);

            var crypted=cipher.Encrypt(TEST_STRING);
            
            var res=cipher.Decrypt(crypted);

            res.Should().Be(TEST_STRING);

        }

    }
}
