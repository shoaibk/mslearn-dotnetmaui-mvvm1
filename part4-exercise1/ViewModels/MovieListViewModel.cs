using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MovieCatalog.ViewModels
{
    public class MovieListViewModel : ObservableObject
    {
        // Holds the list of movies displayed in the UI
        public ObservableCollection<MovieViewModel> Movies { get; set; }

        // Backing field for the SelectedMovie property
        private MovieViewModel _selectedMovie;

        // This property will be bound to the "SelectedItem" of your list control
        public MovieViewModel SelectedMovie
        {
            get => _selectedMovie;
            set => SetProperty(ref _selectedMovie, value);
        }

        public MovieListViewModel() =>
            Movies = new ObservableCollection<MovieViewModel>();

        // Fetches movies from the data source and wraps each in its own MovieViewModel
        public async Task RefreshMovies()
        {
            IEnumerable<Models.Movie> moviesData = await Models.MoviesDatabase.GetMovies();

            foreach (Models.Movie movie in moviesData)
                Movies.Add(new MovieViewModel(movie));
        }

        // Removes a movie from the collection (e.g. after deletion)
        public void DeleteMovie(MovieViewModel movie) =>
            Movies.Remove(movie);
    }
}