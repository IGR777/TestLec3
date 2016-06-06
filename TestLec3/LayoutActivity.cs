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

namespace TestLec3
{
    [Activity(Label = "LayoutActivity")]
    public class LayoutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView (Resource.Layout.activity_layouts);

            var linearLayoutButton = FindViewById<Button>(Resource.Id.linearLayoutButton);
            var relativeLayoutButton = FindViewById<Button>(Resource.Id.relativeLayoutButton);
            var absoluteLayoutButton = FindViewById<Button>(Resource.Id.absoluteLayoutButton);

            linearLayoutButton.Click += (obj, args) =>
            {
                StartActivity(new Intent(this, typeof(LinearLayoutActivity)));
            };
            relativeLayoutButton.Click += (obj, args) =>
            {
                StartActivity(new Intent(this, typeof(RelativeLayoutActivity)));
            };
            absoluteLayoutButton.Click += (obj, args) =>
            {
                StartActivity(new Intent(this, typeof(AbsoluteLayoutActivity)));
            };
        }
    }
}