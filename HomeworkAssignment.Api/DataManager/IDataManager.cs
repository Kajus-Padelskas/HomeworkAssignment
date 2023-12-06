namespace HomeworkAssignment.DataManager;

public interface IDataManager
{
    public Task<string?> ReadAllTextAsync(string fileName, CancellationToken cancellationToken);

    public Task WriteAsync(string fileName, string data);
}
