using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Arctouch.Movies.Core.Data.Base;
using Arctouch.Movies.Core.Data.Converters.Converter;
using Arctouch.Movies.Core.Data.Mappings;
using Arctouch.Movies.Core.Domain.Entities;
using Arctouch.Movies.Core.Domain.Interfaces.Repository;
using Newtonsoft.Json;

namespace Arctouch.Movies.Core.Data.Repositories
{
    public class MovieRepository : RepositoryBase, IMovieRepository
    {
        private readonly IGenreRepository _genreRepository;
        public MovieRepository(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
            _genreRepository.ForceLoadCache();
        }
        
        public async Task<IEnumerable<Movie>> GetAllMoviesPaginated(int page, string search)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var serveradress = string.IsNullOrWhiteSpace(search) ? GetMoviesApiUrl(page) : GetMoviesSearchApiUrl(page, search);

                    httpClient.BaseAddress = new Uri(serveradress);

                    var response = await httpClient.GetAsync(serveradress);

                    using (var content = response.Content)
                    {
                        var moviereturns = await content.ReadAsStringAsync();

                        var moviesList = JsonConvert.DeserializeObject<RootMovieMapping>(moviereturns);
                        
                        return moviesList.results.Select(x => new Movie
                        {
                            BackDropPath = x.backdrop_path,
                            Genres = _genreRepository.GetAllGenreById(x.genre_ids),
                            Id = x.id,
                            Overview = x.overview,
                            ReleaseDate = x.release_date,
                            Title = x.title
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var serveradress = GetMovieByIdApiUrl(movieId);

                    httpClient.BaseAddress = new Uri(serveradress);

                    var response = await httpClient.GetAsync(serveradress);

                    using (var content = response.Content)
                    {
                        var moviereturns = await content.ReadAsStringAsync();

                        var movie = JsonConvert.DeserializeObject<MovieMapping>(moviereturns);

                        return new Movie
                        {
                            BackDropPath = movie.backdrop_path,
                            Genres = movie.genres.ToEntities(),
                            Id = movie.id,
                            Overview = movie.overview,
                            ReleaseDate = movie.release_date,
                            Title = movie.title
                        };
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}