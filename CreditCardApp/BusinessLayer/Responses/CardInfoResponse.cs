using CreditCardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApp.BusinessLayer.Responses
{
    public class CardInfoResponse
    {
        public string CardHolder { get; set; }

        public List<Card> Cards { get; set; }

        public List<CardViewModel> ConvertToCardViewModel() {
            var random = new Random();
            var modelList = new List<CardViewModel>();

            foreach(var card in this.Cards)
            {
                modelList.Add(new CardViewModel() {
                    CardHolderName = this.CardHolder,
                    LastDigits = double.Parse(card.maskedCardNumber.Replace("xx", "")),
                    CardId =  card.cardId,
                    SecurityCode = random.Next(999),
                    ExpirationDate = DateTime.Now.AddMonths(random.Next(13)),
                    CardStatus = Enum.CardCompromisedEnums.OK
                });
            }
            return modelList;
        }
    }

    public class Card
    {
        public int cardId { get; set; }
        public string cardName { get; set; }
        public string maskedCardNumber { get; set; }
    }
}
