using RickAndMortyApp.Domain.Entity;
using RickAndMortyApp.Domain.Repository;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace RickAndMortyApp.Presentation.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly ICharacterRepository _characterRepository;
        private int _currentPage = 1;
        private bool _isLoading = false;
        private bool _hasMorePages = true;

        public ObservableCollection<CharacterEntity> Characters { get; set; }
        public ICommand LoadCharactersCommand { get; }
        public ICommand LoadMoreCharactersCommand { get; }
        public ICommand GoToNextPageCommand { get; }
        public ICommand GoToPreviousPageCommand { get; }
        public ICommand ShowCharacterDetailsCommand { get; }

        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public bool HasMorePages
        {
            get => _hasMorePages;
            set => SetProperty(ref _hasMorePages, value);
        }

        public MainPageViewModel(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
            Characters = new ObservableCollection<CharacterEntity>();
            LoadCharactersCommand = new Command(async () => await LoadCharacters());
            LoadMoreCharactersCommand = new Command(async () => await LoadMoreCharacters());
            GoToNextPageCommand = new Command(async () => await GoToNextPage());
            GoToPreviousPageCommand = new Command(async () => await GoToPreviousPage());
            ShowCharacterDetailsCommand = new Command<CharacterEntity>(async (character) => await ShowCharacterDetails(character));

            LoadCharactersCommand.Execute(null);
        }

        private async Task LoadCharacters()
        {
            if (_isLoading)
                return;

            _isLoading = true;
            _currentPage = 1; // Сброс страницы при первой загрузке

            var characters = await _characterRepository.GetAllCharactersByPage(_currentPage);
            Characters.Clear();
            foreach (var character in characters)
            {
                Characters.Add(character);
            }

            _isLoading = false;
            HasMorePages = characters.Count > 0; // Если данных больше нет, то пагинация закончена
        }

        private async Task LoadMoreCharacters()
        {
            if (_isLoading || !_hasMorePages)
                return;

            _isLoading = true;
            _currentPage++;

            var characters = await _characterRepository.GetAllCharactersByPage(_currentPage);

            if (characters.Count == 0)
            {
                HasMorePages = false;
            }
            else
            {
                Characters.Clear();
                foreach (var character in characters)
                {
                    Characters.Add(character);
                }
            }

            _isLoading = false;
        }

        private async Task GoToNextPage()
        {
            if (_isLoading || !_hasMorePages)
                return;

            _currentPage++;
            await LoadCharactersForCurrentPage();
        }

        private async Task GoToPreviousPage()
        {
            if (_isLoading || _currentPage <= 1)
                return;

            _currentPage--;
            await LoadCharactersForCurrentPage();
        }

        private async Task LoadCharactersForCurrentPage()
        {
            _isLoading = true;

            var characters = await _characterRepository.GetAllCharactersByPage(_currentPage);
            Characters.Clear();
            foreach (var character in characters)
            {
                Characters.Add(character);
            }

            _isLoading = false;
            HasMorePages = characters.Count > 0 || _currentPage > 1; // Если данных больше нет, то пагинация закончена
        }

        private async Task ShowCharacterDetails(CharacterEntity character)
        {
            // Открыть страницу с полным описанием персонажа
            await Shell.Current.GoToAsync($"characterdetail?characterId={character.Id}");
        }
    }
}
