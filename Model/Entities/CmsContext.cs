namespace Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Common;
    using Repository.Interfaces;
    public partial class CmsContext : DbContext
    {
        public CmsContext()
            : base("name=CmsContext")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<CategoriaRol> CategoriaRol { get; set; }
        public virtual DbSet<Contenido> Contenido { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<SubCategoria> SubCategoria { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.SubCategoria)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoriaRol>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaRol>()
                .HasMany(e => e.Categoria)
                .WithRequired(e => e.CategoriaRol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contenido>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Contenido>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Contenido>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Contenido>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Vision)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Mision)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.NumeroCalle)
                .IsFixedLength();

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Colonia)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Coordenadas)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Twitter)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Categoria)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Contenido)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategoria>()
                .Property(e => e.Subcategorias)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategoria>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Foto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Contenido)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.CreadoPor)
                .WillCascadeOnDelete(false);
        }
        public override int SaveChanges()
        {
            Auditar();
            return base.SaveChanges();
        }

        public void Auditar()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is IAuditable && (x.State == System.Data.Entity.EntityState.Added
                     || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditable entity = entry.Entity as IAuditable;
                if (entity != null)
                {
                    var fecha = DateTime.Now;
                    var usuario = SessionHelper.GetUser();

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreadoFecha = fecha;
                        entity.CreadoPor = usuario;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreadoFecha).IsModified = false;
                        base.Entry(entity).Property(x => x.CreadoPor).IsModified = false;
                    }

                    entity.ActualizadoFecha = fecha;
                    entity.ActualizadoPor = usuario;
                }
            }
        }
    }

}
