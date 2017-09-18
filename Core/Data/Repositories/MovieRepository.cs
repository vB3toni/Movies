using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Movie>> GetAllMoviesPaginated(int page, string search)
        {
            using (var httpClient = new HttpClient())
            {
                var serveradress = string.IsNullOrWhiteSpace(search) ? GetMoviesApiUrl(page) : GetMoviesSearchApiUrl(page, search);

                httpClient.BaseAddress = new Uri(serveradress);

                var response = await httpClient.GetAsync(serveradress);

                using (var content = response.Content)
                {
                    var moviereturns = await content.ReadAsStringAsync();

                    var moviesList = JsonConvert.DeserializeObject<IEnumerable<MovieMapping>>(moviereturns);

                    return moviesList.ToEntities();
                }
            }
        }
    }
}