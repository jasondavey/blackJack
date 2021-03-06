﻿using BlackJack.contracts;

namespace BlackJack.domain
{
    internal class Dollar : ICurrency
    {
        public Dollar()
        {
            Name = "Dollar";
        }

        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}