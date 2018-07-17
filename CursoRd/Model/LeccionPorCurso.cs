using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
  public  class LeccionPorCurso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contenido { get; set; }
        public string Video { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
