namespace Platypus.HelperLibrary.Helpers
{
    using Newtonsoft.Json;

    public static class FileHelper
    {
        public static string ReadFileContent(params string[] filepath)
        {
            var filePath = Path.Combine(filepath);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File {filePath} not found");

            return File.ReadAllText(filePath);
        }
    }
}
