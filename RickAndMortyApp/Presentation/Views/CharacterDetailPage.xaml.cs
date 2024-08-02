using RickAndMortyApp.Presentation.ViewModels;

namespace RickAndMortyApp.Presentation.Views
{
    [QueryProperty(nameof(CharacterId), "characterId")]
    public partial class CharacterDetailPage : ContentPage
    {
        public int CharacterId { get; set; }
        public CharacterDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            Console.WriteLine("CharacterDetailPage constructor called");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine($"CharacterDetailPage OnAppearing called with CharacterId: {CharacterId}");

            var viewModel = (CharacterDetailViewModel)BindingContext;
            if (viewModel != null)
            {
                await viewModel.LoadCharacter(CharacterId);
            }
        }
    }
}
