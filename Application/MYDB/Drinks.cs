using System;
using System.Data;
using System.IO;
using SQLite;
using System.Drawing;
using Android.Graphics;
using Mono.Data.Sqlite;



namespace Application.MYDB
{
	[Table("Drinks")]
	public class Drinks
	{
		[PrimaryKey, Column("_Id")]
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }
		public byte[] ImgArray { get; set; }
		public int AlcoholMass { get; set; }
		public int Mass { get; set; }



	}
}