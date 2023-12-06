using HomeworkAssignment.DataManager;
using Xunit;

namespace HomeworkAssignment.Tests.DataManager;
public class FileManagerTests
{
    [Fact]
    public async Task ReadAllTextAsync_WhenFileDoesNotExist_ShouldReturnNull()
    {
        var fileName = "NonExistentFile.txt";
        var cancellationToken = CancellationToken.None;
        var fileManager = new FileManager();

        var result = await fileManager.ReadAllTextAsync(fileName, cancellationToken);

        Assert.Null(result);
    }

    [Fact]
    public async Task ReadAllTextAsync_WhenFileExists_ShouldReturnFileContent()
    {
        var fileName = "ExistingFile.txt";
        var cancellationToken = CancellationToken.None;
        var fileContent = "Test data";
        File.WriteAllText(fileName, fileContent);
        var fileManager = new FileManager();

        var result = await fileManager.ReadAllTextAsync(fileName, cancellationToken);

        Assert.Equal(fileContent, result);
    }

    [Fact]
    public async Task WriteAsync_ShouldWriteDataToFile()
    {
        var fileName = "TestFile.txt";
        var data = "Test data";
        var fileManager = new FileManager();
        await fileManager.WriteAsync(fileName, data);

        Assert.True(File.Exists(fileName));

        var fileContent = await File.ReadAllTextAsync(fileName);
        Assert.Equal(data, fileContent);
    }
}
