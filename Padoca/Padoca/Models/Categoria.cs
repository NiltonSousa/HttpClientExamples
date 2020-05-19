using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padoca.Models
{
    public class Categoria
    {
        #region Properties
        [Key]
        [Column("id_categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [Column("descricao")]
        public string Descricao{ get; set; }
        #endregion
    }
}
