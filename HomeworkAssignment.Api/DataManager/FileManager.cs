namespace HomeworkAssignment.DataManager;

public class FileManager : IDataManager
{
    public async Task<string?> ReadAllTextAsync(string fileName, CancellationToken cancellationToken)
    {
        if (!File.Exists(fileName))
        {
            return null;
        }

        return await File.ReadAllTextAsync(fileName, cancellationToken);
    }

    public async Task WriteAsync(string fileName, string data)
    {
        using StreamWriter outputFile = new(Path.Combine("", fileName));

        await outputFile.WriteAsync(data);
    }
}
