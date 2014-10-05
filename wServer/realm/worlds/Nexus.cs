namespace wServer.realm.worlds
{
    public class Nexus : World
    {
        public Nexus()
        {
            Id = NEXUS_ID;
            Name = "Nexus";
            Background = 0;
            AllowTeleport = true;
            SetMusic("sfx/music/Nexus.m4a");
            base.FromWorldMap(
                typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.nexus.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new Nexus());
        }
    }
}