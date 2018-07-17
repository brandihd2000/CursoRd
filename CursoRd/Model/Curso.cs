using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;



namespace Model
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public Decimal Votos { get; set; }
       

        public IList<CategoriaCurso> CategoriaCurso { get; set; }
    }
}

