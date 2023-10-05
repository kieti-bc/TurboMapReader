using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace TurboMapReader
{
	public class MapLayer
	{
		public int[] data;  // "data":[. . .]
		public int height;  // "height":20,
		public int id;
		public string name; //  "name":"Ground Layer",
		public string type;
		public bool visible;
		public int width;   //  "width":30,
		public int x;
		public int y;
	}

	public class Tileset
	{
		public int firstgid;
		public string source;
	}

	public class TiledMap
	{
		public int compressionLevel;
		public int height;
		public bool infinite;

		public List<MapLayer> layers;

		public int nextlayerid;
		public int nextobjectid;
		public string orientation;
		public string renderorder;
		public string tiledversion;
		public int tileheight;    //  "tileheight":16,

		public List<Tileset> tilesets;

		public int tilewidth;     //  "tilewidth":16,
		public string type;
		public string version;
		public int width;
	}
	public class MapReader
	{
		/// <summary>
		/// Attempts to load a Tiled Map file
		/// from given file.
		/// On success returns a TiledMap instance
		/// that is populated with the data.
		/// If reading fails a Null is returned instead.
		/// </summary>
		/// <param name="filename">Filename of a file. The file must be a .json file that has been exported from Tiled without compression.</param>
		/// <returns>The data in the file wrapped in a TiledMap instance or null if reading fails.</returns>
		public static TiledMap? LoadMapFromFile(string filename)
		{
			StreamReader fileReader = new StreamReader(filename);
			string fileContents = fileReader.ReadToEnd();

			try
			{
				TiledMap mapData = JsonConvert.DeserializeObject<TiledMap>(fileContents);
				return mapData;
			}
			catch (JsonReaderException e)
			{
				Console.Write("Could not read Tiled map file: ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(filename);
				Console.ResetColor();
				Console.WriteLine("Error message: " + e.Message);
				return null;
			}
		}
	}
}