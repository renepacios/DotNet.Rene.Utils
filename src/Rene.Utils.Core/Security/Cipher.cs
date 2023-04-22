using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rene.Utils.Core.Security
{
    using System.Linq;

    public class Cipher
    {
        private readonly string _keyString;
        private readonly int[] _keyLengths = { 16, 24, 32 };

        public Cipher(string keyString)
        {
            if (string.IsNullOrEmpty(keyString)) throw new ArgumentNullException(nameof(keyString));
            if (!_keyLengths.Contains(keyString.Length)) throw new ArgumentOutOfRangeException(Resources.ExceptionMessages.KeySizeOutMessage);

            _keyString = keyString;
        }


        public string Encrypt(string text)
        {
            var key = Encoding.UTF8.GetBytes(_keyString);
            var auxIV = new byte[16]; //TODO: jugar con vector y ver como pasarlo en el base64

            using (var aesAlg = Aes.Create()) {
             
                using (var encryptor = aesAlg.CreateEncryptor(key, auxIV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var cryptedContent = msEncrypt.ToArray();
                        return Convert.ToBase64String(cryptedContent);
                    }
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            var cipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];

            var key = Encoding.UTF8.GetBytes(_keyString);

            using (var alg = Aes.Create())
            {
                using (var decryptor = alg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
