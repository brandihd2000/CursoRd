using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public interface ICategoriaServices
    {
        IEnumerable<Categoria> GetAll();
        bool Add(Categoria model);
        bool Update(Categoria model);
        bool Delete(int categoriaid);
        Categoria Get(int id);
    }

    public class CategoriaServices : ICategoriaServices
    {

        private readonly CursosDbContext _cursosDbContext;

        public CategoriaServices(
            CursosDbContext cursosDbContext
            )
        {
            _cursosDbContext = cursosDbContext;
        }




        public IEnumerable<Categoria> GetAll()
        {
            var result = new List<Categoria>();
            try
            {

                result = _cursosDbContext.Categoria.ToList();

            }
            catch (Exception)
            {

             
            }
            return result;
        }
        public Categoria Get(int id)
        {
            var result = new Categoria();
            try
            {

                result = _cursosDbContext.Categoria.Single(x => x.Id == id);

            }
            catch (Exception)
            {


            }
            return result;
        }
        public bool Add(Categoria model)
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

        public bool Categoria(Categoria model)
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
        public bool Update(Categoria model)
        {
            try
            {

                var originalModel = _cursosDbContext.Categoria.Single(x =>
                    x.Id == model.Id
                    );

                originalModel.Icon = model.Icon;
                originalModel.Nombre = model.Nombre;
                originalModel.Slug = model.Slug;

                _cursosDbContext.Update(originalModel);
                _cursosDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool Delete(int categoriaid)
        {
            try
            {
                _cursosDbContext.Entry(new Categoria { Id = categoriaid }).State = EntityState.Deleted ; ;
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
