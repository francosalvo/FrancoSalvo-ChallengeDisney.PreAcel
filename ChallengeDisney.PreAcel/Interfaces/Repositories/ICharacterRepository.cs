using ChallengeDisney.PreAcel.Entities;
using ChallengeDisney.PreAcel.Interfaces.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.PreAcel.Interfaces.Repositories
{
    public interface ICharacterRepository : IRepository<Character>
    {
        /// <summary>
        /// ESTE METODO DEVUELVE LA LISTA DE PERSONAJES SEGUN FILTROS
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="idMovie"></param>
        /// <returns>RETORNA LISTA DE PERSONAJES FILTRADA POR NOMBRE, EDAD Y/O PELICULA</returns>
        Task<IEnumerable<Character>> GetCharWithSeriesOrMovies(string name, int age, int idMovie);

    }
}
