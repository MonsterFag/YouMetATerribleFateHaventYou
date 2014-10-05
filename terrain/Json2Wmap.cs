using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using db.data;
using Ionic.Zlib;
using Newtonsoft.Json;

namespace terrain
{
    public class Json2Wmap
    {
        public static void ConvertReverse(string from, string to)
        {
            var x = ConvertReverse(File.ReadAllBytes(from));
            File.WriteAllText(to, x);
        }

        public static void Convert(string from, string to)
        {
            var x = Convert(File.ReadAllText(from));
            File.WriteAllBytes(to, x);
        }

        public static string ConvertReverse(byte[] wmap)
        {
            var obj = new json_dat();
            var terdict = new List<TerrainTile>();
            var dict = new List<loc>();

            var wmb = wmap.ToList();
            wmb.RemoveAt(0);
            wmap = ZlibStream.UncompressBuffer(wmb.ToArray());

            var dat = new List<byte>();
            var newDat = new List<short>();
            using (var rdr = new BinaryReader(new MemoryStream(wmap)))
            {
                var dicLength = rdr.ReadInt16();
                for (short i = 0; i < dicLength; i++)
                {
                    terdict.Add(new TerrainTile
                    {
                        TileId = rdr.ReadInt16(),
                        TileObj = rdr.ReadString(),
                        Name = rdr.ReadString(),
                        Terrain = (TerrainType) rdr.ReadByte(),
                        Region = (TileRegion) rdr.ReadByte()
                    });
                }
                obj.width = rdr.ReadInt32();
                obj.height = rdr.ReadInt32();
                dat = rdr.ReadBytes(obj.width*obj.height*3).ToList();
            }
            using (var rdr = new BinaryReader(new MemoryStream(dat.ToArray())))
            {
                for (var i = 0; i < obj.width*obj.height; i++)
                {
                    newDat.Add(rdr.ReadInt16());
                    rdr.ReadByte(); //Elevation, don't need
                }
            }
            foreach (var i in terdict)
            {
                dict.Add(new loc
                {
                    ground = XmlDatas.TileDescs[i.TileId].ObjectId,
                    objs = i.TileObj == null ? null : new[] {new obj {id = i.TileObj, name = i.Name}},
                    regions =
                        i.Region == TileRegion.None
                            ? null
                            : new[] {new obj {id = i.Region.ToString().Replace('_', ' '), name = ""}}
                });
            }

            var s = new MemoryStream();
            using (var wtr = new NWriter(s))
            {
                foreach (var i in newDat)
                {
                    wtr.Write(i);
                }
            }

            obj.dict = dict.ToArray();

            obj.data = ZlibStream.CompressBuffer(s.ToArray());
            return JsonConvert.SerializeObject(obj);
        }

        public static byte[] Convert(string json)
        {
            var obj = JsonConvert.DeserializeObject<json_dat>(json);
            var dat = ZlibStream.UncompressBuffer(obj.data);

            var tileDict = new Dictionary<short, TerrainTile>();
            for (var i = 0; i < obj.dict.Length; i++)
            {
                var o = obj.dict[i];
                tileDict[(short) i] = new TerrainTile
                {
                    TileId = o.ground == null ? (short) 0xff : XmlDatas.IdToType[o.ground],
                    TileObj = o.objs == null ? null : o.objs[0].id,
                    Name = o.objs == null ? "" : o.objs[0].name ?? "",
                    Terrain = TerrainType.None,
                    Region =
                        o.regions == null
                            ? TileRegion.None
                            : (TileRegion) Enum.Parse(typeof (TileRegion), o.regions[0].id.Replace(' ', '_'))
                };
            }

            var tiles = new TerrainTile[obj.width, obj.height];
            using (var rdr = new NReader(new MemoryStream(dat)))
                for (var y = 0; y < obj.height; y++)
                    for (var x = 0; x < obj.width; x++)
                    {
                        tiles[x, y] = tileDict[rdr.ReadInt16()];
                    }
            return WorldMapExporter.Export(tiles);
        }

        public static byte[] ConvertMakeWalls(string json)
        {
            var obj = JsonConvert.DeserializeObject<json_dat>(json);
            var dat = ZlibStream.UncompressBuffer(obj.data);

            var tileDict = new Dictionary<short, TerrainTile>();
            for (var i = 0; i < obj.dict.Length; i++)
            {
                var o = obj.dict[i];
                tileDict[(short) i] = new TerrainTile
                {
                    TileId = o.ground == null ? (short) 0xff : XmlDatas.IdToType[o.ground],
                    TileObj = o.objs == null ? null : o.objs[0].id,
                    Name = o.objs == null ? "" : o.objs[0].name ?? "",
                    Terrain = TerrainType.None,
                    Region =
                        o.regions == null
                            ? TileRegion.None
                            : (TileRegion) Enum.Parse(typeof (TileRegion), o.regions[0].id.Replace(' ', '_'))
                };
            }

            var tiles = new TerrainTile[obj.width, obj.height];
            using (var rdr = new NReader(new MemoryStream(dat)))
                for (var y = 0; y < obj.height; y++)
                    for (var x = 0; x < obj.width; x++)
                    {
                        tiles[x, y] = tileDict[rdr.ReadInt16()];
                        tiles[x, y].X = x;
                        tiles[x, y].Y = y;
                    }

            foreach (var i in tiles)
            {
                if (i.TileId == 0xff && i.TileObj == null)
                {
                    var createWall = false;
                    for (var ty = -1; ty <= 1; ty++)
                        for (var tx = -1; tx <= 1; tx++)
                            try
                            {
                                if (tiles[i.X + tx, i.Y + ty].TileId != 0xff)
                                    createWall = true;
                            }
                            catch
                            {
                            }
                    if (createWall)
                        tiles[i.X, i.Y].TileObj = "Grey Wall";
                }
            }

            return WorldMapExporter.Export(tiles);
        }

        private struct json_dat
        {
            public byte[] data;
            public loc[] dict;
            public int height;
            public int width;
        }

        private struct loc
        {
            public string ground;
            public obj[] objs;
            public obj[] regions;
        }

        private struct obj
        {
            public string id;
            public string name;
        }
    }
}