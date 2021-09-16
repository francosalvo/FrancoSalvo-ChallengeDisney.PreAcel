using ChallengeDisney.PreAcel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.PreAcel.Interfaces.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetCharWithSeriesOrMovies(string name, int age, int idMovie);

        Task<IEnumerable<Character>> GetAllCharacters();

        #region CRUD
        ValueTask<Character> GetCharacter(int id);//Read

        Task AddCharacter(Character entity);//Create

        void UpdateCharacter(Character entity);//Update

        void DeleteCharacter(Character entity);//Delete
        #endregion
    }
}
