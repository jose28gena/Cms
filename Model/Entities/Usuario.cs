namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        public string Foto { get; set; }

        public DateTime CreadoFecha { get; set; }

        public int CreadoPor { get; set; }

        public int ActualizadoPor { get; set; }

        public DateTime ActualizadoFecha { get; set; }

        public int idEmpresa { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
