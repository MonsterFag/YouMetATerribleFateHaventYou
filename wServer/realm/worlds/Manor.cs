namespace wServer.realm.worlds
{
    public class ManorMap : World
    {
        public ManorMap()
        {
            Name = "Manor of the Immortals";
            Background = 0;
            AllowTeleport = true;
            SetMusic("Overworld");
            base.FromWorldMap(
                typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.manor.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new ManorMap());
        }
    }
}
