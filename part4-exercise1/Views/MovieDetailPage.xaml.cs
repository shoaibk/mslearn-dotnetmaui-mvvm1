namespace MovieCatalog.Views;

public partial class MovieDetailPage : ContentPage
{
	public MovieDetailPage()
	{
		InitializeComponent();
		BindingContext = App.MainViewModel.SelectedMovie;
	}
}