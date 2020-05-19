using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padoca.Models
{
    public class Receita
    {
        [Key]
        [Column("id_receita")]
        public int ReceitaId { get; set; }

        [Required(ErrorMessage = "Ingrediente inválido.")]
        [Column("id_ingrediente")]
        public int IngredienteId { get; set; }

        [Required(ErrorMessage = "Prato inválido.")]
        [Column("id_prato")]
        public int PratoId { get; set; }

        public Ingrediente Ingrediente { get; set; }
        public Prato Prato { get; set; }
    }
}
