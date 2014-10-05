namespace wServer.realm.worlds
{
    public class EPcave : World
    {
        public EPcave()
        {
            Name = "Deadwater Docs";
            Background = 0;
            AllowTeleport = false;
            base.FromWorldMap(typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.epicpcave.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new EPcave());
        }
    }
}
