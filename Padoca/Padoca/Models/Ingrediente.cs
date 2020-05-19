using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Padoca.Models
{
    [Table("Ingrediente")]
    public class Ingrediente
    {
        #region Properties
        [Key]
        [Column("id_ingrediente")]
        public int IngredienteId { get; set; }
        
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [Column("nome")]
        public string Nome{ get; set; }
        #endregion
    }
}
