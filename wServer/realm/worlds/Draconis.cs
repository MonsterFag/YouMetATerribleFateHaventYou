using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wServer.realm.entities;
using wServer.logic.loot;

namespace wServer.realm.worlds
{
    public class Draconis : World
    {
        public Draconis()
        {
            Name = "Lair of Draconis";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.draconis.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new Draconis());
        }
    }
}
