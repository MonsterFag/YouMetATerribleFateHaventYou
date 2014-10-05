namespace wServer.realm.worlds
{
    public class Shaitan : World
    {
        public Shaitan()
        {
            Name = "Lair of Shaitan";
            Background = 0;
            AllowTeleport = false;
            base.FromWorldMap(typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.shaitan.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new Shaitan());
        }
    }
}
