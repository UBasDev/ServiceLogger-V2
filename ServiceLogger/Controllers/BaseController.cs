using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLogger.Abstracts;
using ServiceLogger.Models;
using ServiceLogger.Repositories.Abstracts.Base;
using ServiceLogger.Services.Abstracts;
using System.Net;

namespace ServiceLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IBaseWriteRepository _baseWriteRepository;
        private readonly IApiService _apiService;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        public BaseController(IBaseWriteRepository baseWriteRepository, IApiService apiService, IFileService fileService, IEmailService emailService, ISmsService smsService)
        {
            _baseWriteRepository = baseWriteRepository;
            _apiService = apiService;
            _fileService = fileService;
            _emailService = emailService;
            _smsService = smsService;
        }
        [HttpGet]
        public async Task<IActionResult> Base()
        {            
            string stringResponseFromApi = await _apiService.getAllDataAsync();
            if (String.IsNullOrEmpty(stringResponseFromApi))
            {
                await _baseWriteRepository.AddSingleAsync(new RequestLog() { Id = Guid.NewGuid(), IsSuccessfull = false, Name = "Test Service" });
                await _baseWriteRepository.SaveChangesAsync();
                await _fileService.LogToFileAsync("fail");
                await _emailService.CreateEmailAsync();
                await _smsService.SendSmsAsync();
                return NotFound();                
            }
            else
            {
                await _baseWriteRepository.AddSingleAsync(new RequestLog() { Id = Guid.NewGuid(), IsSuccessfull = true, Name = "Test Service" });
                await _baseWriteRepository.SaveChangesAsync();
                await _fileService.LogToFileAsync("success");
                return Ok();                
            }                                                
        }
    }
}
