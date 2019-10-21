using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Bigil
{
    class Program
    {
        static void Main(string[] args)
        {

            AppConfig desConfig = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText("../../../secrets.json"));
            string accountSid = desConfig.AccountSid ;
            string authToken = desConfig.AuthToken;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is the ship that made the Kessel Run in fourteen parsecs?",
                from: new Twilio.Types.PhoneNumber("+12192455815"),
                to: new Twilio.Types.PhoneNumber("+33773275750")
            );

            Console.WriteLine(message.Sid);

        }
    }
}
