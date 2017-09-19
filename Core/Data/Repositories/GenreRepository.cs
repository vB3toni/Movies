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
    public class GenreRepository : RepositoryBase, IGenreRepository
    {
        private IEnumerable<Genre> _cacheAllGenres;

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(GetGenreApiUrl);

                    var response = await httpClient.GetAsync(GetGenreApiUrl);

                    using (var content = response.Content)
                    {
                        var genrereturns = await content.ReadAsStringAsync();

                        var genreList = JsonConvert.DeserializeObject<RootGenreMapping>(genrereturns);

                        return _cacheAllGenres ?? genreList.genres.ToEntities();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Genre GetGenreById(int id)
        {
            ForceLoadCache();

            return _cacheAllGenres.FirstOrDefault(x => x.Id == id);
        }
        public void ForceLoadCache()
        {
            if (_cacheAllGenres == null)
            {
                var taskGenre = GetAllGenres().ContinueWith(result =>
                {
                    _cacheAllGenres = result.Result;
                });
                taskGenre.ConfigureAwait(false);
            }
        }

        public IEnumerable<Genre> GetAllGenreById(List<int> ids)
        {
            ForceLoadCache();

            return _cacheAllGenres.Select(x => x).Where(x => ids.Contains(x.Id));
        }
    }
}