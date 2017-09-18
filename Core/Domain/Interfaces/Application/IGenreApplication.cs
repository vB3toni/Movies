using System.Collections.Generic;
using System.Threading.Tasks;
using Arctouch.Movies.Core.Domain.Entities;

namespace Arctouch.Movies.Core.Domain.Interfaces.Application
{
    public interface IGenreApplication
    {
        Task<IEnumerable<Genre>> GetAllGenre();
    }
}