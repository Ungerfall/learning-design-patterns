using System;

namespace StockExchange.Task4
{
    public class StockPlayersFactory
    {
        public Players CreatePlayers()
        {
            var broker = new Broker();
            var redSocks = new RedSocks(broker) { PlayerId = Guid.NewGuid() };
            var blossomers = new Blossomers(broker) { PlayerId = Guid.NewGuid() };
            var rossStones = new RossStones(broker) { PlayerId = Guid.NewGuid() };
            broker.Subscribe(redSocks);
            broker.Subscribe(blossomers);
            broker.Subscribe(rossStones);
            return new Players
            {
                RedSocks = redSocks,
                Blossomers = blossomers,
                RossStones = rossStones
            };
        }
    }
}