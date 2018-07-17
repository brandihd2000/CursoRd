using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Services;
using SixLabors.ImageSharp;

namespace CursosWeb.Controllers
{
   [Route( "api/[controller]/[action]")]
    public class CursoController : Controller
    {
        private readonly ICursoServices _cursoServices;
       

        public CursoController(ICursoServices cursoServices)
        {
            _cursoServices = cursoServices;
            
        }

      
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(
                _cursoServices.GetAll()
                );
        }


        [HttpGet]
        public IActionResult ultimo()
        {
            return Json(
                _cursoServices.UltimoCurso()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _cursoServices.Get(id)
             );
        }

        [HttpGet("{Nombre}")]
        public IActionResult GetFiltro(string Nombre)
        {
            return Ok(
                _cursoServices.GetFiltro(Nombre)
             );
        }

        [HttpGet("{id}")]
        public IActionResult GetCursoCategoria(int id)
        {
            return Ok(
                _cursoServices.cursosCategoria(id)
             );
        }

        public IActionResult Index()
        {
            return View();
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Curso Model)
        {
            return Ok(
                _cursoServices.Add(Model)
             );

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Curso model)
        {
            model.Id = id;
            return Json(
               _cursoServices.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
              _cursoServices.Delete(id)
           );
        }

       

 [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileUploadViewModel model,  [FromForm] string Nombre, [FromForm]string Descripcion, [FromForm] string Votos, [FromForm] string Categorias)
        {
           
             var file = model.File;

            var modelo = new Curso();
            string path = Path.Combine("C:\\Users\\brand\\Desktop\\Webpack\\ejemplo-webpack\\static\\img");

            if (file.Length > 0)
            {
              

                using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                modelo.Nombre = Nombre;
                modelo.Descripcion = Descripcion;
                modelo.Imagen = "/static/img/" + file.FileName;
                modelo.Votos = Convert.ToDecimal(Votos);

                model.Source = "/static/img/" + file.FileName;
                    model.Extension = Path.GetExtension(file.FileName).Substring(1);
                    model.Size = file.Length / 1000;

                // ModelCurso.Imagen = "/static/img/" + file.FileName; ;
                    _cursoServices.Add(modelo);


                        }

                 int idCurso;
                 idCurso = _cursoServices.UltimoCurso() ;

            List<Categoria> categoriasModel = JsonConvert.DeserializeObject<List<Categoria>>(Categorias);

            foreach (Categoria categoriaModel in categoriasModel)
            {
                CategoriaCurso CategoriaCurso = new CategoriaCurso
                {
                    CategoriaId = categoriaModel.Id,
                    CursoId = idCurso
                };
                _cursoServices.AddCategoriaCurso(CategoriaCurso);
            }

            return Ok();
        }
        
        // POST api/values
        [HttpPost]
        public IActionResult sendEmail()
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("brandihd2000@gmail.com");
            msg.To.Add("20163520@itla.edu.do");
            msg.Subject = "adasd";
            msg.Body = "asdasdasdsadasd";
            MailAddress ms = new MailAddress("20163520@itla.edu.do");
            
            msg.CC.Add(ms);
            SmtpClient sc = new SmtpClient("smtp.gmail.com");
            sc.Port = 25;
            sc.Credentials = new NetworkCredential("brandihd2000@gmail.com" , "brandihd");
            sc.EnableSsl = true;
            sc.Send(msg);
           


            return Ok();
        }

    }
}