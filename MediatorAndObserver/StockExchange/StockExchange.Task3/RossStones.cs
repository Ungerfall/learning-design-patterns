using System;

namespace StockExchange.Task3
{
    public class RossStones : IPlayer
    {
        private readonly IBroker _broker;

        public RossStones(IBroker broker)
        {
            _broker = broker ?? throw new ArgumentNullException(nameof(broker));
        }

        public Guid PlayerId { get; init; }

        public bool SellOffer(string stockName, int numberOfShares)
        {
            return _broker.SellOffer(this, stockName, numberOfShares);
        }

        public bool BuyOffer(string stockName, int numberOfShares)
        {
            return _broker.BuyOffer(this, stockName, numberOfShares);
        }

        public int SoldShares { get; }
        public int BoughtShares { get; }
    }
}