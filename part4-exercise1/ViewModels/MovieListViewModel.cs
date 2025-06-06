using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieCatalog.ViewModels;

public partial class MovieListViewModel : ObservableObject
{
    public ObservableCollection<MovieViewModel> Movies { get; }

   
    private MovieViewModel? _selectedMovie;
    public MovieViewModel? SelectedMovie
    {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }

    
    public ICommand DeleteMovieCommand { get; }

    public MovieListViewModel()
    {
        Movies = [];
        DeleteMovieCommand = new Command<MovieViewModel>(DeleteMovie);
    }

    public async Task RefreshMovies()
    {
        IEnumerable<Models.Movie> data = await Models.MoviesDatabase.GetMovies();
        foreach (var m in data)
            Movies.Add(new MovieViewModel(m));
    }

    public void DeleteMovie(MovieViewModel movie) => Movies.Remove(movie);
}