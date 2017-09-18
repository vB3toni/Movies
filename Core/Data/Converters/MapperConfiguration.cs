using System;
using Arctouch.Movies.Core.Data.Converters.Profile;
using AutoMapper;

namespace Arctouch.Movies.Core.Data.Converters
{
    public static class MapperConfiguration
    {
        public static Action<IMapperConfigurationExpression> ConfigAction = x =>
        {
            x.AddProfile<MovieMappingProfile>();
            x.AddProfile<GenreMappingProfile>();
        };
    }
}