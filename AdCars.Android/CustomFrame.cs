using AdCars;
using AdCars.Droid;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace AdCars.Droid
{
    public class CustomFrameRenderer : FrameRenderer
    {
        public CustomFrameRenderer(Context context) : base(context)
        {

        }
        protected override void OnDraw(Canvas canvas)
        {

            var frame = Element as CustomFrame;

            var my1stPaint = new Android.Graphics.Paint();
            var my2ndPaint = new Android.Graphics.Paint();
            var backgroundPaint = new Android.Graphics.Paint();

            my1stPaint.AntiAlias = true;
            my1stPaint.SetStyle(Paint.Style.Stroke);
            my1stPaint.StrokeWidth = frame.BorderWidth + 2;
            my1stPaint.Color = frame.BorderColor.ToAndroid();

            my2ndPaint.AntiAlias = true;
            my2ndPaint.SetStyle(Paint.Style.Stroke);
            my2ndPaint.StrokeWidth = frame.BorderWidth;
            my2ndPaint.Color = frame.BackgroundColor.ToAndroid();

            backgroundPaint.SetStyle(Paint.Style.Stroke);
            backgroundPaint.StrokeWidth = 4;
            backgroundPaint.Color = frame.BackgroundColor.ToAndroid();

            Android.Graphics.Rect oldBounds = new Android.Graphics.Rect();
            canvas.GetClipBounds(oldBounds);

            RectF oldOutlineBounds = new RectF();
            oldOutlineBounds.Set(oldBounds);

            RectF myOutlineBounds = new RectF();
            myOutlineBounds.Set(oldBounds);
            myOutlineBounds.Top += (int)my2ndPaint.StrokeWidth + 3;
            myOutlineBounds.Bottom -= (int)my2ndPaint.StrokeWidth + 3;
            myOutlineBounds.Left += (int)my2ndPaint.StrokeWidth + 3;
            myOutlineBounds.Right -= (int)my2ndPaint.StrokeWidth + 3;

            canvas.DrawRoundRect(oldOutlineBounds, 10, 10, backgroundPaint); //to "hide" old outline
            canvas.DrawRoundRect(myOutlineBounds, frame.CornerRadius, frame.CornerRadius, my1stPaint);
            canvas.DrawRoundRect(myOutlineBounds, frame.CornerRadius, frame.CornerRadius, my2ndPaint);

            base.OnDraw(canvas);
        }

    }
}