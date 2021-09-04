using System;

namespace StockExchange.Task2
{
    public interface IPlayer
    {
        Guid PlayerId { get; init; }
        bool SellOffer(string stockName, int numberOfShares);
        bool BuyOffer(string stockName, int numberOfShares);
    }
}