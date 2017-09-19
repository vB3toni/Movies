using System;
using Android.App;
using Android.Runtime;
using Arctouch.Movies.Core.CrossCutting;

namespace Arctouch.Movies.Presentation.Droid.Startup
{
    [Application]
    public class GlobalApplication : Application
    {
        public GlobalApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Ioc.Register();
        }
    }
}