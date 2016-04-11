namespace Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CategoriaRol")]
    public partial class CategoriaRol
    {
        public CategoriaRol()
        {
            Categoria = new HashSet<Categoria>();
        }

        [Key]
        public int idCategoriaRol { get; set; }

        [Column("CategoriaRol")]
        [StringLength(50)]
        [Required]
        public string Titulo { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
    }
}
