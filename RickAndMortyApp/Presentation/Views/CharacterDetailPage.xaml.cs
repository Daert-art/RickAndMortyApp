using RickAndMortyApp.Presentation.ViewModels;

namespace RickAndMortyApp.Presentation.Views;

public partial class CharacterDetailPage : ContentPage
{
	public CharacterDetailPage(CharacterDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	public CharacterDetailPage(int characterId)
	{
        InitializeComponent();
        var viewModel = (CharacterDetailViewModel)App.ServiceProvider.GetRequiredService<CharacterDetailViewModel>();
        BindingContext = viewModel;
        viewModel.LoadCharacter(characterId);
    }
}