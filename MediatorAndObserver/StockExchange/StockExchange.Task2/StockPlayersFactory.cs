﻿namespace StockExchange.Task2
{
    public class StockPlayersFactory
    {
        public Players CreatePlayers()
        {
            var broker = new Broker();
            var redSocks = new RedSocks(broker);
            var blossomers = new Blossomers(broker);
            var rossStones = new RossStones(broker);
            return new Players
            {
                RedSocks = redSocks,
                Blossomers = blossomers,
                RossStones = rossStones
            };
        }
    }
}
