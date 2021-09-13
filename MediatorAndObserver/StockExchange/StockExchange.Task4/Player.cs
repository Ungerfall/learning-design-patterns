using System;

namespace StockExchange.Task4
{
    public abstract class Player : IPlayer
    {
        private readonly IBroker _broker;

        protected Player(IBroker broker)
        {
            _broker = broker ?? throw new ArgumentNullException(nameof(broker));
            _broker.OfferSucceeded += BrokerOnOfferSucceeded;
        }

        private void BrokerOnOfferSucceeded(object sender, OfferEventArgs e)
        {
            var (playerId, _, numberOfShares, isBuy) = e.Offer;
            if (playerId != PlayerId)
                return;

            if (isBuy)
            {
                BoughtShares += numberOfShares;
            }
            else
            {
                SoldShares += numberOfShares;
            }
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

        public int SoldShares { get; private set; } = 0;
        public int BoughtShares { get; private set; } = 0;
    }
}