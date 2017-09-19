using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arctouch.Movies.Core.Application.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }

        public string Title { get; set; }

        public string BackDropPath { get; set; }

        public string BackDropWithFullUrl => $"https://image.tmdb.org/t/p/w300{BackDropPath}";

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

        public bool IsEntityValid { get; set; }

        public string GenresNamesFormatted => Genres.Select(x => x.Name).Aggregate((i, j) => i + ", " + j);
    }
}