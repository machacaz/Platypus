namespace Platypus.HelperLibrary.Extensions
{
    public static class EnumExtensions
    {
        public static int EnumToInt<TValue>(this TValue value) where TValue : Enum
        {
            return (int)(object)value;
        }

        public static string EnumToString<TValue>(this TValue value) where TValue : Enum
        {
            return (value.EnumToInt<TValue>()).ToString(); 
        }

        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }
    }
}
