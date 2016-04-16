namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubCategoria")]
    public partial class SubCategoria
    {
        [Key]
        public int idSubcategorias { get; set; }

        [Required]
        [StringLength(50)]
        public string Subcategorias { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public int CreadoPor { get; set; }

        public DateTime CreadoFecha { get; set; }

        public int ActualizadoPor { get; set; }

        public DateTime ActualizadoFecha { get; set; }

        public int idCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
