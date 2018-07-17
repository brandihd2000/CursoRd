
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
   public class AlumnosPorCurso
    {
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool Completado { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }

      /*  [ForeignKey("UsuarioId")]
        public ApplicationUser Usuario { get; set; }
        public string UsuarioId { get; set; }
        */

    }
}
