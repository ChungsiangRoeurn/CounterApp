using CounterApp.Models;
using CounterApp.Services;
using System.Collections.ObjectModel;

namespace CounterApp.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        private readonly MainViewModel _mainViewModel;
        private readonly MovieService _movieService;

        public ObservableCollection<MovieModel> RecentMovies { get; set; }

        private int _moviesLoaded;
        public int MoviesLoaded
        {
            get => _moviesLoaded;
            set { _moviesLoaded = value; OnPropertyChanged(); }
        }

        public OverviewViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _movieService = new MovieService();

            RecentMovies = new ObservableCollection<MovieModel>();

            LoadRecentMovies(); 
        }

        private async void LoadRecentMovies()
        {
            var movies = await _movieService.SearchMovies("batman");

            RecentMovies.Clear();

            foreach (var movie in movies)
            {
                RecentMovies.Add(movie);
            }

            MoviesLoaded = RecentMovies.Count;
        }
    }
}