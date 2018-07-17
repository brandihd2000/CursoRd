using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LeccionesAprendidasPorUsuario
    {
        public int Id { get; set; }

        public LeccionPorCurso leccion { get; set; }
        public int LeccionId { get; set; }

        /*
        [ForeignKey("UsuarioId")]
        public ApplicationUser  Usuario { get; set; }
        public string UsuarioId { get; set; }
        */
    }
}
