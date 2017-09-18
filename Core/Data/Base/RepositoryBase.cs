namespace Arctouch.Movies.Core.Data.Base
{
    public abstract class RepositoryBase
    {
        protected const string ApiKey = "1f54bd990f1cdfb230adb312546d765d";

        public virtual string GetMoviesApiUrl(int page = 1)
        {
            return $"https://api.themoviedb.org/3/movie/popular?api_key={ApiKey}&language=en-US&page={page}";
        }

        public virtual string GetGenreApiUrl =>
            $"https://api.themoviedb.org/3/genre/movie/list?api_key={ApiKey}&language=en-US";
    }
}