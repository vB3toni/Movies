using System.Collections.Generic;
using Arctouch.Movies.Core.Application.Converters.Converter;
using Arctouch.Movies.Core.Application.Dtos;
using Arctouch.Movies.Core.Domain.Interfaces.Application;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using SimpleInjector;

namespace Arctouch.Movies.Core.Application.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Variaveis

        private readonly IMovieApplication _movieApplication;

        private readonly Dictionary<int, IEnumerable<MovieDto>> _moviesDictionary;
        private int _currentPage;
        private string _search;

        #endregion

        public MainViewModel()
        {
            _movieApplication = Mvx.Resolve<Container>().GetInstance<IMovieApplication>();

            _moviesDictionary = new Dictionary<int, IEnumerable<MovieDto>>();
        }

        public IEnumerable<MovieDto> MoviesList
        {
            get
            {
                if (!_moviesDictionary.ContainsKey(_currentPage))
                {
                    var taskmovies = _movieApplication.GetAllMovies(_currentPage, _search).ContinueWith(task =>
                    {
                        _moviesDictionary.Add(_currentPage, task.Result.ToDtos());
                    });
                    taskmovies.ConfigureAwait(false);
                }

                _moviesDictionary.TryGetValue(_currentPage, out var movieEnumerable);

                return movieEnumerable;
            }
        }

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                
                RaisePropertyChanged(() => CurrentPage);
                RaisePropertyChanged(() => MoviesList);
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                
                RaisePropertyChanged(() => Search);
                RaisePropertyChanged(() => MoviesList);
            }
        }
    }
}