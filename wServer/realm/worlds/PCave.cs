namespace wServer.realm.worlds
{
    public class PirateCave : World
    {
        public PirateCave()
        {
            Name = "Pirate Cave";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(
                typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.piratecave.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new PirateCave());
        }
    }
}
