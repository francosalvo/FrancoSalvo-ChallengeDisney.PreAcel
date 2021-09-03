using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChallengeDisney.PreAcel.Context;
using ChallengeDisney.PreAcel.Entities;

namespace ChallengeDisney.PreAcel.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly WordDisneyContext _context;
        private object Character;

        public CharacterController(WordDisneyContext context) => _context = context;

        //TODO: LISTAR Caracteres
        [HttpGet]
       
        public IActionResult Get()
        {
            return Ok(_context.Charactersers.ToList());
        }

        //TODO: Buscar
        [HttpGet("name")]
        
        public ActionResult<Character> GetCharacterByName(string name)
        {
           return Ok(_context.Charactersers.Where(c => c.Name == name));
           //return Ok(_context.Charactersers.Find(name));
        }



        //TODO: crear

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
