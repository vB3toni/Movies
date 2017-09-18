using Arctouch.Movies.Core.Application.Dtos;
using Arctouch.Movies.Core.Domain.Entities;
using AutoMapper;

namespace Arctouch.Movies.Core.Application.Converters.Profile
{
    public class MovieDtoProfile : AutoMapper.Profile
    {
        public MovieDtoProfile()
        {
            Register();
        }

        public void Register()
        {
            CreateMap<Movie, MovieDto>(MemberList.None).PreserveReferences();

            CreateMap<MovieDto, Movie>(MemberList.None);
        }
    }
}