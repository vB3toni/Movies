using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using SimpleInjector;

namespace Arctouch.Movies.Core.Application.ViewModels
{
    public class AppStartup : MvxApplication
    {
        private readonly Container _container;
        public AppStartup(Container container)
        {
            _container = container;
        }

        public override void Initialize()
        {
            try
            {
                CreatableTypes().EndingWith("Repository").AsInterfaces().RegisterAsLazySingleton();

                CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();

                Mvx.RegisterSingleton(() => _container);
                
                Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}