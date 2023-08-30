namespace Platypus.HelperLibrary.Helpers
{
    public static class EnumHelper
    {
        public static string EnumToString<T>(T value) where T : Enum
        {
            return Enum.GetName(typeof(T), value);
        }
    }
}