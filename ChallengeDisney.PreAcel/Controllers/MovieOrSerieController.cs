using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChallengeDisney.PreAcel.Context;
using ChallengeDisney.PreAcel.Entities;
using ChallengeDisney.PreAcel.DTO.GET;
using AutoMapper;

namespace ChallengeDisney.PreAcel.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class MovieOrSerieController : ControllerBase
    {

        private readonly WordDisneyContext _context;
        private readonly IMapper _mapper;

        public MovieOrSerieController(WordDisneyContext context, IMapper mapper) 
        {
            this._context = context;
            this._mapper = mapper;
        }

        //TODO: LISTAR peliculas
        [HttpGet]
        [Route(template: "/GetAllMovies")]
        public IActionResult GetAllMovieOrSerie()
        {
            return Ok(_context.MovieOrSeries.ToList());
        }

        //TODO: LISTAR peliculas con imagen, fecha y titulo
        [HttpGet]
        [Route(template: "/Movies")]
        public IActionResult GetDetailListMovieOrSerie()
        {
            try
            {
                IEnumerable<MovieOrSerie> movieOrSeries = _context.MovieOrSeries.Select(m => new MovieOrSerie
                {
                    Id = m.Id,
                    Title = m.Title,
                    GetDate = m.GetDate,
                    Characters = m.Characters
                }); 
                var movieOrSeriesDTO = _mapper.Map<IEnumerable<MovieOrSerie>, IEnumerable<MovieOrSerieDTO>>(movieOrSeries);

                //Select(m => new MovieOrSeireDTO { Id = m.Id, Title = m.Title, GetDate = m.GetDate,  Characters = m.Characters }).ToList();
                //(MovieOrSerieDTO
                //    from m in _context.MovieOrSeries.ToList()
                //    select new MovieOrSerie
                //    {
                //        Id = m.Id,
                //        Title = m.Title,
                //        GetDate = m.GetDate,
                //        Characters = m.Characters,
                //        Score = null
                //    }

                //).ToList();

                return Ok(movieOrSeriesDTO);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //TODO: Buscar por TITLE
        [HttpGet("name")]

        public ActionResult<Character> GetMovieOrSerieByTitle(string Title)
        {
            return Ok(_context.MovieOrSeries.Where(c => c.Title == Title));
            
        }

        //TODO: Detalle por ID
        [HttpGet("Id")]

        public ActionResult<Character> GetMovieOrSerieByTitle(int Id)
        {
            //MovieOrSerie movie = _context.MovieOrSeries.Where(c => c.Id == Id).FirstOrDefault();
            MovieOrSerie movie = _context.MovieOrSeries.Find(Id);

            return Ok(movie);
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
