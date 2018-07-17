using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace CursosWeb.Controllers
{

    [Route("api/[controller]/[action]")]
    public class PersonaController : Controller
    {

        private readonly IPersonaServices _personaServices;

        public PersonaController(IPersonaServices personaServices)
        {
            _personaServices = personaServices;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _personaServices.Get(id)
             );
        }

        [HttpPost]
        public IActionResult Login([FromBody] Persona persona)
        {
            return Json(
                _personaServices.Login(persona)
             );
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileUploadViewModel model, [FromForm] string username, [FromForm]string password, [FromForm] string nombre
            , [FromForm]string apellidos, [FromForm]string correo, [FromForm]string tipousuario
            )
        {

            var file = model.File;

            var modelo = new Persona();
            string path = Path.Combine("C:\\Users\\brand\\Desktop\\Webpack\\ejemplo-webpack\\static\\img\\Usuarios");

            if (file.Length > 0)
            {

               
                using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                modelo.username = username;
                modelo.password = password;
                modelo.nombre = nombre;
                modelo.apellidos = apellidos;
                modelo.correo = correo;
                modelo.tipousuario = tipousuario;
                modelo.foto = "/static/img/Usuarios/" + file.FileName;

                model.Source = "/static/img/" + file.FileName;
                model.Extension = Path.GetExtension(file.FileName).Substring(1);
                model.Size = file.Length / 1000;

                // ModelCurso.Imagen = "/static/img/" + file.FileName; ;


                _personaServices.Add(modelo);

                try
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("brandihd2000@gmail.com");
                    msg.To.Add(correo);
                    msg.Subject = "Cursos RD";
                    msg.Body =
                        "<div> " +
                        "<h1>Bienvendo a nuestra comunidad </h1> " +
                        "" +
                        "" +
                        "</div>";
                    msg.IsBodyHtml = true;
                    MailAddress ms = new MailAddress(correo);

                    msg.CC.Add(ms);
                    SmtpClient sc = new SmtpClient("smtp.gmail.com");
                    sc.Port = 25;
                    sc.Credentials = new NetworkCredential("brandihd2000@gmail.com", "brandihd");
                    sc.EnableSsl = true;
                    sc.Send(msg);

                }
                catch (Exception)
                {

                    throw;
                }

                return Ok(modelo);


            }
            return BadRequest();
        }

    }
}