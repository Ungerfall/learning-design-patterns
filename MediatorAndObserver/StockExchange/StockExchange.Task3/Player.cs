// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
﻿using System;

namespace StockExchange.Task3
{
    public abstract class Player : IPlayer, IObserver<Offer>
    {
        private readonly IBroker _broker;

        protected Player(IBroker broker)
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

        public int SoldShares { get; private set; } = 0;
        public int BoughtShares { get; private set; } = 0;

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Offer value)
        {
            var (playerId, _, numberOfShares, isBuy) = value;
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
    }
}