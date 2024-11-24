using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.CurrentActivity;
using statuBar_NCL.Droid.statusbar;
using statuBar_NCL.VistaModelo;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly:Dependency(typeof(StatusBar))]

namespace statuBar_NCL.Droid.statusbar
{
    internal class StatusBar : VMstatusbar
    {
        WindowManagerFlags _originalFlags;
        Window GetCurrentwindow()
        {
            var Window = CrossCurrentActivity.Current.Activity.Window;
            Window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return Window;
        }
        public void CambiarColor()
        {
            if(Build.VERSION.SdkInt>= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentwindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Rgb(18, 18, 18));
                });
                    

            }
        }

        public void MostarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }

        public void OcultarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            activity.Window.Attributes = attrs;
        }

        public void Transparente()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentwindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
                     
                });


            }
        }

        public void Traslucido()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags = WindowManagerFlags.TranslucentStatus;
            activity.Window.Attributes = attrs;
        }
    }
}