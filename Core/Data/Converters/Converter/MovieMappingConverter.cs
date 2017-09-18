using System.Collections.Generic;
using Arctouch.Movies.Core.Data.Mappings;
using Arctouch.Movies.Core.Domain.Entities;

namespace Arctouch.Movies.Core.Data.Converters.Converter
{
    public static class MovieMappingConverter
    {
        public static Movie ToEntity(this MovieMapping mapping)
        {
            return AutoMapper.Mapper.Map<MovieMapping, Movie>(mapping);
        }

        public static MovieMapping ToMapping(this Movie entity)
        {
            return AutoMapper.Mapper.Map<Movie, MovieMapping>(entity);
        }

        public static IEnumerable<Movie> ToEntities(this IEnumerable<MovieMapping> mappings)
        {
            return AutoMapper.Mapper.Map<IEnumerable<MovieMapping>, IEnumerable<Movie>>(mappings);
        }

        public static IEnumerable<MovieMapping> ToMappings(this IEnumerable<Movie> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieMapping>>(entity);
        }
    }
}