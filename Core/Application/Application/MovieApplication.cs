using System.Collections.Generic;
using System.Threading.Tasks;
using Arctouch.Movies.Core.Domain.Entities;
using Arctouch.Movies.Core.Domain.Interfaces.Application;
using Arctouch.Movies.Core.Domain.Interfaces.Repository;

namespace Arctouch.Movies.Core.Application.Application
{
    public class MovieApplication : IMovieApplication
    {
        private readonly IMovieRepository _movieRepository;

        public MovieApplication(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task<IEnumerable<Movie>> GetAllMovies(int page, string search)
        {
            return _movieRepository.GetAllMoviesPaginated(page, search);
        }
    }
}