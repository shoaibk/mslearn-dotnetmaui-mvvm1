using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieCatalog.ViewModels;

public partial class MovieListViewModel : ObservableObject
{
    public ObservableCollection<MovieViewModel> Movies { get; set; }

    private MovieViewModel _selectedMovie;
    public MovieViewModel SelectedMovie
    {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }

    public ICommand DeleteMovieCommand { get; }

    public MovieListViewModel()
    {
        Movies = [];
        DeleteMovieCommand = new RelayCommand<MovieViewModel>(DeleteMovie);
    }

    public async Task RefreshMovies()
    {
        IEnumerable<Models.Movie> moviesData = await Models.MoviesDatabase.GetMovies();
        foreach (Models.Movie movie in moviesData)
            Movies.Add(new MovieViewModel(movie));
    }

    public void DeleteMovie(MovieViewModel movie)
    {
        if (Movies.Contains(movie))
            Movies.Remove(movie);
    }
}