using Android.Content;
using Arctouch.Movies.Core.Application.ViewModels;
using Arctouch.Movies.Core.CrossCutting;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

namespace Arctouch.Movies.Presentation.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new AppStartup(Ioc.Container);
        }
    }
}