using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Provider;
using Android.Content.PM;
using Java.IO;
using Android.Net;
using System;
using Android.Graphics;

namespace TestLec3
{
    [Activity(Label = "TestLec3",  Icon = "@drawable/icon")]
    public class IntentActivity : Activity
    {
        File _file;
        File _dir;
        ImageView _imageView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_intent);

            _dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
            Android.OS.Environment.DirectoryPictures), "TestLec3");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }

            // Get our button from the layout resource,
            // and attach an event to it
            var callButton = FindViewById<Button>(Resource.Id.callButton);
            var cameraButton = FindViewById<Button>(Resource.Id.cameraButton);
            var newActivityButton = FindViewById<Button>(Resource.Id.newActivityButton);
            _imageView = FindViewById<ImageView>(Resource.Id.imageView);


            callButton.Click += (obj, args) =>
            {
                var callIntent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel:223322223322"));
                StartActivity(callIntent);
            };
            cameraButton.Click += (obj, args) =>
            {
                if (IsThereAnAppToTakePictures())
                {
                    TakeAPicture();
                }else
                {
                    Toast.MakeText(this, "There is no apps for taking photos", ToastLength.Long);
                }
            };

            newActivityButton.Click += (obj, args) =>
            {
                var activityIntent = new Intent(this, typeof(ActivityToStart));
                activityIntent.PutExtra("NewActivityExtra", "Hello From Intent Activity");
                StartActivity(activityIntent);
            };


        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            var bitmap = LoadAndResizeBitmap(_file.Path, width, height);
            if (bitmap != null)
            {
                _imageView.SetImageBitmap(bitmap);
                bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }

        #region utility methods
        Bitmap LoadAndResizeBitmap(string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }


        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
            StartActivityForResult(intent, 0);

        }

        #endregion

    }
}

