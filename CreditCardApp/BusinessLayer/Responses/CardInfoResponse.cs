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
            var modelList = new List<CardViewModel>();

            foreach(var card in this.Cards)
            {
                modelList.Add(new CardViewModel() {
                    CardHolderName = this.CardHolder,
                    LastFourDigits = double.Parse(card.maskedCardNumber.Replace("xx", "")),
                    CardId =  card.cardId,
                    SecurityCode = 999,
                    ExpirationDate = DateTime.Now.AddYears(2),
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
