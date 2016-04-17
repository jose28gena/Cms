namespace Model.Entities
{
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa:IAuditable
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
        [Display(Name = "Visión")]
        public string Vision { get; set; }

        [StringLength(100)]
        [Display(Name = "Misión")]
        public string Mision { get; set; }
        [Display(Name = "#Domicilio")]
        [StringLength(10)]
        public string NumeroCalle { get; set; }

        [StringLength(150)]
        public string Calle { get; set; }

        [StringLength(50)]
        public string Colonia { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }

        [StringLength(100)]
        public string Coordenadas { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Número telefonico requerido.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Ingrese un número telefonico valido.")]
        public string Telefono { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
       
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Ingrese un número celular valido.")]
        [StringLength(50)]
        public string Celular { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El e-mail es un campo requerido.")]
        [EmailAddress(ErrorMessage = "EL e-mail es invalido.")]
        [StringLength(100)]
        public string Correo { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }
        [Url]
        [StringLength(100)]
        public string Twitter { get; set; }

        public DateTime CreadoFecha { get; set; }

        public int CreadoPor { get; set; }
        
        public int ActualizadoPor { get; set; }

        public DateTime ActualizadoFecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categoria> Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contenido> Contenido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
