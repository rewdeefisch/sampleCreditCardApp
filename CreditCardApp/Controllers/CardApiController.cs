﻿namespace CreditCardApp.Controllers
{
    using CreditCardApp.BusinessLayer.Enum;
    using CreditCardApp.BusinessLayer.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using RestSharp;
    using System;

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
            var content = JsonConvert.DeserializeObject<InternalApiResponse>(result.Content);

            content.Status = (cardStatus == CardCompromisedEnums.OK ? CardCompromisedEnums.Locked : CardCompromisedEnums.OK).ToString("g");
            
            return Json(content);
        }

        // POST api/action
        [HttpPost("api/problem")]
        public JsonResult Problem(string cardId, CardCompromisedEnums cardStatus, string comment)
        {
            var data = new { cardId, cardStatus, comment };

            var request = new RestRequest($"cardcontrols/reportcardissue", Method.POST, DataFormat.Json);
            request.AddHeader("API-Key", apiKey);
            request.AddJsonBody(data);

            var result = Client.Execute(request);
            var content = JsonConvert.DeserializeObject<InternalApiResponse>(result.Content);

            content.Status = cardStatus.ToString("g");

            return Json(content);
        }
    }
}
