using ServiceLogger.Services.Abstracts;

namespace ServiceLogger.Services.Concretes
{
    public class FileService : IFileService
    {
        public async Task LogToFileAsync(string successOrFail)
        { 
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);        
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(filePath,"RequestLog.txt"), append:true))
            {
                if (successOrFail == "success")
                {
                    await streamWriter.WriteAsync($"Successfull!\t{DateTime.Now}\n");
                }
                else{
                    await streamWriter.WriteAsync($"Failed!\t{DateTime.Now}\n");
                }
            }
        }        
    }
}
