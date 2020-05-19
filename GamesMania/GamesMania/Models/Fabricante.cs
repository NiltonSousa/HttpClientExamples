using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamesMania.Models
{
    [Table("Fabricante")]
    public class Fabricante
    {
        #region Properties
        [Key]
        [Column("id_fabricante")]
        public int FabricanteId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres.")]
        [Column("nome")]
        public string Nome { get; set; }
        #endregion

    }
}
