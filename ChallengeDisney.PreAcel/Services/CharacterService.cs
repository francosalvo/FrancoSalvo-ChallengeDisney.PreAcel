using ChallengeDisney.PreAcel.Entities;
using ChallengeDisney.PreAcel.Interfaces.Repositories;
using ChallengeDisney.PreAcel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.PreAcel.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public Task AddCharacter(Character entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(Character entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetAllCharacters()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Character> GetCharacter(int id)
        {
            return await _characterRepository.Get(id);
        }

        public async Task<IEnumerable<Character>> GetCharWithSeriesOrMovies(string name, int age, int idMovie)
        {
            return await _characterRepository.GetCharWithSeriesOrMovies(name, age, idMovie);
        }

        public void UpdateCharacter(Character entity)
        {
            throw new NotImplementedException();
        }
    }
}
