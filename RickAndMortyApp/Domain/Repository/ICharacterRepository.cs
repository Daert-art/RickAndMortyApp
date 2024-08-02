using RickAndMortyApp.Domain.Entity;

namespace RickAndMortyApp.Domain.Repository
{
    public interface ICharacterRepository
    {
        Task<List<CharacterEntity>> GetAllCharactersByPage(int page);
        Task<CharacterEntity> GetCharacterById(int id);
    }
}
