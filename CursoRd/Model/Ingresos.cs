using System;
using System.Collections.Generic;
using System.Text;


namespace Model
{
   public class Ingresos
    {
        public int Id { get; set; }
        public TipoIngreso TipoIngreso { get; set; }
        public PagoCurso PagoCurso { get; set; }
        public decimal Total { get; set; }
        public int EntidadId { get; set; }

    }

    public enum TipoIngreso {PagoCurso }
    public enum PagoCurso {TotalEmpresa,TotalProfesor}
}
