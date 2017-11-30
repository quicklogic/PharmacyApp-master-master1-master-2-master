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
using Xamarin.Forms;
using PharmacyApp.Droid;
using Xamarin.Forms.Platform.Android;
using PharmacyApp;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace PharmacyApp.Droid
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
            if (Control == null)
            {
                Xamarin.Forms.Button button = new Xamarin.Forms.Button();
                button.BorderRadius = 100;
                button.BorderColor = Color.Green;
            }
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                Xamarin.Forms.Button button = new Xamarin.Forms.Button();
                button.BorderRadius = 100;
                button.BorderColor = Color.Green;
            }

        }

    }
}
