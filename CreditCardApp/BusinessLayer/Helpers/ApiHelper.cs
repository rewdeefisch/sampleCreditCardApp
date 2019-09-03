namespace CreditCardApp.BusinessLayer
{
    using CreditCardApp.BusinessLayer.Responses;
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System.Threading.Tasks;
    public static class ApiHelper
    {
        // This would come from a config value, here in plain text for simplicity
        private static readonly RestClient Client = new RestClient("https://anypoint.mulesoft.com/mocking/api/v1/links/2107a7ca-f0f9-4894-93f3-a6f18e9c9f63/");
        // This would come from a secret, here in plain text for simplicity
        private const string apiKey = "C5F5A63C-E604-47AA-A7CC-B01F95FFBF09";

        public static CardInfoResponse GetCardInfo()
        {
            Random _rdm = new Random();
            var userId = _rdm.Next(10000, 99999);

            var request = new RestRequest($"cardInfo/{userId}", Method.GET, DataFormat.Json);
            request.AddHeader("API-Key", apiKey);

            var result = Client.Execute(request);
            return JsonConvert.DeserializeObject<CardInfoResponse>(result.Content);
        }

        public static CardInfoResponse GetCardInfo(string userId)
        {
            var request = new RestRequest($"cardInfo/{userId}", Method.GET, DataFormat.Json);
            request.AddHeader("API-Key", apiKey);

            var result = Client.Execute(request);
            return JsonConvert.DeserializeObject<CardInfoResponse>(result.Content);
        }
    }
}
