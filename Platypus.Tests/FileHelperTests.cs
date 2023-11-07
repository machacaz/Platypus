using Platypus.HelperLibrary.Helpers;

namespace Platypus.Tests;

public class FileHelperTests
{
    [Theory(DisplayName = "Random File Name - Extension")]
    [InlineData(".jpg")]
    public void RandomFileName_Extension(string value)
    {
        var output = FileHelper.GenerateRandomFileNameByExtension(value);

        Assert.NotNull(output);
    }

    [Theory(DisplayName = "Random File Name - FileName")]
    [InlineData("testeFile.docx")]
    public void RandomFileName_FileName(string value)
    {
        var output = FileHelper.GenerateRandomFileNameByFileName(value);

        Assert.NotNull(output); 
    }
}
