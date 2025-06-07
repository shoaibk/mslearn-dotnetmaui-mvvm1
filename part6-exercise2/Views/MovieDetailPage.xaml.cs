// File: MovieCatalog/Views/MovieDetailPage.xaml.cs

using MovieCatalog.ViewModels;
using Microsoft.Maui.Controls;

namespace MovieCatalog.Views
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // If you need to do anything with the bound movie, you can cast BindingContext here:
            if (BindingContext is MovieViewModel movie)
            {
                // For example, display details or log info
                // TitleLabel.Text = movie.Title;
                // etc.
            }
        }
    }
}