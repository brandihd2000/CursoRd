using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ComentariosCursos
    {

        public int  Id { get; set; }
        
        public string Foto { get; set; }

        public string NombreAutor { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }


        public int CursoId { get; set; }
        public Curso curso { get; set; }

        public int PersonaId { get; set; }
        public Persona persona { get; set; }

        public string Color { get; set; }

    }
}
