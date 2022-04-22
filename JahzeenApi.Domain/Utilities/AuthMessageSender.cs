using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace JahzeenApi.Domain.Utilities
{
    public class AuthMessageSender
    {
        public void SendSmsAsync(string number, string message)
        {
            try
            {
                // Plug in your SMS service here to send a text message.
                // Your Account SID from twilio.com/console
                var accountSid = "AC5c19523f86d3a4d53a436fce84bd0144";
                // Your Auth Token from twilio.com/console
                var authToken = "5840837392242033ce5219da8d3853ee";

                TwilioClient.Init(accountSid, authToken);

                MessageResource.CreateAsync(
                  to: new PhoneNumber(number),
                  from: new PhoneNumber("+19477770312"),
                  body: message);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
