using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Arctouch.Movies.Core.Application.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Arctouch.Movies.Presentation.Droid.Activities
{
    [Activity(Label = "Movies Detail", NoHistory = true, Theme = "@style/AppTheme")]
    public class MovieDetailsActivity : MvxAppCompatActivity<MovieDetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.movie_details);

            Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);

            Toast.MakeText(this, "Loading movie details...", ToastLength.Long);
        }
    }
}

