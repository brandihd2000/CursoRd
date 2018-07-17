using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;

namespace Services
{

    public  interface IComentarioServices  {
        bool Add(ComentariosCursos model);
        IEnumerable<ComentariosCursos> GetAll();
        IEnumerable<ComentariosCursos> GetComentarios(int id);
    }

   public class ComentarioServices : IComentarioServices
    {
        private readonly CursosDbContext _cursosDbContext;

        public ComentarioServices(
            CursosDbContext cursosDbContext
            )
        {
            _cursosDbContext = cursosDbContext;
        }

        public IEnumerable<ComentariosCursos> GetComentarios(int id)
        {

            var result = new List<ComentariosCursos>();

            try
            {
                result = (from r in _cursosDbContext.ComentariosCursos
                   where r.CursoId == id
                          select r
                  ).ToList();

            }
            catch (Exception)
            {

                throw;
            }



            return result;
        }


        public IEnumerable<ComentariosCursos> GetAll()
        {
            var result = new List<ComentariosCursos>();
            try
            {

                result = _cursosDbContext.ComentariosCursos.ToList();

            }
            catch (Exception)
            {


            }
            return result;
        }

        public bool Add(ComentariosCursos model)
        {
            try
            {
                _cursosDbContext.Add(model);
                _cursosDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

    }
}
