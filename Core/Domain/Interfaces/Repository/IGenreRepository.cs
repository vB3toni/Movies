using System.Collections.Generic;
using System.Threading.Tasks;
using Arctouch.Movies.Core.Domain.Entities;

namespace Arctouch.Movies.Core.Domain.Interfaces.Repository
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();

        Genre GetGenreById(int id);

        void ForceLoadCache();

        IEnumerable<Genre> GetAllGenreById(List<int> ids);
    }
}