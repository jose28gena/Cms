namespace Common
{
    using Model.Entities;
    using System.Data.Entity;
    public partial class CmsContext : DbContext
    {
        public CmsContext()
            : base("name=CmsContext")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Contenido> Contenido { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Contenido)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.CreadoPor);
            
        }
    }
}
