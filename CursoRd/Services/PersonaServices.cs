using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;

namespace Services
{

    public interface IPersonaServices
    {
        Persona Login(Persona persona);
        bool Add(Persona model);
        Persona Get(int id);
    }

    public class PersonaServices : IPersonaServices
    {
        private readonly CursosDbContext _cursosDbContext;

        public PersonaServices(
            CursosDbContext cursosDbContext
            )
        {
            _cursosDbContext = cursosDbContext;
        }



        public Persona Login(Persona persona) // validacion
        {
            var result = new Persona();

            try
            {

                result = _cursosDbContext.Persona.FirstOrDefault(x => x.username.Equals(persona.username)
                && x.password.Equals(persona.password));

            }
            catch (Exception)
            {


            }
            return result;
        }

        public bool Add(Persona model)
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

        public Persona Get(int id)
        {
            var result = new Persona();
            try
            {

                result = _cursosDbContext.Persona.Single(x => x.Id == id);

            }
            catch (Exception)
            {


            }
            return result;
        }

    }
}
