namespace ServiceLogger.Services.Abstracts
{
    public interface IFileService
    {
        public Task LogToFileAsync(string successOrFail);        
    }
}
