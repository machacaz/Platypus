namespace Platypus.HelperLibrary.Extensions
{
    public static class IntegerExtensions
    {
        public static bool ToEnum<T>(this int value, out T result) where T : struct
        {
            return Enum.TryParse<T>(value.ToString(), out result);
        }

        public static T ToEnum<T>(this int value) where T : struct
        {
            Enum.TryParse<T>(value.ToString(), out T tp);
            return tp;
        }
    }
}
