using System.Net.Mime;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Data;
using Results;
using Commands.Characters;
using Commands.Movies;

namespace disney_api.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    //[Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly Context db = new Context();

        public MovieController()
        {

        }

        [HttpPost]
        [Route("/movies/create")]

        public ActionResult<ResultAPI> createMovie([FromBody] CommandCreateMovie command)
        {
            var result = new ResultAPI();
            if (command.Image.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese una direccion de imagen";
                return result;
            }
            if (command.Title.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese el titulo de la pelicula";
                return result;
            }
            if (command.CreationDate.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la fecha de estreno de la pelicula";
                return result;
            }
            if (command.Qualification == 0)
            {
                result.ok = false;
                result.error = "Ingrese la calificacion";
                return result;
            }

            var m = new Movie();
            m.image = command.Image;
            m.title = command.Title;
            m.creationDate = command.CreationDate;
            m.qualification = command.Qualification;
            db.Movies.Add(m);
            db.SaveChanges();

            return result;
        }

        [HttpPut]
        [Route("/movies/edit")]
        public ActionResult<ResultAPI> editMovie([FromBody] CommandEditMovie command)
        {
            var result = new ResultAPI();
            if (command.Image.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese una direccion de imagen";
                return result;
            }
            if (command.Title.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese el titulo de la pelicula";
                return result;
            }
            if (command.CreationDate.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la fecha de estreno de la pelicula";
                return result;
            }
            if (command.Qualification == 0)
            {
                result.ok = false;
                result.error = "Ingrese la calificacion";
                return result;
            }

            var movie = db.Movies.Where(c => c.Id == command.IdMovie).FirstOrDefault();
            if (movie != null)
            {
                movie.image = command.Image;
                movie.title = command.Title;
                movie.creationDate = command.CreationDate;
                movie.qualification = command.Qualification;
                db.Movies.Update(movie);
                db.SaveChanges();
            }

            result.ok = true;
            result.Return = db.Movies.ToList();

            return result;
        }

        [HttpPost]
        [Route("movies/delete")]
        public ActionResult<ResultAPI> DeleteMovie(int Id)
        {
            var resultado = new ResultAPI();
            try
            {
                var movie = db.Movies.Where(c => c.Id == Id).FirstOrDefault();
                db.Movies.Remove(movie);
                db.SaveChanges();
                resultado.ok = true;
                resultado.Return = db.Movies.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.codeError = 1;
                resultado.error = "Error al eliminar la pelicula";

                return resultado;
            }
        }
    }
}