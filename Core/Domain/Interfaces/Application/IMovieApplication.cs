using System.Collections.Generic;
using System.Threading.Tasks;
using Arctouch.Movies.Core.Domain.Entities;

namespace Arctouch.Movies.Core.Domain.Interfaces.Application
{
    public interface IMovieApplication
    {
        Task<IEnumerable<Movie>> GetAllMovies(int page);
    }
}