using System.IO.Compression;
using System.Text;

namespace webjob6.Extensions
{
    public static partial class Extensions
    {
        public static string DecompressGZip(
            this byte[] @this,
            Encoding? encoding = null)
        {
            const int bufferSize = 1024;
            using var memoryStream = new MemoryStream(@this);
            using var zipStream = new GZipStream(memoryStream, CompressionMode.Decompress);

            // Memory stream for storing the decompressed bytes
            using var outStream = new MemoryStream();
            var buffer = new byte[bufferSize];
            var totalBytes = 0;
            int readBytes;
            while ((readBytes = zipStream.Read(buffer, 0, bufferSize)) > 0)
            {
                outStream.Write(buffer, 0, readBytes);
                totalBytes += readBytes;
            }
            return encoding == null ?
                Encoding.UTF8.GetString(outStream.GetBuffer(), 0, totalBytes) :
                encoding.GetString(outStream.GetBuffer(), 0, totalBytes);
        }
    }
}
