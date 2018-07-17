using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CategoriaCurso
    {
        public int CategoriaId { get; set; }
        public Categoria categoria { get; set; }

        public int CursoId { get; set; }
        public Curso curso { get; set; }
    }
}