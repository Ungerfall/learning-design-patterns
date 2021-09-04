using System;
using System.Collections.Generic;

namespace StockExchange.Task3
{
    public record Offer(Guid PlayerId, string StockName, int NumberOfShares, bool isBuy);

    public sealed class Broker : IBroker
    {
        private readonly List<(Offer offer, bool traded)> sellOffers = new();
        private readonly List<(Offer offer, bool traded)> buyOffers = new();

        public bool SellOffer(IPlayer player, string stockName, int numberOfShares)
        {
            var offer = new Offer(player.PlayerId, stockName, numberOfShares, isBuy: false);
            var succeeded = Sell(offer);

            if (!succeeded)
            {
                sellOffers.Add((offer, traded: false));
            }

            return succeeded;
        }

        public bool BuyOffer(IPlayer player, string stockName, int numberOfShares)
        {
            var offer = new Offer(player.PlayerId, stockName, numberOfShares, isBuy: true);
            var succeeded = Buy(offer);

            if (!succeeded)
            {
                buyOffers.Add((offer, traded: false));
            }

            return succeeded;
        }

        private bool Sell(Offer offer)
        {
            var (player, stockName, numberOfShares, _) = offer;
            for (var i = 0; i < buyOffers.Count; i++)
            {
                var buyOffer = buyOffers[i];
                if (buyOffer.traded || buyOffer.offer.PlayerId == player)
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
            var (player, stockName, numberOfShares, _) = offer;
            for (var i = 0; i < sellOffers.Count; i++)
            {
                var buyOffer = sellOffers[i];
                if (buyOffer.traded || buyOffer.offer.PlayerId == player)
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