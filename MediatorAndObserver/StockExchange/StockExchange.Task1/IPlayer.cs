namespace StockExchange.Task1
{
    public interface IPlayer
    {
        bool SellOffer(string stockName, int numberOfShares);
        bool BuyOffer(string stockName, int numberOfShares);
    }
}