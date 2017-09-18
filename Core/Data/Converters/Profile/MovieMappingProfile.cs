using Arctouch.Movies.Core.Data.Mappings;
using Arctouch.Movies.Core.Domain.Entities;
using AutoMapper;

namespace Arctouch.Movies.Core.Data.Converters.Profile
{
    public class MovieMappingProfile : AutoMapper.Profile
    {
        public MovieMappingProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Movie, MovieMapping>(MemberList.None).PreserveReferences();

            CreateMap<MovieMapping, Movie>(MemberList.None);
        }
    }
}