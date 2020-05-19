using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesMania.Models
{
    [Table("Jogo")]
    public class Jogo
    {
        #region Properties
        [Key]
        [Column("id_jogo")]
        public int JogoId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [Column("nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo FabricanteId é obrigatório.")]
        [Column("id_fabricante")]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }
        #endregion
    }
}
