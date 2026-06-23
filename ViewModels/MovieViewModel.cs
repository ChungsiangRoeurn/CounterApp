using System.Collections.ObjectModel;
using CounterApp.Models;
using CounterApp.Services;

namespace CounterApp.ViewModels
{
    public class MovieListViewModel : BaseViewModel
    {
        private readonly MovieService _movieService;

        public ObservableCollection<MovieModel> Movies { get; set; }

        private string _searchText = string.Empty;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();

                SearchMovies(_searchText); // ✅ FIXED
            }
        }

        public MovieListViewModel(MainViewModel mainViewModel)
        {
            _movieService = new MovieService();
            Movies = new ObservableCollection<MovieModel>();

            LoadDefaultMovies(); // only once on startup
        }

        private async void LoadDefaultMovies()
        {
            var keywords = new[] { "batman", "avengers", "spiderman", "superman" };

            Movies.Clear();

            foreach (var keyword in keywords)
            {
                var movies = await _movieService.SearchMovies(keyword);

                foreach (var movie in movies)
                {
                    Movies.Add(movie);
                }
            }
        }

        private async void SearchMovies(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadDefaultMovies();
                return;
            }

            var movies = await _movieService.SearchMovies(keyword);

            Movies.Clear();

            foreach (var movie in movies)
            {
                Movies.Add(movie);
            }
        }
    }
}