using Arctouch.Movies.Core.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Arctouch.Movies.Core.Domain.Entities
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title { get; set; }

        public string BackDropPath { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }
        
        public bool IsEntityValid => Id > 0 && !string.IsNullOrWhiteSpace(Title);
    }
}
