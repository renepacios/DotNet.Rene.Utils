using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rene.Utils.Core.Validations;
using Xunit;

namespace Rene.Utils.Core.UnitTest.Validations
{
    public class FormatTest
    {
        [Fact]
        public void IsValidEmailAddress_Check()
        {
            Assert.True("rene@rene.com".IsValidEmailAddress());
            Assert.False("mail@domain".IsValidEmailAddress());
            Assert.False("domain.es".IsValidEmailAddress());
            Assert.False(string.Empty.IsValidEmailAddress());
        }

        [Fact]
        public void IsValidUri_Check()
        {
            //http://msdn.microsoft.com/en-us/library/system.uri.scheme(v=vs.110).aspx
            var schemes = new[]
            {
                "file",
                "ftp",
                "gopher",
                "http",
                "https",
                "ldap",
                "mailto",
                "net.pipe",
                "net.tcp",
                "news",
                "nntp",
                "telnet",
                "uuid"
            };

            foreach (var scheme in schemes)
            {
                var url = $"{scheme}://domain.com";
               Assert.True(url.IsValidUri(),$"Error checked: {url}");
            }
        }

    }
}
