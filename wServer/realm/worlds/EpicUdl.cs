using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace wServer.realm.worlds
{
    public class EUdl : World
    {
        public EUdl()
        {
            Name = "Epic Lair";
            Background = 1;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.epicudl.wmap"));            
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new EUdl());
        }
    }
}