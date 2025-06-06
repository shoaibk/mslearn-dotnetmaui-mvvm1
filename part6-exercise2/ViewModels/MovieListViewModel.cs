using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieCatalog.ViewModels;

public class MovieListViewModel : ObservableObject
{
   
    private MovieViewModel? _selectedMovie;
    public MovieViewModel? SelectedMovie
    {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }

   
    public ObservableCollection<MovieViewModel> Movies { get; }

    
    public ICommand DeleteMovieCommand { get; }

    public MovieListViewModel()
    {
        Movies = [];
       
        DeleteMovieCommand = new Command<MovieViewModel>(DeleteMovie);
    }

    public async Task RefreshMovies()
    {
        var moviesData = await Models.MoviesDatabase.GetMovies();
        foreach (var movie in moviesData)
            Movies.Add(new MovieViewModel(movie));
    }

    public void DeleteMovie(MovieViewModel movie) => Movies.Remove(movie);
}