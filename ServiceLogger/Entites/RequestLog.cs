using ServiceLogger.Models.Common;

namespace ServiceLogger.Models
{
    public class RequestLog:BaseEntity
    {
        public string Name { get; set; }
        public bool IsSuccessfull { get; set; }
    }
}
