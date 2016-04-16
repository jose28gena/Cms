namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            SubCategoria = new HashSet<SubCategoria>();
        }

        [Key]
        public int idCategoria { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public int? Orden { get; set; }

        public int idEmpresa { get; set; }

        public int idCategoriaRol { get; set; }

        public virtual CategoriaRol CategoriaRol { get; set; }

        public virtual Empresa Empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubCategoria> SubCategoria { get; set; }
    }
}
