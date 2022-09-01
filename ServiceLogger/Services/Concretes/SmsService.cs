using ServiceLogger.Services.Abstracts;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ServiceLogger.Services.Concretes
{
    public class SmsService : ISmsService
    {
        public async Task SendSmsAsync()
        {
            var accountSid = "ACfd1126bca4b01ba37db773587308abff";  //Find from Twilio profile
            var authToken = "36eb9ee2a5c811151cb222b1b7892464";     //Find from Twilio profile
            TwilioClient.Init(accountSid, authToken);
            var numberToMessage = new List<string>() { "+905326254522", "+905330241994" };
            foreach(string number in numberToMessage)
            {
                CreateMessageOptions messageOptions = new CreateMessageOptions(new PhoneNumber(number));
                messageOptions.Body = "Serviste hata alındı! Lütfen kontrol";
                messageOptions.From = "+19806554864";       //Add free from Twilio profile
                var message = await MessageResource.CreateAsync(messageOptions);                
            }            
        }
    }
}
