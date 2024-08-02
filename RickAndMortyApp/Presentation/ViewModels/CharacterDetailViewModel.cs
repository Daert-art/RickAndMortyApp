using RickAndMortyApp.Domain.Entity;
using RickAndMortyApp.Domain.Repository;
using Location = RickAndMortyApp.Domain.Entity.Location;

namespace RickAndMortyApp.Presentation.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        private readonly ICharacterRepository _characterRepository;
        private CharacterEntity _character;

        public CharacterEntity Character
        {
            get => _character;
            set => SetProperty(ref _character, value);
        }

        public CharacterDetailViewModel(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task LoadCharacter(int characterId)
        {
            var characterModel = await _characterRepository.GetCharacterById(characterId);

            Character = new CharacterEntity
            {
                Id = characterModel.Id,
                Name = characterModel.Name,
                Status = characterModel.Status,
                Species = characterModel.Species,
                Type = characterModel.Type,
                Gender = characterModel.Gender,
                Origin = characterModel.Origin != null ? new Origin
                {
                    Name = characterModel.Origin.Name,
                    Url = characterModel.Origin.Url
                } : new Origin { Name = "No Origin Name", Url = "No Origin URL" },
                Location = characterModel.Location != null ? new Location
                {
                    Name = characterModel.Location.Name,
                    Url = characterModel.Location.Url
                } : new Location { Name = "No Location Name", Url = "No Location URL" },
                Image = characterModel.Image,
                Episode = characterModel.Episode != null && characterModel.Episode.Any() ? characterModel.Episode.First().ToString() : "No Episode"
            };
        }
    }


}
