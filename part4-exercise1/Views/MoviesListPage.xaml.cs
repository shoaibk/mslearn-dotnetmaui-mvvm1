using MovieCatalog.ViewModels;

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
            // No longer passing a MovieViewModel into the constructor,
            // since MovieDetailPage now reads from App.MainViewModel internally.
            await Navigation.PushAsync(new MovieDetailPage());
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var movie = (MovieViewModel)menuItem.BindingContext;
            App.MainViewModel?.DeleteMovie(movie);
        }
    }
}