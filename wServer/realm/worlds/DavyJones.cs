using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace wServer.realm.worlds
{
    public class Davy : World
    {
        public Davy()
        {
            Name = "Davy Jones Locker";
            Background = 1;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.davyjohannes.wmap"));            
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new Davy());
        }
    }
}
