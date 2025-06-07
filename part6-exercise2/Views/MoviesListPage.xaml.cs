// File: MovieCatalog/Views/MoviesListPage.xaml.cs

using MovieCatalog.ViewModels;
using Microsoft.Maui.Controls;

namespace MovieCatalog.Views
{
    public partial class MoviesListPage : ContentPage
    {
        public MoviesListPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // We bound SelectedItem to SelectedMovie, so vm.SelectedMovie is non-null if a row is tapped
            if (BindingContext is MovieListViewModel vm && vm.SelectedMovie != null)
            {
                // Pass SelectedMovie into MovieDetailPage via BindingContext
                var detailPage = new MovieDetailPage
                {
                    BindingContext = vm.SelectedMovie
                };
                await Navigation.PushAsync(detailPage);
            }
        }

        // Note: MenuItem_Clicked has already been removed.
    }
}