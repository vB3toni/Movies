using Arctouch.Movies.Core.Data.Repositories;
using Arctouch.Movies.Core.Domain.Interfaces.Repository;
using SimpleInjector;

namespace Arctouch.Movies.Core.CrossCutting
{
    public static class RepositoryRegister
    {
        public static void Register(Container container)
        {
            container.Register<IGenreRepository, GenreRepository>(Lifestyle.Singleton);
            container.Register<IMovieRepository, MovieRepository>(Lifestyle.Singleton);
        }
    }
}