using System;
using System.Collections.Generic;
using System.IO;
using terrain;

namespace terrain
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2 || args.Length > 3)
            {
                Console.WriteLine("usage: Json2wmapConv.exe jsonfile wmapfile");
                return;
            }
            try
            {
                var fi = new FileInfo(args[0]);
                if (fi.Exists)
                    if (args.Length != 3)
                        terrain.Json2Wmap.Convert(args[0], args[1]);
                    else
                        terrain.Json2Wmap.ConvertReverse(args[0], args[1]);
                else
                {
                    Console.WriteLine("input file not found: " + fi.FullName);
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e);
            }
            Console.WriteLine("done");
        }
    }
}