using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using db;
using db.data;

namespace admincmd
{
    class Program
    {
        static Account acc;
        static Database db;

        static string uuid;
        static string pass;

        static string server = "198.27.110.117";

        static void Main(string[] args)
        {
            db = new Database();
            Console.WriteLine("Please log in.");
            LoginPrompt();
        }
        static Client Connect()
        {
            try
            {
                var ret = new Client(server);
                return ret;
            }
            catch
            {
                Console.WriteLine("Failed to connect to server.");
                return null;
            }
        }
        static void LoginPrompt()
        {
            Console.Write("Username: ");
            uuid = Console.ReadLine();
            Console.Write("Password: ");
            pass = Console.ReadLine();
            if ((acc = db.Verify(uuid, pass)) == null)
            {
                Console.WriteLine("Account does not exist.");
                LoginPrompt();
            }
            if (acc.Rank < 5)
            {
                Console.WriteLine("Admin console access denied.");
                LoginPrompt();
            }
            File.WriteAllText("lastlogin", uuid);
            Console.WriteLine("Type \"help\" for available commands.");
            Input();
        }
        static void Input()
        {
            Console.Write("> ");
            string inp = Console.ReadLine();
            Command(inp);
        }
        static void Help()
        {
            Console.WriteLine(@"Commands:
  help - This command.
  gift <player name> <item name> - Gifts item to one player.
  giftall <item name> - Gifts item to all players.
  giftip <item name> - Gifts item to all IPs.
  say <message> - Test
");
        }
        static void Command(string input)
        {
            if (input.Length == 0)
            {
                Console.WriteLine("No command specified.");
                Input();
                return;
            }
            var argl = input.Split(' ').ToList(); argl.RemoveAt(0); var args = argl.ToArray();
            var cmd = input.Split(' ')[0];
            switch (cmd)
            {
                case "help":
                    Help(); break;
                case "gift":
                    if (args.Length < 2)
                        Console.WriteLine("Usage: gift <player name> <item name>");
                    else
                        SendGift(args[0], string.Join(" ", args, 1, args.Length - 1));
                    break;
                case "giftall":
                    if (args.Length < 1)
                        Console.WriteLine("Usage: giftall <item name>");
                    else
                        SendGifts(false, string.Join(" ", args));
                    break;
                case "giftip":
                    if (args.Length < 1)
                        Console.WriteLine("Usage: giftip <item name>");
                    else
                        SendGifts(true, string.Join(" ", args));
                    break;
                case "say":
                    if (args.Length < 1)
                        Console.WriteLine("Usage: say <message>");
                    else
                        BroadcastMessage(string.Join(" ", args));
                    break;
                case "crash":
                    if (args.Length < 1)
                        Console.WriteLine("Usage: crash <ip>");
                    else
                        CrashServer(args[0]);
                    break;
                default:
                    Console.WriteLine("Unknown command."); break;
            }
            Input();
        }

        static void SendGift(string name, string itemname)
        {
            short itemId;
            if (!XmlDatas.IdToType.TryGetValue(itemname, out itemId))
            {
                Console.WriteLine("Unknown item.");
                return;
            }
            List<short> itens = new List<short>();
            var cmd = db.CreateQuery();
            cmd.CommandText = "SELECT * FROM accounts WHERE name=@name";
            cmd.Parameters.AddWithValue("@name",name);
            int accId;
            using (var rdr = cmd.ExecuteReader())
            {
                if (!rdr.HasRows)
                {
                    Console.WriteLine("Unknown player.");
                    return;
                }
                rdr.Read();
                itens = Utils.FromCommaSepString16(rdr.GetString("bonuses")).ToList();
                accId = rdr.GetInt32("id");
            }
            itens.Add(itemId);
            if (db.SetBonuses(accId, itens))
            {
                Console.WriteLine("Gifted item to " + name + ".");
            }
            else
            {
                Console.WriteLine("Could not gift item.");
            }
        }
        static void SendGifts(bool ip, string itemname)
        {
            short itemId;
            if(!XmlDatas.IdToType.TryGetValue(itemname, out itemId))
            {
                Console.WriteLine("Unknown item.");
                return;
            }
            if (ip)
            {
                Dictionary<string, List<short>> itens = new Dictionary<string, List<short>>();
                var cmd = db.CreateQuery();
                cmd.CommandText = "SELECT * FROM ips WHERE banned=0";
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                        itens.Add(rdr.GetString("ip"), Utils.FromCommaSepString16(rdr.GetString("gifts")).ToList());
                foreach (var i in itens)
                {
                    i.Value.Add(itemId);
                    db.SetBonuses(i.Key, i.Value);
                }
                Console.WriteLine("Added item to all IPs.");
            }
            else
            {
                Dictionary<int, List<short>> itens = new Dictionary<int, List<short>>();
                var cmd = db.CreateQuery();
                cmd.CommandText = "SELECT * FROM accounts WHERE banned=0";
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                        itens.Add(rdr.GetInt32("id"), Utils.FromCommaSepString16(rdr.GetString("bonuses")).ToList());
                foreach (var i in itens)
                {
                    i.Value.Add(itemId);
                    db.SetBonuses(i.Key, i.Value);
                }
                Console.WriteLine("Added item to all accounts.");
            }
        }
        static void BroadcastMessage(string msg)
        {
            var c = Connect();
            if (c != null)
            {
                c.BroadcastMessage(msg, uuid, pass);
                Console.WriteLine("Broadcasted message.");
                c.Close();
            }
        }
        static void TestHello()
        {
            var c = Connect();
            if (c != null)
            {
                c.TestHello(uuid, pass);
                c.Close();
            }
        }
        static void CrashServer(string ip)
        {
            Client c;
            try
            {
                c = new Client(ip);
            }
            catch
            {
                Console.WriteLine("Failed to connect to server.");
                return;
            }
            Random r = new Random();
            while (r.Next(1, 50) != 5)
            {
                c.BroadcastMessage("I COMMAND THEE TO SHUT DOWN", "", "");
            }
            c.Close();
        }
    }
}
