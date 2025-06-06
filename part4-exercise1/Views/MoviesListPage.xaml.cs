namespace MovieCatalog.Views;

public partial class MoviesListPage : ContentPage
{
    public MoviesListPage()
    {
        InitializeComponent();
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // No need to pass movie manually, we now use SelectedMovie via binding
        await Navigation.PushAsync(new MovieDetailPage());
    }
}