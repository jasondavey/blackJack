using System;
using BlackJack.contracts.games;

namespace BlackJack.contracts
{
    public interface IGameFactory
    {
        IGame BuildGame(Enum gameType);
       
    }
}