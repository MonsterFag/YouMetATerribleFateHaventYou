namespace wServer.realm.worlds
{
    public class SpiderDen : World
    {
        public SpiderDen()
        {
            Name = "Spider Den";
            Background = 0;
            AllowTeleport = true;
            SetMusic("Snake Pit");
            base.FromWorldMap(
                typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.spiderden.wmap"));
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new SpiderDen());
        }
    }
}
