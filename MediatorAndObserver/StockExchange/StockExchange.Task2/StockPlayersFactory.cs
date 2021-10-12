// Copyright © 2021 EPAM Systems, Inc. All Rights Reserved. All information contained herein is, and remains the
// property of EPAM Systems, Inc. and/or its suppliers and is protected by international intellectual
// property law. Dissemination of this information or reproduction of this material is strictly forbidden,
// unless prior written permission is obtained from EPAM Systems, Inc
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