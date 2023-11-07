using Microsoft.AspNetCore.Http;

namespace Platypus.HelperLibrary.Helpers;
public static class FileHelper
{
    public static string ReadFileContent(params string[] filepath)
    {
        var filePath = Path.Combine(filepath);
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File {filePath} not found");

        return File.ReadAllText(filePath);
    }

    //public static byte[] FileToByteArray(IFormFile formFile)
    //{
    //    using MemoryStream memoryStream = new MemoryStream();
    //    formFile.CopyTo(memoryStream);
    //    return memoryStream.ToArray();
    //}

    //public static Stream FileToStream(IFormFile formFile)
    //{
    //    MemoryStream ms = new MemoryStream();
    //    formFile.CopyTo(ms);
    //    return ms;
    //}

    public static string GenerateRandomFileNameByFileName(string fileName)
    {
        var fName = GenerateRandomFileNameByExtension(Path.GetExtension(fileName));

        fName = string.Concat(Path.GetFileNameWithoutExtension(fileName), "_", fName);
        return fName;
    }

    public static string GenerateRandomFileNameByExtension(string extension)
    {
        return String.Concat(Path.GetRandomFileName(), extension);
    }
}