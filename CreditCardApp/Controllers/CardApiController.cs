using CreditCardApp.BusinessLayer.Enum;
using CreditCardApp.BusinessLayer.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditCardApp.Controllers
{
    public class CardApiController : Controller
    {
        // This would come from a config value, here in plain text for simplicity
        private static readonly RestClient Client = new RestClient("https://anypoint.mulesoft.com/mocking/api/v1/links/2107a7ca-f0f9-4894-93f3-a6f18e9c9f63/");
        // This would come from a secret, here in plain text for simplicity
        private const string apiKey = "C5F5A63C-E604-47AA-A7CC-B01F95FFBF09";

        // POST api/action
        [HttpPost("api/lock")]
        public JsonResult Lock(string cardId, CardCompromisedEnums cardStatus)
        {
            var request = new RestRequest($"cardcontrols/onoff/{cardId}", Method.POST);
            request.AddHeader("API-Key", apiKey);

            var result = Client.Execute(request);
            var content = JsonConvert.DeserializeObject<ApiResponse>(result.Content);

            content.Status = (cardStatus == CardCompromisedEnums.OK ? CardCompromisedEnums.Locked : CardCompromisedEnums.OK).ToString("g");
            
            return Json(content);
        }

        // POST api/action
        [HttpPost("api/problem")]
        public JsonResult Problem(string cardId, CardCompromisedEnums cardStatus, string comment)
        {
            var request = new RestRequest($"cardcontrols/reportcardissue/", Method.POST);
            request.AddHeader("API-Key", apiKey);
            request.AddParameter("cardId", cardId);
            request.AddParameter("cardStatus", cardStatus);
            request.AddParameter("comment", comment);

            var result = Client.Execute(request);
            var content = JsonConvert.DeserializeObject<ApiResponse>(result.Content);

            content.Status = cardStatus.ToString("g");

            return Json(result.Content);
        }
    }
}
