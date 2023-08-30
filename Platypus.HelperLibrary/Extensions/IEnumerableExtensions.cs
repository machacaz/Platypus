namespace Platypus.HelperLibrary.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T item in @this)
            {
                action(item);
            }
        }

        public static string FlatToString(this IEnumerable<string> list)
        {
            return string.Join("#", list.ToArray());
        }

    }
}
