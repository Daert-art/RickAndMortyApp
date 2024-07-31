using RickAndMortyApp.Data.Source.Remote.Api;
using RickAndMortyApp.Domain.Entity;

namespace RickAndMortyApp.Domain.Repository
{
    public sealed class CharacterRepository : ICharacterRepository
    {
        private ApiProvider _apiProvider {  get; set; }

        public CharacterRepository() 
        {
            _apiProvider = new ApiProvider();
        }
        public CharacterRepository(ApiProvider provider)
        {
            _apiProvider = provider;
        }

        public async Task<List<CharacterEntity>> GetAllCharactersByPage(int page)
        {
            try
            {
                var resultList = await _apiProvider.GetCharactersEndPoint(page);
                List<CharacterEntity> characterEntities = new List<CharacterEntity>();
                foreach (var characterModel in resultList)
                {
                    if (characterModel != null)
                    {
                        characterEntities.Add(new CharacterEntity(characterModel));
                    }
                }
                return characterEntities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<CharacterEntity> GetCharacterById(int id)
        {
            try
            {
                var dto = await _apiProvider.GetCharacter(id);
                CharacterEntity characterEntity = new CharacterEntity(dto);
                return characterEntity;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
