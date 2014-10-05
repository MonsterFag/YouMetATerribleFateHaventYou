using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Item_Generator
{
    class CreateItem
    {
        public static string name { get; set; }
        public static string id { get; set; }
        public static string file { get; set; }
        public static string index { get; set; }
        public static bool remote { get; set; }
        public static string remotetexture { get; set; }
        public static string tier { get; set; }
        public static string itemtype { get; set; }
        public static string slottype { get; set; }

        public static void Execute()
        {
            if (tier.StartsWith("Tier"))
            {
                tier = tier.Last().ToString();
            }
            

            switch (itemtype)
            {
                case "Sword": slottype = "1";
                    break;
                case "Dagger": slottype = "2";
                    break;
                case "Bow": slottype = "3";
                    break;
                case "Tome": slottype = "4";
                    break;
                case "Shield": slottype = "5";
                    break;
                case "Leather Armor": slottype = "6";
                    break;
                case "Heavy Armor": slottype = "7";
                    break;
                case "Wand": slottype = "8";
                    break;
                case "Ring": slottype = "9";
                    break;
                case "Spell": slottype = "11";
                    break;
                case "Seal": slottype = "12";
                    break;
                case "Cloak": slottype = "13";
                    break;
                case "Robe": slottype = "14";
                    break;
                case "Quiver": slottype = "15";
                    break;
                case "Helm": slottype = "16";
                    break;
                case "Staff": slottype = "17";
                    break;
                case "Poison": slottype = "18";
                    break;
                case "Skull": slottype = "19";
                    break;
                case "Trap": slottype = "20";
                    break;
                case "Orb": slottype = "21";
                    break;
                case "Prism": slottype = "22";
                    break;
                case "Scepter": slottype = "23";
                    break;
                case "Katana": slottype = "24";
                    break;
                case "Shuriken": slottype = "25";
                    break;
                case "Halo": slottype = "26";
                    break;
                case "Samurai Scroll": slottype = "27";
                    break;
                case "Summoning Scroll": slottype = "28";
                    break;
                case "Pearl": slottype = "30";
                    break;
                case "Turret": slottype = "32";
                    break;
                
            }
            var dir = @"Items";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (var writer = new StreamWriter(@"Items\Tests.txt", true))
            {
                writer.WriteLine(@"<Object type=""" + id + @""" id=""" + name + @""">");
                writer.WriteLine("<Class>Equipment</Class>");
                writer.WriteLine("<Item/>");
                if (remote)
                {
                    writer.WriteLine("<RemoteTexture>");
                    writer.WriteLine("<Id>draw:" + remotetexture + "</Id>");
                    writer.WriteLine("</RemoteTexture>");
                }
                else if (!remote)
                {
                    writer.WriteLine("<Texture>");
                    writer.WriteLine("<File>" + file + "</File>");
                    writer.WriteLine("<Index>" + index + "<Index>");
                    writer.WriteLine("</Texture>");
                }
                if (tier != "UT")
                {
                    writer.WriteLine("<Tier>" + tier + "</tier>");
                }
                writer.WriteLine("<SlotType>" + slottype + "<SlotType>");
            }
        }   
    }
    
}
