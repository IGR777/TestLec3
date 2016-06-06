using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestLec3
{
    public class LifecycleFragment : Fragment
    {
        int _layout;

        string _name;

        public LifecycleFragment(int layout, string name) : base()
        {
            _layout = layout;
            _name = name;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            Console.WriteLine("Fragment {0}, OnCreate", _name);
        }

        public override void OnAttach(Context context)
        {

            Console.WriteLine("Fragment {0}, OnAttach", _name);
            base.OnAttach(context);
        }

        public override void OnDestroy()
        {
            Console.WriteLine("Fragment {0}, OnDestroy", _name);
            base.OnDestroy();
        }

        public override void OnDestroyView()
        {
            Console.WriteLine("Fragment {0}, OnDestroyView", _name);
            base.OnDestroyView();
        }

        public override void OnDetach()
        {
            Console.WriteLine("Fragment {0}, OnDetach", _name);
            base.OnDetach();
        }

        public override void OnPause()
        {
            Console.WriteLine("Fragment {0}, OnPause", _name);
            base.OnPause();
        }

        public override void OnResume()
        {
            Console.WriteLine("Fragment {0}, OnResume", _name);
            base.OnResume();
        }

        public override void OnStart()
        {
            Console.WriteLine("Fragment {0}, OnStart", _name);
            base.OnStart();
        }

        public override void OnStop()
        {
            Console.WriteLine("Fragment {0}, OnStop", _name);
            base.OnStart();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            Console.WriteLine("Fragment {0}, OnCreateView", _name);
            return inflater.Inflate(_layout, container, false);
        }
    }
}