using System.Collections.Generic;

namespace StockExchange.Task2
{
    public record Offer(IPlayer Player, string StockName, int NumberOfShares);

    public sealed class Broker : IBroker
    {
        private readonly List<(Offer offer, bool traded)> sellOffers = new();
        private readonly List<(Offer offer, bool traded)> buyOffers = new();

        public bool SellOffer(IPlayer player, string stockName, int numberOfShares)
        {
            var offer = new Offer(player, stockName, numberOfShares);
            var succeeded = Sell(offer);

            if (!succeeded)
            {
                sellOffers.Add((offer, traded: false));
            }

            return succeeded;
        }

        public bool BuyOffer(IPlayer player, string stockName, int numberOfShares)
        {
            var offer = new Offer(player, stockName, numberOfShares);
            var succeeded = Buy(offer);

            if (!succeeded)
            {
                buyOffers.Add((offer, traded: false));
            }

            return succeeded;
        }

        private bool Sell(Offer offer)
        {
            var (player, stockName, numberOfShares) = offer;
            for (var i = 0; i < buyOffers.Count; i++)
            {
                var buyOffer = buyOffers[i];
                if (buyOffer.traded || buyOffer.offer.Player == player)
                    continue;

                if (buyOffer.offer.StockName == stockName
                    && buyOffer.offer.NumberOfShares == numberOfShares)
                {
                    buyOffer.traded = true;
                    return true;
                }
            }

            return false;
        }

        private bool Buy(Offer offer)
        {
            var (player, stockName, numberOfShares) = offer;
            for (var i = 0; i < sellOffers.Count; i++)
            {
                var buyOffer = sellOffers[i];
                if (buyOffer.traded || buyOffer.offer.Player == player)
                    continue;

                if (buyOffer.offer.StockName == stockName
                    && buyOffer.offer.NumberOfShares == numberOfShares)
                {
                    buyOffer.traded = true;
                    return true;
                }
            }

            return false;
        }
    }
}