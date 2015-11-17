using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysLibrary.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SysLibrary.Data
{
    public class Context : DbContext
    {
        public Context()
            : base("Connection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Exemplar> Exemplar { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Obra> Obra { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Locacao> Locacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Autor>().ToTable("Autores");
            modelBuilder.Entity<Editora>().ToTable("Editoras");
            modelBuilder.Entity<Exemplar>().ToTable("Exemplares");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Obra>().ToTable("Obras");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Locacao>().ToTable("Locacoes");

            base.OnModelCreating(modelBuilder);

        }
    }
}
