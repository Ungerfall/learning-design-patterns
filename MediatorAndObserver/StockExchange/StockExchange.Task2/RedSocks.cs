using System;

namespace StockExchange.Task2
{
    public class RedSocks : IPlayer
    {
        private readonly IBroker _broker;

        public RedSocks(IBroker broker)
        {
            _broker = broker ?? throw new ArgumentNullException(nameof(broker));
        }

        public bool SellOffer(string stockName, int numberOfShares)
        {
            return _broker.SellOffer(this, stockName, numberOfShares);
        }

        public bool BuyOffer(string stockName, int numberOfShares)
        {
            return _broker.BuyOffer(this, stockName, numberOfShares);
        }
    }
}
