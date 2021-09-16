using ChallengeDisney.PreAcel.Context;
using ChallengeDisney.PreAcel.Entities;
using ChallengeDisney.PreAcel.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.PreAcel.Repositories
{
    public class CharacterRepository : BaseRepository<Character, WordDisneyContext>, ICharacterRepository
    {
        private readonly WordDisneyContext _dbContext;

        public CharacterRepository(WordDisneyContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Character>> GetCharWithSeriesOrMovies(string name, int age, int idMovie)
        {
            //List<Character> characters = await _dbContext.Charactersers.Select(c => new Character { Id = c.Id, Name = c.Name, Image = c.Image, Age = c.Age, MovieOrSeries = c.MovieOrSeries }).ToListAsync();
            
            //LOS TRES COMPLETOS
            if(!string.IsNullOrEmpty(name) && age > 0 && idMovie > 0)
            {
                return await _dbContext.Charactersers.Include(c => c.MovieOrSeries.Where(m => m.Id == idMovie)).Where(c => c.Name == name && c.Age == age).ToListAsync();
            }

            //NOMBRE VACIO Y EDAD Y PELICULA COMPLETO
            if (string.IsNullOrEmpty(name) && age > 0 && idMovie > 0)
            {
                return await _dbContext.Charactersers.Include(c => c.MovieOrSeries.Where(m => m.Id == idMovie)).Where(c => c.Age == age).ToListAsync();
            }

            //NOMBRE Y EDAD VACIO Y PELICULA COMPLETO
            if (string.IsNullOrEmpty(name) && age == 0 && idMovie > 0)
            {
                return await _dbContext.Charactersers.Include(c => c.MovieOrSeries.Where(m => m.Id == idMovie)).ToListAsync();
            }

            //NOMBRE COMPLETO, EDAD VACIO Y PELICULA COMPLETO
            if (!string.IsNullOrEmpty(name) && age == 0 && idMovie > 0)
            {
                return await _dbContext.Charactersers.Include(c => c.MovieOrSeries.Where(m => m.Id == idMovie)).Where(c => c.Name == name).ToListAsync();
            }

            //NOMBRE COMPLETO, EDAD COMPLETO Y PELICULA VACIO
            if (!string.IsNullOrEmpty(name) && age == 0 && idMovie > 0)
            {
                return await _dbContext.Charactersers.Include(c => c.MovieOrSeries).Where(c => c.Name == name && c.Age == age).ToListAsync();
            }

            //NOMBRE Y EDAD Y PELICULA VACIO
            return await _dbContext.Charactersers.Include(c => c.MovieOrSeries).ToListAsync();
        }

        public Character AddCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public new void Update(Character character)
        {
            throw new NotImplementedException();
        }

        public List<Character> GetAllCharacters()
        {
            throw new NotImplementedException();
        }

        public Character GetCharacter(int id)
        {
            return _dbContext.Charactersers.Find(id);
        }
    }
}
