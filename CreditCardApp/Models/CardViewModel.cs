namespace CreditCardApp.Models
{
    using CreditCardApp.BusinessLayer.Enum;
    using System;

    public class CardViewModel
    {
        public double LastDigits { get; set; }

        public string CardHolderName { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double SecurityCode { get; set; }

        public CardCompromisedEnums CardStatus { get; set; }

        public int CardId { get; set; }
    }
}
