using webjob6.Extensions;
using Xunit;

namespace webjob6.UnitTests.Services
{
    public class gzipandgunzip
    {
        [Fact]
        public void testgzipandgunzip()
        {
            const string str = "The quick brown fox jumps over the lazy dog. ";
            const string originalStr = str + str + str + str;

            var compressedStr = originalStr.CompressGZip();
            var uncompressedStr = compressedStr.DecompressGZip();
            Assert.Equal(originalStr, uncompressedStr);
        }

    }
}
