using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace CursosWeb.Controllers
{

    [Route("api/[controller]/[action]")]
    public class LeccionController : Controller
    {
        private readonly ILeccionServices _leccionServices;


        public LeccionController(ILeccionServices leccionServices)
        {
            _leccionServices = leccionServices;

        }


        [HttpGet]
        public IActionResult Get()
        {
            return Json(
                _leccionServices.GetAll()
                );
        }

        [HttpGet("{Nombre}/{Id}")]
        public IActionResult GetFiltro(string Nombre, int Id)
        {
            return Ok(
                _leccionServices.GetFiltro(Nombre, Id)
             );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _leccionServices.Get(id)
             );
        }

        [HttpGet("{id}")]
        public IActionResult GetLeccion(int id)
        {
            return Ok(
                _leccionServices.GetLeccion(id)
             );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]LeccionPorCurso Model)
        {
            return Ok(
                _leccionServices.Add(Model)
             );

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LeccionPorCurso model)
        {
            model.Id = id;
            return Json(
               _leccionServices.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
              _leccionServices.Delete(id)
           );
        }
    }
}