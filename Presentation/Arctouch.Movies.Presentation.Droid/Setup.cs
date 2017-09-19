using Android.Content;
using Arctouch.Movies.Core.Application.ViewModels;
using Arctouch.Movies.Core.CrossCutting;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.Plugins;

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

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.DownloadCache.PluginLoader>();

            base.LoadPlugins(pluginManager);
        }
    }
}