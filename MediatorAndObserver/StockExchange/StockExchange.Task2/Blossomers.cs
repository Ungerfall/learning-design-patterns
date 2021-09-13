using System;

namespace StockExchange.Task2
{
    // TODO Дублирование кода во всех реализациях IPlayer
    public class Blossomers : IPlayer
    {
        private readonly IBroker _broker;

        public Blossomers(IBroker broker)
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
    }
}
