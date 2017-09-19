using System.Collections.Generic;
using System.Linq;
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

        private MvxCommand _pageBackCommand;
        private MvxCommand _pageForwardCommand;
        private MvxCommand<MovieDto> _openMoviesDetailsCommand;

        #endregion

        public MainViewModel()
        {
            _movieApplication = Mvx.Resolve<Container>().GetInstance<IMovieApplication>();

            _moviesDictionary = new Dictionary<int, IEnumerable<MovieDto>>();

            _currentPage = 1;
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

                        RaisePropertyChanged(() => MoviesList);
                    });
                    taskmovies.ConfigureAwait(false);
                }

                _moviesDictionary.TryGetValue(_currentPage, out var movieEnumerable);

                return string.IsNullOrWhiteSpace(_search) ? movieEnumerable : movieEnumerable?.Where(x => x.Title.ToUpper().Contains(_search.ToUpper()));
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
                RaisePropertyChanged(() => EnablePageBack);
                RaisePropertyChanged(() => EnablePageForward);
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

        public bool EnablePageBack => _currentPage > 1;

        public bool EnablePageForward => _currentPage < 500;

        public MvxCommand PageBack => _pageBackCommand = _pageBackCommand ?? new MvxCommand(() =>
        {
            if (_currentPage > 1)
            {
                CurrentPage -= 1;
            }
        });

        public MvxCommand PageForward => _pageForwardCommand = _pageForwardCommand ?? new MvxCommand(() =>
        {
            if (_currentPage < 500)
            {
                CurrentPage += 1;
            }
        });

        public MvxCommand<MovieDto> OpenMovieDetails => _openMoviesDetailsCommand =
            _openMoviesDetailsCommand ?? new MvxCommand<MovieDto>(
                movie =>
                {
                    var bundle = new MvxBundle();
                    bundle.Data.Add("idmovie", movie.Id.ToString());

                    ShowViewModel<MovieDetailsViewModel>(bundle);
                });
    }
}