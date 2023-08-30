namespace Platypus.HelperLibrary.Helpers
{
    using Newtonsoft.Json;

    public static class JSonHelpers
    {
        /// <summary>
        /// Parses Json Content To a T Type
        /// </summary>
        public static T ParseJsonFile<T>(string jsonString)
        {
            var output = JsonConvert.DeserializeObject<T>(jsonString);
            return output ?? default;
        }

        /// <summary>
        /// Allows Parse a json to a list of elements
        /// </summary>
        public static IEnumerable<T> ParseJsonToList<T>(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString)) return Enumerable.Empty<T>();

            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }
    }
}
