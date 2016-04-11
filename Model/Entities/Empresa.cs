namespace Model.Entities
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            Categoria = new HashSet<Categoria>();
            Contenido = new HashSet<Contenido>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int idEmpresa { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(150)]
        public string Imagen { get; set; }

        [StringLength(100)]
        public string Vision { get; set; }

        [StringLength(100)]
        public string Mision { get; set; }

        [StringLength(150)]
        public string Direccion { get; set; }

        public int? Telefono { get; set; }

        public int? Celular { get; set; }

        [StringLength(50)]
        public string Facebook { get; set; }

        [StringLength(50)]
        public string Twittwer { get; set; }

        public string Ubicacion { get; set; }

        public DateTime? CreadoFecha { get; set; }

        public int? CreadorPor { get; set; }

        public int? ActualizadoPor { get; set; }

        public DateTime? ActualizadoFecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categoria> Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contenido> Contenido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }


    }
}
