using System;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Extensions
{
    public class StringExtensionsTest
    {
        [Fact]
        public void FromBase64_Convert()
        {
            const string base64Input = "SGVsbG8gV29ybGQhISE=";
            const string expected = "Hello World!!!";

            var result = base64Input.ToStringFromBase64();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToBase64_Convert()
        {
            const string strInput = "Hello World!!!";
            const string expected = "SGVsbG8gV29ybGQhISE=";

            var result = strInput.ToBase64();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToGuid_Convert()
        {
            var strGuid = "DDADCD3F-A494-474C-87AA-D66D882879A0";
            // {DDADCD3F-A494-474C-87AA-D66D882879A0}
            var expected = new Guid(0xddadcd3f, 0xa494, 0x474c, 0x87, 0xaa, 0xd6, 0x6d, 0x88, 0x28, 0x79, 0xa0);

            var result = strGuid.ToGuid();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToGuid_Detect_BadFormatGuid()
        {
            var strGuid = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
            var expected = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";

            //Guid result=Guid.Empty;
            Action act = () => strGuid.ToGuid();

            Exception ex = Assert.Throws<FormatException>(act);

            Assert.Equal($"{strGuid} is not a valid GUID", ex.Message);
            Assert.Equal(expected, strGuid);
        }

        [Fact]
        public void ToInt_DefaultValue_Must_Be_Zero()
        {
            var result = "a".ToInt();
            Assert.Equal(0, result);

            var result_1 = "-1.3".ToInt();
            Assert.Equal(0, result_1);
        }

        [Fact]
        public void ToInt_Must_Be_Int()
        {
            var result = "1".ToInt();
            Assert.Equal(1, result);

            var result_1 = "-1".ToInt();
            Assert.Equal(-1, result_1);
        }

        [Fact]
        public void ToInt_NullOrEmptyString_Must_Be_Zero()
        {
            var result = string.Empty.ToInt();
            Assert.Equal(0, result);

            var result_1 = StringExtensions.ToInt(null);
            Assert.Equal(0, result_1);
        }
    }
}