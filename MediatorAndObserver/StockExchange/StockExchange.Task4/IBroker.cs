﻿using System;

namespace StockExchange.Task4
{
    public interface IBroker
    {
        bool SellOffer(IPlayer player, string stockName, int numberOfShares);
        bool BuyOffer(IPlayer player, string stockName, int numberOfShares);
        event EventHandler<OfferEventArgs> OfferSucceeded;
    }
}