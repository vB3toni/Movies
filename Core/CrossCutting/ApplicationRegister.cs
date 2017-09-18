using Arctouch.Movies.Core.Application.Application;
using Arctouch.Movies.Core.Domain.Interfaces.Application;
using SimpleInjector;

namespace Arctouch.Movies.Core.CrossCutting
{
    public static class ApplicationRegister
    {
        public static void Register(Container container)
        {
            container.Register<IMovieApplication, MovieApplication>(Lifestyle.Transient);
            container.Register<IGenreApplication, GenreApplication>(Lifestyle.Transient);
        }
    }
}