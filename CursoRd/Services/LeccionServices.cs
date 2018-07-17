using System;
using System.Collections.Generic;
using System.Text;
using Persistence;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface ILeccionServices
    {
        IEnumerable<LeccionPorCurso> GetAll();
        IEnumerable<LeccionPorCurso> GetFiltro(string Nombre, int Id);
        bool Add(LeccionPorCurso model);
        bool Update(LeccionPorCurso model);
        bool Delete(int leccionid);
        IEnumerable<LeccionPorCurso> Get(int id);
        LeccionPorCurso GetLeccion(int id);

    }

   public class LeccionServices : ILeccionServices
    {
        private readonly CursosDbContext _cursosDbContext;

        public LeccionServices(CursosDbContext cursosDbContext)
        {
            _cursosDbContext = cursosDbContext;
        }




        public IEnumerable<LeccionPorCurso> GetAll()
        {
            var result = new List<LeccionPorCurso>();
            try
            {

                result = _cursosDbContext.LeccionPorCurso.ToList();

            }
            catch (Exception)
            {


            }
            return result;
        }

        public IEnumerable<LeccionPorCurso> Get(int id)
        {

     var result = new List<LeccionPorCurso>();

            try
            {
                result = (from r in _cursosDbContext.LeccionPorCurso

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


        public bool Add(LeccionPorCurso model)
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

        public bool Update(LeccionPorCurso model)
        {
            try
            {

                var originalModel = _cursosDbContext.LeccionPorCurso.Single(x =>
                    x.Id == model.Id
                    );

                
                originalModel.Contenido = model.Contenido;
                originalModel.CursoId = model.CursoId;
                originalModel.Nombre = model.Nombre;
                originalModel.Video = model.Video;

                _cursosDbContext.Update(originalModel);
                _cursosDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool Delete(int leccionid)
        {
            try
            {
                _cursosDbContext.Entry(new LeccionPorCurso { Id = leccionid }).State = EntityState.Deleted; 
                _cursosDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public LeccionPorCurso GetLeccion(int id)
        {
            var result = new LeccionPorCurso();
            try
            {

                result = _cursosDbContext.LeccionPorCurso.Single(x => x.Id == id);

            }
            catch (Exception)
            {


            }
            return result;
        }

        public IEnumerable<LeccionPorCurso> GetFiltro(string Nombre, int Id)
        {
            var result = new List<LeccionPorCurso>();
            try
            {

                result = _cursosDbContext.LeccionPorCurso.Where(c => (c.Nombre.Contains(Nombre) || c.Contenido.Contains(Nombre)) && c.CursoId == Id ).ToList();

               

            }
            catch (Exception)
            {


            }
            return result;
        }

    }
}
