using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Slug { get; set; }
        public string Icon { get; set; }

        public IList<CategoriaCurso> CategoriaCurso { get; set; }
    }
}
