using RickAndMortyApp.Presentation.ViewModels;

namespace RickAndMortyApp.Presentation.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
