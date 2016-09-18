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
using Application.Fragments;
using static Android.Resource;
using RadialProgress;

namespace Application
{
	[Activity(Label = "Content")]
	public class Content : Activity
	{
		private RadialProgressView radialProgress;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Content);

			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			FindViews();
			HandleEvents();

			AddTab(" FAVORIT", Resource.Drawable.Favorit, new Favorite());
			AddTab(" ALL", Resource.Drawable.All, new All());
			AddTab(" ADD", Resource.Drawable.Add, new AddOption());

		}

		private void FindViews()
		{
			radialProgress = FindViewById<RadialProgressView>(Resource.Id.progressView);
			
		}

		private void HandleEvents()
		{
			radialProgress.LayoutChange += RadialProgress_LayoutChange; ; 
			radialProgress.Click += RadialProgress_Click;
		}

		private void RadialProgress_LayoutChange(object sender, View.LayoutChangeEventArgs e)
		{
			Toast.MakeText(this, "testText", ToastLength.Short);
		}

		private void RadialProgress_Click(object sender, EventArgs e)
		{
			radialProgress.Value++;
		}

		private void RadialProgress_ScrollChange(object sender, View.ScrollChangeEventArgs e)
		{
			Toast.MakeText(this, "testText", ToastLength.Short);
		}

		private void AddTab(string tabText, int iconResourceId, Fragment view)
		{
			var tab = this.ActionBar.NewTab();
			tab.SetText(tabText);
			tab.SetIcon(iconResourceId);

			tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
			{
				var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
				if (fragment != null)
					e.FragmentTransaction.Remove(fragment);
				e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
			};
			tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
			{
				e.FragmentTransaction.Remove(view);
			};

			this.ActionBar.AddTab(tab);

		}
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (resultCode == Result.Ok && requestCode == 100)
			{
				/*var selectedHotDog = hotDogDataService.GetHotDogById(data.GetIntExtra("selectedHotDogId", 0));

				var dialog = new AlertDialog.Builder(this);
				dialog.SetTitle("Confirmation");
				dialog.SetMessage(string.Format("You've added {0} time(s) the {1}", data.GetIntExtra("amount", 0), selectedHotDog.Name));
				dialog.Show();*/
			}
		}
	}
}