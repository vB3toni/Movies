using System;
using System.Collections.Generic;

namespace Arctouch.Movies.Core.Application.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }

        public string Title { get; set; }

        public string BackDropPath { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public bool IsEntityValid { get; set; }
    }
}