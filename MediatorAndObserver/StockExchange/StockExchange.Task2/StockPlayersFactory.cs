﻿using System;

namespace StockExchange.Task2
{
    public class StockPlayersFactory
    {
        public Players CreatePlayers()
        {
            var broker = new Broker();
            var redSocks = new RedSocks(broker) { PlayerId = Guid.NewGuid() };
            var blossomers = new Blossomers(broker) { PlayerId = Guid.NewGuid() };
            var rossStones = new RossStones(broker) { PlayerId = Guid.NewGuid() };
            return new Players
            {
                RedSocks = redSocks,
                Blossomers = blossomers,
                RossStones = rossStones
            };
        }
    }
}