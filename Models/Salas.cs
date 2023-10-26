using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCardapio.Models
{
    [Table("Salas")]
    public class Salas
    {
        [Column("SalasId")]
        [Display(Name = "Id das Salas")]

        public int id { get; set; }

        [Column("SalasNome")]
        [Display(Name = "Nome das Salas")]

        public string NomeSalas { get; set; } = string.Empty;
    }
}
