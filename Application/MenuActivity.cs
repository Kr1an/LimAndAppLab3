using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Application.MYDB;

using System;

using System.IO;
using Android.Media;
using System.ComponentModel;
using Android.Graphics;
using System.Collections.Generic;

namespace Application
{
	[Activity(Label = "Limitless", MainLauncher = true, Icon = "@drawable/icon")]
	public class MenuActivity : Activity
	{
		private ImageButton btnLvl1;
		private ImageButton btnLvl2;
		private ImageButton btnLvl3;
		private ImageButton btnLvl4;
		private ImageButton btnSetting;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.MainMenu);

			FindViews();
			HandleEvents();
			BDHandler();
		}

		private void BDHandler()
		{
			Bitmap bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Drunk_Lvl_3);
			var ms = new MemoryStream();
			bitmap.Compress(Bitmap.CompressFormat.Png, 0, ms);
			byte[] imgBytes = ms.ToArray();

			DBRepository dbr = new DBRepository();
			
			dbr.CreateDB();
			dbr.CreateTable();
			dbr.Values_init();
			dbr.RemoveAll();
			dbr.InsertRecord(new MYDB.Drinks() { Name = "Beer", AlcoholMass = 8, Mass = 2, ImgArray = imgBytes });
			dbr.InsertRecord(new MYDB.Drinks() { Name = "Wine", AlcoholMass = 4, Mass = 2, ImgArray = imgBytes });
			dbr.InsertRecord(new MYDB.Drinks() { Name = "Shvapse", AlcoholMass = 1, Mass = 2, ImgArray = imgBytes });
			dbr.InsertRecord(new MYDB.Drinks() { Name = "Pepsi", AlcoholMass = 60, Mass = 2, ImgArray = imgBytes });
			dbr.InsertRecord(new MYDB.Drinks() { Name = "Cola", AlcoholMass = 0, Mass = 2, ImgArray = imgBytes });
			dbr.RemoveTask(3);
			List<Drinks> list = dbr.GetAllRecords();
			btnLvl1.SetImageBitmap(BitmapFactory.DecodeByteArray(list[0].ImgArray, 0, list[0].ImgArray.Length) );





		}

		protected override void OnRestart()
		{
			base.OnRestart();
		}
		private void FindViews()
		{
			btnLvl1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
			btnLvl2 = FindViewById<ImageButton>(Resource.Id.imageButton2);
			btnLvl3 = FindViewById<ImageButton>(Resource.Id.imageButton3);
			btnLvl4 = FindViewById<ImageButton>(Resource.Id.imageButton4);
			btnSetting = FindViewById<ImageButton>(Resource.Id.imageButton5);
		}
		private void HandleEvents()
		{
			btnLvl1.Click += BtnLvl1_Click;
			btnLvl2.Click += BtnLvl2_Click;
			btnLvl3.Click += BtnLvl3_Click;
			btnLvl4.Click += BtnLvl4_Click;
			btnSetting.Click += BtnSetting_Click;

		}

		private void BtnSetting_Click(object sender, EventArgs e)
		{
			var intent = new Intent(this, typeof(OptionActivity));
			StartActivity(intent);
		}

		private void BtnLvl4_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnLvl3_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnLvl2_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnLvl1_Click(object sender, EventArgs e)
		{
			var intent = new Intent(this, typeof(Content));
			StartActivity(intent);
		}
	}
}

