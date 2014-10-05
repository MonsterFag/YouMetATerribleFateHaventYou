using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Web;

namespace admincmd
{
    class Client
    {
        Socket cliSkt;
        RC4 SendKey;
        RC4 ReceiveKey;

        string server;

        public Client(string svr)
        {
            this.server = svr;

            cliSkt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            cliSkt.Connect(svr, 2050);

            ReceiveKey = new RC4(new byte[] { 0x72, 0xc5, 0x58, 0x3c, 0xaf, 0xb6, 0x81, 0x89, 0x95, 0xcb, 0xd7, 0x4b, 0x80 });
            SendKey = new RC4(new byte[] { 0x31, 0x1f, 0x80, 0x69, 0x14, 0x51, 0xc7, 0x1b, 0x09, 0xa1, 0x3a, 0x2a, 0x6e });
        }

        public void BroadcastMessage(string msg, string username, string password)
        {
            MemoryStream s = new MemoryStream();
            using (var w = new NWriter(s))
            {
                w.Write32UTF(username);
                w.Write32UTF(password);
                w.Write32UTF(msg);
            }

            SendPacket(new Packet(PacketID.Broadcast, s.ToArray()));
        }

        public void TestHello(string username, string password)
        {
            MemoryStream s = new MemoryStream();
            using (var wtr = new NWriter(s))
            {
                wtr.WriteUTF("0.5.2");
                wtr.Write(-2);
                wtr.WriteUTF(RSA.Instance.Encrypt(username));
                wtr.WriteUTF(RSA.Instance.Encrypt(password));
                wtr.WriteUTF(RSA.Instance.Encrypt(""));
                wtr.Write(0);
                wtr.Write(1);
                wtr.Write(new byte[]{ 1 });
                wtr.Write32UTF("");
                wtr.WriteUTF("");
                wtr.WriteUTF("");
                wtr.WriteUTF("");
                wtr.WriteUTF("");
            }

            SendPacket(new Packet(PacketID.Hello, s.ToArray()));
            Console.WriteLine("Receiving MapInfo packet...");
            var pkt = ReceivePacket(PacketID.MapInfo);

            using (var rdr = new NReader(new MemoryStream(pkt.body)))
            {
                var Width = rdr.ReadInt32();
                var Height = rdr.ReadInt32();
                var Name = rdr.ReadUTF();
                var Seed = rdr.ReadUInt32();
                var Background = rdr.ReadInt32();
                var AllowTeleport = rdr.ReadBoolean();
                var ShowDisplays = rdr.ReadBoolean();

                var ClientXML = new string[rdr.ReadInt16()];
                for (int i = 0; i < ClientXML.Length; i++)
                    ClientXML[i] = rdr.Read32UTF();

                var ExtraXML = new string[rdr.ReadInt16()];
                for (int i = 0; i < ExtraXML.Length; i++)
                    ExtraXML[i] = rdr.Read32UTF();

                Console.WriteLine("Grabbed info from " + Name + ".");
                Console.WriteLine("There are " + ExtraXML.Length.ToString() + " XML files.");
            }
        }

        public Packet ReceivePacket(PacketID pid)
        {
            byte[] buff = new byte[0x10000];
            while (true)
            {
                if(cliSkt.ReceiveBufferSize > 0)
                {
                    try
                    {
                        cliSkt.Receive(buff);
                        using (var rdr = new NReader(new MemoryStream(buff)))
                        {
                            int len = rdr.ReadInt32() - 5;
                            byte id = rdr.ReadByte();
                            byte[] content = rdr.ReadBytes(len);
                            ReceiveKey.Crypt(content, content.Length);

                            Console.WriteLine((PacketID)id);
                            if ((PacketID)id == pid)
                                return new Packet((PacketID)id, content);
                        }
                    }
                    catch { }
                }
            }
        }

        public void EndReceivePacket(object sender, SocketAsyncEventArgs e)
        {

        }

        public void SendPacket(Packet p)
        {
            MemoryStream s = new MemoryStream();
            using (var wtr = new NWriter(s))
            {
                byte[] content = p.body.ToArray();
                byte[] ret = new byte[5 + content.Length];
                content = SendKey.Crypt(content, content.Length);
                Buffer.BlockCopy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(ret.Length)), 0, ret, 0, 4);
                ret[4] = (byte)p.id;
                Buffer.BlockCopy(content, 0, ret, 5, content.Length);

                wtr.Write(ret);
            }
            cliSkt.Send(s.ToArray());
        }

        public void Close()
        {
            cliSkt.Close();
        }
    }

    class Packet
    {
        public PacketID id;
        public byte[] body;

        public Packet(PacketID id, byte[] body)
        {
            this.id = id;
            this.body = body;
        }
    }
    public enum PacketID : byte
    {
        UpdateAck = 11,
        Reconnect = 39,
        Failure = 0,
        InvitedToGuild = 77,
        CreateGuildResult = 58,
        Damage = 47,
        GroundDamage = 64,
        File = 55,
        Pic = 28,
        Text = 25,
        Update = 26,
        AOE = 68,
        AllyShoot = 74,
        New_Tick = 62,
        TradeRequested = 61,
        TradeDone = 12,
        Notification = 63,
        Shoot = 13,
        MultiShoot = 19,
        NameResult = 20,
        AccountList = 46,
        GlobalNotification = 9,
        ClientStat = 75,
        Create_Success = 31,
        QuestObjId = 34,
        InvResult = 4,
        PlaySound = 44,
        BuyResult = 27,
        TradeStart = 67,
        TradeAccepted = 18,
        Show_Effect = 56,
        MapInfo = 60,
        Ping = 6,
        Goto = 52,
        TradeChanged = 23,
        Death = 41,
        Hello = 17,
        GuildRemove = 78,
        CreateGuild = 15,
        GuildInvite = 8,
        JoinGuild = 5,
        ChangeGuildRank = 40,
        Buy = 50,
        Create = 36,
        Teleport = 49,
        Pong = 16,
        Move = 7,
        PlayerShoot = 38,
        CheckCredits = 48,
        SquareHit = 51,
        ShootAck = 22,
        Escape = 42,
        PlayerText = 69,
        Load = 45,
        InvSwap = 65,
        GotoAck = 14,
        SetCondition = 10,
        EditAccountList = 53,
        RequestTrade = 21,
        OtherHit = 66,
        ChooseName = 33,
        PlayerHit = 24,
        AOEAck = 59,
        ChangeTrade = 37,
        UsePortal = 3,
        AcceptTrade = 57,
        UseItem = 30,
        CancelTrade = 1,
        EnemyHit = 76,
        InvDrop = 35,
        Visibullet = 80,
        TextBox = 81,
        TextBoxButton = 82,

        Broadcast = 100
    }
}
