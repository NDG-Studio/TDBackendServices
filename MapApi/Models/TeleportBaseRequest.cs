using System;
namespace MapApi.Models
{
	public class TeleportBaseRequest
	{
		public int CoordX { get; set; }
		public int CoordY { get; set; }
		public double Distance { get; set; }
	}
}

