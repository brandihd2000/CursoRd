using System;
using System.Collections.Generic;
using System.Text;

using Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
   public class CursosDbContext : DbContext 
    {

        public CursosDbContext(DbContextOptions<CursosDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaCurso>().HasKey(sc => new { sc.CategoriaId, sc.CursoId });
        }

        // public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //  public DbSet<ApplicationRole> ApplicationRole { get; set; }
        //   public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<LeccionesAprendidasPorUsuario> LeccionesAprendidasPorUsuario { get; set; }
        public DbSet<LeccionPorCurso> LeccionPorCurso { get; set; }
        public DbSet<RevisionCurso> RevisionCurso { get; set; }
        public DbSet<AlumnosPorCurso> AlumnosPorCurso { get; set; }
        public DbSet<CategoriaCurso> CategoriaCurso { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<ComentariosCursos> ComentariosCursos { get; set; }


    }
}
