using System;

namespace BlackJack.contracts
{
    public interface ICurrency
    {
        string Name { get; set; }
        Decimal Value { get; set; }
    }
}