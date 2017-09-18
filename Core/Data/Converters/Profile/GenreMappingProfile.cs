using Arctouch.Movies.Core.Data.Mappings;
using Arctouch.Movies.Core.Domain.Entities;
using AutoMapper;

namespace Arctouch.Movies.Core.Data.Converters.Profile
{
    public class GenreMappingProfile : AutoMapper.Profile
    {
        public GenreMappingProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Genre, GenreMapping>(MemberList.None).PreserveReferences();

            CreateMap<GenreMapping, Genre>(MemberList.None);
        }
    }
}