using RickAndMortyApp.Domain.Entity;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using RickAndMortyApp.Domain.Repository;

namespace RickAndMortyApp.Presentation.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        private readonly ICharacterRepository _characterRepository;
        private int _characterId;

        public CharacterEntity Character { get; set; }


        public CharacterDetailViewModel(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task LoadCharacter(int characterId)
        {
            _characterId = characterId;
            Character = await _characterRepository.GetCharacterById(_characterId);
        }
    }
}
