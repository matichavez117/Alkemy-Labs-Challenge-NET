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
using Commands.Users;

namespace disney_api.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    //[Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Context db = new Context();

        public UserController()
        {

        }

        [HttpPost]
        [Route("/auth/login")]
        public ActionResult<ResultAPI> Login([FromBody] CommandUserLogin command)
        {
            var result = new ResultAPI();
            var email = command.email.Trim();
            var password = command.password;

            try
            {
                var usuario = db.Users.FirstOrDefault(u => u.Password.Equals(password) && u.Email.Equals(email));
                if (usuario != null)
                {

                    result.ok = true;
                    result.Return = usuario;
                }
                else
                {
                    result.ok = false;
                    result.error = "Usuario o contraseña incorrectos";
                }

                return result;
            }
            catch (Exception ex)
            {
                result.ok = false;
                result.codeError = 1;
                result.error = "Usuario no encontrado";

                return result;
            }
        }

        [HttpPost]
        [Route("/auth/register")]

        public ActionResult<ResultAPI> userRegister([FromBody] CommandUserRegister command)
        {
            var result = new ResultAPI();
            if (command.email.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese su email";
                return result;
            }
            if (command.username.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese su nombre de usuario";
                return result;
            }
            if (command.password.Equals(""))
            {
                result.ok = false;
                result.error = "Ingrese su clave de acceso";
                return result;
            }

            var a = new User();
            a.username = command.username;
            a.password = command.password;
            a.email = command.email;

            db.Users.Add(a);
            db.SaveChanges();

            return result;
        }
    }
}