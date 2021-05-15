﻿using AdCars.Droid;
using AdCars.ViewModels;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace AdCars.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {  
        public CustomEntryRenderer(Context context):base(context)
        { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.White);
                Control.SetPadding(30, 30, 30, 30); 
            }
        }
    }
}