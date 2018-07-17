using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace CursosWeb.Controllers
{
    [Route( "api/[controller]/[action]")]
    public class CategoriaController : Controller
    {

        private readonly ICategoriaServices _categoriaServices;

        public CategoriaController( ICategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(
                _categoriaServices.GetAll()
                ) ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult  Get(int id)
        {

            var result = _categoriaServices.Get(id);

          
                if (result.Id == 0)
                {
                return NotFound();
                 }
                else
                {
                    return Ok(result);
                }
                
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Categoria Model)
        {
            return Ok(
                _categoriaServices.Add(Model)
             );


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria model )
        {
            model.Id = id;
            return Json(
               _categoriaServices.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
              _categoriaServices.Delete(id)
           );
        }
    
}
}