using Android.App;
using Android.OS;

namespace Arctouch.Movies.Presentation.Droid
{
    [Activity(Label = "Arctouch Movies", MainLauncher = true, NoHistory = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
        }
    }
}

