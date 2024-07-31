using RickAndMortyApp.Presentation.Views;

namespace RickAndMortyApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CharacterDetailPage), typeof(CharacterDetailPage));
        }
    }
}
