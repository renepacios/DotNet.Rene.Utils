namespace Rene.Utils.Core.UnitTest.Security
{
    using Core.Security;
    using FluentAssertions;
    using Xunit;

    public class UrlEncoderTest
    {
        private const string Base64WithChars =
            "o55h+zQQQyGuYPF7Jr2BRin2ppWonMq+DgWPNkzwi8AhaCQvfhdIuJJGmQVPMCTGZyOLQ87rp36TdFCUG+Gvug==";


        [Fact]
        public void UrlEncoder_work_as_should()
        {
            var encode = UrlEncoder.EncodeFromBase64(Base64WithChars);

            var decode = UrlEncoder.DecodeToBase64(encode);

            decode.Should().Be(Base64WithChars);
        }
    }
}
