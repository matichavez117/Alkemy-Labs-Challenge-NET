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

namespace disney_api.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    //[Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly Context db = new Context();

        public CharacterController()
        {

        }

        [HttpGet]
        [Route("/characters")]
        public ActionResult<ResultAPI> Get()
        {
            var chList = db.Characters.ToList();
            var chList2 = new List<Character>();

            foreach (var ch in chList)
            {
                var b = new Character
                {
                    Image = ch.image,
                    Name = ch.name
                };
                chList2.Add(b);
            }
            return Ok(chList2);
        }

        [HttpPost]
        [Route("/characters/create")]

        public ActionResult<ResultAPI> createCharacter([FromBody] CommandCreateCharacter command)
        {
            var result = new ResultAPI();
            if (command.Image.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese una direccion de imagen";
                return result;
            }
            if (command.Name.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese el nombre del personaje";
                return result;
            }
            if (command.Age.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la edad del personaje";
                return result;
            }
            if (command.Weight.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese el peso del personaje";
                return result;
            }
            if (command.History.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la historia del personaje";
                return result;
            }
            if (command.IdMovie.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la pelicula que protagonizo el personaje";
                return result;
            }

            var p = new Character();
            p.image = command.Image;
            p.name = command.Name;
            p.age = command.Age;
            p.weight = command.Weight;
            p.history = command.History;
            p.idMovie = command.IdMovie;

            db.Characters.Add(p);
            db.SaveChanges();

            return result;
        }

        [HttpPut]
        [Route("/characters/edit")]
        public ActionResult<ResultAPI> editCharacter([FromBody] CommandEditCharacter command)
        {
            var result = new ResultAPI();
            if (command.Image.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese una direccion de imagen";
                return result;
            }
            if (command.Name.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese el nombre del personaje";
                return result;
            }
            if (command.Age.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la edad del personaje";
                return result;
            }
            if (command.Weight.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese el peso del personaje";
                return result;
            }
            if (command.History.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la historia del personaje";
                return result;
            }
            if (command.IdMovie.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese la pelicula que protagonizo el personaje";
                return result;
            }

            var character = db.Characters.Where(c => c.Id == command.IdCharacter).FirstOrDefault();
            if (character != null)
            {
                character.image = command.Image;
                character.name = command.Name;
                character.age = command.Age;
                character.weight = command.Weight;
                character.history = command.History;
                character.idMovie = command.IdMovie;
                db.Characters.Update(character);
                db.SaveChanges();
            }

            result.ok = true;
            result.Return = db.Characters.ToList();

            return result;
        }

        [HttpPost]
        [Route("character/delete")]
        public ActionResult<ResultAPI> DeleteCharacter(int Id)
        {
            var resultado = new ResultAPI();
            try
            {
                var character = db.Characters.Where(c => c.Id == Id).FirstOrDefault();
                db.Characters.Remove(character);
                db.SaveChanges();
                resultado.ok = true;
                resultado.Return = db.Characters.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.codeError = 1;
                resultado.error = "Error al eliminar el personaje";

                return resultado;
            }
        }

        [HttpGet]
        [Route("/characters/details")]
        public ActionResult<ResultAPI> charactersDetails()
        {
            var resultado = new ResultAPI();
            var table = db.Characters.ToList();
            try
            {
                resultado.ok = true;
                resultado.Return = table;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.ok = false;
                resultado.error = "Error al obtener detalles";
                resultado.codeError = 1;

                return resultado;
            }
        }

        [HttpGet]
        [Route("character/get/(name)")]
        public ActionResult<ResultAPI> GetName(string name)
        {
            var result = new ResultAPI();
            try
            {
                var character = db.Characters.Where(c => c.Name.Equals(name)).FirstOrDefault();
                result.ok = true;
                result.Return = character;
                return result;

            }
            catch (Exception ex)
            {
                result.ok = false;
                result.codeError = 1;
                result.error = "Personaje no encontrado";

                return result;
            }
        }
    }
}