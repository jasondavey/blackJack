using System;

namespace BlackJack.contracts
{
    public interface IGameFactory
    {
        IGame BuildGame(Enum gameType);
       
    }
}