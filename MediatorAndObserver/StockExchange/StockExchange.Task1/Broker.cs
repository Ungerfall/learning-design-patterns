using System.Collections.Generic;
using System.Linq;

namespace StockExchange.Task1
{
    public record Offer(IPlayer Player, string StockName, int NumberOfShares);

    public sealed class Broker : IBroker
    {
        private readonly List<Offer> sellOffers = new();
        private readonly List<Offer> buyOffers = new();

        public bool SellOffer(IPlayer player, string stockName, int numberOfShares)
        {
            var offer = buyOffers.FirstOrDefault(x =>
                x.Player != player
                && x.StockName == stockName
                && x.NumberOfShares == numberOfShares);

            sellOffers.Add(new Offer(player, stockName, numberOfShares));

            return offer != default;
        }

        public bool BuyOffer(IPlayer player, string stockName, int numberOfShares)
        {
            var offer = sellOffers.FirstOrDefault(x =>
                x.Player != player
                && x.StockName == stockName
                && x.NumberOfShares == numberOfShares);

            buyOffers.Add(new Offer(player, stockName, numberOfShares));

            return offer != default;
        }
    }
}