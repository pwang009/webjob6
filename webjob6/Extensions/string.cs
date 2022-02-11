using System.IO.Compression;
using System.Text;

namespace webjob6.Extensions
{
    public static partial class Extensions
    {

        /// <summary>
        ///     A string extension method that compress the given string to GZip byte array.
        /// </summary>
        /// <param name="this">The stringToCompress to act on.</param>
        /// <returns>The string compressed into a GZip byte array.</returns>
        public static byte[] CompressGZip(this string @this, Encoding? encoding = null)
        {
            var stringAsBytes = encoding == null ?
                 Encoding.UTF8.GetBytes(@this) :
                 encoding.GetBytes(@this);

            using var memoryStream = new MemoryStream();
            using var zipStream = new GZipStream(memoryStream, CompressionMode.Compress);
            zipStream.Write(stringAsBytes, 0, stringAsBytes.Length);
            zipStream.Close();
            return (memoryStream.ToArray());
        }


    }
}
