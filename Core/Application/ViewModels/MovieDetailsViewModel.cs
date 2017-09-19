using System;
using Arctouch.Movies.Core.Application.Converters.Converter;
using Arctouch.Movies.Core.Application.Dtos;
using Arctouch.Movies.Core.Domain.Interfaces.Application;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using SimpleInjector;

namespace Arctouch.Movies.Core.Application.ViewModels
{
    public class MovieDetailsViewModel : MvxViewModel
    {
        private readonly IMovieApplication _movieApplication;
        private string _movieIdSelected;

        private MovieDto _movieDto;

        public MovieDetailsViewModel()
        {
            _movieApplication = Mvx.Resolve<Container>().GetInstance<IMovieApplication>();                
        }

        private void LoadSelectedMovie()
        {
            var task = _movieApplication.GetMovieById(Convert.ToInt32(_movieIdSelected));
            task.ContinueWith(result =>
            {
                _movieDto = result.Result.ToDto();

                RaisePropertyChanged(() => MovieDetail);
            });
            task.ConfigureAwait(false);
        }

        public MovieDto MovieDetail
        {
            get => _movieDto;
            set
            {
                _movieDto = value;

                RaisePropertyChanged(() => MovieDetail);
            }
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            parameters.Data.TryGetValue("idmovie", out _movieIdSelected);

            LoadSelectedMovie();
        }
    }
}