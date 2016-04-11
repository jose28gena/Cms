namespace Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Contenido = new HashSet<Contenido>();
        }

        [Key]
        public int idCategoria { get; set; }

        [StringLength(50)]
        [Required]

        public string Titulo { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public int idEmpresa { get; set; }

        public int idCategoriaRol { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual CategoriaRol CategoriaRol { get; set; }

        public int? Orden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contenido> Contenido { get; set; }
    }
}
