namespace ServiceLogger.Services.Abstracts
{
    public interface IApiService
    {
        public Task<string> getAllDataAsync();
    }
}
