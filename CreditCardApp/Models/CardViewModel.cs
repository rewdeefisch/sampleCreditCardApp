using CreditCardApp.BusinessLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApp.Models
{
    public class CardViewModel
    {
        public double LastFourDigits { get; set; }

        public string CardHolderName { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double SecurityCode { get; set; }

        public CardCompromisedEnums CardStatus { get; set; }

        public int CardId { get; set; }
    }
}
