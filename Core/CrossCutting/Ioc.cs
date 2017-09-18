using System;
using SimpleInjector;

namespace Arctouch.Movies.Core.CrossCutting
{
    public class Ioc
    {
        public static readonly Container Container = new Container();

        public static void Register()
        {
            try
            {
                AutoMapper.Mapper.Initialize(x =>
                {
                    Application.Converters.MapperConfiguration.ConfigAction.Invoke(x);
                    Data.Converters.MapperConfiguration.ConfigAction.Invoke(x);
                });

                ApplicationRegister.Register(Container);

                RepositoryRegister.Register(Container);

                Container.Verify();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}