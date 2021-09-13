using System;
using System.Collections.Generic;

namespace StockExchange.Task3
{
    public record Offer(Guid PlayerId, string StockName, int NumberOfShares, bool isBuy);

    public sealed class Broker : IBroker, IObservable<Offer>
    {
        private readonly List<(Offer offer, bool traded)> sellOffers = new();
        private readonly List<(Offer offer, bool traded)> buyOffers = new();

        private readonly List<IObserver<Offer>> observers = new();

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

        private bool Sell(Offer sellOffer)
        {
            var (player, stockName, numberOfShares, _) = sellOffer;
            for (var i = 0; i < buyOffers.Count; i++)
            {
                var (buyOffer, traded) = buyOffers[i];
                if (traded || buyOffer.PlayerId == player)
                    continue;

                if (buyOffer.StockName == stockName
                    && buyOffer.NumberOfShares == numberOfShares)
                {
                    buyOffers[i] = (buyOffer, traded: true);
                    NotifySucceededOffer(sellOffer);
                    NotifySucceededOffer(buyOffer);
                    return true;
                }
            }

            return false;
        }

        private bool Buy(Offer buyOffer)
        {
            var (player, stockName, numberOfShares, _) = buyOffer;
            for (var i = 0; i < sellOffers.Count; i++)
            {
                var (sellOffer, traded) = sellOffers[i];
                if (traded || sellOffer.PlayerId == player)
                    continue;

                if (sellOffer.StockName == stockName
                    && sellOffer.NumberOfShares == numberOfShares)
                {
                    sellOffers[i] = (sellOffer, traded: true);
                    NotifySucceededOffer(sellOffer);
                    NotifySucceededOffer(buyOffer);
                    return true;
                }
            }

            return false;
        }

        public IDisposable Subscribe(IObserver<Offer> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }

        private void NotifySucceededOffer(Offer offer)
        {
            foreach (var observer in observers) // TODO Уведомление рассылается всем игрокам, а должно только участникам конкретной сделки
            {
                observer.OnNext(offer);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Offer>> _observers;
            private IObserver<Offer> _observer;

            public Unsubscriber(List<IObserver<Offer>> observers, IObserver<Offer> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}