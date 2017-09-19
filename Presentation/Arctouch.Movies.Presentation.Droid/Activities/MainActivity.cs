using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Arctouch.Movies.Core.Application.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.Widget;
using SearchView = Android.Support.V7.Widget.SearchView;

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

            SetSupportActionBar(_tbMenu);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            Toast.MakeText(this, "Loading movies, wait a second...", ToastLength.Long).Show();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_search, menu);

            var item = menu.FindItem(Resource.Id.menu_search);

            var searchView = MenuItemCompat.GetActionView(item).JavaCast<SearchView>();
            searchView.QueryTextChange += OnSearchViewOnQueryTextChange;
            searchView.QueryTextSubmit += OnSearchViewOnQueryTextSubmit; 
            
            return true;
        }

        private void OnSearchViewOnQueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs args)
        {
            ViewModel.Search = args.Query;
            args.Handled = true;
        }

        private void OnSearchViewOnQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            ViewModel.Search = e.NewText;
        }
    }
}

