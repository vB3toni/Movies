using System.Collections.Generic;
using System.Threading.Tasks;
using Arctouch.Movies.Core.Domain.Entities;
using Arctouch.Movies.Core.Domain.Interfaces.Application;
using Arctouch.Movies.Core.Domain.Interfaces.Repository;

namespace Arctouch.Movies.Core.Application.Application
{
    public class GenreApplication : IGenreApplication
    {
        private readonly IGenreRepository _genreRepository;

        public GenreApplication(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Task<IEnumerable<Genre>> GetAllGenre()
        {
            return _genreRepository.GetAllGenres();
        }
    }
}