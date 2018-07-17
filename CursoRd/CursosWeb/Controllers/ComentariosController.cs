using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Model;

namespace CursosWeb.Controllers
{

    [Route("api/[controller]/[action]")]
    public class ComentariosController : Controller
    {

        private readonly IComentarioServices _comentarioServices;

        public ComentariosController(IComentarioServices comentarioServices)
        {
            _comentarioServices = comentarioServices;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(
                _comentarioServices.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetComentarios(int id)
        {
            return Ok(
                _comentarioServices.GetComentarios(id)
             );
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ComentariosCursos Model)
        {
            return Ok(
                _comentarioServices.Add(Model)
             );

        }

    }
}