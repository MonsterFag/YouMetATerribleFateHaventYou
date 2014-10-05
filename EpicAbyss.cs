using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace wServer.realm.worlds
{
    public class MoltenCaves : World
    {
        public MoltenCaves()
        {
            Id = EABYSS_ID;
        	Name = "Molten Caves";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.epicabyss.wmap"));
        }
    }
}