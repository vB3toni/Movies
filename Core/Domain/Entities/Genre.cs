using Arctouch.Movies.Core.Domain.Interfaces.Base;

namespace Arctouch.Movies.Core.Domain.Entities
{
    public class Genre : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsEntityValid => Id > 0 && !string.IsNullOrWhiteSpace(Name);
    }
}