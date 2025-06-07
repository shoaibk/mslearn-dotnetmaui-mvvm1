// File: MovieCatalog/App.xaml.cs

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MovieCatalog.ViewModels;

namespace MovieCatalog
{
    public partial class App : Application
    {
        public static MovieListViewModel MainViewModel { get; private set; }

        public App()
        {
            InitializeComponent();

            // Instantiate the main VM; no RefreshMovies() call
            MainViewModel = new MovieListViewModel();

            MainPage = new NavigationPage(new Views.MoviesListPage());
        }
    }
}