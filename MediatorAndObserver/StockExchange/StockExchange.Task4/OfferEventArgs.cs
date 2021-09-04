using System;

namespace StockExchange.Task4
{
    public class OfferEventArgs : EventArgs
    {
        public Offer Offer { get; init; }
    }
}