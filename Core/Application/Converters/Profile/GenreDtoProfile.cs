using Arctouch.Movies.Core.Application.Dtos;
using Arctouch.Movies.Core.Domain.Entities;
using AutoMapper;

namespace Arctouch.Movies.Core.Application.Converters.Profile
{
    public class GenreDtoProfile : AutoMapper.Profile
    {
        public GenreDtoProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Genre, GenreDto>(MemberList.None).PreserveReferences();

            CreateMap<GenreDto, Genre>(MemberList.None);
        }
    }
}