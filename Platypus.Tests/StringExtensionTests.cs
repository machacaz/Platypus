using System.Globalization;

namespace Platypus.Tests
{
    public class StringExtensionTests
    {
        [Theory(DisplayName = "String Extension - String Equals")]
        [InlineData("interesting", "INTERESTING")]
        public void StringEquals(string a, string b) 
        {
            Assert.True(a.IsEqual(b));
        }


        [Theory(DisplayName = "String Extension - Test TurkishIssue - String Equals")]
        [InlineData("interesting", "INTERESTING")]
        public void StringEqualsTurkish(string a, string b)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");

            Assert.True(a.IsEqual(b));
        }

        [Theory(DisplayName = "String Extension - Test TurkishIssue - String Equals")]
        [InlineData("interesting", "INTERESTING")]
        public void StringEqualsTurkishNoCultureSet(string a, string b)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var c = Thread.CurrentThread.CurrentCulture; 

            var result =  a.ToUpper() == b ; 


            Assert.True(result);
        }
    }
}
