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
    [Activity(Label = "FragmentsActivity")]
    public class FragmentsActivity : Activity
    {
        int counter = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_fragments);

            
            var changeButton = FindViewById<Button>(Resource.Id.fragment_change_button);

            var redFragment = new LifecycleFragment(Resource.Layout.fragment_red, "Red");
            var greenFragment = new LifecycleFragment(Resource.Layout.fragment_green, "Green");
            var blueFragment = new LifecycleFragment(Resource.Layout.fragment_blue, "Blue");

            changeButton.Click += (obj, args) =>
            {
                var fragmentIndex = counter++ % 3;

                switch (fragmentIndex)
                {
                    case 0:
                        FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, redFragment).Commit();
                        break;
                    case 1:
                        FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, greenFragment).Commit();
                        break;
                    case 2:                    
                        FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, blueFragment).Commit();
                        break;
                }
            };
        }
    }
}