namespace StockExchange.Task3
{
    public interface IBroker
    {
        bool SellOffer(IPlayer player, string stockName, int numberOfShares);
        bool BuyOffer(IPlayer player, string stockName, int numberOfShares);
    }
}