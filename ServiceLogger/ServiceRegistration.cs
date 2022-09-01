using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Polly;
using Polly.Extensions.Http;
using ServiceLogger.Abstracts;
using ServiceLogger.Concretes;
using ServiceLogger.Contexts;
using ServiceLogger.Repositories.Abstracts.Base;
using ServiceLogger.Repositories.Concretes.Base;
using ServiceLogger.Services.Abstracts;
using ServiceLogger.Services.Concretes;

namespace ServiceLogger
{
    public static class ServiceRegistration
    {
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
        public static void AddAllServices(this IServiceCollection services)
        {
            services.AddDbContext<SQLServerDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBaseWriteRepository, BaseWriteRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddHttpClient<IApiService, ApiService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.ApiUrl);
                //client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).SetHandlerLifetime(TimeSpan.FromSeconds(10)).AddPolicyHandler(GetRetryPolicy());
        }
    }
}
