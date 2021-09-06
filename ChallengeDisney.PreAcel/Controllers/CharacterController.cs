using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChallengeDisney.PreAcel.Context;
using ChallengeDisney.PreAcel.DTO.GET;
using AutoMapper;
using ChallengeDisney.PreAcel.Entities;

namespace ChallengeDisney.PreAcel.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly WordDisneyContext _context;
        private readonly IMapper _mapper;

        public CharacterController(WordDisneyContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        //TODO: LISTAR Caracteres
        [HttpGet]
       
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Character> characters = _context.Charactersers.Select(c => new Character
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = c.Image,
                  
                });
                var charactersDTO = _mapper.Map<IEnumerable<Character>, IEnumerable<CharacterDTO>>(characters);
                return Ok(charactersDTO);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //TODO: LISTAR Caracteres
        [HttpGet]
        [Route(template: "api/[controller]/GetCharWithSeriesOrMovies")]
        public IActionResult GetCharWithSeriesOrMovies()
        {
            try
            {
                List<Character> characters = _context.Charactersers.Select(c => new Character { Id = c.Id, Name = c.Name, Image = c.Image, Age = c.Age, MovieOrSeries = c.MovieOrSeries }).ToList();
                //(
                //                                from ca in _context.Charactersers.ToList() 
                //                                //join mc in _context.MovieOrSeries.Select(m => m.Characters).FirstOrDefault()                               
                //                                //on ca.Id equals mc.Id
                //                                select new Character 
                //                                { 
                //                                    Id = ca.Id,
                //                                    Name = ca.Name, 
                //                                    Image = ca.Image,
                //                                    Age = ca.Age,
                //                                    Weight = ca.Weight,
                //                                    History = ca.History,
                //                                    MovieOrSeries = ca.MovieOrSeries
                //                                }).ToList();

                return Ok(characters);//(_context.Charactersers.ToList());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //TODO: Buscar Nombre
        [HttpGet("name")]
        
        public ActionResult<Character> GetCharacterByName(string name)
        {
           return Ok(_context.Charactersers.Where(c => c.Name == name));
           //return Ok(_context.Charactersers.Find(name));
        }


        //TODO: Buscar Edad
        [HttpGet("Age")]

        public ActionResult<Character> GetCharacterByAge(int Age)
        {
            return Ok(_context.Charactersers.Where(c => c.Age == Age));
            
        }


        //TODO: Buscar Movie Or Serie
        [HttpGet("movies")]

        //public ActionResult<Character> GetCharacterByMovieOrSerie(int IdMovie)
        //{
        //    return Ok(_context.Charactersers.Where(c => c. == IdMovie));

        //}




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
