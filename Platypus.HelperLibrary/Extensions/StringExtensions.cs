namespace Platypus.HelperLibrary.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEqual(this string basestring, string otherString) 
        {
            if(string.IsNullOrEmpty(basestring) || string.IsNullOrEmpty(otherString)) return false;

            var equals = false;
            equals = string.Equals(basestring, otherString, StringComparison.OrdinalIgnoreCase);
            return equals;
        }
    }
}