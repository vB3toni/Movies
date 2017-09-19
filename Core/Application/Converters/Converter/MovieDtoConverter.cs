using System.Collections.Generic;
using Arctouch.Movies.Core.Application.Dtos;
using Arctouch.Movies.Core.Domain.Entities;

namespace Arctouch.Movies.Core.Application.Converters.Converter
{
    public static class MovieDtoConverter
    {
        public static Movie ToEntity(this MovieDto mapping)
        {
            return AutoMapper.Mapper.Map<MovieDto, Movie>(mapping);
        }

        public static MovieDto ToMapping(this Movie entity)
        {
            return AutoMapper.Mapper.Map<Movie, MovieDto>(entity);
        }

        public static IEnumerable<Movie> ToEntities(this IEnumerable<MovieDto> mappings)
        {
            return AutoMapper.Mapper.Map<IEnumerable<MovieDto>, IEnumerable<Movie>>(mappings);
        }

        public static IEnumerable<MovieDto> ToMappings(this IEnumerable<Movie> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(entity);
        }
    }
}