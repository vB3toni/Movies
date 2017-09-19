using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Arctouch.Movies.Core.Application.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Arctouch.Movies.Presentation.Droid.Activities
{
    [Activity(Label = "Arctouch Movies", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        private Toolbar _tbMenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main);

            _tbMenu = FindViewById<Toolbar>(Resource.Id.main_tbmenu);
            var search = _tbMenu.Menu.FindItem(Resource.Id.menu_search);
            var searchView = search.ActionView.JavaCast<Android.Support.V7.Widget.SearchView>();
            searchView.QueryHint = "Search movies...";
            searchView.QueryTextChange += (s, e) => ViewModel.Search = e.NewText;

            searchView.QueryTextSubmit += (s, e) =>
            {
                ViewModel.Search = e.Query;
                e.Handled = true;
            };

            SetSupportActionBar(_tbMenu);

            Toast.MakeText(this, "Loading movies, wait a second...", ToastLength.Long).Show();
            
        }


    }
}

