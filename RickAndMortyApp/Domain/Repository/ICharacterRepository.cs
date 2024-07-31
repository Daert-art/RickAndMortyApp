using RickAndMortyApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyApp.Domain.Repository
{
    public interface ICharacterRepository
    {
        Task<List<CharacterEntity>> GetAllCharactersByPage(int page);
        Task<CharacterEntity> GetCharacterById(int id);
    }
}
