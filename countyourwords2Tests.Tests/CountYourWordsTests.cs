using System.IO;
using Xunit;

public class WordCounterTests
{
    [Fact]
    public void CountsWordsFromInputFile()
    {
        // Arrange
        string path = "input.txt";
        File.WriteAllText(path, "This is a test file with seven words.");

        // Act
        int result = WordCounter.CountWordsInFile(path);

        // Assert
        Assert.Equal(7, result);

        // Clean up
        File.Delete(path);
    }
}
