namespace Platypus.Tests
{
    using Newtonsoft.Json.Linq;
    using Platypus.HelperLibrary.Extensions;

    public class GuidExtensionsTests
    {
        readonly string emptyEncodedGuid = "AAAAAAAAAAAAAAAAAAAAAA";

        [Fact(DisplayName = "Guid Extension - Encode")]
        public void GuidToString()
        {
            var guid = Guid.NewGuid();
            object value = guid.EncodeBase64String();

            Assert.NotEqual(value, emptyEncodedGuid);
        }

        [Fact(DisplayName = "Guid Extension - Decode")]
        public void StringToGuidAsCharReadOnlySpan()
        {
            var emptyGuid = Guid.Empty;
            Guid actual = ((ReadOnlySpan<char>)emptyEncodedGuid).DecodeBase64String();

            Assert.Equal(emptyGuid, actual);
        }

        [Theory(DisplayName = "Guid Extension - Decode")]
        [InlineData("AAAAAAAAAAAAAAAAAAAAAA")]
        public void StringToGuidAsString(string value)
        {
            var emptyGuid = Guid.Empty;
            Guid actual = value.DecodeBase64String();

            Assert.Equal(emptyGuid, actual);
        }

        [Theory(DisplayName = "Guid Extensions - Test for EqualValue")]
        [InlineData("c9d045f3-e21c-46d0-971d-b92ebc2ab83c", "c9d045f3-e21c-46d0-971d-b92ebc2ab8a4")]
        public void EqualGuids(string value, string value2)
        {
            var b1Encoded = (new Guid(value)).EncodeBase64String();//.ToLower();
            var b2Encoded = (new Guid(value2)).EncodeBase64String();//.ToLower(); 

            Assert.NotEqual(b1Encoded, b2Encoded);
        }
    }
}