using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChallengeDisney.PreAcel.Context;
using ChallengeDisney.PreAcel.DTO.GET;
using AutoMapper;
using ChallengeDisney.PreAcel.Entities;
using ChallengeDisney.PreAcel.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDisney.PreAcel.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly WordDisneyContext _context;
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(WordDisneyContext context, IMapper mapper, ICharacterService characterService) {
            _context = context;
            _mapper = mapper;
            _characterService = characterService;
        }

        public async Task<IActionResult> GetCharacter(int id)
        {
            try
            {
                Character character = await _characterService.GetCharacter(id);
                var characterDTO = _mapper.Map<Character, CharacterDTO>(character);
                return Ok(characterDTO);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // DEVUELVE INFO DETALLADA DE UN PERSONAJE EN PARTICULAR
        [HttpGet] //Verbo de http GET 
        [Route(template: "GetCharacterWithMovies")]
        public async Task<IActionResult> GetCharacterWithMovies(string name, int age, int idMovie) // Puedo agregarle parámetros para que funcionen como filtros
        {
            //filtra el personaje por nombre, id o edad. - ´También devuelve todas las películas en las que participó ese personaje
            try
            {
                var charactersWithMovies = await _characterService.GetCharWithSeriesOrMovies(name, age, idMovie);

                var charactersWithMoviesDTO = _mapper.Map<IEnumerable<Character>, IEnumerable<GetCharacterWithMoviesDTO>>(charactersWithMovies);

                return Ok(charactersWithMoviesDTO);
            }
            catch(Exception ex)
            {
                return Problem("Ha ocurrido un problema, por favor intente nuevamente. Detalle: " + ex.Message);
            }
        }

        [HttpPost]
        [Route(template: "api/[controller]/Create")]
        public IActionResult Post(Character character)
        {
            _context.Charactersers.Add(character);
            _context.SaveChanges();
            return Ok(_context.Charactersers.ToList());
        }

        //TODO: modificar
        [HttpPut]
        [Route(template: "api/[controller]/Update")]
        public IActionResult Put(Character character)
        {
            if (_context.Charactersers.FirstOrDefault(g => g.Id == character.Id) == null) return BadRequest("EL Personaje enviado no existe");
            var internaCharacter = _context.Charactersers.Find(character.Id);

            internaCharacter.Name = character.Name;
            internaCharacter.Image = character.Image;
            internaCharacter.Age = character.Age;
            _context.SaveChanges();
            return Ok(_context.Charactersers.ToList());
        }

        //TODO: borrar
        [HttpDelete]
        [Route("{id}/Delete")]
        public IActionResult Delete(int id)
        {
            if (_context.Charactersers.FirstOrDefault(g => g.Id == id) == null) return BadRequest("EL Personaje enviado no existe");

            var internaCharacter = _context.Charactersers.Find(id);
            _context.Charactersers.Remove(internaCharacter);
            _context.SaveChanges();
            return Ok();
        }

    }

}
 
