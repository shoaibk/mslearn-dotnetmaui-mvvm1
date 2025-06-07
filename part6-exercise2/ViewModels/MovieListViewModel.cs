// File: MovieCatalog/ViewModels/MovieListViewModel.cs

using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;    // for Command<T>
using MovieCatalog.Models;         // for Movie
using MovieCatalog.ViewModels;     // for MovieViewModel

namespace MovieCatalog.ViewModels
{
    public partial class MovieListViewModel : ObservableObject
    {
        // 1) Keep the Movies collection
        public ObservableCollection<MovieViewModel> Movies { get; }

        // 2) Restore the SelectedMovie property:
        private MovieViewModel? _selectedMovie;
        public MovieViewModel? SelectedMovie
        {
            get => _selectedMovie;
            set => SetProperty(ref _selectedMovie, value);
        }

        // 3) Keep DeleteMovieCommand
        public ICommand DeleteMovieCommand { get; private set; }

        public MovieListViewModel()
        {
            // Initialize Movies using the correct Movie(...) constructor
            Movies = new ObservableCollection<MovieViewModel>
            {
                new MovieViewModel(new Movie("Inception",    "Syncopy",            "Christopher Nolan", 2010)),
                new MovieViewModel(new Movie("The Matrix",   "Warner Bros.",       "The Wachowskis",     1999)),
                new MovieViewModel(new Movie("Interstellar", "Paramount Pictures", "Christopher Nolan", 2014)),
                // …etc.
            };

            // Instantiate DeleteMovieCommand
            DeleteMovieCommand = new Command<MovieViewModel>(DeleteMovie);
        }

        private void DeleteMovie(MovieViewModel movie)
        {
            if (movie == null) return;
            if (Movies.Contains(movie))
            {
                Movies.Remove(movie);
            }
        }
    }
}