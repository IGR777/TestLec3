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
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.activity_main);

            var intentsButton = FindViewById<Button>(Resource.Id.intentsButton);
            var layoutsButton = FindViewById<Button>(Resource.Id.layoutsButton);
            var resourcesButton = FindViewById<Button>(Resource.Id.resourcesButton);
            var fragmentsButton = FindViewById<Button>(Resource.Id.fragmentsButton);

            intentsButton.Click += (obj, args) =>
            {
                StartActivity(new Intent(this, typeof(IntentActivity)));
            };
            layoutsButton.Click += (obj, args) =>
            {
                StartActivity(new Intent(this, typeof(LayoutActivity)));
            };
            resourcesButton.Click += (obj, args) =>
            {
                StartActivity(new Intent(this, typeof(ResourcesActivity)));
            };
            fragmentsButton.Click += (obj, args) =>
            {
                StartActivity(new Intent(this, typeof(FragmentsActivity)));
            };
        }
    }
}