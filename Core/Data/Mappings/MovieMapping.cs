
using System.Collections.Generic;

namespace Arctouch.Movies.Core.Data.Mappings
{
    public class MovieMapping
    {
        public int id { get; set; }

        public IEnumerable<int> genre_ids { get; set; }

        public string title { get; set; }

        public string backdrop_path { get; set; }

        public string overview { get; set; }

        public string release_date { get; set; }
    }
}