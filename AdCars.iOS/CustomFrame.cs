using AdCars;
using AdCars.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]

namespace AdCars.iOS
{
    public class CustomFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
             
            var frame = (CustomFrame)Element;
            if (frame == null)
                return; 

            if (frame.HasShadow)
            {
                this.Layer.ShadowColor = frame.ShadowColor.ToCGColor();
            }

            if (frame.BorderWidth > 0)
            {
                this.Layer.BorderColor = frame.BorderColor.ToCGColor();
                this.Layer.BorderWidth = frame.BorderWidth;
            }

        }
    }
}