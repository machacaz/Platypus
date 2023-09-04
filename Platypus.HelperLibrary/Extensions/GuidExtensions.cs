using System.Buffers.Text;
using System.Runtime.InteropServices;

namespace Platypus.HelperLibrary.Extensions
{
    public static class GuidExtensions
    {
        private const char Dash = '-';
        private const char EqualsChar = '=';
        private const byte ForwardSlashByte = (byte)Slash;
        private const char Plus = '+';
        private const byte PlusByte = (byte)Plus;
        private const char Slash = '/';
        private const char Underscore = '_';
        private const int Base64LengthWithoutEquals = 22;

        public static bool IsNullOrEmptyGuid(this Guid? guid)
        {
            return (guid == null || guid == Guid.Empty);
        }

        /*
         https://www.stevejgordon.co.uk/using-high-performance-dotnetcore-csharp-techniques-to-base64-encode-a-guid
         */

        public static Guid DecodeBase64String(this string encodedGuid) 
        {
            if (string.IsNullOrEmpty(encodedGuid)) return Guid.Empty;

            return encodedGuid.AsSpan().DecodeBase64String(); 
        }

        public static Guid DecodeBase64String(this ReadOnlySpan<char> id)
        {
            Span<char> base64Chars = stackalloc char[24];

            for (var i = 0; i < Base64LengthWithoutEquals; i++)
            {
                base64Chars[i] = id[i] switch
                {
                    Dash => Slash,
                    Underscore => Plus,
                    _ => id[i],
                };
            }

            base64Chars[22] = EqualsChar;
            base64Chars[23] = EqualsChar;

            Span<byte> idBytes = stackalloc byte[16];
            Convert.TryFromBase64Chars(base64Chars, idBytes, out _);

            return new(idBytes);
        }

        public static string EncodeBase64String(this Guid guid)
        {
            Span<byte> guidBytes = stackalloc byte[16];
            Span<byte> encodedBytes = stackalloc byte[24];

            MemoryMarshal.TryWrite(guidBytes, ref guid);
            Base64.EncodeToUtf8(guidBytes, encodedBytes, out _, out _);

            Span<char> chars = stackalloc char[Base64LengthWithoutEquals];

            // Replace any characters which are not URL safe.
            // And skip the final two bytes as these will be '==' padding we don't need.
            for (int i = 0; i < Base64LengthWithoutEquals; i++)
            {
                chars[i] = encodedBytes[i] switch
                {
                    ForwardSlashByte => Dash,
                    PlusByte => Underscore,
                    _ => (char)encodedBytes[i],
                };
            }

            return new(chars);
        }


        #region ToDelete 

        public static string ToHtmlIdentifier(this Guid input)
        {
            return GuidToBase64(input);
        }

        public static Guid FromHtmlIdentifier(this string input)
        {
            return Base64ToGuid(input);
        }

        public static string GuidToBase64(this Guid identifier)
        {
            return Convert.ToBase64String(identifier.ToByteArray()).Replace("/", "-").Replace("+", "_").Replace("=", "");
        }

        public static Guid Base64ToGuid(string base64)
        {
            Guid guid = default(Guid);
            if (string.IsNullOrEmpty(base64) || Guid.TryParse(base64, out guid))
            {
                return guid;
            }

            base64 = base64.Replace("-", "/").Replace("_", "+") + "==";

            try
            {
                guid = new Guid(Convert.FromBase64String(base64));
            }
            catch (Exception ex)
            {
                throw new Exception("Bad Base64 conversion to GUID", ex);
            }

            return guid;
        }

        #endregion
    }
}