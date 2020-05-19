using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padoca.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Column("id_pedido")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Prato inválido.")]
        [Column("id_prato")]
        public int PratoId { get; set; }
        public Prato Prato { get; set; }
    }
}
