using System.IO;

namespace Angalia.Core.Services
{
    public static class StreamExtensions
    {
        #region Methods

        public static byte[] ToByte(this Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        #endregion
    }
}