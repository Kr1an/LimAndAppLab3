using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Graphics;
using System.IO;
using Android.Content.Res;

namespace Application.Fragments
{
	public class AddOption : BaseFragment
	{
		private View curView;
		private ImageButton addButton;
		private TextView nameTextView;
		private SeekBar alcoholSeekBar;
		private SeekBar massSeekBar;

		private int ImgIndex=1;
		private String Name;
		private int Mass;
		private int AlcoholMass;
		private byte[] ImgArray;

		private List<ImageButton> ColorBtns;
		private List<ImageButton> IconBtns;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}


		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			FindViews();
			HandleEvents();
		}
		public void FindViews(View view)
		{

			base.FindViews();

			addButton = view.FindViewById<ImageButton>(Resource.Id.AddButton);
			nameTextView = view.FindViewById<TextView>(Resource.Id.nameTextView);
			alcoholSeekBar = view.FindViewById<SeekBar>(Resource.Id.alcoholSeekBar);
			massSeekBar = view.FindViewById<SeekBar>(Resource.Id.massSeekBar);
			FindViewsColorBtn();
			FindViewsIconBtn();
		}

		private void FindViewsIconBtn()
		{
			/*IconBtns = new List<ImageButton>();
			ImageButton temp = curView.FindViewById<ImageButton>(Resource.Id.imageButton1);
			temp.Click += Temp_Click;
			temp.re
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton1));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton2));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton3));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton4));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton5));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton6));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton7));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton8));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton9));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton10));
			IconBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.imageButton11));
			IconBtns[10].Click += (object sender, EventArgs e)=> { ImgIndex = 0 + 1; Toast.MakeText(this.Activity, "not not not " + ImgIndex, ToastLength.Long).Show(); };
			for (int i = 0; i < IconBtns.Count; i++)
			{
				IconBtns[i].Click -= (object sender, EventArgs e) => {
					ImgIndex = i + 1;
					Toast.MakeText(this.Activity, "index is " + ImgIndex, ToastLength.Long).Show();
				};
			}*/
		}

		private void Temp_Click(object sender, EventArgs e)
		{
			Toast.MakeText(this.Activity, "ou yes, " + 1, ToastLength.Short).Show();
		}

		private void AddOption_Click(object sender, EventArgs e)
		{
			
			throw new NotImplementedException();
		}

		private void FindViewsColorBtn()
		{
			ColorBtns = new List<ImageButton>();

			ColorBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.colorButton1));
			ColorBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.colorButton2));
			ColorBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.colorButton3));
			ColorBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.colorButton4));
			ColorBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.colorButton5));
			ColorBtns.Add(curView.FindViewById<ImageButton>(Resource.Id.colorButton6));

			for (int i = 0; i < ColorBtns.Count; i++)
			{
				ColorBtns[i].Click += (object sender, EventArgs e) =>
				{
					Color tempColor = new Color();
					switch (i)
					{
						case 1: tempColor = Color.Rgb(0, 0, 0); break;
						case 2: tempColor = Color.Rgb(255, 218, 68); break;
						case 3: tempColor = Color.Rgb(145, 220, 90); break;
						case 4: tempColor = Color.Rgb(0, 109, 240); break;
						case 5: tempColor = Color.Rgb(147, 62, 197); break;
					}

					ChangeColor(Resource.Drawable.im1, tempColor, 1);
					ChangeColor(Resource.Drawable.im2, tempColor, 2);
					ChangeColor(Resource.Drawable.im3, tempColor, 3);
					ChangeColor(Resource.Drawable.im4, tempColor, 4);
					ChangeColor(Resource.Drawable.im5, tempColor, 5);
					ChangeColor(Resource.Drawable.im6, tempColor, 6);
					ChangeColor(Resource.Drawable.im7, tempColor, 7);
					ChangeColor(Resource.Drawable.im8, tempColor, 8);
					ChangeColor(Resource.Drawable.im9, tempColor, 9);
					ChangeColor(Resource.Drawable.im10, tempColor, 10);
					ChangeColor(Resource.Drawable.im11, tempColor, 11);




				};
			}
		}
		public void ChangeColor(Int32 id, Color color, int index)
		{
			BitmapFactory.Options options = new BitmapFactory.Options();
			options.InMutable = true;
			Bitmap bmp = BitmapFactory.DecodeResource(Resources, id, options);
			Color tmpColor;
			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Height; y++)
				{
					int pixel = bmp.GetPixel(x, y);
					tmpColor = Color.Argb(pixel, pixel, pixel, pixel);
					bmp.SetPixel(x, y, Color.Argb(tmpColor.A, color.R, color.G, color.B));
				}
			}
			var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
			var filename = System.IO.Path.Combine(path, "im"+index+".png");
			Save(filename, bmp);
			
			
			




		}
		public void Save(string path, Bitmap bitmap)
		{
			
			using (var os = new FileStream(path, FileMode.Create))
			{
				bitmap.Compress(Bitmap.CompressFormat.Png, 95, os);
			}
		}

		public void HandleEvents()
		{
			base.HandleEvents();

			addButton.Click += AddButton_Click;
			

		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if(nameTextView.Text.Length >= 2 && massSeekBar.Progress > 0)
			{

			}
			
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			curView = inflater.Inflate(Resource.Layout.AddOption, container, false);
			FindViews(curView);
			HandleEvents();
			return curView;
		}
	}
}