using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public interface ICursoServices
    {
        IEnumerable<Curso> GetAll();
        IEnumerable<Curso> GetFiltro(string Nombre);
        bool Add(Curso model);
        bool AddCategoriaCurso(CategoriaCurso model);
        bool Update(Curso model);
        bool Delete(int cursoid);
        Curso Get(int id);
        int UltimoCurso();
        IEnumerable<Curso> cursosCategoria(int id);
    }


    public class CursoServices : ICursoServices
    {
        private readonly CursosDbContext _cursosDbContext;

        public int idCurso ;


        public CursoServices(CursosDbContext cursosDbContext )
        {
            _cursosDbContext = cursosDbContext;
         }

        

        public int UltimoCurso()
        {
            try
            {

                idCurso = _cursosDbContext.Curso
           .OrderByDescending(x => x.Id)
           .First().Id;

               
            }
            catch (Exception ex)
            {
               
            }
            return idCurso;
        }

        public IEnumerable<Curso> GetAll()
        {
            var result = new List<Curso>();
            try
            {

                result = _cursosDbContext.Curso.ToList();

                
            }
            catch (Exception)
            {


            }
            return result;
        }

     

        public Curso Get(int id)
        {
            var result = new Curso();
            try
            {

                result = _cursosDbContext.Curso.Single(x => x.Id == id);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public bool Add(Curso model)
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

        public bool AddCategoriaCurso(CategoriaCurso model )
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
        public bool Update(Curso model)
        {
            try
            {

                var originalModel = _cursosDbContext.Curso.Single(x =>
                    x.Id == model.Id
                    );

                originalModel.Nombre = model.Nombre;
                originalModel.Descripcion = model.Descripcion;
                
                originalModel.Votos = model.Votos;


               

                _cursosDbContext.Update(originalModel);
                _cursosDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool Delete(int cursoId)
        {
            try
            {
                _cursosDbContext.Entry(new Curso { Id = cursoId }).State = EntityState.Deleted; ;
                _cursosDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<Curso> cursosCategoria(int id)
        {
            var result = new List<Curso>();
            try
            {
                result = (from curso in _cursosDbContext.Curso
                              join categoriacurso in _cursosDbContext.CategoriaCurso
                              on curso.Id equals categoriacurso.CursoId
                            where (categoriacurso.CategoriaId == id) 
                      select curso).ToList();

            }
            catch (Exception)
            {


            }
            return result;
        }

        public IEnumerable<Curso> GetFiltro(string Nombre)
        {
            var result = new List<Curso>();
            try
            {

                result = _cursosDbContext.Curso.Where(c => c.Nombre.Contains(Nombre) || c.Descripcion.Contains(Nombre)).ToList();

            }
            catch (Exception)
            {


            }
            return result;
        }

      

    }

}
