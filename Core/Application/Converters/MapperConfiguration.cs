using System;
using Arctouch.Movies.Core.Application.Converters.Profile;
using AutoMapper;

namespace Arctouch.Movies.Core.Application.Converters
{
    public static class MapperConfiguration
    {
        public static Action<IMapperConfigurationExpression> ConfigAction = x =>
        {
            x.AddProfile<MovieDtoProfile>();
            x.AddProfile<GenreDtoProfile>();
        };
    }
}