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
    [Activity(Label = "ActivityToStart")]
    public class ActivityToStart : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.activity_to_start);

            var text = FindViewById<TextView>(Resource.Id.text);
            text.Text = Intent.GetStringExtra("NewActivityExtra") ?? "Data not available";
        }
    }
}