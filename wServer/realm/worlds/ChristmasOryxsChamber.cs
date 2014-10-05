using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class ChristmasOryxsChamber : World
    {
        public ChristmasOryxsChamber()
        {
   //         Id = CHOCHAMBER;
            Name = "Christmas Oryxs Chamber";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(
                typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.oryxchristmas.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new ChristmasOryxsChamber());
        }
    }
}