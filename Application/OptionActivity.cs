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

namespace Application
{
	[Activity(Label = "OptionActivity")]
	public class OptionActivity : Activity
	{
		private RadioGroup group2;
		private SeekBar seekBar;
		private TextView textView;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Setting);

			FindViews();
			HandleEvents();
			SeekBarHandler();
		}

		private void SeekBarHandler()
		{
			seekBar.Max = 59;
			seekBar.Progress = 27;
			textView.Text = string.Format("MASS:  {0} kg", seekBar.Progress + 40);
		}

		private void HandleEvents()
		{
			group2.CheckedChange += Group2_CheckedChange;
			seekBar.ProgressChanged += SeekBar_ProgressChanged;
		}

		private void SeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
		{
			textView.Text = string.Format("MASS:  {0} kg", e.Progress+40);
			if (e.Progress >= seekBar.Max)
				textView.Text = string.Format("MASS: >{0} kg", e.Progress + 40);
			else if (e.Progress <= 0)
				textView.Text = string.Format("MASS: <{0} kg", e.Progress + 40);
		}
		private void Group2_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
		{
			
		}
		private void FindViews()
		{
			group2 = FindViewById<RadioGroup>(Resource.Id.radioGroup2);
			seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
			textView = FindViewById<TextView>(Resource.Id.textView1);
		}
	}
}