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
    public class GenreRepository : RepositoryBase, IGenreRepository
    {
        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(GetGenreApiUrl);

                var response = await httpClient.GetAsync(GetGenreApiUrl);

                using (var content = response.Content)
                {
                    var genrereturns = await content.ReadAsStringAsync();

                    var genreList = JsonConvert.DeserializeObject<IEnumerable<GenreMapping>>(genrereturns);

                    return genreList.ToEntities();
                }
            }
        }
    }
}