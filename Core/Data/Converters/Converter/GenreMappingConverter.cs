using System.Collections.Generic;
using Arctouch.Movies.Core.Data.Mappings;
using Arctouch.Movies.Core.Domain.Entities;


namespace Arctouch.Movies.Core.Data.Converters.Converter
{
    public static class GenreMappingConverter
    {
        public static Genre ToEntity(this GenreMapping mapping)
        {
            return AutoMapper.Mapper.Map<GenreMapping, Genre>(mapping);
        }

        public static GenreMapping ToMapping(this Genre entity)
        {
            return AutoMapper.Mapper.Map<Genre, GenreMapping>(entity);
        }

        public static IEnumerable<Genre> ToEntities(this IEnumerable<GenreMapping> mappings)
        {
            return AutoMapper.Mapper.Map<IEnumerable<GenreMapping>, IEnumerable<Genre>>(mappings);
        }

        public static IEnumerable<GenreMapping> ToMappings(this IEnumerable<Genre> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreMapping>>(entity);
        }
    }
}