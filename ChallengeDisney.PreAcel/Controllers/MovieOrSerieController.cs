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
    public class MovieOrSerieController : ControllerBase
    {



        private readonly WordDisneyContext _context;
        private object MovieOrSerie;

        public MovieOrSerieController(WordDisneyContext context) => _context = context;

        //TODO: LISTAR peliculas
        [HttpGet]
        [Route(template: "/Movies")]
        public IActionResult Get()
        {
            return Ok(_context.MovieOrSeries.ToList());
        }

        //TODO: Buscar
        [HttpGet("name")]

        public ActionResult<Character> GetMovieOrSerieByTitle(string Title)
        {
            return Ok(_context.MovieOrSeries.Where(c => c.Title == Title));
            
        }



        //TODO: crear

        [HttpPost]
        [Route(template: "api/[controller]/Create")]
        public IActionResult Post(MovieOrSerie MovieOrSerie)
        {
            _context.MovieOrSeries.Add(MovieOrSerie);
            _context.SaveChanges();
            return Ok(_context.MovieOrSeries.ToList());
        }

        //TODO: modificar
        [HttpPut]
        [Route(template: "api/[controller]/Update")]
        public IActionResult Put(MovieOrSerie MovieOrSerie)
        {
            if (_context.MovieOrSeries.FirstOrDefault(g => g.Id == MovieOrSerie.Id) == null) return BadRequest("La Pelicula o Serie enviado no existe");
            var internaMovieOrSerie = _context.MovieOrSeries.Find(MovieOrSerie.Id);

            internaMovieOrSerie.Title = MovieOrSerie.Title;
            internaMovieOrSerie.Image = MovieOrSerie.Image;
            internaMovieOrSerie.Score = MovieOrSerie.Score;
            _context.SaveChanges();
            return Ok(_context.MovieOrSeries.ToList());
        }
        //TODO: borrar
        [HttpDelete]
        [Route("{id}/Delete")]
        public IActionResult Delete(int id)
        {
            if (_context.MovieOrSeries.FirstOrDefault(g => g.Id == id) == null) return BadRequest("La Pelicula o Serie enviado no existe");

            var internaCharacter = _context.MovieOrSeries.Find(id);
            _context.MovieOrSeries.Remove(internaCharacter);
            _context.SaveChanges();
            return Ok();



        }



    }




}
