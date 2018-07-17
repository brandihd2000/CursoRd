using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Model
{
   public class RevisionCurso
    {
        public int Id { get; set; }
        public decimal Voto { get; set; }
        public string Comentario { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }

        /*
        [ForeignKey("UsuarioId")]
        public ApplicationUser Usuario { get; set; }
        public string UsuarioId { get; set; }
        */
    }
}
