using System;
using System.Data;
using System.IO;
using SQLite;
using System.Collections.Generic;

namespace Application.MYDB
{
	public class DBRepository
	{
		//code to create database
		public static int ID_VALUE;
		public static string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Drinks.db3");

		public void Values_init()
		{
			ID_VALUE = (new SQLiteConnection(PATH).Table<Drinks>().Count()) + 1;
		}

		public void CreateDB()
		{
			var db = new SQLiteConnection(PATH);
		}

		public void CreateTable()
		{
				var db = new SQLiteConnection(PATH);
				db.CreateTable<Drinks>();
		}

		public void InsertRecord(Drinks item)
		{
				var db = new SQLiteConnection(PATH);
				db.Insert(new Drinks(){ Name = item.Name, ImgArray = item.ImgArray, AlcoholMass = item.AlcoholMass, Mass = item.Mass, Id = DBRepository.ID_VALUE++ });
		}
		public List<Drinks> GetAllRecords()
		{
			var db = new SQLiteConnection(PATH);
			var table = db.Table<Drinks>();
			var list = new List<Drinks>();
			foreach (var item in table)
			{
				list.Add(item);
			}
			return list;
		}
		public Drinks GetItemById(int id)
		{
			
			var db = new SQLiteConnection(PATH);

			var item = db.Get<Drinks>(id);
			return item;
		}
		public void updateRecord(int id, Drinks ch)
		{
			var db = new SQLiteConnection(PATH);

			var item = db.Get<Drinks>(id);

			item.Name = ch.Name;
			item.ImgArray = ch.ImgArray;
			item.Mass = ch.Mass;
			item.AlcoholMass = ch.AlcoholMass;

			db.Update(item);
		}
		public void RemoveTask(int id)
		{
			var db = new SQLiteConnection(PATH);
			var list = new List<Drinks>();

			var item = db.Get<Drinks>(id);
			db.Delete(item);
			var table = db.Table<Drinks>();

			foreach(var x in table)
			{
				list.Add(x);
			}
			this.RemoveAll();
			DBRepository.ID_VALUE = 1;
			foreach(var x in list)
			{
				InsertRecord(x);
			}
		}
		public void RemoveAll()
		{
			var db = new SQLiteConnection(PATH);
			var table = db.Table<Drinks>();

			foreach (var item in table)
			{
				db.Delete(item);
			}
			DBRepository.ID_VALUE = 1;
		}
	}
}