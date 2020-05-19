using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padoca.Models
{
    [Table("Prato")]
    public class Prato
    {
        #region Properties
        [Key]
        [Column("id_prato")]
        public int PratoId{ get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(50,ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [MinLength(3,ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [Column("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Categoria inválida.")]
        [Column("id_categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        #endregion
    }
}
