using System;

namespace StockExchange.Task4
{
    public interface IPlayer
    {
        Guid PlayerId { get; init; }
        bool SellOffer(string stockName, int numberOfShares);
        bool BuyOffer(string stockName, int numberOfShares);
        int SoldShares { get; }
        int BoughtShares { get; }
    }
}