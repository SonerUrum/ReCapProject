﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Card : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OwnerName { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public int Debts { get; set; }
    }
}
