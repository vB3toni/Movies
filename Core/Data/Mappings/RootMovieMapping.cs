using System.Collections.Generic;

namespace Arctouch.Movies.Core.Data.Mappings
{
    public class RootMovieMapping
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<MovieMapping> results { get; set; }
    }
}