namespace Platypus.HelperLibrary.Helpers
{
    public static class ArrayHelper
    {
        public static void WriteArrayToConsole<T>(T[,] genericArray, bool display = false)
        {
            if (!display)
                return;

            for (int column = 0; column < genericArray.GetLength(1); column++)
            {
                for (int row = 0; row < genericArray.GetLength(0); row++)
                {
                    Console.Write(genericArray[row, column] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static IEnumerable<T> ToEnumerable<T>(this T[,] array)
        {
            foreach (var item in array)
                yield return item;
        }

        public static IEnumerable<T> GetChildItems<T, S>(T[,] genericArray)
        {
            return (IEnumerable<T>)genericArray.ToEnumerable().Where(i => i is S).ToList();
        }
    }
}