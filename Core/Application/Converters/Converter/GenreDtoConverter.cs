using System.Collections.Generic;
using Arctouch.Movies.Core.Application.Dtos;
using Arctouch.Movies.Core.Domain.Entities;

namespace Arctouch.Movies.Core.Application.Converters.Converter
{
    public static class GenreDtoConverter
    {
        public static Genre ToEntity(this GenreDto mapping)
        {
            return AutoMapper.Mapper.Map<GenreDto, Genre>(mapping);
        }

        public static GenreDto ToMapping(this Genre entity)
        {
            return AutoMapper.Mapper.Map<Genre, GenreDto>(entity);
        }

        public static IEnumerable<Genre> ToEntities(this IEnumerable<GenreDto> mappings)
        {
            return AutoMapper.Mapper.Map<IEnumerable<GenreDto>, IEnumerable<Genre>>(mappings);
        }

        public static IEnumerable<GenreDto> ToMappings(this IEnumerable<Genre> entity)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(entity);
        }
    }
}